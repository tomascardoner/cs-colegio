USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2016-02-03
-- Updates:
--		- 2021-04-11: se cambió el nombre del stored procedure
-- Description:	Lista la Composición del Saldo de una Entidad
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'uspEntidadComposicionSaldo') AND type in (N'P', N'PC'))
	 DROP PROCEDURE uspEntidadComposicionSaldo
GO

CREATE PROCEDURE uspEntidadComposicionSaldo
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
	END
GO