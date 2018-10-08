CREATE PROCEDURE [LOS_NULL].[GETID_ROL]
	@NOMBRE_ROL varchar(50)
	
AS 
BEGIN
	
	SELECT ID_Rol FROM LOS_NULL.Rol WHERE Nombre_Rol=@NOMBRE_ROL

END
GO


CREATE PROCEDURE [LOS_NULL].[INSERTARROL]
	@NOMBRE_ROL varchar(18),
	@BAJA_LOGICA bit
	
AS
BEGIN
	INSERT INTO LOS_NULL.Rol (Nombre_Rol,Baja_Logica)
	VALUES (@NOMBRE_ROL,@BAJA_LOGICA)
	
END
GO

CREATE PROCEDURE [LOS_NULL].[MODIFICARROL]
	@ID_ROL numeric(18,0),
	@NOMBRE_ROL varchar(18),
	@BAJA_LOGICA bit
	
AS 
BEGIN
	
	UPDATE LOS_NULL.Rol 
	SET Nombre_Rol=@NOMBRE_ROL, Baja_Logica=@BAJA_LOGICA
	WHERE ID_Rol=@ID_ROL

END
GO

CREATE PROCEDURE [LOS_NULL].[AGREGARFUNC_A_ROL]
	@ID_ROL numeric(18,0),
	@ID_FUNC numeric(18,0)

AS
BEGIN
	
	
	INSERT INTO LOS_NULL.FuncionalidadXRol (ID_Rol,ID_Funcionalidad)
	VALUES (@ID_ROL,@ID_FUNC)
	
	
END
GO


CREATE PROCEDURE [LOS_NULL].[MODIFICARUSER]
	@ID_USER varchar(50),
	@PASS varchar(64),
	@TRIES numeric (18,0),
	@BAJA_LOGICA bit,
	@NUEVO_USER varchar(50)
	
AS 
BEGIN
	
	UPDATE LOS_NULL.Usuario
	SET ID_Usuario=@NUEVO_USER,Password=@PASS, Intentos=@TRIES, Baja_Logica=@BAJA_LOGICA
	WHERE ID_Usuario=@ID_USER

END
GO

CREATE PROCEDURE [LOS_NULL].[INSERTARUSER]
	@ID_USER varchar(50),
	@PASS varchar(64),
	@TRIES numeric(18,0),
	@BAJA_LOGICA bit
	
AS
BEGIN
	INSERT INTO LOS_NULL.Usuario (ID_Usuario,Password,Intentos,Baja_Logica)
	VALUES (@ID_USER,@PASS,@TRIES,@BAJA_LOGICA)
	
END
GO

CREATE PROCEDURE [LOS_NULL].[AGREGARROL_A_USER]
@ID_ROL numeric (18,0),
@ID_USER varchar (50)

AS
BEGIN

	INSERT INTO LOS_NULL.UsuarioXRol (ID_Rol,ID_Usuario)
	VALUES (@ID_ROL,@ID_USER);

END
GO

CREATE PROCEDURE [LOS_NULL].[AGREGARHOTEL_A_USER]
@ID_HOTEL numeric (18,0),
@ID_USER varchar (50)

AS
BEGIN

	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario)
	VALUES (@ID_HOTEL,@ID_USER);

END
GO

CREATE PROCEDURE [LOS_NULL].[INSERTARDATOSPERS_USER]
	@ID_USER varchar(50),
	@NOM varchar (50),
	@AP varchar(50),
	@TDOC varchar (5),
	@DOC numeric (18,0),
	@FEC date,
	@DOM varchar (60),
	@TEL numeric (18,0),
	@MAIL varchar (20)
	
AS
BEGIN
	INSERT INTO LOS_NULL.Persona (Tipo_Documento,Nro_Documento,Nombre,Apellido,Mail,Telefono,Direccion,Fecha_Nac,Usuario)
	VALUES (@TDOC,@DOC,@NOM,@AP,@MAIL,@TEL,@DOM,@FEC,@ID_USER)
	
END
GO

CREATE PROCEDURE [LOS_NULL].[MODIFICARDATOSPERS_USER]
	@ID_USER varchar(50),
	@NOM varchar (50),
	@AP varchar(50),
	@TDOC varchar (5),
	@DOC numeric (18,0),
	@FEC date,
	@DOM varchar (60),
	@TEL numeric (18,0),
	@MAIL varchar (20)
	
AS
BEGIN
	UPDATE LOS_NULL.Persona 
	SET Tipo_Documento=@TDOC,Nro_Documento=@DOC,Nombre=@NOM,Apellido=@AP,Mail=@MAIL,Telefono=@TEL,
		Direccion=@DOM,Fecha_Nac=@FEC
	WHERE Usuario=@ID_USER
	
END
GO

CREATE PROCEDURE [LOS_NULL].[CAMBIAR_PASSWORD]
	@ID_USER varchar(50),
	@PASS varchar(64)
AS 
BEGIN
	
	UPDATE LOS_NULL.Usuario
	SET Password=@PASS
	WHERE ID_Usuario=@ID_USER

END
GO

CREATE PROCEDURE [LOS_NULL].[LOGIN_FALLIDO]
	@ID_USER varchar(50)
	
AS 
BEGIN
	
	UPDATE LOS_NULL.Usuario
	SET Intentos+=1
	WHERE ID_Usuario=@ID_USER

END
GO

CREATE PROCEDURE [LOS_NULL].[RESET_LOGIN_TRIES]
	@ID_USER varchar(50)
	
AS 
BEGIN
	
	UPDATE LOS_NULL.Usuario
	SET Intentos=0
	WHERE ID_Usuario=@ID_USER

END
GO

CREATE PROCEDURE [LOS_NULL].[ELIMINARFUNC_DE_ROL]
	@ID_ROL numeric(18,0),
	@ID_FUNC numeric(18,0)

AS
BEGIN
	
	
	DELETE FROM LOS_NULL.FuncionalidadXRol
	WHERE ID_Funcionalidad=@ID_FUNC AND ID_Rol=@ID_ROL; 
	
END
GO

CREATE PROCEDURE [LOS_NULL].[ELIMINARUSER_DE_HOTEL]
	@ID_HOTEL numeric(18,0),
	@ID_USER varchar(50)

AS
BEGIN
	
	
	DELETE FROM LOS_NULL.UsuarioXHotel
	WHERE ID_Hotel=@ID_HOTEL AND ID_Usuario=@ID_USER; 
	
END
GO

CREATE PROCEDURE [LOS_NULL].[ELIMINAROL_DE_USER]
	@ID_ROL numeric(18,0),
	@ID_USER varchar(50)

AS
BEGIN
	
	
	DELETE FROM LOS_NULL.UsuarioXRol
	WHERE ID_Rol=@ID_ROL AND ID_Usuario=@ID_USER; 
	
END
GO

CREATE PROCEDURE [LOS_NULL].[CERRAR_ESTADIA]
	@ESTADIA numeric (18,0),
	@CANT numeric (18,0),
	@USER varchar (50)
	
AS
BEGIN

	UPDATE LOS_NULL.Estadia SET Cant_Noches_Estadia=@CANT,Usuario_Egreso=@USER WHERE ID_Estadia=@ESTADIA

END
GO

CREATE PROCEDURE [LOS_NULL].[INSERTARESTADIA]
	@FECHA date,
	@NOCHES numeric(18,0),
	@RES numeric (18,0),
	@USER varchar(50)
	
AS
BEGIN

	INSERT INTO LOS_NULL.Estadia (Fecha_Inicio,Cant_Noches,Codigo_Reserva,Usuario_Ingreso,Usuario_Egreso,Cant_Noches_Estadia) 
	VALUES (@FECHA,@NOCHES,@RES,@USER,'','')
	
	UPDATE LOS_NULL.Reserva
	SET ID_Estado=6
	WHERE Codigo_Reserva=@RES
	
END
GO

CREATE PROCEDURE [LOS_NULL].[UPDATESTATUS_NOSHOW]
	@RESERVA numeric(18,0),
	@STATUS numeric(18,0),
	@FECHA date,
	@USER varchar(50)
	
AS 
BEGIN
	
	DECLARE @MOTIVO varchar(255)
	SET @MOTIVO = 'El cliente no se presentó a tiempo para el Check-In'
	
	UPDATE LOS_NULL.Reserva
	SET ID_Estado=@STATUS, Usuario=@USER
	WHERE Codigo_Reserva=@RESERVA
	
	INSERT INTO LOS_NULL.CancelacionReserva (Codigo_Reserva,Fecha,Motivo,Usuario)
	VALUES (@RESERVA,@FECHA,@MOTIVO,@USER)

END
GO

CREATE PROCEDURE [LOS_NULL].[CANTIDADPERSONAS_RESERVA]
	@RESERVA numeric(18,0)
	
AS
BEGIN

	SELECT SUM(TH.Capacidad) FROM LOS_NULL.ReservaXHabitacion RH JOIN LOS_NULL.Habitacion H ON (RH.ID_Habitacion=H.ID_Habitacion)
	JOIN LOS_NULL.TipoHabitacion TH ON (TH.Codigo_Tipo=H.Codigo_Tipo)
	WHERE RH.ID_Reserva=@RESERVA

END
GO