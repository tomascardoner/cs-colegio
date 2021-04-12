USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tom�s A. Cardoner
-- Create date: 2015-06-29
-- Updates:
--		- 2021-04-11: se cambi� el nombre del stored procedure
-- Description:	Lista los Alumnos o Padres a los cuales les faltan completar datos para facturar
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'uspEntidadesParaFacturarIncompletas') AND type in (N'P', N'PC'))
	 DROP PROCEDURE uspEntidadesParaFacturarIncompletas
GO

CREATE PROCEDURE uspEntidadesParaFacturarIncompletas AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		--ALUMNOS QUE NO ESPECIFICAN A QUIEN FACTURARLE
		(SELECT EntidadAlumno.IDEntidad AS IDEntidad, EntidadAlumno.ApellidoNombre AS EntidadApellidoNombre, 'No especifica a qui�n factura.' AS Mensaje
					FROM Entidad AS EntidadAlumno
					WHERE EntidadAlumno.TipoAlumno = 1 AND EntidadAlumno.EsActivo = 1 AND EntidadAlumno.EmitirFacturaA IS NULL)
		UNION
		--TITULARES DE FACTURAS QUE NO TIENEN ESPECIFICADO EL DOCUMENTO
		(SELECT EntidadesParaFacturar.IDEntidad AS IDEntidad, EntidadTitular.ApellidoNombre AS EntidadApellidoNombre, 'No tiene especificado ning�n Documento.' AS Mensaje
			FROM Entidad AS EntidadTitular INNER JOIN dbo.usvEntidadesParaFacturar AS EntidadesParaFacturar ON EntidadTitular.IDEntidad = EntidadesParaFacturar.IDEntidad
			WHERE (EntidadTitular.IDDocumentoTipo IS NULL AND EntidadTitular.FacturaIDDocumentoTipo IS NULL)
				OR (EntidadTitular.DocumentoNumero IS NULL AND EntidadTitular.FacturaDocumentoNumero IS NULL))
		UNION
		--TITULARES DE FACTURAS QUE NO TIENEN ESPECIFICADA LA CATEGORIA DE IVA
		(SELECT EntidadesParaFacturar.IDEntidad AS IDEntidad, EntidadTitular.ApellidoNombre AS EntidadApellidoNombre, 'No tiene especificada la Categor�a de IVA.' AS Mensaje
			FROM Entidad AS EntidadTitular INNER JOIN dbo.usvEntidadesParaFacturar AS EntidadesParaFacturar ON EntidadTitular.IDEntidad = EntidadesParaFacturar.IDEntidad
			WHERE EntidadTitular.IDCategoriaIVA IS NULL)
		UNION
		--TITULARES DE FACTURAS QUE NO TIENEN ESPECIFICADA NINGUNA DIRECCION DE EMAIL
		(SELECT EntidadesParaFacturar.IDEntidad AS IDEntidad, EntidadTitular.ApellidoNombre AS EntidadApellidoNombre, 'No tiene especificada ninguna direcci�n de E-mail.' AS Mensaje
			FROM Entidad AS EntidadTitular INNER JOIN dbo.usvEntidadesParaFacturar AS EntidadesParaFacturar ON EntidadTitular.IDEntidad = EntidadesParaFacturar.IDEntidad
			WHERE EntidadTitular.Email1 IS NULL AND EntidadTitular.Email2 IS NULL)
		ORDER BY EntidadApellidoNombre, Mensaje
	END
GO