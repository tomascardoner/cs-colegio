USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-06-28
-- Updates:
--		- 2021-04-11: se cambió el nombre del stored procedure
-- Description:	Lista los Alumnos con desceunto
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'uspAlumnosConDescuento') AND type in (N'P', N'PC'))
	 DROP PROCEDURE uspAlumnosConDescuento
GO

CREATE PROCEDURE uspAlumnosConDescuento AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT Entidad.IDEntidad AS IDEntidad, Entidad.ApellidoNombre AS EntidadApellidoNombre, Descuento.Nombre AS DescuentoNombre, Descuento.Porcentaje AS DescuentoPorcentaje
			FROM Entidad INNER JOIN Descuento ON Entidad.IDDescuento = Descuento.IDDescuento
			WHERE Entidad.TipoAlumno = 1 AND Entidad.EsActivo = 1
			ORDER BY Entidad.ApellidoNombre
	END
GO