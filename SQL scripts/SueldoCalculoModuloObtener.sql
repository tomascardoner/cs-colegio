USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2024-08-03
-- Updates:
-- Description:	Obtiene el cálculo de módulo de sueldos
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'SueldoCalculoModuloObtener') AND type in (N'P', N'PC'))
	 DROP PROCEDURE SueldoCalculoModuloObtener
GO

CREATE PROCEDURE SueldoCalculoModuloObtener
	@Anio smallint,
	@Mes tinyint AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		DECLARE @BasicoConceptoCodigo smallint
		DECLARE @AntiguedadConceptoCodigo smallint

		DECLARE @BaseAntiguedadImporteActual money
		DECLARE @ModuloImporteActual money

		DECLARE @AnioAnterior smallint
		DECLARE @MesAnterior tinyint
		DECLARE @BaseAntiguedadImporteAnterior money
		DECLARE @ModuloImporteAnterior money

		SELECT @BasicoConceptoCodigo = NumeroEntero
			FROM Parametro
			WHERE IDParametro = 'SUELDO_CONCEPTO_BASICO_CODIGO'

		SELECT @AntiguedadConceptoCodigo = NumeroEntero
			FROM Parametro
			WHERE IDParametro = 'SUELDO_CONCEPTO_ANTIGUEDAD_CODIGO'

		SELECT @BaseAntiguedadImporteActual = Importe
			FROM SueldoCalculoModulo AS scm
				INNER JOIN SueldoConcepto AS sc ON scm.IdSueldoConcepto = sc.IdSueldoConcepto
			WHERE scm.Anio = @Anio AND scm.Mes = @Mes AND sc.Codigo = @BasicoConceptoCodigo

		SELECT @ModuloImporteActual = SUM(scm.Importe * CASE sc.Tipo WHEN 'D' THEN -1 ELSE 1 END)
			FROM SueldoCalculoModulo AS scm
				INNER JOIN SueldoConcepto AS sc ON scm.IdSueldoConcepto = sc.IdSueldoConcepto
			WHERE scm.Anio = @Anio AND scm.Mes = @Mes AND ISNULL(sc.Codigo, '') <> @AntiguedadConceptoCodigo

		SELECT TOP 1 @AnioAnterior = Anio, @MesAnterior = Mes
			FROM SueldoCalculoModulo
			ORDER BY Anio DESC, Mes DESC

		SELECT @BaseAntiguedadImporteAnterior = Importe
			FROM SueldoCalculoModulo AS scm
				INNER JOIN SueldoConcepto AS sc ON scm.IdSueldoConcepto = sc.IdSueldoConcepto
			WHERE scm.Anio = @AnioAnterior AND scm.Mes = @MesAnterior AND sc.Codigo = @BasicoConceptoCodigo

		SELECT @ModuloImporteAnterior = SUM(scm.Importe * CASE sc.Tipo WHEN 'D' THEN -1 ELSE 1 END)
			FROM SueldoCalculoModulo AS scm
				INNER JOIN SueldoConcepto AS sc ON scm.IdSueldoConcepto = sc.IdSueldoConcepto
			WHERE scm.Anio = @AnioAnterior AND scm.Mes = @MesAnterior AND ISNULL(sc.Codigo, '') <> @AntiguedadConceptoCodigo

		SELECT @BaseAntiguedadImporteActual AS BaseAntiguedadImporteActual, @ModuloImporteActual AS ModuloImporteActual, @BaseAntiguedadImporteAnterior AS BaseAntiguedadImporteAnterior, @ModuloImporteAnterior AS ModuloImporteAnterior
	END
GO