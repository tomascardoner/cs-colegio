USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tom�s A. Cardoner
-- Create date: 2024-08-01
-- Updates:
-- Description:	Obtiene el c�lculo de adicionales de sueldos de directivos
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SueldoLiquidacionObtenerDirectores') AND type in (N'P', N'PC'))
	 DROP PROCEDURE SueldoLiquidacionObtenerDirectores
GO

CREATE PROCEDURE SueldoLiquidacionObtenerDirectores
	@Anio smallint,
	@Mes tinyint AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

	DECLARE @Resultado TABLE (
		ApellidoNombre varchar(152),
		NetoReciboImporte money,
		AdicionalAntiguedadPorcentaje decimal(3, 2),
		AdicionalAntiguedadImporte money,
		AdicionalAntiguedadSubtotal money,
		Adicional1Porcentaje decimal(3, 2),
		Adicional1Importe money,
		Adicional2Porcentaje decimal(3, 2),
		Adicional2Importe money,
		AdicionalTotal money)

		INSERT INTO @Resultado
			(ApellidoNombre, NetoReciboImporte, AdicionalAntiguedadPorcentaje, AdicionalAntiguedadImporte, Adicional1Porcentaje, Adicional2Porcentaje)
			SELECT e.ApellidoNombre, SUM(sler.ImporteNeto) AS ImporteNetoRecibo, epc.AdicionalAntiguedad, ROUND(SUM(sler.ImporteBasico) * epc.AdicionalAntiguedad, 2) AS AdicionalAntiguedadImporte, epc.Adicional1, epc.Adicional2
				FROM SueldoLiquidacion AS sl
					INNER JOIN SueldoLiquidacionEntidad AS sle ON sl.IdSueldoLiquidacion = sle.IdSueldoLiquidacion
					INNER JOIN SueldoLiquidacionEntidadRecibo AS sler ON sle.IdSueldoLiquidacion = sler.IdSueldoLiquidacion AND sle.IdEntidad = sler.IdEntidad
					INNER JOIN Entidad AS e ON sle.IdEntidad = e.IDEntidad
					INNER JOIN EntidadPersonalColegio AS epc ON e.IdEntidad = epc.IDEntidad
				WHERE epc.IdEntidadGrupo = 1 AND sl.Anio = @Anio AND sl.Mes = @Mes
				GROUP BY e.ApellidoNombre, epc.AdicionalAntiguedad, epc.Adicional1, epc.Adicional2

		UPDATE @Resultado
			SET AdicionalAntiguedadSubtotal = NetoReciboImporte + AdicionalAntiguedadImporte,
				Adicional1Importe = ROUND((NetoReciboImporte + ISNULL(AdicionalAntiguedadImporte, 0)) * Adicional1Porcentaje, 2)

		UPDATE @Resultado
			SET Adicional2Importe = ROUND((NetoReciboImporte + ISNULL(Adicional1Importe, 0)) * Adicional2Porcentaje, 2)

		UPDATE @Resultado
			SET AdicionalTotal = ISNULL(Adicional1Importe, 0) + ISNULL(Adicional2Importe, 0)

		SELECT *
			FROM @Resultado
	END
GO