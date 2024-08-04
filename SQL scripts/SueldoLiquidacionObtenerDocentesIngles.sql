USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2024-08-01
-- Updates:
-- Description:	Obtiene el cálculo de adicionales de sueldos de inglés
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SueldoLiquidacionObtenerDocentesIngles') AND type in (N'P', N'PC'))
	 DROP PROCEDURE SueldoLiquidacionObtenerDocentesIngles
GO

CREATE PROCEDURE SueldoLiquidacionObtenerDocentesIngles
	@Anio smallint,
	@Mes tinyint AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT e.ApellidoNombre, sle.ModuloCantidad, sle.Antiguedad, ROUND(sle.ModuloCantidad * sl.ModuloImporte, 2) AS ModuloImporte, ROUND(sle.ModuloCantidad * sl.BaseAntiguedadImporte * sle.Antiguedad, 2) AS AntiguedadImporte, SUM(sler.ImporteNeto) AS RecibosImporte, ROUND(sle.ModuloCantidad * sl.ModuloImporte, 2) + ROUND(sle.ModuloCantidad * sl.BaseAntiguedadImporte * sle.Antiguedad, 2) - SUM(sler.ImporteNeto) AS DiferenciaImporte
			FROM SueldoLiquidacion AS sl
				INNER JOIN SueldoLiquidacionEntidad AS sle ON sl.IdSueldoLiquidacion = sle.IdSueldoLiquidacion
				INNER JOIN SueldoLiquidacionEntidadRecibo AS sler ON sle.IdSueldoLiquidacion = sler.IdSueldoLiquidacion AND sle.IdEntidad = sler.IdEntidad
				INNER JOIN Entidad AS e ON sle.IdEntidad = e.IDEntidad
				INNER JOIN EntidadPersonalColegio AS epc ON e.IdEntidad = epc.IDEntidad
			WHERE epc.IdEntidadGrupo = 2 AND sl.Anio = @Anio AND sl.Mes = @Mes
			GROUP BY e.ApellidoNombre, sle.ModuloCantidad, sle.Antiguedad, sl.ModuloImporte, sl.BaseAntiguedadImporte
	END
GO