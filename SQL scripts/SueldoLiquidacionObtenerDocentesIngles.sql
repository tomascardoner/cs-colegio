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
-- Description:	Obtiene el cálculo de adicionales de sueldos de inglés
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SueldoLiquidacionObtenerDocentesIngles') AND type in (N'P', N'PC'))
	 DROP PROCEDURE SueldoLiquidacionObtenerDocentesIngles
GO

CREATE PROCEDURE SueldoLiquidacionObtenerDocentesIngles
	@Anio smallint,
	@Mes tinyint,
	@IdEntidad int AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT e.ApellidoNombre, dt.Nombre AS DocumentoTipo, e.DocumentoNumero,
				sle.ModuloCantidad, sl.ModuloImporte AS ModuloPrecio, ROUND(sle.ModuloCantidad * sl.ModuloImporte, 2) AS ModuloImporte,
				sle.Antiguedad, sl.BaseAntiguedadImporte, ROUND(sle.ModuloCantidad * sl.BaseAntiguedadImporte * sle.Antiguedad, 2) AS AntiguedadImporte,
				ROUND(sle.ModuloCantidad * sl.ModuloImporte, 2) + ROUND(sle.ModuloCantidad * sl.BaseAntiguedadImporte * sle.Antiguedad, 2) AS SubtotalImporte,
				ISNULL(sle.Recibo1ImporteNeto, 0) + ISNULL(sle.Recibo2ImporteNeto, 0) + ISNULL(sle.Recibo3ImporteNeto, 0) + ISNULL(sle.Recibo4ImporteNeto, 0) + ISNULL(sle.Recibo5ImporteNeto, 0) AS RecibosImporte,
				ROUND(sle.ModuloCantidad * sl.ModuloImporte, 2) + ROUND(sle.ModuloCantidad * sl.BaseAntiguedadImporte * ISNULL(sle.Antiguedad, 0), 2) - ISNULL(sle.Recibo1ImporteNeto, 0) + ISNULL(sle.Recibo2ImporteNeto, 0) + ISNULL(sle.Recibo3ImporteNeto, 0) + ISNULL(sle.Recibo4ImporteNeto, 0) + ISNULL(sle.Recibo5ImporteNeto, 0) AS DiferenciaImporte
			FROM SueldoLiquidacion AS sl
				INNER JOIN SueldoLiquidacionEntidad AS sle ON sl.IdSueldoLiquidacion = sle.IdSueldoLiquidacion
				INNER JOIN Entidad AS e ON sle.IdEntidad = e.IDEntidad
				INNER JOIN EntidadPersonalColegio AS epc ON e.IdEntidad = epc.IDEntidad
				LEFT JOIN DocumentoTipo AS dt ON e.IDDocumentoTipo = dt.IDDocumentoTipo
			WHERE epc.IdEntidadGrupo = 2
				AND sl.Anio = @Anio AND sl.Mes = @Mes
				AND (@IdEntidad IS NULL OR sle.IdEntidad = @IdEntidad)
	END
GO