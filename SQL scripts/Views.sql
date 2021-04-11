SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-06-29
-- Description:	Lista los Alumnos, Padres, Madres o Terceros qe serán titulares de facturas
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'usvEntidadesParaFacturar') AND type = 'V')
	 DROP VIEW usvEntidadesParaFacturar
GO

CREATE VIEW usvEntidadesParaFacturar AS

	SELECT DISTINCT EntidadTitular.IDEntidad AS IDEntidad
		FROM Entidad AS EntidadTitular, Entidad AS EntidadAlumno
		WHERE EntidadAlumno.TipoAlumno = 1 AND EntidadAlumno.EsActivo = 1 AND EntidadTitular.EsActivo = 1
			AND ((EntidadAlumno.EmitirFacturaA = 'A' AND EntidadTitular.IDEntidad = EntidadAlumno.IDEntidad)
					OR (EntidadAlumno.EmitirFacturaA IN('P', '2', '3') AND EntidadTitular.IDEntidad = EntidadAlumno.IDEntidadPadre)
					OR (EntidadAlumno.EmitirFacturaA IN('M', '2', '3') AND EntidadTitular.IDEntidad = EntidadAlumno.IDEntidadMadre)
					OR (EntidadAlumno.EmitirFacturaA IN('T', '3') AND EntidadTitular.IDEntidad = EntidadAlumno.IDEntidadTercero))
GO
