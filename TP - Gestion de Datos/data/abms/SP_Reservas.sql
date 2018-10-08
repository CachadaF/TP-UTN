
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[QUITARRESERVAXHABITACION]
	@ID_HABITACION NUMERIC(18,0),
	@CODIGO_RESERVA NUMERIC(18,0)
AS
BEGIN
	
	DELETE FROM LOS_NULL.ReservaXHabitacion
	WHERE ID_Habitacion = @ID_HABITACION AND ID_Reserva = @CODIGO_RESERVA
	
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[INSERTARRESERVAXHABITACION]
	@ID_HABITACION NUMERIC(18,0),
	@CODIGO_RESERVA NUMERIC(18,0)
AS
BEGIN

	INSERT INTO LOS_NULL.ReservaXHabitacion(ID_Habitacion,ID_Reserva)
	VALUES (@ID_HABITACION,@CODIGO_RESERVA)
	
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[INSERTARCLIENTERESERVA]
	@COD_RESERVA NUMERIC(18,0),
	@ID_CLIENTE NUMERIC(18,0)
AS
BEGIN
		IF EXISTS (SELECT * FROM LOS_NULL.ReservaXCliente WHERE Codigo_Reserva=@COD_RESERVA)
			BEGIN
				INSERT INTO ReservaXCliente(Codigo_Reserva,Nro_Cliente,Flag_Reserva)
				VALUES (@COD_RESERVA,@ID_CLIENTE,0) --ya existia la reserva, ya fue guardado el cliente generador
			END
		ELSE
			BEGIN
				INSERT INTO ReservaXCliente(Codigo_Reserva,Nro_Cliente,Flag_Reserva)
				VALUES (@COD_RESERVA,@ID_CLIENTE,1) --es la primera vez que se guarda en esta tabla con este codigo de reserva
			END
		

END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETALLCLIENTES]
	
AS
BEGIN
		SELECT C.Apellido,C.Baja_Logica,C.Depto,C.Dom_Calle,C.Duplicado_Mail,C.Duplicado_Pasaporte,
				C.Fecha_nac,C.Mail,C.Nombre,C.Nro_Calle,C.Nro_Cliente,C.Nro_Pasaporte,C.Piso
		FROM LOS_NULL.Cliente C
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [LOS_NULL].[MODIFICARRESERVA]
	@FECHA_INICIAL DATETIME,
	@CANTIDAD_DIAS NUMERIC(18,0),
	@FECHA_REALIZADA DATETIME,
	@REGIMEN NVARCHAR(255),
	@USUARIO NVARCHAR(255),
	@CODIGO_RESERVA NUMERIC(18,0)
AS
BEGIN

DECLARE @TIPO_USER NVARCHAR(255)

	IF (NOT(@USUARIO = 'Guest'))
	BEGIN
		SET @TIPO_USER = (SELECT TOP 1 (R.Nombre_Rol)
						FROM LOS_NULL.Usuario U 
						JOIN LOS_NULL.UsuarioXHotel UH ON (U.ID_Usuario = UH.ID_Usuario)
						JOIN LOS_NULL.UsuarioXRol UR ON (U.ID_Usuario = UR.ID_Usuario)
						JOIN LOS_NULL.Rol R ON (R.ID_Rol = UR.ID_Rol)
						WHERE U.ID_Usuario = @USUARIO)
	END
	
	IF (@TIPO_USER IS NOT NULL AND @TIPO_USER = 'Administrador')
	BEGIN
		UPDATE LOS_NULL.Reserva
		SET Cant_Noches = @CANTIDAD_DIAS,Fecha_Inicio = @FECHA_INICIAL,Fecha_Realizada = @FECHA_REALIZADA,
			ID_Estado = 3,Usuario = @USUARIO,ID_Regimen = LOS_NULL.ID_REGIMEN(@REGIMEN)
		WHERE Codigo_Reserva = @CODIGO_RESERVA
	END
	
	IF (@TIPO_USER IS NOT NULL AND @TIPO_USER = 'Recepcionista')
	BEGIN
		UPDATE LOS_NULL.Reserva
		SET Cant_Noches = @CANTIDAD_DIAS,Fecha_Inicio = @FECHA_INICIAL,Fecha_Realizada = @FECHA_REALIZADA,
			ID_Estado = 3,Usuario = @USUARIO,ID_Regimen = LOS_NULL.ID_REGIMEN(@REGIMEN)
		WHERE Codigo_Reserva = @CODIGO_RESERVA
	END
	
	IF (@USUARIO = 'Guest')
	BEGIN
		UPDATE LOS_NULL.Reserva
		SET Cant_Noches = @CANTIDAD_DIAS,Fecha_Inicio = @FECHA_INICIAL,Fecha_Realizada = @FECHA_REALIZADA,
			ID_Estado = 4,Usuario = @USUARIO,ID_Regimen = LOS_NULL.ID_REGIMEN(@REGIMEN)
		WHERE Codigo_Reserva = @CODIGO_RESERVA
	END	
	

END
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[INSERTARRESERVA]
	@FECHA_INICIAL DATETIME,
	@CANTIDAD_DIAS NUMERIC(18,0),
	@FECHA_REALIZADA DATETIME,
	@REGIMEN NVARCHAR(255),
	@USUARIO NVARCHAR(255)
AS
BEGIN
	
	--Estado 1 -> Realizada
	INSERT INTO LOS_NULL.Reserva(Cant_Noches,Fecha_Inicio,Fecha_Realizada,ID_Estado,ID_Regimen,Usuario)
	VALUES (@CANTIDAD_DIAS,@FECHA_INICIAL,@FECHA_REALIZADA,1,LOS_NULL.ID_REGIMEN(@REGIMEN),@USUARIO)
	
	DECLARE @RETORNO_RESERVA NUMERIC(18,0)
	SET @RETORNO_RESERVA = @@IDENTITY

	
	SELECT @RETORNO_RESERVA
	
END
GO
USE [GD2C2014]
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETHABITACIONPORCODIGORESERVA]    Script Date: 11/09/2014 01:06:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETHABITACIONPORCODIGORESERVA]
	@COD_RESERVA NUMERIC(18,0)
AS
BEGIN
	
	SELECT H.ID_Habitacion,H.Baja_Logica,H.Codigo_Tipo,H.Descripcion,H.Frente,H.ID_Hotel,H.Numero,H.Piso
	FROM LOS_NULL.Reserva R 
			JOIN LOS_NULL.ReservaXHabitacion RH ON (R.Codigo_Reserva = RH.ID_Reserva)
			JOIN LOS_NULL.Habitacion H ON (RH.ID_Habitacion = H.ID_Habitacion)
	WHERE R.Codigo_Reserva = @COD_RESERVA 

	
	
END
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
USE [GD2C2014]
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETRESERVAHOTEL]    Script Date: 11/10/2014 21:46:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETRESERVAHOTEL]
	@COD_RESERVA NUMERIC(18,0),
	@ID_HOTEL NUMERIC(18,0)
AS
BEGIN
	
	SELECT R.Cant_Noches,R.Codigo_Reserva,R.Fecha_Inicio,R.Fecha_Realizada,R.ID_Estado,R.ID_Regimen,R.Usuario
	FROM LOS_NULL.Reserva R 
			JOIN LOS_NULL.ReservaXHabitacion RH ON (R.Codigo_Reserva = RH.ID_Reserva)
			JOIN LOS_NULL.Habitacion H ON (RH.ID_Habitacion = H.ID_Habitacion)
	WHERE R.Codigo_Reserva = @COD_RESERVA 
			AND H.ID_Hotel = @ID_HOTEL 
		
	
	
END


GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[INSERTARRESERVA]
	@ID_HABITACION NUMERIC(18,0),
	@FECHA_INICIAL DATETIME,
	@CANTIDAD_DIAS NUMERIC(18,0),
	@FECHA_REALIZADA DATETIME,
	@REGIMEN NVARCHAR(255),
	@USUARIO NVARCHAR(255)
AS
BEGIN
	
	--Estado 1 -> Realizada
	INSERT INTO LOS_NULL.Reserva(Cant_Noches,Fecha_Inicio,Fecha_Realizada,ID_Estado,ID_Regimen,Usuario)
	VALUES (@CANTIDAD_DIAS,@FECHA_INICIAL,@FECHA_REALIZADA,1,LOS_NULL.ID_REGIMEN(@REGIMEN),@USUARIO)
	
	DECLARE @RETORNO_RESERVA NUMERIC(18,0)
	SET @RETORNO_RESERVA = @@IDENTITY
	
	INSERT INTO LOS_NULL.ReservaXHabitacion(ID_Habitacion,ID_Reserva)
	VALUES (@ID_HABITACION,@RETORNO_RESERVA)
	
	SELECT @RETORNO_RESERVA
	
END
GO

USE [GD2C2014]
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLHABITACIONPORHOTELPORFECHAYCANTIDAD]    Script Date: 11/09/2014 15:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [LOS_NULL].[GETALLHABITACIONPORHOTELPORFECHAYCANTIDAD] 
	@ID_HOTEL NUMERIC(18,0),
	@ID_TIPO_HAB NUMERIC(18,0),
	@FECHA_INI DATETIME,
	@FECHA_FIN DATETIME
AS
BEGIN
	
	SELECT *
	FROM  LOS_NULL.Habitacion HA			
	WHERE HA.ID_Hotel = @ID_HOTEL
	AND HA.Codigo_Tipo = @ID_TIPO_HAB
	AND HA.Baja_Logica = 0
	AND(
	SELECT COUNT(*)
	FROM  LOS_NULL.ReservaXHabitacion RHA 
			JOIN LOS_NULL.Reserva R ON (R.Codigo_Reserva = RHA.ID_Reserva)
	WHERE RHA.ID_Habitacion = HA.ID_Habitacion
		AND
		(R.ID_Estado != 1 AND R.ID_Estado != 2 AND R.ID_Estado != 6 )
		AND
		(
		--Existe una reserva que inicia entre las fechas que quiero usar
		(R.Fecha_Inicio BETWEEN @FECHA_INI AND @FECHA_FIN) 
		OR
		--Existe una reserva que finaliza entre las fechas que quiero usar
		(DATEADD(D,R.Cant_Noches,R.Fecha_Inicio) BETWEEN @FECHA_INI AND @FECHA_FIN)				 
		OR
		--Existe una reserva que se realiza que supera el rango que quiero
		((R.Fecha_Inicio < @FECHA_INI) AND (DATEADD(D,R.Cant_Noches,R.Fecha_Inicio) > @FECHA_FIN))
		)	
	) = 0
	AND
	( 
	SELECT COUNT(*)
	FROM LOS_NULL.Hotel H 
		JOIN LOS_NULL.BajaTemporalHotel BH ON (H.ID_Hotel = BH.ID_Baja_Hotel)
	WHERE BH.ID_Hotel = @ID_HOTEL
		AND
		(
		--Existe una reserva que inicia entre las fechas que quiero usar
		(BH.Fecha_Inicio BETWEEN @FECHA_INI AND @FECHA_FIN) 
		OR
		--Existe una reserva que finaliza entre las fechas que quiero usar
		(BH.Fecha_Fin BETWEEN @FECHA_INI AND @FECHA_FIN)				 
		OR
		--Existe una reserva que se realiza que supera el rango que quiero
		((BH.Fecha_Inicio < @FECHA_INI) AND BH.Fecha_Fin > @FECHA_FIN)
		)	
	) = 0
END


-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETTIPOHABITACIONPORCANTIDAD]
	@CANTIDAD NUMERIC(18,0)
AS
BEGIN
	SELECT *
	FROM LOS_NULL.TipoHabitacion TH
	WHERE TH.Capacidad = @CANTIDAD
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETALLHOTELES]

AS
BEGIN
	SELECT *
	FROM LOS_NULL.Hotel 
END
GO

/****** Object:  StoredProcedure [LOS_NULL].[GETVALORHABITACION]    Script Date: 11/02/2014 18:20:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
USE [GD2C2014]
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETVALORHABITACION]    Script Date: 11/05/2014 13:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETVALORHABITACION]
	@ID_HOTEL NUMERIC(18,0),
	@ID_HABITACION NUMERIC(18,0),
	@REGIMEN NVARCHAR(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @VALOR_HAB NUMERIC(18,2)
	
	SET @VALOR_HAB = 
	(
	SELECT(H.Recarga_Estrella+R.Precio)*TH.Capacidad+TH.Porcentual*(H.Recarga_Estrella+R.Precio)*TH.Capacidad/100
	FROM LOS_NULL.Hotel H 
		JOIN LOS_NULL.Habitacion HA ON (H.ID_Hotel = HA.ID_Hotel)
		JOIN LOS_NULL.TipoHabitacion TH ON (HA.Codigo_Tipo = TH.Codigo_Tipo)
		JOIN LOS_NULL.RegimenXHotel RH ON (RH.ID_Hotel = H.ID_Hotel)
		JOIN LOS_NULL.Regimen R ON (R.ID_Regimen = RH.ID_Regimen)
	WHERE H.ID_Hotel = @ID_HOTEL AND R.ID_Regimen = LOS_NULL.ID_REGIMEN(@REGIMEN) AND HA.ID_Habitacion = @ID_HABITACION
	)
	IF (@VALOR_HAB IS NULL)
	BEGIN
		SET @VALOR_HAB = 0;
	END
	
	SELECT @VALOR_HAB

END



/****** Object:  StoredProcedure [LOS_NULL].[CANCELARRESERVA]    Script Date: 11/02/2014 22:20:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[CANCELARRESERVA]
	@MOTIVO NVARCHAR(255),
	@FECHA DATETIME,
	@USUARIO NVARCHAR(255),
	@CODIGO_RESERVA NUMERIC(18,0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @FECHA_INICIO DATETIME
	DECLARE @MENSAJE NVARCHAR(255)
	DECLARE @ESTADO numeric (18,0)
	SET @MENSAJE = 'NO EXISTE EL NUMERO DE RESERVA'
	
	IF @USUARIO='Guest' SET @ESTADO=4
	ELSE SET @ESTADO=3
	
	IF EXISTS
	(
	SELECT * FROM LOS_NULL.Reserva R
	WHERE R.Codigo_Reserva=@CODIGO_RESERVA
	)
	BEGIN
		INSERT INTO LOS_NULL.CancelacionReserva(Motivo, Fecha, Usuario, Codigo_Reserva)
		VALUES (@MOTIVO, @FECHA, @USUARIO, @CODIGO_RESERVA)
		
		--actualizar estado de reserva
		SET @FECHA_INICIO = (SELECT R.Fecha_Inicio FROM LOS_NULL.Reserva R WHERE R.Codigo_Reserva=@CODIGO_RESERVA)
		IF (DATEADD(DAY,-1,@FECHA) > @FECHA_INICIO)
		BEGIN
			IF EXISTS(SELECT * FROM LOS_NULL.Usuario U WHERE U.ID_Usuario = @USUARIO)
			BEGIN
				UPDATE LOS_NULL.Reserva 
				SET ID_Estado=@ESTADO WHERE Codigo_Reserva=@CODIGO_RESERVA
				SET @MENSAJE = 'RESERVA CANCELADA POR '+@USUARIO
			END
		END
		ELSE SET @MENSAJE = 'YA NO PUEDE CANCELAR LA RESERVA'
	END
	
	SELECT @MENSAJE
END
GO

USE [GD2C2014]
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETRESERVAHOTEL]    Script Date: 11/10/2014 21:17:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETRESERVAVIGENTE_HOTEL]
	@COD_RESERVA NUMERIC(18,0),
	@ID_HOTEL NUMERIC(18,0)
AS
BEGIN
	
	SELECT R.Cant_Noches,R.Codigo_Reserva,R.Fecha_Inicio,R.Fecha_Realizada,R.ID_Estado,R.ID_Regimen,R.Usuario
	FROM LOS_NULL.Reserva R 
			JOIN LOS_NULL.ReservaXHabitacion RH ON (R.Codigo_Reserva = RH.ID_Reserva)
			JOIN LOS_NULL.Habitacion H ON (RH.ID_Habitacion = H.ID_Habitacion)
	WHERE R.Codigo_Reserva = @COD_RESERVA 
			AND H.ID_Hotel = @ID_HOTEL 
			AND (
				R.ID_Estado = 1
				OR
				R.ID_Estado = 2	
				)
	
	
END
