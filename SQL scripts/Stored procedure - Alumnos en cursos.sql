USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tom�s A. Cardoner
-- Create date: 2015-06-30
-- Updates:
--		- 2021-04-11: se cambi� el nombre del stored procedure
-- Description:	Lista los Alumnos que est�n cargados en un Curso, dado un A�o Lectivo
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'uspAlumnosEnCurso') AND type in (N'P', N'PC'))
	 DROP PROCEDURE uspAlumnosEnCurso
GO

CREATE PROCEDURE uspAlumnosEnCurso
	@AnioLectivo smallint,
	@IDCurso tinyint AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT Nivel.Nombre AS NivelNombre, Anio.Nombre AS AnioNombre, Turno.Nombre AS TurnoNombre, Curso.Division AS Division, Entidad.IDEntidad, Entidad.ApellidoNombre
			FROM (((((Entidad INNER JOIN EntidadAnioLectivoCurso ON Entidad.IDEntidad = EntidadAnioLectivoCurso.IDEntidad)
				INNER JOIN AnioLectivoCurso ON EntidadAnioLectivoCurso.IDAnioLectivoCurso = AnioLectivoCurso.IDAnioLectivoCurso)
				INNER JOIN Curso ON AnioLectivoCurso.IDCurso = Curso.IDCurso)
				INNER JOIN Turno ON Curso.IDTurno = Turno.IDTurno)
				INNER JOIN Anio ON Curso.IDAnio = Anio.IDAnio)
				INNER JOIN Nivel ON Anio.IDNivel = Nivel.IDNivel
				WHERE AnioLectivoCurso.AnioLectivo = @AnioLectivo AND AnioLectivoCurso.IDCurso = @IDCurso
				ORDER BY Entidad.ApellidoNombre

	END
GO