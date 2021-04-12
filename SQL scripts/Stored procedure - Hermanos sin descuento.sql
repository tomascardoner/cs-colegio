USE CSColegio
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Tomás A. Cardoner
-- Create date: 2015-06-06
-- Updates:
--		- 2021-04-11: se cambió el nombre del stored procedure
-- Description:	Lista los Hermanos sin desceunto agrupados por Padre/Madre
-- =============================================
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'uspHermanosSinDescuento') AND type in (N'P', N'PC'))
	 DROP PROCEDURE uspHermanosSinDescuento
GO

CREATE PROCEDURE uspHermanosSinDescuento AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.
		SET NOCOUNT ON;

	(SELECT EntidadPadre.ApellidoNombre AS PadreMadre, EntidadHijos.ApellidoNombre AS Hijo
		FROM (Entidad AS EntidadPadre INNER JOIN Entidad AS EntidadHijos ON EntidadPadre.IDEntidad = EntidadHijos.IDEntidadPadre)
		INNER JOIN 
			(SELECT Entidad.IDEntidadPadre AS IDEntidad, COUNT(Entidad.IDEntidad) AS CantidadHijos
				FROM Entidad
				WHERE Entidad.IDEntidadPadre iS NOT NULL AND Entidad.EsActivo = 1
				GROUP BY Entidad.IDEntidadPadre
				HAVING COUNT(Entidad.IDEntidad) > 1 AND MAX(Entidad.IDDescuento) IS NULL) AS SubQ ON EntidadPadre.IDEntidad = SubQ.IDEntidad)
	UNION
	(SELECT EntidadMadre.ApellidoNombre AS PadreMadre, EntidadHijos.ApellidoNombre AS Hijo
		FROM (Entidad AS EntidadMadre INNER JOIN Entidad AS EntidadHijos ON EntidadMadre.IDEntidad = EntidadHijos.IDEntidadMadre)
		INNER JOIN 
			(SELECT Entidad.IDEntidadMadre AS IDEntidad, COUNT(Entidad.IDEntidad) AS CantidadHijos
				FROM Entidad
				WHERE Entidad.IDEntidadMadre iS NOT NULL AND Entidad.EsActivo = 1
				GROUP BY Entidad.IDEntidadMadre
				HAVING COUNT(Entidad.IDEntidad) > 1 AND MAX(Entidad.IDDescuento) IS NULL) AS SubQ ON EntidadMadre.IDEntidad = SubQ.IDEntidad)
	END
GO