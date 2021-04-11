USE CSColegio
GO

IF EXISTS(
  SELECT *
    FROM sys.triggers
	WHERE name = N'Entidad_Email_CheckDuplicate'
)
	DROP TRIGGER Entidad_Email_CheckDuplicate
GO

CREATE TRIGGER Entidad_Email_CheckDuplicate ON dbo.Entidad
	AFTER INSERT, UPDATE
AS 

BEGIN
	DECLARE @Email1 varchar(50)
	DECLARE @Email2 varchar(50)

	IF UPDATE(Email1) OR UPDATE(Email2)
		BEGIN
		SELECT @Email1 = Email1, @Email2 = Email2 FROM inserted
		IF (@Email1 IS NOT NULL) OR (@Email2 IS NOT NULL)
			BEGIN
			IF @Email1 = @Email2
				BEGIN
				RAISERROR ('La dirección de e-Mail 1 especificada es igual a la dirección de e-Mail 2. ', 16, 1)
				ROLLBACK TRANSACTION
				END
			IF UPDATE(Email1) AND (@Email1 IS NOT NULL)
				BEGIN
				IF EXISTS (SELECT IDEntidad FROM Entidad WHERE Email1 = @Email1 OR Email2 = @Email1)
					BEGIN
					RAISERROR ('La dirección de e-Mail 1 especificada, ya existe en la base de datos. ', 16, 1)
					ROLLBACK TRANSACTION
					END
				END
			IF UPDATE(Email2) AND (@Email2 IS NOT NULL)
				BEGIN
				IF EXISTS (SELECT IDEntidad FROM Entidad WHERE Email1 = @Email2 OR Email2 = @Email2)
					BEGIN
					RAISERROR ('La dirección de e-Mail 2 especificada, ya existe en la base de datos. ', 16, 1)
					ROLLBACK TRANSACTION
					END
				END
			END
		END
END
GO


