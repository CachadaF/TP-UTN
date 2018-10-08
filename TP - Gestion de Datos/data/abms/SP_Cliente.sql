/****** Object:  StoredProcedure [LOS_NULL].[AgregaractualizarCliente]    Script Date: 10/19/2014 05:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
IF OBJECT_ID('LOS_NULL.AgregarActualizarCliente') IS NOT NULL
	DROP PROCEDURE LOS_NULL.AgregarActualizarCliente
	GO
CREATE PROCEDURE [LOS_NULL].[AgregarActualizarCliente]
	@ID_CLIENTE numeric(18, 0) OUTPUT,
	@ID_NACIONALIDAD numeric(18, 0),
	--@id_tipo_doc numeric(18, 0), 
	@NRO_PASAPORTE numeric(18, 0), 
	@APELLIDO nvarchar(255), 
	@NOMBRE nvarchar(255),
	@FECHA_NAC datetime,
	@MAIL nvarchar(255),
	@DOM_CALLE nvarchar(255),
	@NRO_CALLE numeric(18, 0),
	@PISO numeric(18, 0),
	@DEPTO nvarchar(255),
	@BAJA_LOGICA bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRY

		DECLARE @mail_duplicado numeric(18, 0);
		
		SET @mail_duplicado = (SELECT TOP 1 C.Mail FROM LOS_NULL.Cliente C WHERE C.Mail = @MAIL)
		
		if @mail_duplicado is not null
		BEGIN
			
			DECLARE @ErrorSeverityMail INT;
			DECLARE @ErrorStateMail INT;

			SELECT @ErrorSeverityMail = ERROR_SEVERITY(), @ErrorStateMail = ERROR_STATE();

			RAISERROR ('El mail ya se encuentra registrado', -- Message text.
				   @ErrorSeverityMail, -- Severity.
				   @ErrorStateMail -- State.
				   );
		END
		ELSE
		BEGIN
			BEGIN TRAN
				
				if (@ID_CLIENTE is not NULL) 
				begin
					UPDATE LOS_NULL.Cliente SET ID_Nacionalidad=@ID_NACIONALIDAD, Nro_Pasaporte=@NRO_PASAPORTE,
					Apellido=@APELLIDO, Nombre=@NOMBRE, Fecha_nac=@FECHA_NAC, Mail=@MAIL, Dom_Calle=@DOM_CALLE,
					Nro_Calle=@NRO_CALLE, Piso=@PISO, Depto=@DEPTO, Baja_Logica=@BAJA_LOGICA
					WHERE Nro_Cliente=@ID_CLIENTE
				end
				else
				begin
					INSERT INTO LOS_NULL.Cliente(ID_Nacionalidad, Nro_Pasaporte, Apellido, Nombre, Fecha_nac,
					Mail, Dom_Calle, Nro_Calle, Piso, Depto, Baja_Logica) VALUES (@ID_NACIONALIDAD, @NRO_PASAPORTE,
					@APELLIDO, @NOMBRE, @FECHA_NAC, @MAIL, @DOM_CALLE, @NRO_CALLE, @PISO, @DEPTO, @BAJA_LOGICA)
				end
				
			COMMIT TRAN
		END
		
	END TRY
	BEGIN CATCH
		ROLLBACK TRAN
		
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage, -- Message text.
			   @ErrorSeverity, -- Severity.
			   @ErrorState -- State.
			   );
	END CATCH

END
GO



----------------------HABILITACION DE CLIENTE--------------------------
IF OBJECT_ID('LOS_NULL.deshabilitarCliente') IS NOT NULL 
	DROP PROCEDURE DATA_GROUP.deshabilitarCliente
	GO
CREATE PROCEDURE LOS_NULL.deshabilitarCliente
@nro_cliente numeric(18, 0)
AS
BEGIN

	UPDATE LOS_NULL.Cliente
	SET Baja_Logica=1
	WHERE Nro_Cliente=@nro_cliente
	
END
GO


IF OBJECT_ID('LOS_NULL.habilitarCliente') IS NOT NULL 
	DROP PROCEDURE LOS_NULL.habilitarCliente
	GO

CREATE PROCEDURE LOS_NULL.habilitarCliente
@nro_cliente numeric(18, 0)
AS
BEGIN

	UPDATE LOS_NULL.Cliente
	SET Baja_Logica=0
	WHERE Nro_Cliente=@nro_cliente
	
END
GO


----------------------------------FILTRO DE CLIENTE--------------------------------

USE [GD2C2014]
GO
/****** Object:  StoredProcedure [LOS_NULL].[LISTADO_CLIENTES_POR_CAMPOS]    Script Date: 11/08/2014 18:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[LISTADO_CLIENTES_POR_CAMPOS] 
	@NRO_PASAPORTE numeric(18,0),
	--@NACIONALIDAD nvarchar(255),
	@EMAIL nvarchar(255),
	@NOMBRE nvarchar(255),
	@APELLIDO nvarchar(255)	
AS
BEGIN

	SELECT * --C.Nombre,C.Apellido,C.Nro_Pasaporte,C.Mail
	FROM LOS_NULL.Cliente C
	WHERE (C.Nro_Pasaporte = @NRO_PASAPORTE  OR @NRO_PASAPORTE IS NULL)
	--AND (LOS_NULL.ID_NACIONALIDAD(@NACIONALIDAD) = C.ID_Nacionalidad OR @NACIONALIDAD IS NULL)
	AND (C.Apellido = @APELLIDO OR @APELLIDO IS NULL OR @APELLIDO = '')
	AND (C.Nombre = @NOMBRE OR @NOMBRE IS NULL OR @NOMBRE = '')
	AND (C.Mail = @EMAIL OR @EMAIL IS NULL OR @EMAIL = '')

END



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GET_NACIONALIDADES]
AS
BEGIN
	SELECT *
	FROM LOS_NULL.Nacionalidad N	
END

/*
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GET_TIPODOC]
AS
BEGIN
	SELECT *
	FROM LOS_NULL.TipoDoc N	
END
*/