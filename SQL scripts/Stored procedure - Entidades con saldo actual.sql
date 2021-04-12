USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-11-10
-- Updates:
--		- 2021-04-11: se cambió el nombre del stored procedure
-- Description:	Lista las Entidades con su Saldo actual
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'uspEntidadSaldo') AND type in (N'P', N'PC'))
	 DROP PROCEDURE uspEntidadSaldo
GO

CREATE PROCEDURE uspEntidadSaldo
	@SaldoMinimo money,
	@SaldoMaximo money,
	@DiasAntiguedadDebitoMinimo smallint,
	@DiasAntiguedadDebitoMaximo smallint,
	@DiasAntiguedadCreditoMinimo smallint,
	@DiasAntiguedadCreditoMaximo smallint AS

	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT Entidad.IDEntidad, Entidad.ApellidoNombre AS EntidadApellidoNombre,
			MAX(CASE ComprobanteTipo.MovimientoTipo WHEN 'C' THEN Comprobante.FechaEmision ELSE NULL END) AS FechaUltimoDebito,
			MAX(CASE ComprobanteTipo.MovimientoTipo WHEN 'D' THEN Comprobante.FechaEmision ELSE NULL END) AS FechaUltimoCredito,
			SUM(dbo.udfObtenerComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1)) AS Saldo
			FROM (Entidad INNER JOIN Comprobante ON Entidad.IDEntidad = Comprobante.IDEntidad) INNER JOIN ComprobanteTipo ON Comprobante.IDComprobanteTipo = ComprobanteTipo.IDComprobanteTipo
			WHERE Comprobante.IDUsuarioAnulacion IS NULL
			GROUP BY Entidad.IDEntidad, Entidad.ApellidoNombre
			HAVING (@SaldoMinimo IS NULL OR SUM(dbo.udfObtenerComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1)) >= @SaldoMinimo)
				AND (@SaldoMaximo IS NULL OR SUM(dbo.udfObtenerComprobanteImporteConSigno(ComprobanteTipo.MovimientoTipo, Comprobante.ImporteTotal1)) <= @SaldoMaximo)
				AND (@DiasAntiguedadDebitoMinimo IS NULL OR DATEDIFF(day, MAX(CASE ComprobanteTipo.MovimientoTipo WHEN 'C' THEN Comprobante.FechaEmision ELSE NULL END), GETDATE()) >= @DiasAntiguedadDebitoMinimo)
				AND (@DiasAntiguedadDebitoMaximo IS NULL OR DATEDIFF(day, MAX(CASE ComprobanteTipo.MovimientoTipo WHEN 'C' THEN Comprobante.FechaEmision ELSE NULL END), GETDATE()) <= @DiasAntiguedadDebitoMaximo)
				AND (@DiasAntiguedadCreditoMinimo IS NULL OR DATEDIFF(day, MAX(CASE ComprobanteTipo.MovimientoTipo WHEN 'D' THEN Comprobante.FechaEmision ELSE NULL END), GETDATE()) >= @DiasAntiguedadCreditoMinimo)
				AND (@DiasAntiguedadCreditoMaximo IS NULL OR DATEDIFF(day, MAX(CASE ComprobanteTipo.MovimientoTipo WHEN 'D' THEN Comprobante.FechaEmision ELSE NULL END), GETDATE()) <= @DiasAntiguedadCreditoMaximo)

	END
GO