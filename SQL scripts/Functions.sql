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