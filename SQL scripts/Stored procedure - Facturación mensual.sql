USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2016-07-18
-- Updates:
--		- 2021-04-11: se cambió el nombre del stored procedure
-- Description:	Facturación mensual
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'uspFacturacionMensual') AND type in (N'P', N'PC'))
	 DROP PROCEDURE uspFacturacionMensual
GO

CREATE PROCEDURE uspFacturacionMensual
	@AnioDesde smallint,
	@MesDesde tinyint,
	@AnioHasta smallint,
	@MesHasta tinyint AS

	BEGIN
		SELECT YEAR(FechaEmision) AS Anio, MONTH(FechaEmision) As Mes,
			CAST(FORMAT(SUM(Factura), 'N', 'es-AR') as varchar(20)) AS Facturas,
			CAST(FORMAT(SUM(NotaDebito), 'N', 'es-AR') as varchar(20)) AS NotasDebito,
			CAST(FORMAT(SUM(NotaCredito), 'N', 'es-AR') as varchar(20)) AS NotasCredito,
			CAST(FORMAT(SUM(Factura) + SUM(NotaDebito) - SUM(NotaCredito), 'N', 'es-AR') as varchar(20)) AS Neto
				FROM (SELECT FechaEmision, (CASE IDComprobanteTipo WHEN 1 THEN ImporteTotal1 ELSE 0 END) AS Factura, (CASE IDComprobanteTipo WHEN 14 THEN ImporteTotal1 ELSE 0 END) AS NotaDebito, (CASE IDComprobanteTipo WHEN 12 THEN ImporteTotal1 ELSE 0 END) AS NotaCredito
						FROM Comprobante
						WHERE Comprobante.FechaHoraAnulacion IS NULL AND IDComprobanteTipo IN (1, 12,14)
							AND (@AnioDesde IS NULL OR YEAR(FechaEmision) >= @AnioDesde)
							AND (@MesDesde IS NULL OR MONTH(FechaEmision) >= @MesDesde)
							AND (@AnioHasta IS NULL OR YEAR(FechaEmision) <= @AnioHasta)
							AND (@MesHasta IS NULL OR MONTH(FechaEmision) <= @MesHasta)
						) AS SubQuery
				GROUP BY YEAR(FechaEmision), MONTH(FechaEmision)
				ORDER BY Anio, Mes
	END
GO