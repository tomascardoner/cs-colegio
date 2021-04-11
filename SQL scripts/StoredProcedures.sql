USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-06-06
-- Description:	Lista los Hermanos sin desceunto agrupados por Padre/Madre
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_HermanosSinDescuento') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_HermanosSinDescuento
GO

CREATE PROCEDURE usp_HermanosSinDescuento AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

	(SELECT EntidadPadre.ApellidoNombre AS PadreMadre, EntidadHijos.ApellidoNombre AS Hijo
		FROM (Entidad AS EntidadPadre INNER JOIN Entidad AS EntidadHijos ON EntidadPadre.IDEntidad = EntidadHijos.IDEntidadPadre)
		INNER JOIN 
			(SELECT Entidad.IDEntidadPadre AS IDEntidad, COUNT(Entidad.IDEntidad) AS CantidadHijos
				FROM Entidad
				WHERE Entidad.IDEntidadPadre iS NOT NULL AND Entidad.EsActivo = 1
				GROUP BY Entidad.IDEntidadPadre
				HAVING COUNT(Entidad.IDEntidad) > 1 AND MAX(Entidad.IDDescuento) IS NULL) AS SubQ ON EntidadPadre.IDEntidad = SubQ.IDEntidad)
	UNION
	(SELECT EntidadMadre.ApellidoNombre AS PadreMadre, EntidadHijos.ApellidoNombre AS Hijo
		FROM (Entidad AS EntidadMadre INNER JOIN Entidad AS EntidadHijos ON EntidadMadre.IDEntidad = EntidadHijos.IDEntidadMadre)
		INNER JOIN 
			(SELECT Entidad.IDEntidadMadre AS IDEntidad, COUNT(Entidad.IDEntidad) AS CantidadHijos
				FROM Entidad
				WHERE Entidad.IDEntidadMadre iS NOT NULL AND Entidad.EsActivo = 1
				GROUP BY Entidad.IDEntidadMadre
				HAVING COUNT(Entidad.IDEntidad) > 1 AND MAX(Entidad.IDDescuento) IS NULL) AS SubQ ON EntidadMadre.IDEntidad = SubQ.IDEntidad)
	END
GO



-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-06-28
-- Description:	Lista los Alumnos con desceunto
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_AlumnosConDescuento') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_AlumnosConDescuento
GO

CREATE PROCEDURE usp_AlumnosConDescuento AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT Entidad.IDEntidad AS IDEntidad, Entidad.ApellidoNombre AS EntidadApellidoNombre, Descuento.Nombre AS DescuentoNombre, Descuento.Porcentaje AS DescuentoPorcentaje
			FROM Entidad INNER JOIN Descuento ON Entidad.IDDescuento = Descuento.IDDescuento
			WHERE Entidad.TipoAlumno = 1 AND Entidad.EsActivo = 1
			ORDER BY Entidad.ApellidoNombre
	END
GO




-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-06-29
-- Description:	Lista los Alumnos o Padres a los cuales les faltan completar datos para facturar
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_EntidadesParaFacturarIncompletas') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_EntidadesParaFacturarIncompletas
GO

CREATE PROCEDURE usp_EntidadesParaFacturarIncompletas AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		--ALUMNOS QUE NO ESPECIFICAN A QUIEN FACTURARLE
		(SELECT EntidadAlumno.IDEntidad AS IDEntidad, EntidadAlumno.ApellidoNombre AS EntidadApellidoNombre, 'No especifica a quién factura.' AS Mensaje
					FROM Entidad AS EntidadAlumno
					WHERE EntidadAlumno.TipoAlumno = 1 AND EntidadAlumno.EsActivo = 1 AND EntidadAlumno.EmitirFacturaA IS NULL)
		UNION
		--TITULARES DE FACTURAS QUE NO TIENEN ESPECIFICADO EL DOCUMENTO
		(SELECT EntidadesParaFacturar.IDEntidad AS IDEntidad, EntidadTitular.ApellidoNombre AS EntidadApellidoNombre, 'No tiene especificado ningún Documento.' AS Mensaje
			FROM Entidad AS EntidadTitular INNER JOIN dbo.usvEntidadesParaFacturar AS EntidadesParaFacturar ON EntidadTitular.IDEntidad = EntidadesParaFacturar.IDEntidad
			WHERE (EntidadTitular.IDDocumentoTipo IS NULL AND EntidadTitular.FacturaIDDocumentoTipo IS NULL)
				OR (EntidadTitular.DocumentoNumero IS NULL AND EntidadTitular.FacturaDocumentoNumero IS NULL))
		UNION
		--TITULARES DE FACTURAS QUE NO TIENEN ESPECIFICADA LA CATEGORIA DE IVA
		(SELECT EntidadesParaFacturar.IDEntidad AS IDEntidad, EntidadTitular.ApellidoNombre AS EntidadApellidoNombre, 'No tiene especificada la Categoría de IVA.' AS Mensaje
			FROM Entidad AS EntidadTitular INNER JOIN dbo.usvEntidadesParaFacturar AS EntidadesParaFacturar ON EntidadTitular.IDEntidad = EntidadesParaFacturar.IDEntidad
			WHERE EntidadTitular.IDCategoriaIVA IS NULL)
		UNION
		--TITULARES DE FACTURAS QUE NO TIENEN ESPECIFICADA NINGUNA DIRECCION DE EMAIL
		(SELECT EntidadesParaFacturar.IDEntidad AS IDEntidad, EntidadTitular.ApellidoNombre AS EntidadApellidoNombre, 'No tiene especificada ninguna dirección de E-mail.' AS Mensaje
			FROM Entidad AS EntidadTitular INNER JOIN dbo.usvEntidadesParaFacturar AS EntidadesParaFacturar ON EntidadTitular.IDEntidad = EntidadesParaFacturar.IDEntidad
			WHERE EntidadTitular.Email1 IS NULL AND EntidadTitular.Email2 IS NULL)
		ORDER BY EntidadApellidoNombre, Mensaje
	END
GO




-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-06-30
-- Description:	Lista los Alumnos que están cargados en más de un Curso, dado un Año Lectivo
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_AlumnosDuplicadosEnCursos') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_AlumnosDuplicadosEnCursos
GO

CREATE PROCEDURE usp_AlumnosDuplicadosEnCursos
	@AnioLectivo smallint,
	@IDEntidad int AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT Entidad.IDEntidad, Entidad.ApellidoNombre, Nivel.Nombre AS NivelNombre, Anio.Nombre AS AnioNombre, Turno.Nombre AS TurnoNombre, Curso.Division AS Division
			FROM (((((Entidad INNER JOIN EntidadAnioLectivoCurso ON Entidad.IDEntidad = EntidadAnioLectivoCurso.IDEntidad)
				INNER JOIN AnioLectivoCurso ON EntidadAnioLectivoCurso.IDAnioLectivoCurso = AnioLectivoCurso.IDAnioLectivoCurso)
				INNER JOIN Curso ON AnioLectivoCurso.IDCurso = Curso.IDCurso)
				INNER JOIN Turno ON Curso.IDTurno = Turno.IDTurno)
				INNER JOIN Anio ON Curso.IDAnio = Anio.IDAnio)
				INNER JOIN Nivel ON Anio.IDNivel = Nivel.IDNivel
			WHERE AnioLectivoCurso.AnioLectivo = @AnioLectivo AND Entidad.IDEntidad IN 
				(SELECT EntidadAnioLectivoCurso.IDEntidad AS IDEntidad
					FROM EntidadAnioLectivoCurso INNER JOIN AnioLectivoCurso ON EntidadAnioLectivoCurso.IDAnioLectivoCurso = AnioLectivoCurso.IDAnioLectivoCurso
					WHERE AnioLectivoCurso.AnioLectivo = @AnioLectivo AND (@IDEntidad IS NULL OR Entidad.IDEntidad = @IDEntidad)
					GROUP BY EntidadAnioLectivoCurso.IDEntidad
					HAVING COUNT(EntidadAnioLectivoCurso.IDAnioLectivoCurso) > 1)
			ORDER BY Entidad.ApellidoNombre, Nivel.Nombre, Anio.Nombre, Turno.Nombre, Curso.Division

	END
GO



-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-06-30
-- Description:	Lista los Alumnos que están cargados en un Curso, dado un Año Lectivo
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_AlumnosEnCurso') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_AlumnosEnCurso
GO

CREATE PROCEDURE usp_AlumnosEnCurso
	@AnioLectivo smallint,
	@IDCurso tinyint AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT Nivel.Nombre AS NivelNombre, Anio.Nombre AS AnioNombre, Turno.Nombre AS TurnoNombre, Curso.Division AS Division, Entidad.IDEntidad, Entidad.ApellidoNombre
			FROM (((((Entidad INNER JOIN EntidadAnioLectivoCurso ON Entidad.IDEntidad = EntidadAnioLectivoCurso.IDEntidad)
				INNER JOIN AnioLectivoCurso ON EntidadAnioLectivoCurso.IDAnioLectivoCurso = AnioLectivoCurso.IDAnioLectivoCurso)
				INNER JOIN Curso ON AnioLectivoCurso.IDCurso = Curso.IDCurso)
				INNER JOIN Turno ON Curso.IDTurno = Turno.IDTurno)
				INNER JOIN Anio ON Curso.IDAnio = Anio.IDAnio)
				INNER JOIN Nivel ON Anio.IDNivel = Nivel.IDNivel
				WHERE AnioLectivoCurso.AnioLectivo = @AnioLectivo AND AnioLectivoCurso.IDCurso = @IDCurso
				ORDER BY Entidad.ApellidoNombre

	END
GO



-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-11-08
-- Description:	Lista el Resumen de Cuenta de una Entidad
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_Entidad_ResumenCuenta') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_Entidad_ResumenCuenta
GO

CREATE PROCEDURE usp_Entidad_ResumenCuenta
	@IDEntidad int,
	@FechaDesde date,
	@FechaHasta date AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		DECLARE @SaldoInicial money
		DECLARE @SaldoInicialCredito money
		DECLARE @SaldoInicialDebito money

		IF @FechaDesde IS NULL
			SET @SaldoInicial = 0
		ELSE
			BEGIN
			SET @SaldoInicial = ISNULL((SELECT SUM(dbo.udf_GetComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1))
									FROM Comprobante INNER JOIN ComprobanteTipo ON Comprobante.IDComprobanteTipo = ComprobanteTipo.IDComprobanteTipo
									WHERE Comprobante.IDEntidad = @IDEntidad AND Comprobante.IDUsuarioAnulacion IS NULL AND Comprobante.FechaEmision < @FechaDesde), 0)
			IF @SaldoInicial < 0
				BEGIN
				SET @SaldoInicialCredito = 0
				SET @SaldoInicialDebito = @SaldoInicial
				END
			ELSE
				BEGIN
				SET @SaldoInicialCredito = @SaldoInicial
				SET @SaldoInicialDebito = 0
				END
			END
		
		(SELECT Entidad.IDEntidad, Entidad.ApellidoNombre AS EntidadApellidoNombre, 0 AS IDComprobanteTipo, 'Saldo Inicial' AS ComprobanteTipoNombre, @FechaDesde AS ComprobanteFecha, '' AS ComprobanteNumero, @SaldoInicialDebito AS ImporteCredito, @SaldoInicialCredito AS ImporteDebito, @SaldoInicial AS ImporteFinal
			FROM Entidad
			WHERE Entidad.IDEntidad = @IDEntidad)
		UNION
		(SELECT Entidad.IDEntidad, Entidad.ApellidoNombre AS EntidadApellidoNombre, ComprobanteTipo.IDComprobanteTipo, ComprobanteTipo.NombreConLetra AS ComprobanteTipoNombre, Comprobante.FechaEmision AS ComprobanteFecha, Comprobante.NumeroCompleto AS ComprobanteNumero, dbo.udf_GetComprobanteImporteDebito(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1) AS ImporteCredito, dbo.udf_GetComprobanteImporteCredito(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1) AS ImporteDebito, dbo.udf_GetComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1) AS ImporteFinal
			FROM (Entidad INNER JOIN Comprobante ON Entidad.IDEntidad = Comprobante.IDEntidad) INNER JOIN ComprobanteTipo ON Comprobante.IDComprobanteTipo = ComprobanteTipo.IDComprobanteTipo
				WHERE Entidad.IDEntidad = @IDEntidad AND Comprobante.IDUsuarioAnulacion IS NULL
					AND (@FechaDesde IS NULL OR Comprobante.FechaEmision >= @FechaDesde)
					AND (@FechaHasta IS NULL OR Comprobante.FechaEmision <= @FechaHasta))
		ORDER BY ComprobanteFecha, ComprobanteNumero

	END
GO



-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2016-02-03
-- Description:	Lista la Composición del Saldo de una Entidad
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_Entidad_ComposicionSaldo') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_Entidad_ComposicionSaldo
GO

CREATE PROCEDURE usp_Entidad_ComposicionSaldo
	@IDEntidad int,
	@FechaDesde date,
	@FechaHasta date AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		DECLARE @WorkTable TABLE(IDComprobante int PRIMARY KEY NOT NULL, ComprobanteFecha date NOT NULL, IDComprobanteTipo tinyint NULL, ComprobanteTipoNombre varchar(54) NOT NULL, MovimientoTipo char(1) NULL, ComprobanteNumero varchar(13) NOT NULL, ImporteOriginal money NOT NULL, ImporteAplicado money NULL, ImportePendiente money NULL)
		DECLARE @SaldoInicial money
		DECLARE @SaldoInicialCredito money
		DECLARE @SaldoInicialDebito money


		-- CÁLCULO DEL SALDO INICIAL
		IF @FechaDesde IS NULL
			BEGIN
			SET @SaldoInicial = 0
			SET @SaldoInicialCredito = 0
			SET @SaldoInicialDebito = 0
			END
		ELSE
			BEGIN
			SET @SaldoInicial = ISNULL((SELECT SUM(dbo.udf_GetComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1))
									FROM Comprobante INNER JOIN ComprobanteTipo ON Comprobante.IDComprobanteTipo = ComprobanteTipo.IDComprobanteTipo
									WHERE Comprobante.IDEntidad = @IDEntidad AND Comprobante.IDUsuarioAnulacion IS NULL AND Comprobante.FechaEmision < @FechaDesde), 0)
			IF @SaldoInicial < 0
				BEGIN
				SET @SaldoInicialCredito = 0
				SET @SaldoInicialDebito = @SaldoInicial
				END
			ELSE
				BEGIN
				SET @SaldoInicialCredito = @SaldoInicial
				SET @SaldoInicialDebito = 0
				END
			END

		-- INSERTO EN LA TABLA DE TRABAJO, LOS REGISTROS CORRESPONDIENTES A LAS FACTURAS (O COMPROBANTES APLICABLES)
		INSERT INTO @WorkTable (IDComprobante, ComprobanteFecha, IDComprobanteTipo, ComprobanteTipoNombre, MovimientoTipo, ComprobanteNumero, ImporteOriginal, ImporteAplicado, ImportePendiente)
			SELECT Comprobante.IDComprobante, Comprobante.FechaEmision, ComprobanteTipo.IDComprobanteTipo, ComprobanteTipo.NombreConLetra, ComprobanteTipo.MovimientoTipo, Comprobante.NumeroCompleto, Comprobante.ImporteTotal1, SUM(ComprobanteAplicacion.Importe), Comprobante.ImporteTotal1 - SUM(ComprobanteAplicacion.Importe)
				FROM (Comprobante INNER JOIN ComprobanteTipo ON Comprobante.IDComprobanteTipo = ComprobanteTipo.IDComprobanteTipo) LEFT JOIN ComprobanteAplicacion ON Comprobante.IDComprobante = ComprobanteAplicacion.IDComprobanteAplicado
					WHERE Comprobante.IDEntidad = @IDEntidad AND Comprobante.IDUsuarioAnulacion IS NULL AND ComprobanteTipo.UtilizaAplicacion = 0
						AND (@FechaDesde IS NULL OR Comprobante.FechaEmision >= @FechaDesde)
						AND (@FechaHasta IS NULL OR Comprobante.FechaEmision <= @FechaHasta)
					GROUP BY Comprobante.IDComprobante, Comprobante.FechaEmision, ComprobanteTipo.IDComprobanteTipo, ComprobanteTipo.NombreConLetra, ComprobanteTipo.MovimientoTipo, Comprobante.NumeroCompleto, Comprobante.ImporteTotal1
					HAVING SUM(ComprobanteAplicacion.Importe) IS NULL OR (SUM(Comprobante.ImporteTotal1) - SUM(ComprobanteAplicacion.Importe)) <> 0
		
		-- INSERTO EN LA TABLA DE TRABAJO, LOS REGISTROS CORRESPONDIENTES A LOS RECIBOS (O COMPROBANTES APLICANTES)
		INSERT INTO @WorkTable (IDComprobante, ComprobanteFecha, IDComprobanteTipo, ComprobanteTipoNombre, MovimientoTipo, ComprobanteNumero, ImporteOriginal, ImporteAplicado, ImportePendiente)
			SELECT Comprobante.IDComprobante, Comprobante.FechaEmision, ComprobanteTipo.IDComprobanteTipo, ComprobanteTipo.NombreConLetra, ComprobanteTipo.MovimientoTipo, Comprobante.NumeroCompleto, Comprobante.ImporteTotal1, SUM(ComprobanteAplicacion.Importe), Comprobante.ImporteTotal1 - SUM(ComprobanteAplicacion.Importe)
				FROM (Comprobante INNER JOIN ComprobanteTipo ON Comprobante.IDComprobanteTipo = ComprobanteTipo.IDComprobanteTipo) LEFT JOIN ComprobanteAplicacion ON Comprobante.IDComprobante = ComprobanteAplicacion.IDComprobanteAplicante
					WHERE Comprobante.IDEntidad = @IDEntidad AND Comprobante.IDUsuarioAnulacion IS NULL AND ComprobanteTipo.UtilizaAplicacion = 1
						AND (@FechaDesde IS NULL OR Comprobante.FechaEmision >= @FechaDesde)
						AND (@FechaHasta IS NULL OR Comprobante.FechaEmision <= @FechaHasta)
					GROUP BY Comprobante.IDComprobante, Comprobante.FechaEmision, ComprobanteTipo.IDComprobanteTipo, ComprobanteTipo.NombreConLetra, ComprobanteTipo.MovimientoTipo, Comprobante.NumeroCompleto, Comprobante.ImporteTotal1
					HAVING SUM(ComprobanteAplicacion.Importe) IS NULL OR (SUM(Comprobante.ImporteTotal1) - SUM(ComprobanteAplicacion.Importe)) <> 0

		-- REALIZO LA CONSULTA SOBRE LA TABLA DE TRABAJO Y LAS OTRAS DEPENDIENTES		
		(SELECT Entidad.IDEntidad, Entidad.ApellidoNombre AS EntidadApellidoNombre, 0 AS IDComprobante, @FechaDesde AS ComprobanteFecha, 0 AS IDComprobanteTipo, 'Saldo Inicial' AS ComprobanteTipoNombre, '' AS ComprobanteNumero, 0 AS ImporteOriginal, 0 AS ImportePendiente, @SaldoInicialDebito AS ImporteCredito, @SaldoInicialCredito AS ImporteDebito, @SaldoInicial AS ImporteFinal
			FROM Entidad
			WHERE Entidad.IDEntidad = @IDEntidad)
		UNION
		(SELECT Entidad.IDEntidad, Entidad.ApellidoNombre AS EntidadApellidoNombre, wrktbl.IDComprobante AS IDComprobante, wrktbl.ComprobanteFecha AS ComprobanteFecha, wrktbl.IDComprobanteTipo AS IDComprobanteTipo, wrktbl.ComprobanteTipoNombre AS ComprobanteTipoNombre, wrktbl.ComprobanteNumero AS ComprobanteNumero, wrktbl.ImporteOriginal AS ImporteOriginal, wrktbl.ImportePendiente, dbo.udf_GetComprobanteImporteDebito(wrktbl.MovimientoTipo, wrktbl.ImportePendiente) AS ImporteCredito, dbo.udf_GetComprobanteImporteCredito(wrktbl.MovimientoTipo, wrktbl.ImportePendiente) AS ImporteDebito, (-dbo.udf_GetComprobanteImporteCredito(wrktbl.MovimientoTipo, wrktbl.ImportePendiente) + dbo.udf_GetComprobanteImporteDebito(wrktbl.MovimientoTipo, wrktbl.ImportePendiente)) AS ImporteFinal
			FROM Entidad, @WorkTable AS wrktbl
			WHERE Entidad.IDEntidad = @IDEntidad)





		/*
		SELECT Entidad.IDEntidad, Entidad.ApellidoNombre AS EntidadApellidoNombre, 
			FROM (Entidad INNER JOIN Comprobante ON Entidad.IDEntidad = Comprobante.IDEntidad)
		(SELECT Entidad.IDEntidad, Entidad.ApellidoNombre AS EntidadApellidoNombre, Comprobante.FechaEmision AS ComprobanteFecha, ComprobanteTipo.IDComprobanteTipo, ComprobanteTipo.NombreConLetra AS ComprobanteTipoNombre, Comprobante.NumeroCompleto AS ComprobanteNumero, Comprobante.ImporteTotal AS ImporteOriginal, dbo.udf_GetComprobanteImporteDebito(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal) AS ImporteCredito, dbo.udf_GetComprobanteImporteCredito(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal) AS ImporteDebito, dbo.udf_GetComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal) + SUM(ComprobanteAplicacion.Importe) AS ImporteFinal
			FROM ((Entidad INNER JOIN Comprobante ON Entidad.IDEntidad = Comprobante.IDEntidad) INNER JOIN ComprobanteTipo ON Comprobante.IDComprobanteTipo = ComprobanteTipo.IDComprobanteTipo) LEFT JOIN ComprobanteAplicacion ON Comprobante.IDComprobante = ComprobanteAplicacion.IDComprobanteAplicado
				WHERE Entidad.IDEntidad = @IDEntidad AND Comprobante.IDUsuarioAnulacion IS NULL AND ComprobanteTipo.UtilizaAplicacion = 0
				GROUP BY Entidad.IDEntidad, Entidad.ApellidoNombre, Comprobante.FechaEmision, ComprobanteTipo.IDComprobanteTipo, ComprobanteTipo.NombreConLetra, Comprobante.NumeroCompleto, Comprobante.ImporteTotal, dbo.udf_GetComprobanteImporteDebito(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal), dbo.udf_GetComprobanteImporteCredito(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal), dbo.udf_GetComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal), ComprobanteTipo.UtilizaAplicacion
				HAVING SUM(ComprobanteAplicacion.Importe) IS NULL OR (SUM(Comprobante.ImporteTotal) - SUM(ComprobanteAplicacion.Importe)) <> 0)
		UNION
		(SELECT Entidad.IDEntidad, Entidad.ApellidoNombre AS EntidadApellidoNombre, Comprobante.FechaEmision AS ComprobanteFecha, ComprobanteTipo.IDComprobanteTipo, ComprobanteTipo.NombreConLetra AS ComprobanteTipoNombre, Comprobante.NumeroCompleto AS ComprobanteNumero, Comprobante.ImporteTotal AS ImporteOriginal, dbo.udf_GetComprobanteImporteDebito(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal) AS ImporteCredito, dbo.udf_GetComprobanteImporteCredito(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal) AS ImporteDebito, dbo.udf_GetComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal) - SUM(ComprobanteAplicacion.Importe) AS ImporteFinal
			FROM ((Entidad INNER JOIN Comprobante ON Entidad.IDEntidad = Comprobante.IDEntidad) INNER JOIN ComprobanteTipo ON Comprobante.IDComprobanteTipo = ComprobanteTipo.IDComprobanteTipo) LEFT JOIN ComprobanteAplicacion ON Comprobante.IDComprobante = ComprobanteAplicacion.IDComprobanteAplicante
				WHERE Entidad.IDEntidad = @IDEntidad AND Comprobante.IDUsuarioAnulacion IS NULL AND ComprobanteTipo.UtilizaAplicacion = 1
				GROUP BY Entidad.IDEntidad, Entidad.ApellidoNombre, Comprobante.FechaEmision, ComprobanteTipo.IDComprobanteTipo, ComprobanteTipo.NombreConLetra, Comprobante.NumeroCompleto, Comprobante.ImporteTotal, dbo.udf_GetComprobanteImporteDebito(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal), dbo.udf_GetComprobanteImporteCredito(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal), dbo.udf_GetComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal), ComprobanteTipo.UtilizaAplicacion
				HAVING SUM(ComprobanteAplicacion.Importe) IS NULL OR (SUM(Comprobante.ImporteTotal) - SUM(ComprobanteAplicacion.Importe)) <> 0)		ORDER BY ComprobanteFecha, ComprobanteNumero

				*/

	END
GO



-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-11-10
-- Description:	Lista las Entidades con su Saldo actual
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_Entidad_Saldo') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_Entidad_Saldo
GO

CREATE PROCEDURE usp_Entidad_Saldo
	@SaldoMinimo money,
	@SaldoMaximo money,
	@DiasAntiguedadDebitoMinimo smallint,
	@DiasAntiguedadDebitoMaximo smallint,
	@DiasAntiguedadCreditoMinimo smallint,
	@DiasAntiguedadCreditoMaximo smallint AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT Entidad.IDEntidad, Entidad.ApellidoNombre AS EntidadApellidoNombre,
			MAX(CASE ComprobanteTipo.MovimientoTipo WHEN 'C' THEN Comprobante.FechaEmision ELSE NULL END) AS FechaUltimoDebito,
			MAX(CASE ComprobanteTipo.MovimientoTipo WHEN 'D' THEN Comprobante.FechaEmision ELSE NULL END) AS FechaUltimoCredito,
			SUM(dbo.udf_GetComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1)) AS Saldo
			FROM (Entidad INNER JOIN Comprobante ON Entidad.IDEntidad = Comprobante.IDEntidad) INNER JOIN ComprobanteTipo ON Comprobante.IDComprobanteTipo = ComprobanteTipo.IDComprobanteTipo
			WHERE Comprobante.IDUsuarioAnulacion IS NULL
			GROUP BY Entidad.IDEntidad, Entidad.ApellidoNombre
			HAVING (@SaldoMinimo IS NULL OR SUM(dbo.udf_GetComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1)) >= @SaldoMinimo)
				AND (@SaldoMaximo IS NULL OR SUM(dbo.udf_GetComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1)) <= @SaldoMaximo)
				AND (@DiasAntiguedadDebitoMinimo IS NULL OR DATEDIFF(day, MAX(CASE ComprobanteTipo.MovimientoTipo WHEN 'C' THEN Comprobante.FechaEmision ELSE NULL END), GETDATE()) >= @DiasAntiguedadDebitoMinimo)
				AND (@DiasAntiguedadDebitoMaximo IS NULL OR DATEDIFF(day, MAX(CASE ComprobanteTipo.MovimientoTipo WHEN 'C' THEN Comprobante.FechaEmision ELSE NULL END), GETDATE()) <= @DiasAntiguedadDebitoMaximo)
				AND (@DiasAntiguedadCreditoMinimo IS NULL OR DATEDIFF(day, MAX(CASE ComprobanteTipo.MovimientoTipo WHEN 'D' THEN Comprobante.FechaEmision ELSE NULL END), GETDATE()) >= @DiasAntiguedadCreditoMinimo)
				AND (@DiasAntiguedadCreditoMaximo IS NULL OR DATEDIFF(day, MAX(CASE ComprobanteTipo.MovimientoTipo WHEN 'D' THEN Comprobante.FechaEmision ELSE NULL END), GETDATE()) <= @DiasAntiguedadCreditoMaximo)

	END
GO



-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-11-17
-- Description:	Lista las Entidades con sus Comprobantes de Recibo sin aplicar
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_Entidad_ComprobantesSinAplicar') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_Entidad_ComprobantesSinAplicar
GO

CREATE PROCEDURE usp_Entidad_ComprobantesSinAplicar
	@IDEntidad int AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT Entidad.IDEntidad, Entidad.ApellidoNombre AS EntidadApellidoNombre, Comprobante.FechaEmision, ComprobanteTipo.NombreConLetra AS ComprobanteTipoNombre, Comprobante.NumeroCompleto AS ComprobanteNumero, Comprobante.ImporteTotal1, (Comprobante.ImporteTotal1 - ISNULL(SUM(ComprobanteAplicacion.Importe), 0)) AS ImporteSinAplicar
			FROM ((Entidad INNER JOIN Comprobante ON Entidad.IDEntidad = Comprobante.IDEntidad) INNER JOIN ComprobanteTipo ON Comprobante.IDComprobanteTipo = ComprobanteTipo.IDComprobanteTipo) LEFT JOIN ComprobanteAplicacion ON Comprobante.IDComprobante = ComprobanteAplicacion.IDComprobanteAplicante
			WHERE Comprobante.IDUsuarioAnulacion IS NULL AND ComprobanteTipo.OperacionTipo = 'V' AND ComprobanteTipo.MovimientoTipo = 'D'
				AND (@IDEntidad IS NULL OR Entidad.IDEntidad = @IDEntidad)
			GROUP BY Entidad.IDEntidad, Entidad.ApellidoNombre, Comprobante.FechaEmision, ComprobanteTipo.NombreConLetra, Comprobante.NumeroCompleto, Comprobante.ImporteTotal1
			HAVING (Comprobante.ImporteTotal1 - ISNULL(SUM(ComprobanteAplicacion.Importe), 0)) > 0
			ORDER BY EntidadApellidoNombre, FechaEmision, ComprobanteTipoNombre, ComprobanteNumero
	END
GO



-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2016-07-18
-- Description:	Facturación mensual
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usp_FacturacionMensual') AND type in (N'P', N'PC'))
	 DROP PROCEDURE usp_FacturacionMensual
GO

CREATE PROCEDURE usp_FacturacionMensual
	@AnioDesde smallint,
	@MesDesde tinyint,
	@AnioHasta smallint,
	@MesHasta tinyint AS

	BEGIN
		SELECT YEAR(FechaEmision) AS Anio, MONTH(FechaEmision) As Mes,
			SUM(CASE IDComprobanteTipo WHEN 1 THEN ImporteTotal1 ELSE 0 END) Facturas,
			SUM(CASE IDComprobanteTipo WHEN 12 THEN ImporteTotal1 ELSE 0 END) NotasDeCredito,
			SUM(CASE IDComprobanteTipo WHEN 14 THEN ImporteTotal1 ELSE 0 END) NotasDeDebito
				FROM Comprobante
				WHERE (@AnioDesde IS NULL OR YEAR(FechaEmision) >= @AnioDesde)
					AND (@MesDesde IS NULL OR MONTH(FechaEmision) >= @MesDesde)
					AND (@AnioHasta IS NULL OR MONTH(FechaEmision) <= @AnioHasta)
					AND (@MesHasta IS NULL OR MONTH(FechaEmision) <= @MesHasta)
				GROUP BY YEAR(FechaEmision), MONTH(FechaEmision)
				ORDER BY Anio, Mes
	END
GO