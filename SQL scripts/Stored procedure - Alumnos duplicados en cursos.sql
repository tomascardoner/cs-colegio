USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-06-30
-- Updates:
--		- 2021-04-11: se cambió el nombre del stored procedure
-- Description:	Lista los Alumnos que están cargados en más de un Curso, dado un Año Lectivo
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'uspAlumnosDuplicadosEnCursos') AND type in (N'P', N'PC'))
	 DROP PROCEDURE uspAlumnosDuplicadosEnCursos
GO

CREATE PROCEDURE uspAlumnosDuplicadosEnCursos
	@AnioLectivo smallint,
	@IDEntidad int AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT Entidad.IDEntidad, Entidad.ApellidoNombre, Nivel.Nombre AS NivelNombre, Anio.Nombre AS AnioNombre, Turno.Nombre AS TurnoNombre, Curso.Division AS Division
			FROM (((((Entidad INNER JOIN EntidadAnioLectivoCurso ON Entidad.IDEntidad = EntidadAnioLectivoCurso.IDEntidad)
				INNER JOIN AnioLectivoCurso ON EntidadAnioLectivoCurso.IDAnioLectivoCurso = AnioLectivoCurso.IDAnioLectivoCurso)
				INNER JOIN Curso ON AnioLectivoCurso.IDCurso = Curso.IDCurso)
				INNER JOIN Turno ON Curso.IDTurno = Turno.IDTurno)
				INNER JOIN Anio ON Curso.IDAnio = Anio.IDAnio)
				INNER JOIN Nivel ON Anio.IDNivel = Nivel.IDNivel
			WHERE AnioLectivoCurso.AnioLectivo = @AnioLectivo AND Entidad.IDEntidad IN 
				(SELECT EntidadAnioLectivoCurso.IDEntidad AS IDEntidad
					FROM EntidadAnioLectivoCurso INNER JOIN AnioLectivoCurso ON EntidadAnioLectivoCurso.IDAnioLectivoCurso = AnioLectivoCurso.IDAnioLectivoCurso
					WHERE AnioLectivoCurso.AnioLectivo = @AnioLectivo AND (@IDEntidad IS NULL OR Entidad.IDEntidad = @IDEntidad)
					GROUP BY EntidadAnioLectivoCurso.IDEntidad
					HAVING COUNT(EntidadAnioLectivoCurso.IDAnioLectivoCurso) > 1)
			ORDER BY Entidad.ApellidoNombre, Nivel.Nombre, Anio.Nombre, Turno.Nombre, Curso.Division

	END
GO