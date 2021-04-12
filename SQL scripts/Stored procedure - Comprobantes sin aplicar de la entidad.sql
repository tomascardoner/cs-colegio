USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-11-17
-- Updates:
--		- 2021-04-11: se cambió el nombre del stored procedure
-- Description:	Lista las Entidades con sus Comprobantes de Recibo sin aplicar
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'uspEntidadComprobantesSinAplicar') AND type in (N'P', N'PC'))
	 DROP PROCEDURE uspEntidadComprobantesSinAplicar
GO

CREATE PROCEDURE uspEntidadComprobantesSinAplicar
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