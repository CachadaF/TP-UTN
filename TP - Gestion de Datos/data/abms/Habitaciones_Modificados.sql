USE [GD2C2014]
GO
/****** Object:  StoredProcedure [LOS_NULL].[MODIFICARHABITACION]    Script Date: 11/07/2014 19:12:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [LOS_NULL].[MODIFICARHABITACION]	
	@ID_HOTEL numeric(18,0),
	@NUMERO numeric(18,0),
	@PISO numeric(18,0),
	@FRENTE nvarchar(255),
	@ID_TIPO_HAB numeric(18,0),
	@BAJA_LOGICA bit,
	@DESCRIPCION nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE LOS_NULL.Habitacion 
	SET Baja_Logica = @BAJA_LOGICA,Frente = @FRENTE,Piso = @PISO,Codigo_Tipo = @ID_TIPO_HAB,descripcion = @DESCRIPCION
	WHERE ID_Hotel = @ID_HOTEL AND Numero = @NUMERO

	
END

USE [GD2C2014]
GO
/****** Object:  StoredProcedure [LOS_NULL].[INSERTARHABITACION]    Script Date: 11/07/2014 19:12:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [LOS_NULL].[INSERTARHABITACION]	
	@ID_HOTEL numeric(18,0),
	@NUMERO numeric(18,0),
	@PISO numeric(18,0),
	@FRENTE nvarchar(255),
	@ID_TIPO_HAB numeric(18,0),
	@DESCRIPCION nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO LOS_NULL.Habitacion(Codigo_Tipo,Frente,ID_Hotel,Numero,Piso,Descripcion)
	VALUES (@ID_TIPO_HAB,@FRENTE,@ID_HOTEL,@NUMERO,@PISO,@DESCRIPCION)
	
END
