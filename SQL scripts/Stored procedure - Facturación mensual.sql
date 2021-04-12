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