# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project overview

CS-Colegio ("cscolegio") is a Windows Forms desktop application (VB.NET, .NET Framework 4.8) for administering a school (billing/invoicing, students ("Entidades"), courses, payroll ("Sueldos"), communications, AFIP e-invoicing, bank integrations). It is one of several "Cardoner Sistemas" (`cs-*`) products built on a shared framework.

## Solution layout

- `CSColegio.sln` — single project solution.
- `Desktop Application/` — the VB.NET WinForms project (`Desktop Application.vbproj`), assembly name `CSColegio`, root namespace `CSColegio.DesktopApplication`.
- `Reports/` — Crystal Reports `.rpt` files, loaded at runtime from the path in `Config/General.json` (`ReportsPath`).
- `SQL scripts/` — standalone SQL Server scripts (stored procedures, views, triggers, functions) that are **not** deployed automatically; they document/maintain database-side logic and must be run manually against the target DB when changed.
- `packages/` — NuGet packages (packages.config-style, not PackageReference).

## Critical external dependency: framework-vbnet

The project links (via `<Compile Include="..\..\framework-vbnet\*.vb"> <Link>Framework\...</Link>`) source files from a **sibling repository** located two levels up from the project file, i.e. next to `cs-colegio` itself (`Cardoner Sistemas\framework-vbnet`). This is shared, hand-written framework code (database helpers, AFIP web services, encryption, error handling, email, controls, etc.) used across all `cs-*` Cardoner Sistemas products — it is not vendored into this repo.

- The build will fail if `framework-vbnet` is not checked out as a sibling of `cs-colegio`.
- Do not duplicate framework functionality inside `Desktop Application/` — if something looks missing, check `framework-vbnet` first; changes that should benefit every `cs-*` product belong there, not here.
- Files referenced from there are namespaced under `CardonerSistemas.*` (e.g. `CardonerSistemas.ErrorHandler`, `CardonerSistemas.Database.Ado.SqlServer`, `CardonerSistemas.ConfigurationJson`, `CardonerSistemas.Encrypt.StringCipher`).

## Build

Requires Visual Studio (or MSBuild) on Windows with the VB.NET / .NET Framework 4.8 workload, and locally installed **SAP Crystal Reports for .NET Framework 4.0** runtime (referenced via absolute path to `Program Files (x86)\SAP BusinessObjects\...`, `<Private>False</Private>`, i.e. not copied to output — must exist on the dev/build machine).

```
msbuild CSColegio.sln /p:Configuration=Debug /p:Platform="Any CPU"
```

There is no test project, no lint config, and no CI pipeline in this repo — verification is manual (build + run the app).

## Configuration

App configuration is a set of JSON files under `Desktop Application/Config/*.json`, each deserialized into a matching `*Config.vb` class by `CardonerSistemas.ConfigurationJson.LoadFile` (framework-vbnet), loaded once at startup by `Config/Configuration.vb` → `LoadFiles()`. Config files are copied to the output directory (`CopyToOutputDirectory=PreserveNewest`) so they ship next to the exe. Notable ones:

- `Database.json` — SQL Server connection info (encrypted password); also resaved after a successful login with new credentials.
- `General.json` — reports path, decimal places for currency, punto de venta, etc.
- `AfipWebServices.json`, `Santander.json`, `Email.json`, `Comprobante.json`, `Appearance.json`, `OutlookContactsSync.json` — feature-specific settings.

Secrets in JSON (e.g. SMTP password) are stored encrypted (`CS_Encrypt_TripleDES`) and decrypted in-memory at load time — never log or persist the decrypted value.

## Application startup flow (`Sistema/StartUp.vb`, `Sub Main`)

1. Load all config files (`Configuration.LoadFiles`).
2. Register the Syncfusion license.
3. Open an ADO.NET connection (`CardonerSistemas.Database.Ado.SqlServer`) using `DatabaseConfig`, then derive the Entity Framework connection string from it (`CSColegioContext.ConnectionString`).
4. Load `Parametro` rows from the DB (`Parametros.LoadParameters`) and verify `Parametros.APPLICATION_DATABASE_GUID` matches `Constantes.APPLICATION_DATABASE_GUID` — this guards against pointing the app at the wrong database.
5. Decrypt and display the licensed company name.
6. Show `formMDIMain`, then `formLogin` for credentials (skipped — auto-login as user id 1 — when `CS_Instance.IsRunningUnderIDE` is true, i.e. running under the VS debugger).
7. `Application.Run(pFormMDIMain)`.

Module-level (`Friend`) fields declared in `StartUp` (`pDatabase`, `pUsuario`, `pPermisos`, `pParametros`, `pFormMDIMain`, the `p*Config` objects, etc.) act as the application's global state/session and are referenced throughout the codebase from forms and modules without being passed explicitly.

## Data access: Entity Framework 6, Database First

- `CSColegio.edmx` is the EF6 Database-First model; `CSColegio.tt` / `CSColegio.Context.tt` are T4 templates that regenerate `CSColegio.vb` (entity POCOs) and `CSColegio.Context.vb` (`CSColegioContext : DbContext`) from it. Regenerate via Visual Studio (run custom tool on the `.tt` files) after editing the `.edmx` — do not hand-edit the generated files.
- Each entity has a corresponding generated `<Entity>.vb` (partial class, one file at the project root, e.g. `Comprobante.vb`, `Entidad.vb`) plus, for entities needing custom behavior, a hand-written partial-class extension in `Database/<Entity>Extension.vb` (e.g. `Database/EntidadExtension.vb`, `Database/ComprobanteExtension.vb`, `Database/CursoExtension.vb`, `Database/ReporteExtension.vb`, `Database/ReporteParametroExtension.vb`, `Database/ComprobanteDetalleExtension.vb`). Add new entity-specific logic to a `Database/<Entity>Extension.vb` partial class rather than editing the generated file.
- `Database/CSColegioContextExtension.vb` adds a constructor and overrides `SaveChanges()` to translate `DbEntityValidationException` into `FormattedDbEntityValidationException` (`Database/FormattedDbEntityValidationException.vb`) with a readable message.
- Typical usage pattern: `Using dbcontext As New CSColegioContext(True) ... End Using` for a scoped unit of work.
- Business logic that's easier/faster in T-SQL lives in `SQL scripts/` as stored procedures/views/functions/triggers and is called from the app rather than expressed in LINQ — check there before assuming a query must be written in EF.

## UI architecture (WinForms, MDI, Syncfusion)

- Single MDI parent (`Sistema/formMDIMain.vb`); most feature forms are opened as MDI children.
- Forms are organized by feature area under folders named after the domain: `Entidades/`, `Comprobantes/`, `Comunicaciones/`, `Sueldos/`, `Usuarios/`, `Reportes/`, `Tablas ABMs/` (generic CRUD "ABM" — Alta/Baja/Modificación — screens like `formCABGenerico.vb`, `formAnio.vb`, `formCurso.vb`). Each form follows WinForms designer conventions: `formX.vb` (logic) + `formX.Designer.vb` + `formX.resx`.
- `Comunes/Forms/`, `Comunes/Listas/`, `Comunes/RefreshLists/` hold logic shared across similar forms (e.g. the payroll ("Sueldos") screens), split by responsibility: form wiring, list/combo population, and list refresh.
- Grids/inputs/controls use Syncfusion Windows Forms components (licensed via `ConstantsSyncfusion.LicenseKey`).
- `Sistema/Appearance.vb` centralizes look/behavior toggles driven by `AppearanceConfig`.

## Permissions model

`Usuarios/Permisos.vb` defines every permission as a `Friend Const` string (e.g. `COMPROBANTE_EDITAR`, `ENTIDAD_SINCRONIZAR_OUTLOOK`) grouped by feature area, backed by the `UsuarioGrupoPermiso` table. Key entry points:

- `VerificarPermiso(IDPermiso, MostrarAviso:=True)` — call before allowing an action; short-circuits to `True` for the built-in administrators group (`USUARIOGRUPO_ADMINISTRADORES_ID`), otherwise checks `pPermisos` (loaded once at login via `LoadPermisos()`).
- `CargarArbolDePermisos` / `AgregarNodos` — build the permissions-tree UI (`formUsuarioGrupoPermisos`) from the same constants, mapping each to a display label.

When adding a new permission-gated feature: add the `Const` to `Permisos.vb`, wire it into `CargarArbolDePermisos`, add the corresponding row via the permissions UI/DB, and call `VerificarPermiso` at the point of use.

## Reports (Crystal Reports)

Reports are database-driven: the `Reporte` table stores metadata (file name under `GeneralConfig.ReportsPath`, associated `ReporteParametro` rows), and `Database/ReporteExtension.vb` (`Open`, `SetDatabaseConnection`) loads the `.rpt` file, binds its parameters from `ReporteParametro`, and sets the DB logon info at runtime. `Sistema/Reportes.vb` (`PreviewCrystalReport`) opens the result in `Reportes/formReportesVisor.vb`. When adding a new report: add the `.rpt` file to `Reports/`, register it (and its parameters) in the `Reporte`/`ReporteParametro` tables, and it becomes available through the existing viewer/parameter forms without new UI code.

## External integrations

- **AFIP** (Argentine tax authority e-invoicing): via `framework-vbnet`'s `Afip.vb` / `AfipWebServices.vb`, configured by `AfipWebServicesConfig` (certificate/key paths, homologación vs. producción). Invoice ("Comprobante") transmission/verification flows live under `Comprobantes/formComprobantesTransmitirAFIP.vb`, `formComprobanteVerificaAFIP.vb`.
- **Banco Santander**: file-based débito directo / recaudación-por-caja import/export (`Sistema/BancoSantander_ADDI.vb`, `SantanderConfig`, forms under `Comprobantes/formComprobantes*Santander*.vb`).
- **PagosEDUC / Pago Mis Cuentas**: export flows for third-party payment collection services (`Comprobantes/formComprobantesTransmitirPagosEduc.vb`, `formComprobantesTransmitirPagomiscuentas.vb`).
- **Email**: `Email/Mailer.vb`, `Sender.vb`, `SmtpOAuth20.vb`, `SmtpStandard.vb` — supports both OAuth2 (Google API, `Google.Apis.*` packages) and standard SMTP, per `EmailConfig`.
- **Outlook**: contact sync (`Config/OutlookContactsSyncConfig.vb`, `Outlook/` folder, `Entidad_SincronizarOutlook*` permissions).

## Conventions to follow

- Code and UI strings are in **Spanish** (domain terms: `Entidad` = person/entity, `Comprobante` = invoice/voucher, `Sueldo` = payroll, `Cuota` = installment/fee, `Anio Lectivo` = school year, `Turno` = shift). Keep new identifiers, comments, and user-facing text consistent with this — do not mix in English domain terms.
- `Option Strict On`, `Option Explicit On`, `Option Infer On` are enforced project-wide (see `.vbproj`); several warnings are elevated to errors (`WarningsAsErrors` in the `.vbproj`) — avoid late binding and implicit narrowing conversions.
- Follow the existing split between generated EF entity files (project root, one per entity, `DependentUpon CSColegio.tt`) and hand-written `Database/<Entity>Extension.vb` partial classes — never add business logic to the generated files since they're overwritten on regeneration.
- Error handling goes through `CardonerSistemas.ErrorHandler.ProcessError(ex, "message")` (framework-vbnet), not ad hoc `MessageBox.Show` on exceptions.
