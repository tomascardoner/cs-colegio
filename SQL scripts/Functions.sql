USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-11-08
-- Description:	Devuelve el Importe Debito o cero, dependiendo del Tipo de Documento
-- =============================================
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.udfObtenerComprobanteImporteDebito') AND type = N'FN')
	DROP FUNCTION dbo.udfObtenerComprobanteImporteDebito
GO

CREATE FUNCTION udfObtenerComprobanteImporteDebito
(	
	@MovimimientoTipo char(1),
	@Importe money
) RETURNS money AS
BEGIN
	DECLARE @ReturnValue money

	IF @MovimimientoTipo = 'C'
		SET @ReturnValue = 0
	IF @MovimimientoTipo = 'D'
		SET @ReturnValue = @Importe

	RETURN @ReturnValue
END
GO


-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-11-08
-- Description:	Devuelve el Importe Crédito o cero, dependiendo del Tipo de Documento
-- =============================================
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.udfObtenerComprobanteImporteCredito') AND type = N'FN')
	DROP FUNCTION dbo.udfObtenerComprobanteImporteCredito
GO

CREATE FUNCTION udfObtenerComprobanteImporteCredito
(	
	@MovimimientoTipo char(1),
	@Importe money
) RETURNS money AS
BEGIN
	DECLARE @ReturnValue money

	IF @MovimimientoTipo = 'C'
		SET @ReturnValue = @Importe
	IF @MovimimientoTipo = 'D'
		SET @ReturnValue = 0

	RETURN @ReturnValue
END
GO


-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-11-08
-- Description:	Devuelve el Importe con el signo correspondiente, dependiendo del Tipo de Documento
-- =============================================
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.udfObtenerComprobanteImporteConSigno') AND type = N'FN')
	DROP FUNCTION dbo.udfObtenerComprobanteImporteConSigno
GO

CREATE FUNCTION udfObtenerComprobanteImporteConSigno 
(	
	@MovimimientoTipo char(1),
	@Importe money
) RETURNS money AS
BEGIN
	DECLARE @ReturnValue money

	IF @MovimimientoTipo = 'C'
		SET @ReturnValue = -@Importe
	IF @MovimimientoTipo = 'D'
		SET @ReturnValue = @Importe

	RETURN @ReturnValue
END
GO



-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2022-03-17
-- Description:	Devuelve un número de teléfono formateado
-- =============================================
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.udfObtenerTelefonoConFormato') AND type = N'FN')
	DROP FUNCTION dbo.udfObtenerTelefonoConFormato
GO

CREATE FUNCTION udfObtenerTelefonoConFormato 
(	
	@Telefono varchar(50)
) RETURNS money AS
BEGIN
	DECLARE @ReturnValue varchar(50)

	SET @ReturnValue = REPLACE(REPLACE(REPLACE(@Telefono, ' ', ''), '-', ''), '+', '')

	RETURN @ReturnValue
END
GO



-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2024-02-18
-- Description:	Devuelve la CUIT o CUIL de la entidad
-- =============================================
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.ObtenerEntidadCuitCuil') AND type = N'FN')
	DROP FUNCTION dbo.ObtenerEntidadCuitCuil
GO

CREATE FUNCTION ObtenerEntidadCuitCuil 
(	
	@IDDocumentoTipo tinyint,
	@DocumentoNumero varchar(12),
	@FacturaIDDocumentoTipo tinyint,
	@FacturaDocumentoNumero varchar(12)
) RETURNS varchar(12) AS
BEGIN
	DECLARE @Result varchar(12)

	IF @IDDocumentoTipo IN (80, 86)
		SET @Result = ISNULL(@DocumentoNumero, '')
	ELSE
		IF @FacturaIDDocumentoTipo IN (80, 86)
			SET @Result = ISNULL(@FacturaDocumentoNumero, '')
		ELSE
			SET @Result = ''

	RETURN @Result

END
GO






-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2024-02-18
-- Description:	Devuelve el documento que no sea la CUIT o CUIL de la entidad
-- =============================================
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.ObtenerEntidadDocumentoNoCuitCuil') AND type = N'FN')
	DROP FUNCTION dbo.ObtenerEntidadDocumentoNoCuitCuil
GO

CREATE FUNCTION ObtenerEntidadDocumentoNoCuitCuil 
(	
	@IDDocumentoTipo tinyint,
	@DocumentoNumero varchar(12),
	@FacturaIDDocumentoTipo tinyint,
	@FacturaDocumentoNumero varchar(12)
) RETURNS varchar(12) AS
BEGIN
	DECLARE @Result varchar(12)

	IF @IDDocumentoTipo NOT IN (80, 86)
		SET @Result = ISNULL(@DocumentoNumero, '')
	ELSE
		IF @FacturaIDDocumentoTipo NOT IN (80, 86)
			SET @Result = ISNULL(@FacturaDocumentoNumero, '')
		ELSE
			SET @Result = ''

	RETURN @Result

END
GO
