USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-11-08
-- Updates:
--		- 2021-04-11: se cambió el nombre del stored procedure
-- Description:	Lista el Resumen de Cuenta de una Entidad
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'uspEntidadResumenCuenta') AND type in (N'P', N'PC'))
	 DROP PROCEDURE uspEntidadResumenCuenta
GO

CREATE PROCEDURE uspEntidadResumenCuenta
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
			SET @SaldoInicial = ISNULL((SELECT SUM(dbo.udfObtenerComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1))
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
		(SELECT Entidad.IDEntidad, Entidad.ApellidoNombre AS EntidadApellidoNombre, ComprobanteTipo.IDComprobanteTipo, ComprobanteTipo.NombreConLetra AS ComprobanteTipoNombre, Comprobante.FechaEmision AS ComprobanteFecha, Comprobante.NumeroCompleto AS ComprobanteNumero, dbo.udfObtenerComprobanteImporteDebito(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1) AS ImporteCredito, dbo.udfObtenerComprobanteImporteCredito(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1) AS ImporteDebito, dbo.udfObtenerComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1) AS ImporteFinal
			FROM (Entidad INNER JOIN Comprobante ON Entidad.IDEntidad = Comprobante.IDEntidad) INNER JOIN ComprobanteTipo ON Comprobante.IDComprobanteTipo = ComprobanteTipo.IDComprobanteTipo
				WHERE Entidad.IDEntidad = @IDEntidad AND Comprobante.IDUsuarioAnulacion IS NULL
					AND (@FechaDesde IS NULL OR Comprobante.FechaEmision >= @FechaDesde)
					AND (@FechaHasta IS NULL OR Comprobante.FechaEmision <= @FechaHasta))
		ORDER BY ComprobanteFecha, ComprobanteNumero

	END
GO