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
--		- 2021-11-25: se agregaron datos y se filtró por becas
-- Description:	Lista los Alumnos con desceunto
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'uspAlumnosConDescuento') AND type in (N'P', N'PC'))
	 DROP PROCEDURE uspAlumnosConDescuento
GO

CREATE PROCEDURE uspAlumnosConDescuento AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT d.Nombre AS DescuentoNombre, d.Porcentaje AS DescuentoPorcentaje, al.ApellidoNombre AS Alumne, p.ApellidoNombre AS Padre, m.ApellidoNombre AS Madre, a.Nombre AS Anio
			FROM Entidad AS al
				INNER JOIN Descuento AS d ON al.IDDescuento = d.IDDescuento
				LEFT JOIN Entidad AS p ON al.IDEntidadPadre = p.IDEntidad
				LEFT JOIN Entidad AS m ON al.IDEntidadMadre = m.IDEntidad
				INNER JOIN EntidadAnioLectivoCurso AS ealc ON al.IDEntidad = ealc.IDEntidad
				INNER JOIN AnioLectivoCurso AS alc ON ealc.IDAnioLectivoCurso = alc.IDAnioLectivoCurso
				INNER JOIN Curso AS c ON alc.IDCurso = c.IDCurso
				INNER JOIN Anio AS a ON c.IDAnio = a.IDAnio
			WHERE al.TipoAlumno = 1 AND a.EsActivo = 1
				AND al.IDDescuento NOT IN (1, 3)
				AND alc.AnioLectivo = 2021
			ORDER BY d.Porcentaje DESC, al.ApellidoNombre
	END
GO