USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2024-08-01
-- Updates: 2024-08-10 - se éliminó la tabla de Recibos y se agregaron los valores a la tabla de la entidad
-- Description:	Obtiene el cálculo de adicionales de sueldos de directivos
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
			SELECT e.ApellidoNombre,
					ISNULL(sle.Recibo1ImporteNeto, 0) + ISNULL(sle.Recibo2ImporteNeto, 0) + ISNULL(sle.Recibo3ImporteNeto, 0) + ISNULL(sle.Recibo4ImporteNeto, 0) + ISNULL(sle.Recibo5ImporteNeto, 0) AS ImporteNetoRecibo,
					epc.AdicionalAntiguedad,
					ROUND((ISNULL(sle.Recibo1ImporteBasico, 0) + ISNULL(sle.Recibo2ImporteBasico, 0) + ISNULL(sle.Recibo3ImporteBasico, 0) + ISNULL(sle.Recibo4ImporteBasico, 0) + ISNULL(sle.Recibo5ImporteBasico, 0)) * epc.AdicionalAntiguedad, 2) AS AdicionalAntiguedadImporte,
					epc.Adicional1, epc.Adicional2
				FROM SueldoLiquidacion AS sl
					INNER JOIN SueldoLiquidacionEntidad AS sle ON sl.IdSueldoLiquidacion = sle.IdSueldoLiquidacion
					INNER JOIN Entidad AS e ON sle.IdEntidad = e.IDEntidad
					INNER JOIN EntidadPersonalColegio AS epc ON e.IdEntidad = epc.IDEntidad
				WHERE epc.IdEntidadGrupo = 1
					AND e.EsActivo = 1
					AND sl.Anio = @Anio AND sl.Mes = @Mes

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