--CREACION DE TABLAS, FUNCIONES, PROCEDURES
USE [GD2C2014]
GO
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'LOS_NULL')
DROP SCHEMA [LOS_NULL]
GO
USE [GD2C2014]
GO
/****** Object:  Schema [LOS_NULL]    Script Date: 11/11/2014 21:57:11 ******/
CREATE SCHEMA [LOS_NULL] AUTHORIZATION [gd]
GO
/****** Object:  Table [LOS_NULL].[Funcionalidad]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Funcionalidad](
	[ID_Funcionalidad] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre_Func] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[ID_Funcionalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LOS_NULL].[EstadoReserva]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[EstadoReserva](
	[ID_Estado] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_EstadoReserva] PRIMARY KEY CLUSTERED 
(
	[ID_Estado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LOS_NULL].[Consumible]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Consumible](
	[ID_Consumible] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[Precio] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Consumible] PRIMARY KEY CLUSTERED 
(
	[ID_Consumible] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LOS_NULL].[Persona]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Persona](
	[Tipo_Documento] [nchar](10) NOT NULL,
	[Nro_Documento] [numeric](18, 0) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](25) NULL,
	[Direccion] [nvarchar](50) NULL,
	[Fecha_Nac] [smalldatetime] NOT NULL,
	[Usuario] [nvarchar](255) NOT NULL,
	[Numero] [numeric](18, 0) NULL,
	[Piso] [numeric](18, 0) NULL,
	[Depto] [nvarchar](50) NULL,
	[Localidad] [nvarchar](255) NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Tipo_Documento] ASC,
	[Nro_Documento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LOS_NULL].[Nacionalidad]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Nacionalidad](
	[ID_Nacionalidad] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Nacionalidad] PRIMARY KEY CLUSTERED 
(
	[ID_Nacionalidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LOS_NULL].[Hotel]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Hotel](
	[ID_Hotel] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Ciudad] [nvarchar](255) NOT NULL,
	[Calle] [nvarchar](255) NOT NULL,
	[Nro_Calle] [numeric](18, 0) NOT NULL,
	[Cant_Estrellas] [numeric](18, 0) NOT NULL,
	[Recarga_Estrella] [numeric](18, 2) NOT NULL,
	[Telefono] [nvarchar](25) NULL,
	[Pais] [nvarchar](255) NULL,
	[Fecha_Creacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[ID_Hotel] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[MENOR_FECHA]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION[LOS_NULL].[MENOR_FECHA]
(
	@FECHA1 datetime,
	@FECHA2 datetime
)
RETURNS datetime

AS
BEGIN
	
	DECLARE @FECHA_MENOR datetime

	IF (@FECHA1 < @FECHA2) SET @FECHA_MENOR= @FECHA1
	ELSE SET @FECHA_MENOR= @FECHA2
	
	RETURN @FECHA_MENOR
	
END
GO
/****** Object:  Table [LOS_NULL].[TipoHabitacion]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[TipoHabitacion](
	[Codigo_Tipo] [numeric](18, 0) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[Porcentual] [numeric](18, 2) NOT NULL,
	[Capacidad] [numeric](18, 0) NULL,
 CONSTRAINT [PK_TipoHabitacion] PRIMARY KEY CLUSTERED 
(
	[Codigo_Tipo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LOS_NULL].[Tarjeta]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Tarjeta](
	[ID_Tarjeta] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Numero] [numeric](18, 0) NOT NULL,
	[Tipo] [nvarchar](255) NOT NULL,
	[Descripcion] [nvarchar](255) NULL,
 CONSTRAINT [PK_TarjetaDeCredito] PRIMARY KEY CLUSTERED 
(
	[ID_Tarjeta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LOS_NULL].[Rol]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Rol](
	[ID_Rol] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Nombre_Rol] [nvarchar](255) NOT NULL,
	[Baja_Logica] [bit] NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[ID_Rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LOS_NULL].[Usuario]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Usuario](
	[ID_Usuario] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](64) NOT NULL,
	[Intentos] [numeric](1, 0) NOT NULL,
	[Baja_Logica] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LOS_NULL].[Regimen]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Regimen](
	[ID_Regimen] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[Precio] [numeric](18, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Regimen] PRIMARY KEY CLUSTERED 
(
	[ID_Regimen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [LOS_NULL].[MODIFICARHOTELPORID]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[MODIFICARHOTELPORID]
	@ID_HOTEL NUMERIC(18,0),
	@CALLE NVARCHAR(255),
	@RECARGA_ESTRELLA NUMERIC(18,2),
	@TELEFONO NVARCHAR(25),
	@NRO_CALLE NUMERIC(18,0),
	@CANTIDAD_ESTRELLAS NUMERIC(18,0),
	@CIUDAD NVARCHAR(255),
	@PAIS NVARCHAR(255)
AS
BEGIN
	
	UPDATE LOS_NULL.Hotel
	SET Calle = @CALLE,Cant_Estrellas = @CANTIDAD_ESTRELLAS,Ciudad = @CIUDAD,
	Nro_Calle = @NRO_CALLE,Pais = @PAIS,Recarga_Estrella = @RECARGA_ESTRELLA,Telefono = @TELEFONO
	WHERE ID_Hotel = @ID_HOTEL
	
	
END
GO
/****** Object:  Table [LOS_NULL].[UsuarioXRol]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[UsuarioXRol](
	[ID_Usuario] [nvarchar](255) NOT NULL,
	[ID_Rol] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_UsuarioXRol] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC,
	[ID_Rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LOS_NULL].[UsuarioXHotel]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[UsuarioXHotel](
	[ID_Usuario] [nvarchar](255) NOT NULL,
	[ID_Hotel] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_UsuarioXHotel] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC,
	[ID_Hotel] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [LOS_NULL].[RESET_LOGIN_TRIES]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [LOS_NULL].[LOGIN_FALLIDO]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  UserDefinedFunction [LOS_NULL].[ID_TIPOHABITACION]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [LOS_NULL].[ID_TIPOHABITACION]
(
	@Descripcion nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	
	RETURN 
	(
		SELECT T.Codigo_Tipo
		FROM TipoHabitacion T
		WHERE T.Descripcion = @Descripcion
	)

END
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[ID_TARJETA]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [LOS_NULL].[ID_TARJETA] 
(
	@TIPO NVARCHAR(255),
	@NUMERO NUMERIC(18,0)
)
RETURNS NUMERIC(18,0)
AS
BEGIN
	
	RETURN 
	(
	SELECT TOP 1(T.ID_Tarjeta)
	FROM LOS_NULL.Tarjeta T
	WHERE T.Numero = @NUMERO AND T.Tipo = @TIPO
	)
	

END
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[ID_REGIMEN]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [LOS_NULL].[ID_REGIMEN]
(
	@DESCRIPCION nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	
	RETURN (
	SELECT R.ID_Regimen
	FROM LOS_NULL.Regimen R
	WHERE R.Descripcion = @DESCRIPCION
	)

END
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[ID_NACIONALIDAD]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [LOS_NULL].[ID_NACIONALIDAD]
(
	@NACIONALIDAD nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	
	RETURN (
	SELECT N.ID_Nacionalidad
	FROM LOS_NULL.Nacionalidad N
	WHERE N.Descripcion = @NACIONALIDAD
	)

END
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[ID_HOTEL]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [LOS_NULL].[ID_HOTEL]
(
	@Ciudad nvarchar(255),
	@Calle nvarchar(255),
	@Nro_Calle numeric(18,0),
	@CantEstrellas numeric(18,0),
	@RecargaEstrellas numeric(18,0)
	
)
RETURNS numeric(18,0)
AS
BEGIN
	
	RETURN 
	(
		SELECT H.ID_Hotel
		FROM LOS_NULL.Hotel H
		WHERE H.Calle = @Calle 
		AND H.Ciudad = @Ciudad
		AND H.Nro_Calle = @Nro_Calle
		AND H.Recarga_Estrella = @RecargaEstrellas
		AND H.Cant_Estrellas = @CantEstrellas
	)

END
GO
/****** Object:  Table [LOS_NULL].[Habitacion]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Habitacion](
	[ID_Habitacion] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Numero] [numeric](18, 0) NOT NULL,
	[Piso] [numeric](18, 0) NOT NULL,
	[Codigo_Tipo] [numeric](18, 0) NOT NULL,
	[ID_Hotel] [numeric](18, 0) NOT NULL,
	[Frente] [nvarchar](255) NOT NULL,
	[Baja_Logica] [bit] NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Habitacion] PRIMARY KEY CLUSTERED 
(
	[ID_Habitacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LOS_NULL].[Reserva]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Reserva](
	[Codigo_Reserva] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Fecha_Inicio] [datetime] NOT NULL,
	[Cant_Noches] [numeric](18, 0) NOT NULL,
	[Fecha_Realizada] [datetime] NOT NULL,
	[ID_Estado] [numeric](18, 0) NOT NULL,
	[Usuario] [nvarchar](255) NULL,
	[ID_Regimen] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[Codigo_Reserva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LOS_NULL].[RegimenXHotel]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[RegimenXHotel](
	[ID_Regimen] [numeric](18, 0) NOT NULL,
	[ID_Hotel] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_RegimenXHotel] PRIMARY KEY CLUSTERED 
(
	[ID_Regimen] ASC,
	[ID_Hotel] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [LOS_NULL].[INSERTARUSER]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [LOS_NULL].[INSERTARTARJETA]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[INSERTARTARJETA]
	@NUMERO NUMERIC(18,0),
	@TIPO NVARCHAR(255),
	@DESCRIPCION NVARCHAR(255)
	
AS
BEGIN
	
	INSERT INTO LOS_NULL.Tarjeta(Numero,Tipo,Descripcion)
	VALUES (@NUMERO,@TIPO,@DESCRIPCION)
	
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[INSERTARROL]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [LOS_NULL].[MIGRAR_CONSUMIBLES]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[MIGRAR_CONSUMIBLES]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--
	--
	SET IDENTITY_INSERT LOS_NULL.Consumible ON;
	--
	--
	INSERT INTO LOS_NULL.Consumible(ID_Consumible,Descripcion,Precio)
	
	SELECT M.Consumible_Codigo,M.Consumible_Descripcion,M.Consumible_Precio
	FROM gd_esquema.Maestra M
	WHERE M.Consumible_Codigo is not NULL
	GROUP BY M.Consumible_Codigo,M.Consumible_Descripcion,M.Consumible_Precio
	ORDER BY M.Consumible_Codigo,M.Consumible_Descripcion,M.Consumible_Precio
	--
	--
	SET IDENTITY_INSERT LOS_NULL.Consumible OFF;
	--
	--

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[INSERTARDATOSPERS_USER]    Script Date: 11/11/2014 13:51:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[INSERTARDATOSPERS_USER]
	@ID_USER varchar(50),
	@NOM varchar (50),
	@AP varchar(50),
	@TDOC varchar (5),
	@DOC numeric (18,0),
	@FEC date,
	@DOM varchar (60),
	@NRO numeric(18,0),
	@PISO numeric (18,0),
	@DPTO varchar (18),
	@LOC varchar (50),
	@TEL varchar (20),
	@MAIL varchar (20)
	
AS
BEGIN
	INSERT INTO LOS_NULL.Persona (Tipo_Documento,Nro_Documento,Nombre,Apellido,Mail,Telefono,Direccion,Numero,Piso,Depto,Localidad,Fecha_Nac,Usuario)
	VALUES (@TDOC,@DOC,@NOM,@AP,@MAIL,@TEL,@DOM,@NRO,@PISO,@DPTO,@LOC,@FEC,@ID_USER)
	
END
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[ID_ESTADORESERVA]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [LOS_NULL].[ID_ESTADORESERVA] 
(
	@ESTADO_RESERVA nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	RETURN 
	(
	SELECT E.ID_Estado
	FROM LOS_NULL.EstadoReserva E
	WHERE E.Descripcion = @ESTADO_RESERVA
	)

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[MIGRAR_TIPO_HABITACION]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[MIGRAR_TIPO_HABITACION] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   INSERT INTO LOS_NULL.TipoHabitacion(Codigo_Tipo,Descripcion,Porcentual)
   
   SELECT M.Habitacion_Tipo_Codigo,M.Habitacion_Tipo_Descripcion,M.Habitacion_Tipo_Porcentual
   FROM gd_esquema.Maestra M
   GROUP BY M.Habitacion_Tipo_Codigo,M.Habitacion_Tipo_Descripcion,M.Habitacion_Tipo_Porcentual
   ORDER BY M.Habitacion_Tipo_Codigo,M.Habitacion_Tipo_Descripcion,M.Habitacion_Tipo_Porcentual
	
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[MODIFICARDATOSPERS_USER]    Script Date: 11/11/2014 13:51:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[MODIFICARDATOSPERS_USER]
	@ID_USER varchar(50),
	@NOM varchar (50),
	@AP varchar(50),
	@TDOC varchar (5),
	@DOC numeric (18,0),
	@FEC date,
	@DOM varchar (60),
	@NRO numeric (18,0),
	@PISO numeric (18,0),
	@DPTO varchar (18),
	@LOC varchar (50),
	@TEL varchar (20),
	@MAIL varchar (20)
	
AS
BEGIN
	UPDATE LOS_NULL.Persona 
	SET Tipo_Documento=@TDOC,Nro_Documento=@DOC,Nombre=@NOM,Apellido=@AP,Mail=@MAIL,Telefono=@TEL,
		Direccion=@DOM,Numero=@NRO,Piso=@PISO,Depto=@DPTO,Localidad=@LOC,Fecha_Nac=@FEC
	WHERE Usuario=@ID_USER
	
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[MIGRAR_NACIONALIDADES]	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO LOS_NULL.Nacionalidad (Descripcion)
	SELECT M.Cliente_Nacionalidad
	FROM gd_esquema.Maestra M
	group by M.Cliente_Nacionalidad
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[MIGRAR_HOTELES]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[MIGRAR_HOTELES]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	INSERT INTO LOS_NULL.Hotel (Calle,Cant_Estrellas,Ciudad,Nro_Calle,Recarga_Estrella,Fecha_Creacion,Pais)
	select M.Hotel_Calle,M.Hotel_CantEstrella,M.Hotel_Ciudad,M.Hotel_Nro_Calle,M.Hotel_Recarga_Estrella,GETDATE(),'Argentina'
	from gd_esquema.Maestra M
	group by  M.Hotel_Calle,M.Hotel_CantEstrella,M.Hotel_Ciudad,M.Hotel_Nro_Calle,M.Hotel_Recarga_Estrella

	
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[MODIFICARUSER]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [LOS_NULL].[MODIFICARROL]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [LOS_NULL].[Cliente]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Cliente](
	[Nro_Cliente] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ID_Nacionalidad] [numeric](18, 0) NOT NULL,
	[Nro_Pasaporte] [numeric](18, 0) NOT NULL,
	[Apellido] [nvarchar](255) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Fecha_nac] [datetime] NOT NULL,
	[Mail] [nvarchar](255) NOT NULL,
	[Dom_Calle] [nvarchar](255) NOT NULL,
	[Nro_Calle] [numeric](18, 0) NOT NULL,
	[Piso] [numeric](18, 0) NULL,
	[Depto] [nvarchar](50) NULL,
	[Baja_Logica] [bit] NOT NULL,
	[Duplicado_Pasaporte] [bit] NOT NULL,
	[Duplicado_Mail] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Nro_Cliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [LOS_NULL].[CARGAR_ESTADO_RESERVAS]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[CARGAR_ESTADO_RESERVAS]
	
AS
BEGIN
	
	INSERT INTO LOS_NULL.EstadoReserva (Descripcion) VALUES ('Reserva Correcta')
	INSERT INTO LOS_NULL.EstadoReserva (Descripcion) VALUES ('Reserva Modificada')
	INSERT INTO LOS_NULL.EstadoReserva (Descripcion) VALUES ('Reserva Cancelada por Recepcion')
	INSERT INTO LOS_NULL.EstadoReserva (Descripcion) VALUES ('Reserva Cancelada por Cliente')
	INSERT INTO LOS_NULL.EstadoReserva (Descripcion) VALUES ('Reserva Cancelada por No-Show')
	INSERT INTO LOS_NULL.EstadoReserva (Descripcion) VALUES ('Reserva Con Ingreso(Efectivizada)')
	
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[CAMBIAR_PASSWORD]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [LOS_NULL].[BajaTemporalHotel]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[BajaTemporalHotel](
	[ID_Baja_Hotel] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ID_Hotel] [numeric](18, 0) NOT NULL,
	[Fecha_Inicio] [datetime] NOT NULL,
	[Fecha_Fin] [datetime] NOT NULL,
	[Descripcion] [nvarchar](255) NULL,
 CONSTRAINT [PK_BajaTemporalHotel] PRIMARY KEY CLUSTERED 
(
	[ID_Baja_Hotel] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LOS_NULL].[Factura]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Factura](
	[Nro_Factura] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Total] [numeric](18, 2) NOT NULL,
	[Forma_De_Pago] [nvarchar](255) NOT NULL,
	[ID_Tarjeta_Credito] [numeric](18, 0) NULL,
	[Cuotas] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[Nro_Factura] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLHOTEL]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETALLHOTEL]
	
AS 
BEGIN
	
	SELECT ID_Hotel FROM LOS_NULL.Hotel

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLHOTELES]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETALLHOTELES]

AS
BEGIN
	SELECT *
	FROM LOS_NULL.Hotel 
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GET_NACIONALIDADES]    Script Date: 11/11/2014 21:57:09 ******/
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
ALTER PROCEDURE [LOS_NULL].[GET_TIPODOC]
AS
BEGIN
	SELECT *
	FROM LOS_NULL.TipoDoc N	
END
*/
GO
/****** Object:  Table [LOS_NULL].[FuncionalidadXRol]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[FuncionalidadXRol](
	[ID_Funcionalidad] [numeric](18, 0) NOT NULL,
	[ID_Rol] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_FuncionalidadXRol] PRIMARY KEY CLUSTERED 
(
	[ID_Funcionalidad] ASC,
	[ID_Rol] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLFUNCS]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETALLFUNCS]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [LOS_NULL].Funcionalidad
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLCONSUMIBLES]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETALLCONSUMIBLES]

AS
BEGIN
	SELECT *
	FROM LOS_NULL.Consumible
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETUSUARIO]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETUSUARIO]
	@ID_USUARIO varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [LOS_NULL].Usuario U WHERE U.ID_Usuario = @ID_USUARIO
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETTIPOHABITACIONPORCANTIDAD]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
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
/****** Object:  StoredProcedure [LOS_NULL].[GETTIPOHABITACION]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETTIPOHABITACION]
	@CODIGOTIPO NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [LOS_NULL].TipoHabitacion T WHERE T.Codigo_Tipo = @CODIGOTIPO
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETTARJETA]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETTARJETA]
	@NUMERO NUMERIC(18,0),
	@TIPO NVARCHAR(255)
	
AS
BEGIN
	
	SELECT *
	FROM LOS_NULL.Tarjeta T
	WHERE T.Numero =@NUMERO AND T.Tipo = @TIPO
	
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETROL]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETROL]
	@ID_ROL	numeric(18,0)

AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [LOS_NULL].Rol WHERE ID_Rol=@ID_ROL
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETREGIMEN]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETREGIMEN]
	@ID_REGIMEN NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [LOS_NULL].Regimen R WHERE R.ID_Regimen = @ID_REGIMEN
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETPRECIOCONSUMIBLE]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETPRECIOCONSUMIBLE]
	@CONSUMIBLE NVARCHAR(255)
AS
BEGIN
	SELECT TOP 1(C.Precio)
	FROM LOS_NULL.Consumible C
	WHERE C.Descripcion = @CONSUMIBLE
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETNUMEROCONSUMIBLE]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETNUMEROCONSUMIBLE]
	@CONSUMIBLE NVARCHAR(255)
AS
BEGIN
	SELECT TOP 1(C.ID_Consumible)
	FROM LOS_NULL.Consumible C
	WHERE C.Descripcion = @CONSUMIBLE
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETIDTIPOHABITACION]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETIDTIPOHABITACION]
	@DESCRIPCION nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 1 T.Codigo_Tipo FROM [LOS_NULL].TipoHabitacion T WHERE T.Descripcion = @DESCRIPCION
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETID_ROL]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETID_ROL]
	@NOMBRE_ROL varchar(50)
	
AS 
BEGIN
	
	SELECT ID_Rol FROM LOS_NULL.Rol WHERE Nombre_Rol=@NOMBRE_ROL

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETID_FUNC]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETID_FUNC]
	@NOMBRE_FUNC varchar(50)
	
AS 
BEGIN
	
	SELECT ID_Funcionalidad FROM LOS_NULL.Funcionalidad WHERE Nombre_Func=@NOMBRE_FUNC

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETHOTEL]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETHOTEL]
	@ID_HOTEL NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [LOS_NULL].Hotel H WHERE H.ID_Hotel = @ID_HOTEL
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETDESCRIPCIONTIPOHABITACION]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETDESCRIPCIONTIPOHABITACION]

AS
BEGIN
	SELECT TH.Descripcion
	FROM LOS_NULL.TipoHabitacion TH
	GROUP BY TH.Descripcion
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETDATOSPERS_USER]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETDATOSPERS_USER]
	@ID_USER varchar(50)
	
AS 
BEGIN
	
	SELECT * FROM LOS_NULL.Persona WHERE Usuario=@ID_USER

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETCONSUMIBLE]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETCONSUMIBLE]
	@ID_CONSUMIBLE NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [LOS_NULL].Consumible C WHERE C.ID_Consumible = @ID_CONSUMIBLE
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETESTADORESERVA]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETESTADORESERVA]
	@ID_ESTADO NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [LOS_NULL].EstadoReserva E WHERE E.ID_Estado = @ID_ESTADO
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLREGIMENES]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETALLREGIMENES]

AS
BEGIN
	SELECT *
	FROM LOS_NULL.Regimen	
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLUSUARIOS]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETALLUSUARIOS]
	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [LOS_NULL].Usuario 
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLTIPOHABITACION]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETALLTIPOHABITACION]

AS
BEGIN
	SELECT TH.Codigo_Tipo,TH.Capacidad,TH.Descripcion,TH.Porcentual
	FROM LOS_NULL.TipoHabitacion TH
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLTARJETAS]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETALLTARJETAS]
	
AS
BEGIN
	
	SELECT *
	FROM LOS_NULL.Tarjeta
	
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLROLES]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETALLROLES]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [LOS_NULL].Rol 
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLROL_USER]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETALLROL_USER]
	@ID_User varchar(50)
	
AS 
BEGIN
	
	SELECT R.Nombre_Rol, R.Baja_Logica FROM LOS_NULL.UsuarioXRol UR JOIN LOS_NULL.Rol R ON (UR.ID_Rol = R.ID_Rol)
	WHERE ID_Usuario=@ID_User

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLREGIMENPORHOTEL]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETALLREGIMENPORHOTEL]
	@ID_HOTEL NUMERIC(18,0)
AS
BEGIN
	
	SELECT R.ID_Regimen,R.Descripcion,R.Estado,R.Precio
	FROM LOS_NULL.Regimen R JOIN LOS_NULL.RegimenXHotel RH ON (R.ID_Regimen = RH.ID_Regimen)
	WHERE RH.ID_Hotel = @ID_HOTEL
	GROUP BY R.ID_Regimen,R.Descripcion,R.Estado,R.Precio
	
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLUBICACIONESHABITACION]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETALLUBICACIONESHABITACION]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT H.Frente
	FROM LOS_NULL.Habitacion H
	GROUP BY H.Frente
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETHABITACION]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETHABITACION]
	@ID_HABITACION NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [LOS_NULL].Habitacion H WHERE H.ID_Habitacion = @ID_HABITACION
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETCLIENTE]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETCLIENTE]
	@ID_CLIENTE NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [LOS_NULL].Cliente C WHERE C.Nro_Cliente = @ID_CLIENTE
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETHABITACIONPORHOTELYHABITACION]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETHABITACIONPORHOTELYHABITACION]
	@ID_HOTEL NUMERIC(18,0),
	@NUMERO NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * 
	FROM [LOS_NULL].[Habitacion] H 
	WHERE H.ID_Hotel = @ID_HOTEL AND H.Numero = @NUMERO
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETPOSICIONHABITACION]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETPOSICIONHABITACION]

AS
BEGIN
	SELECT H.Frente
	FROM LOS_NULL.Habitacion H
	GROUP BY H.Frente
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETRESERVA]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETRESERVA]
	@COD_RESERVA NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [LOS_NULL].Reserva R WHERE R.Codigo_Reserva = @COD_RESERVA
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETREGIMENFALTANTESHOTEL]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETREGIMENFALTANTESHOTEL]
	@ID_HOTEL NUMERIC(18,0)
AS
BEGIN
	
	SELECT R.ID_Regimen,R.Descripcion,R.Estado,R.Precio
	FROM LOS_NULL.Regimen R 
	WHERE (SELECT COUNT(RH.ID_Regimen) FROM LOS_NULL.RegimenXHotel RH WHERE RH.ID_Regimen = R.ID_Regimen AND RH.ID_Hotel = @ID_HOTEL ) = 0
	GROUP BY R.ID_Regimen,R.Descripcion,R.Estado,R.Precio
	
END

-- ================================================
-- Template generated from Template Explorer using:
-- ALTER Procedure (New Menu).SQL
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
/****** Object:  StoredProcedure [LOS_NULL].[GETALLCLIENTES]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
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
/****** Object:  StoredProcedure [LOS_NULL].[GETALLHOTELESPAISES]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETALLHOTELESPAISES]
	@ADMINISTRADOR NVARCHAR(255)
AS
BEGIN
	
	SELECT H.Pais
	FROM LOS_NULL.Hotel H JOIN LOS_NULL.UsuarioXHotel UH ON (H.ID_Hotel = UH.ID_Hotel)
	WHERE UH.ID_Usuario = @ADMINISTRADOR
	GROUP BY H.Pais
	
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLHOTELESCIUDADES]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETALLHOTELESCIUDADES]
	@ADMINISTRADOR NVARCHAR(255)
AS
BEGIN
	
	SELECT H.Ciudad
	FROM LOS_NULL.Hotel H JOIN LOS_NULL.UsuarioXHotel UH ON (H.ID_Hotel = UH.ID_Hotel)
	WHERE UH.ID_Usuario = @ADMINISTRADOR
	GROUP BY H.Ciudad
	
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLHOTELESADMINISTRADOR]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETALLHOTELESADMINISTRADOR]
	@ADMINISTRADOR NVARCHAR(255)
AS
BEGIN
		SELECT *
		FROM LOS_NULL.Hotel H JOIN LOS_NULL.UsuarioXHotel UH ON (H.ID_Hotel = UH.ID_Hotel)
		WHERE UH.ID_Usuario = @ADMINISTRADOR
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLHOTEL_USER]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETALLHOTEL_USER]
	@ID_User varchar(50)
	
AS 
BEGIN
	
	SELECT ID_Hotel FROM LOS_NULL.UsuarioXHotel WHERE ID_Usuario=@ID_User

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLHABITACIONPORHOTEL]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETALLHABITACIONPORHOTEL]
	@ID_Hotel_Habitaciones numeric(18,0)
AS
BEGIN

	SELECT *
	FROM LOS_NULL.Habitacion H 
	WHERE H.ID_Hotel = @ID_Hotel_Habitaciones
	ORDER BY H.Numero
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLHABITACION]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETALLHABITACION]

AS
BEGIN

	SELECT *
	FROM LOS_NULL.Habitacion H 
	ORDER BY H.Numero
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLFUNCXROL]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETALLFUNCXROL]
	@ID_ROL	numeric(18,0)

AS
BEGIN
	SET NOCOUNT ON;
	select F.ID_Funcionalidad, F.Nombre_Func from LOS_NULL.Rol R JOIN LOS_NULL.FuncionalidadXRol FR ON (R.ID_Rol=FR.ID_Rol)
				JOIN LOS_NULL.Funcionalidad F ON (FR.ID_Funcionalidad = F.ID_Funcionalidad)
				
		  WHERE R.ID_Rol=@ID_ROL
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[FILTRARHOTELESPORCAMPOS]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[FILTRARHOTELESPORCAMPOS]
	@ADMINISTRADOR NVARCHAR(255),
	@CANTIDAD_ESTRELLAS NUMERIC(18,0),
	@CIUDAD NVARCHAR(255),
	@PAIS NVARCHAR(255)
AS
BEGIN

	SELECT H.ID_Hotel,H.Calle,H.Cant_Estrellas,H.Ciudad,H.Fecha_Creacion,H.Nro_Calle,H.Pais,H.Recarga_Estrella,H.Telefono
	FROM LOS_NULL.Hotel H JOIN LOS_NULL.UsuarioXHotel UH ON (H.ID_Hotel = UH.ID_Hotel)
	WHERE @ADMINISTRADOR = UH.ID_Usuario
	AND (H.Ciudad = @CIUDAD OR @CIUDAD IS NULL OR @CIUDAD = '')
	AND (H.Cant_Estrellas = @CANTIDAD_ESTRELLAS OR @CANTIDAD_ESTRELLAS IS NULL OR @CANTIDAD_ESTRELLAS = 0)
	AND (H.Pais = @PAIS OR @PAIS IS NULL OR @PAIS = '')
	
END
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[CANTIDAD_DIAS_SIN_SERVICIO]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [LOS_NULL].[CANTIDAD_DIAS_SIN_SERVICIO]
(
	@ID_HOTEL numeric (18,0),
	@FECHA datetime
)

RETURNS numeric (18,0)

AS
BEGIN
	
	RETURN
	(
	SELECT SUM (DATEDIFF(day,Fecha_Inicio,LOS_NULL.MENOR_FECHA(Fecha_Fin,@FECHA))) FROM   
		(SELECT Id_Hotel FROM LOS_NULL.Hotel WHERE Id_Hotel = @ID_HOTEL) HO 
		JOIN LOS_NULL.BajaTemporalHotel BH ON (HO.Id_Hotel = BH.Id_Hotel)
		WHERE DATEDIFF (QUARTER,Fecha_Inicio,@FECHA)=0
	)

	/*--utilizo la funcion MENOR_FECHA para lo siguiente:
	Si por ejemplo:
	Fecha_Inicio_de_baja=11/3/2014
	Fecha_Fin_de_baja=2/4/2014
	Entonces, la fecha de fin supera el primer trimestre de consulta (que termina el 31/3/2014)
	Utilizando esta funcion, me va a devolver la cantidad de dias inhabilitados desde inicio hasta la fecha limite del fin del trimestre
	Por ahi esta demás, pero me parece logico
	
	*/
	
END
GO
/****** Object:  Table [LOS_NULL].[CancelacionReserva]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[CancelacionReserva](
	[ID_Cancelacion] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Motivo] [nvarchar](255) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Usuario] [nvarchar](255) NOT NULL,
	[Codigo_Reserva] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_CancelacionReserva] PRIMARY KEY CLUSTERED 
(
	[ID_Cancelacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [LOS_NULL].[DAMEMENORFECHA]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[DAMEMENORFECHA] 

AS
BEGIN
	
	SELECT TOP 1 (YEAR(R.Fecha_Inicio)) AÑO
	FROM LOS_NULL.Reserva R
	ORDER BY R.Fecha_Inicio ASC
	
END
GO
/****** Object:  Table [LOS_NULL].[Estadia]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Estadia](
	[ID_Estadia] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Fecha_Inicio] [datetime] NOT NULL,
	[Cant_Noches] [numeric](18, 0) NOT NULL,
	[Codigo_Reserva] [numeric](18, 0) NOT NULL,
	[Usuario_Ingreso] [nvarchar](255) NULL,
	[Usuario_Egreso] [nvarchar](255) NULL,
	[Cant_Noches_Estadia] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Estadia] PRIMARY KEY CLUSTERED 
(
	[ID_Estadia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [LOS_NULL].[ELIMINARUSER_DE_HOTEL]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [LOS_NULL].[ELIMINARREGIMENHOTEL]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[ELIMINARREGIMENHOTEL] 
	@ID_HOTEL NUMERIC(18,0),
	@DESCRIPCION NVARCHAR(255)
AS
BEGIN
	DELETE FROM LOS_NULL.RegimenXHotel
	WHERE ID_Hotel = @ID_HOTEL AND ID_Regimen = LOS_NULL.ID_REGIMEN(@DESCRIPCION)	

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[ELIMINAROL_DE_USER]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [LOS_NULL].[ELIMINARFUNC_DE_ROL]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  UserDefinedFunction [LOS_NULL].[DAMEVALORHABITACION]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [LOS_NULL].[DAMEVALORHABITACION] 
(
	@ID_HOTEL NUMERIC(18,0),
	@NUMERO_HABITACION NUMERIC(18,0),
	@ID_REGIMEN NUMERIC(18,0)
)
RETURNS NUMERIC(18,2)
AS
BEGIN

	RETURN
	(
	SELECT (H.Recarga_Estrella+R.Precio)*TH.Capacidad+TH.Porcentual*(H.Recarga_Estrella+R.Precio)*TH.Capacidad/100
	FROM LOS_NULL.Hotel H 
		JOIN LOS_NULL.Habitacion HA ON (H.ID_Hotel = HA.ID_Hotel)
		JOIN LOS_NULL.TipoHabitacion TH ON (HA.Codigo_Tipo = TH.Codigo_Tipo)
		JOIN LOS_NULL.RegimenXHotel RH ON (RH.ID_Hotel = H.ID_Hotel)
		JOIN LOS_NULL.Regimen R ON (R.ID_Regimen = RH.ID_Regimen)
	WHERE H.ID_Hotel = @ID_HOTEL AND RH.ID_Regimen = @ID_REGIMEN AND HA.Numero = @NUMERO_HABITACION
	)

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[BAJAHABITACION]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[BAJAHABITACION]
	@ID_HABITACION numeric(18,0)
AS
BEGIN
		DELETE FROM LOS_NULL.Habitacion 
		WHERE ID_Habitacion = @ID_HABITACION
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[ALTAHOTEL]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[ALTAHOTEL]
	@ADMINISTRADOR NVARCHAR(255),
	@CALLE NVARCHAR(255),
	@RECARGA_ESTRELLA NUMERIC(18,2),
	@TELEFONO NVARCHAR(25),
	@NRO_CALLE NUMERIC(18,0),
	@CANTIDAD_ESTRELLAS NUMERIC(18,0),
	@CIUDAD NVARCHAR(255),
	@PAIS NVARCHAR(255),
	@FECHA_CREACION DATETIME
AS
BEGIN
	
	INSERT INTO LOS_NULL.Hotel (Calle,Cant_Estrellas,Ciudad,Nro_Calle,Pais,Fecha_Creacion,Recarga_Estrella,Telefono)
	VALUES (@CALLE,@CANTIDAD_ESTRELLAS,@CIUDAD,@NRO_CALLE,@PAIS,@FECHA_CREACION,@RECARGA_ESTRELLA,@TELEFONO)
	
	DECLARE @IDENT NUMERIC(18,0)
	
	SET @IDENT = @@IDENTITY
	
	INSERT INTO LOS_NULL.UsuarioXHotel(ID_Hotel,ID_Usuario)
	VALUES(@IDENT,@ADMINISTRADOR)

	SELECT *
	FROM LOS_NULL.Hotel H
	WHERE H.ID_Hotel = @IDENT
			
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[AGREGARROL_A_USER]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [LOS_NULL].[AGREGARHOTEL_A_USER]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [LOS_NULL].[AGREGARFUNC_A_ROL]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [LOS_NULL].[ClienteNuevo]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[ClienteNuevo](
@id_nacionalidad numeric(18, 0),
--@id_tipo_doc numeric(18, 0), 
@nro_pasaporte numeric(18, 0), 
@apellido nvarchar(255), 
@nombre nvarchar(255),
@fecha_nac datetime,
@mail nvarchar(255),
@dom_calle nvarchar(255),
@nro_calle numeric(18, 0),
@piso numeric(18, 0),
@depto nvarchar(255),
@baja_logica bit
)
AS
BEGIN
		DECLARE @MENSAJE nvarchar(255);
	
	IF EXISTS (SELECT C.Nro_Pasaporte FROM LOS_NULL.Cliente C WHERE C.Nro_Pasaporte = @nro_pasaporte)
	BEGIN
		SET @MENSAJE = 'El numero de documento ya se encuentra registrado'
		SELECT @MENSAJE
		RETURN
	END
	ELSE IF EXISTS (SELECT C.Mail FROM LOS_NULL.Cliente C WHERE C.Mail = @mail)
	BEGIN
		SET @MENSAJE = 'El mail ya se encuentra registrado'
		SELECT @MENSAJE
		RETURN
	END
	ELSE
		INSERT INTO LOS_NULL.Cliente(
				id_nacionalidad,
				--id_tipo_doc, 
				nro_pasaporte, 
				apellido, 
				nombre,
				fecha_nac,
				mail,
				dom_calle,
				nro_calle,
				piso,
				depto,
				baja_logica)
		VALUES (@id_nacionalidad,
				--@id_tipo_doc, 
				@nro_pasaporte, 
				@apellido, 
				@nombre,
				@fecha_nac,
				@mail,
				@dom_calle,
				@nro_calle,
				@piso,
				@depto,
				@baja_logica)
				
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[MODIFICARRESERVA]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[MODIFICARRESERVA]
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
/****** Object:  StoredProcedure [LOS_NULL].[MIGRAR_HABITACIONES]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[MIGRAR_HABITACIONES]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	
	INSERT INTO LOS_NULL.Habitacion(ID_Hotel,Frente,Numero,Piso,Codigo_Tipo,Descripcion)
	
	SELECT LOS_NULL.ID_HOTEL(M.Hotel_Ciudad,M.Hotel_Calle,M.Hotel_Nro_Calle,M.Hotel_CantEstrella,M.Hotel_Recarga_Estrella)
	,M.Habitacion_Frente,M.Habitacion_Numero,M.Habitacion_Piso,M.Habitacion_Tipo_Codigo,'Migradas de BD Original'
	FROM gd_esquema.Maestra M
	GROUP BY LOS_NULL.ID_HOTEL(M.Hotel_Ciudad,M.Hotel_Calle,M.Hotel_Nro_Calle,M.Hotel_CantEstrella,M.Hotel_Recarga_Estrella)
	,M.Habitacion_Frente,M.Habitacion_Numero,M.Habitacion_Piso,M.Habitacion_Tipo_Codigo
	ORDER BY LOS_NULL.ID_HOTEL(M.Hotel_Ciudad,M.Hotel_Calle,M.Hotel_Nro_Calle,M.Hotel_CantEstrella,M.Hotel_Recarga_Estrella)


END
GO
/****** Object:  StoredProcedure [LOS_NULL].[modificarCliente]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[modificarCliente]
(	
	@nro_cliente numeric(18, 0),
	@id_nacionalidad numeric(18, 0),
	--@id_tipo_doc numeric(18, 0), 
	@nro_pasaporte numeric(18, 0), 
	@apellido nvarchar(255), 
	@nombre nvarchar(255),
	@fecha_nac datetime,
	@mail nvarchar(255),
	@dom_calle nvarchar(255),
	@nro_calle numeric(18, 0),
	@piso numeric(18, 0),
	@depto nvarchar(255),
	@baja_logica bit
)
AS
BEGIN
	DECLARE @MENSAJE nvarchar(255);
	
	IF EXISTS (SELECT C.Nro_Pasaporte FROM LOS_NULL.Cliente C WHERE C.Nro_Pasaporte = @nro_pasaporte)
	BEGIN
		SET @MENSAJE = 'El numero de documento ya se encuentra registrado'
		SELECT @MENSAJE
		RETURN
	END
	ELSE IF EXISTS (SELECT C.Mail FROM LOS_NULL.Cliente C WHERE C.Mail = @mail)
	BEGIN
		SET @MENSAJE = 'El mail ya se encuentra registrado'
		SELECT @MENSAJE
		RETURN
	END
	ELSE
		
		UPDATE LOS_NULL.Cliente
		SET 
			ID_Nacionalidad=@id_nacionalidad,
			Nro_Pasaporte=@nro_pasaporte,
			nombre=@nombre, 
			apellido=@apellido,
			fecha_nac=@fecha_nac, 
			dom_calle=@dom_calle, 
			piso=@piso,
			depto=@depto, 
			mail=@mail,
			Baja_Logica=@baja_logica
			
		WHERE Nro_Cliente=@nro_cliente

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[MIGRAR_USUARIOSROLESFUNCIONALIDADES]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[MIGRAR_USUARIOSROLESFUNCIONALIDADES]

AS
BEGIN
	--INSERTAR FUNCIONALIDADES
	INSERT INTO LOS_NULL.FUNCIONALIDAD (Nombre_Func) VALUES ('abmRol');
	INSERT INTO LOS_NULL.FUNCIONALIDAD (Nombre_Func) VALUES ('abmUsuario');
	INSERT INTO LOS_NULL.FUNCIONALIDAD (Nombre_Func) VALUES ('abmClientes');
	INSERT INTO LOS_NULL.FUNCIONALIDAD (Nombre_Func) VALUES ('abmHotel');
	INSERT INTO LOS_NULL.FUNCIONALIDAD (Nombre_Func) VALUES ('abmHabitacion');
	INSERT INTO LOS_NULL.FUNCIONALIDAD (Nombre_Func) VALUES ('abmRegimenEstadia');
	INSERT INTO LOS_NULL.FUNCIONALIDAD (Nombre_Func) VALUES ('generarReserva');
	INSERT INTO LOS_NULL.FUNCIONALIDAD (Nombre_Func) VALUES ('cancelarReserva');
	INSERT INTO LOS_NULL.FUNCIONALIDAD (Nombre_Func) VALUES ('registrarEstadia');
	INSERT INTO LOS_NULL.FUNCIONALIDAD (Nombre_Func) VALUES ('registrarConsumible');
	INSERT INTO LOS_NULL.FUNCIONALIDAD (Nombre_Func) VALUES ('facturarPublicaciones');
	INSERT INTO LOS_NULL.FUNCIONALIDAD (Nombre_Func) VALUES ('listadoEstadistico');
	--INSERTAR ROLES
	INSERT INTO LOS_NULL.ROL (Nombre_Rol) VALUES ('Administrador');
	INSERT INTO LOS_NULL.ROL (Nombre_Rol) VALUES ('Recepcionista');
	INSERT INTO LOS_NULL.ROL (Nombre_Rol) VALUES ('Guest');
	--INSERTAR FUNCIONALIDADESXROL
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,1)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,2)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,3)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,4)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,5)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,6)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,7)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,8)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,9)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,10)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,11)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (1,12)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,3)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,7)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,8)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,9)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,10)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,11)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (2,12)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (3,7)
	INSERT INTO LOS_NULL.FUNCIONALIDADXROL (ID_ROL,ID_FUNCIONALIDAD) VALUES (3,8)
	
	--INSERT INTO LOS_NULL.Usuario (ID_Usuario,Password) VALUES ('SuperUser','gd2014')
	INSERT INTO LOS_NULL.Usuario (ID_Usuario,Password) VALUES ('SuperUser','8623f73bbb01f6c2eb02a97f652301f6a59a1be8c75da5266bc3475c9e1e569d') 
	INSERT INTO LOS_NULL.UsuarioXRol (ID_Rol,ID_Usuario) VALUES (1,'SuperUser')
		INSERT INTO LOS_NULL.Persona (Nro_Documento,Tipo_Documento,Usuario,Apellido,Nombre,Mail,Direccion,Telefono,Fecha_Nac,Numero,Piso,Depto,Localidad)
	VALUES (0,'DNI','SuperUser','S','U','SuperUser@Gmail.com','Calle Falsa 123','123-2312',GETDATE(),0,0,'1A','Springfield')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (1,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (2,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (3,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (4,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (5,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (6,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (7,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (8,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (9,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (10,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (11,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (12,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (13,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (14,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (15,'SuperUser')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (16,'SuperUser')

	--INSERT INTO LOS_NULL.Usuario (ID_Usuario,Password) VALUES ('Juan123','gd2014')
	INSERT INTO LOS_NULL.Usuario (ID_Usuario,Password) VALUES ('Juan123','8623f73bbb01f6c2eb02a97f652301f6a59a1be8c75da5266bc3475c9e1e569d')
	INSERT INTO LOS_NULL.UsuarioXRol (ID_Rol,ID_Usuario) VALUES (2,'Juan123')
	INSERT INTO LOS_NULL.Persona (Nro_Documento,Tipo_Documento,Usuario,Apellido,Nombre,Mail,Direccion,Telefono,Fecha_Nac,Numero,Piso,Depto,Localidad) 
	VALUES (1212121212,'DNI','Juan123','Asd','Juan','Juan123@Gmail.com','Calle Falsa 123','123-2312',GETDATE(),0,0,'1A','Springfield')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (3,'Juan123')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (5,'Juan123')
	--Inserto usuario pedido en el TP
	--INSERT INTO LOS_NULL.Usuario (ID_Usuario,Password) VALUES ('admin','w23e')
	INSERT INTO LOS_NULL.Usuario (ID_Usuario,Password) VALUES ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7')
	INSERT INTO LOS_NULL.Persona (Nro_Documento,Tipo_Documento,Usuario,Apellido,Nombre,Mail,Direccion,Telefono,Fecha_Nac,Numero,Piso,Depto,Localidad) 
	 VALUES (1,'DNI','admin','ad','min','admin@Gmail.com','Avendida siempre viva','555-3535',GETDATE(),0,0,'1A','Springfield')
	INSERT INTO LOS_NULL.UsuarioXRol (ID_Rol,ID_Usuario) VALUES (1,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (1,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (2,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (3,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (4,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (5,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (6,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (7,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (8,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (9,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (10,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (11,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (12,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (13,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (14,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (15,'admin')
	INSERT INTO LOS_NULL.UsuarioXHotel (ID_Hotel,ID_Usuario) VALUES (16,'admin')
	
	INSERT INTO LOS_NULL.Usuario(ID_Usuario,Password) VALUES ('Guest','')
	INSERT INTO LOS_NULL.UsuarioXRol(ID_Usuario,ID_Rol) VALUES ('Guest',3)
	
	

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[INSERTARRESERVA]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[INSERTARRESERVA]
	--@ID_HABITACION NUMERIC(18,0),
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
	
	--INSERT INTO LOS_NULL.ReservaXHabitacion(ID_Habitacion,ID_Reserva)
	--VALUES (@ID_HABITACION,@RETORNO_RESERVA)
	
	SELECT @RETORNO_RESERVA
	
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[INSERTARNUEVOREGIMENHOTEL]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[INSERTARNUEVOREGIMENHOTEL]
	@ID_HOTEL NUMERIC(18,0),
	@DESCRIPCION NVARCHAR(255)
AS
BEGIN
	
	DECLARE @ID_REGIMEN NUMERIC(18,0)
	SET @ID_REGIMEN = LOS_NULL.ID_REGIMEN(@DESCRIPCION)
	
	IF (@ID_REGIMEN IS NOT NULL)
	BEGIN
		INSERT INTO LOS_NULL.RegimenXHotel(ID_Hotel,ID_Regimen)
		VALUES(@ID_HOTEL,@ID_REGIMEN)
	END
		
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[INSERTARHABITACION]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[INSERTARHABITACION]	
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
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[ID_CLIENTE]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [LOS_NULL].[ID_CLIENTE] 
(
	@Nacionalidad NVARCHAR(255),
	@Nro_Pasaporte NUMERIC(18,0),
	@Apellido NVARCHAR(255),
	@Nombre NVARCHAR(255)
)
RETURNS NUMERIC(18,0)
AS
BEGIN

	RETURN 
	(
	SELECT TOP 1 C.Nro_Cliente
	FROM LOS_NULL.Cliente C
	WHERE		C.Nro_Pasaporte = @Nro_Pasaporte
			AND LOS_NULL.ID_NACIONALIDAD(@Nacionalidad) = C.ID_Nacionalidad 
			AND C.Apellido = @Apellido
			AND C.Nombre = @Nombre
	)

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETVALORHABITACION]    Script Date: 11/11/2014 21:57:10 ******/
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
/****** Object:  UserDefinedFunction [LOS_NULL].[ID_HABITACION]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [LOS_NULL].[ID_HABITACION]
(
	@ID_HOTEL numeric(18,0),
	@Numero numeric(18,0),
	@Piso numeric(18,0),
	@Frente nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN

	RETURN 
	(
	SELECT H.ID_Habitacion
	FROM LOS_NULL.Habitacion H
	WHERE H.ID_Hotel = @ID_HOTEL 
	AND H.Numero = @Numero
	AND H.Piso = @Piso
	AND H.Frente = @Frente
	)

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[LISTADO_CLIENTES_POR_CAMPOS]    Script Date: 11/11/2014 21:57:10 ******/
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
	AND (UPPER(C.Apellido) LIKE '%'+@APELLIDO OR @APELLIDO+'%' IS NULL OR @APELLIDO = '')
	AND (UPPER(C.Nombre) LIKE '%'+@NOMBRE+'%' OR @NOMBRE IS NULL OR @NOMBRE = '')
	AND (UPPER(C.Mail) LIKE '%'+@EMAIL+'%' OR @EMAIL IS NULL OR @EMAIL = '')

END



SET ANSI_NULLS ON
GO
/****** Object:  Table [LOS_NULL].[ReservaXHabitacion]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[ReservaXHabitacion](
	[ID_Habitacion] [numeric](18, 0) NOT NULL,
	[ID_Reserva] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_ReservaXHabitacion] PRIMARY KEY CLUSTERED 
(
	[ID_Habitacion] ASC,
	[ID_Reserva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LOS_NULL].[ReservaXCliente]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[ReservaXCliente](
	[Codigo_Reserva] [numeric](18, 0) NOT NULL,
	[Nro_Cliente] [numeric](18, 0) NOT NULL,
	[Flag_Reserva] [bit] NOT NULL,
 CONSTRAINT [PK_ReservaXCliente_1] PRIMARY KEY CLUSTERED 
(
	[Codigo_Reserva] ASC,
	[Nro_Cliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [LOS_NULL].[MIGRAR_REGIMENES]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[MIGRAR_REGIMENES]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	--
	INSERT INTO LOS_NULL.Regimen (Precio,Descripcion)
	--
	SELECT M.Regimen_Precio,M.Regimen_Descripcion
	FROM gd_esquema.Maestra M
	GROUP BY M.Regimen_Precio,M.Regimen_Descripcion
	ORDER BY M.Regimen_Precio,M.Regimen_Descripcion
	--
	--
	INSERT INTO LOS_NULL.RegimenXHotel (ID_Hotel,ID_Regimen)
	--
	SELECT H.ID_Hotel,LOS_NULL.ID_REGIMEN(M.Regimen_Descripcion)
	FROM LOS_NULL.Hotel H JOIN gd_esquema.Maestra M ON 
	(
	H.Calle = M.Hotel_Calle AND
	H.Cant_Estrellas = M.Hotel_CantEstrella AND
	H.Ciudad = M.Hotel_Ciudad AND
	H.Nro_Calle = M.Hotel_Nro_Calle AND
	H.Recarga_Estrella = M.Hotel_Recarga_Estrella
	)
	GROUP BY H.ID_Hotel,LOS_NULL.ID_REGIMEN(M.Regimen_Descripcion)
	ORDER BY H.ID_Hotel,LOS_NULL.ID_REGIMEN(M.Regimen_Descripcion)
	--
	
	
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[MODIFICARHABITACION]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[MODIFICARHABITACION]	
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
GO
/****** Object:  StoredProcedure [LOS_NULL].[QUITARRESERVAXHABITACION]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
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
/****** Object:  StoredProcedure [LOS_NULL].[TOP5HOTELESFUERADESERVICIO]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[TOP5HOTELESFUERADESERVICIO]
	@FECHA datetime
	
AS
BEGIN
	
	SELECT * FROM
		(SELECT TOP 5 HO.ID_HOTEL,
			LOS_NULL.CANTIDAD_DIAS_SIN_SERVICIO(HO.Id_Hotel,@FECHA) Dias_Inhabilitado
		FROM LOS_NULL.Hotel HO
		ORDER BY Dias_Inhabilitado DESC) TAB
	WHERE TAB.Dias_Inhabilitado IS NOT NULL

    
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[UPDATESTATUS_NOSHOW]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [LOS_NULL].[Item_Factura]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Item_Factura](
	[ID_Item_Factura] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Cantidad] [numeric](18, 0) NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
	[Nro_Factura] [numeric](18, 0) NULL,
	[ID_Estadia] [numeric](18, 0) NOT NULL,
	[Codigo_Consumible] [numeric](18, 0) NULL,
	[Detalle] [nvarchar](255) NULL,
 CONSTRAINT [PK_Item_Factura] PRIMARY KEY CLUSTERED 
(
	[ID_Item_Factura] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [LOS_NULL].[MIGRAR_ESTADIAS]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[MIGRAR_ESTADIAS]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	INSERT INTO LOS_NULL.Estadia(Codigo_Reserva,Cant_Noches,Fecha_Inicio,Usuario_Egreso,Usuario_Ingreso,Cant_Noches_Estadia)
	
	SELECT  M.Reserva_Codigo,M.Estadia_Cant_Noches,M.Estadia_Fecha_Inicio,'SuperUser','SuperUser',M.Estadia_Cant_Noches
	FROM gd_esquema.Maestra M
	WHERE M.Estadia_Cant_Noches IS NOT NULL AND M.Estadia_Fecha_Inicio IS NOT NULL
	GROUP BY M.Reserva_Codigo,M.Estadia_Cant_Noches,M.Estadia_Fecha_Inicio
	ORDER BY M.Reserva_Codigo
  
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[INSERTARESTADIA]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[INSERTARESTADIA]
	@FECHA date,
	@NOCHES numeric(18,0),
	@RES numeric (18,0),
	@USER varchar(50)
	
AS
BEGIN

	INSERT INTO LOS_NULL.Estadia (Fecha_Inicio,Cant_Noches,Codigo_Reserva,Usuario_Ingreso,Usuario_Egreso,Cant_Noches_Estadia) 
	VALUES (@FECHA,@NOCHES,@RES,@USER,null,null)
	
	UPDATE LOS_NULL.Reserva
	SET ID_Estado=6 WHERE Codigo_Reserva=@RES

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[MIGRAR_CLIENTES]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[MIGRAR_CLIENTES]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	INSERT INTO LOS_NULL.Cliente (ID_Nacionalidad,Nro_Pasaporte,Apellido,Nombre,Fecha_nac,Mail,
	Dom_Calle,Nro_Calle,Piso,Depto,Duplicado_Pasaporte)
	
	(
	SELECT LOS_NULL.ID_NACIONALIDAD(M.Cliente_Nacionalidad),M.Cliente_Pasaporte_Nro,M.Cliente_Apellido,M.Cliente_Nombre,M.Cliente_Fecha_Nac,
		M.Cliente_Mail,M.Cliente_Dom_Calle,M.Cliente_Nro_Calle,M.Cliente_Piso,M.Cliente_Depto,0		
	FROM gd_esquema.Maestra M
	WHERE (SELECT COUNT(*) FROM gd_esquema.Maestra M1
	   WHERE M1.Cliente_Apellido != M.Cliente_Apellido
		AND M1.Cliente_Nombre != M.Cliente_Nombre
		AND M1.Cliente_Mail != M.Cliente_Mail
		AND M1.Cliente_Pasaporte_Nro = M.Cliente_Pasaporte_Nro ) < 1
	GROUP BY LOS_NULL.ID_NACIONALIDAD(M.Cliente_Nacionalidad),M.Cliente_Pasaporte_Nro,M.Cliente_Apellido,M.Cliente_Nombre,M.Cliente_Fecha_Nac,
		M.Cliente_Mail,M.Cliente_Dom_Calle,M.Cliente_Nro_Calle,M.Cliente_Piso,M.Cliente_Depto
	)UNION(
	SELECT LOS_NULL.ID_NACIONALIDAD(M.Cliente_Nacionalidad),M.Cliente_Pasaporte_Nro,M.Cliente_Apellido,M.Cliente_Nombre,M.Cliente_Fecha_Nac,
		M.Cliente_Mail,M.Cliente_Dom_Calle,M.Cliente_Nro_Calle,M.Cliente_Piso,M.Cliente_Depto,1		
	FROM gd_esquema.Maestra M
	WHERE 
	(SELECT COUNT(*) FROM gd_esquema.Maestra M1
	   WHERE M1.Cliente_Apellido != M.Cliente_Apellido
	   AND M1.Cliente_Nombre != M.Cliente_Nombre
	   AND M1.Cliente_Mail != M.Cliente_Mail
	   AND M1.Cliente_Pasaporte_Nro = M.Cliente_Pasaporte_Nro ) 
	   >= 1
	GROUP BY LOS_NULL.ID_NACIONALIDAD(M.Cliente_Nacionalidad),M.Cliente_Pasaporte_Nro,M.Cliente_Apellido,M.Cliente_Nombre,M.Cliente_Fecha_Nac,
		M.Cliente_Mail,M.Cliente_Dom_Calle,M.Cliente_Nro_Calle,M.Cliente_Piso,M.Cliente_Depto
	)											
	ORDER BY M.Cliente_Pasaporte_Nro	
	---------------------------------------------------------------------------------
	
	INSERT INTO LOS_NULL.ReservaXCliente (Codigo_Reserva,Nro_Cliente,Flag_Reserva)

	SELECT M.Reserva_Codigo,C.Nro_Cliente,1
	FROM gd_esquema.Maestra M JOIN LOS_NULL.Cliente C ON 
				( LOS_NULL.ID_NACIONALIDAD(M.Cliente_Nacionalidad) = C.ID_Nacionalidad
				AND M.Cliente_Apellido = C.Apellido 
				AND M.Cliente_Nombre = C.Nombre 
				AND M.Cliente_Pasaporte_Nro = C.Nro_Pasaporte)
	GROUP BY M.Reserva_Codigo,C.Nro_Cliente

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[INSERTARRESERVAXHABITACION]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
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
/****** Object:  StoredProcedure [LOS_NULL].[INSERTARCLIENTERESERVA]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
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
/****** Object:  StoredProcedure [LOS_NULL].[MIGRAR_RESERVAS]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[MIGRAR_RESERVAS]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	--Cargo los tipos de reserva que voy a usar
	EXEC [LOS_NULL].[CARGAR_ESTADO_RESERVAS]
	--
	--
	SET IDENTITY_INSERT LOS_NULL.Reserva ON;
	--
	--
	INSERT INTO LOS_NULL.Reserva(Codigo_Reserva,Fecha_Inicio,Fecha_Realizada,Cant_Noches,ID_Estado,ID_Regimen,Usuario)
	
	(
	SELECT M.Reserva_Codigo,M.Reserva_Fecha_Inicio,M.Reserva_Fecha_Inicio,M.Reserva_Cant_Noches,
	LOS_NULL.ID_ESTADORESERVA('Reserva Correcta'),LOS_NULL.ID_REGIMEN(M.Regimen_Descripcion),'SuperUser'
	FROM gd_esquema.Maestra M
	WHERE M.Estadia_Cant_Noches IS NULL 
	AND M.Estadia_Fecha_Inicio IS NULL
	AND NOT EXISTS 
	( 
	SELECT M2.Reserva_Codigo
	FROM gd_esquema.Maestra M2
	WHERE M2.Reserva_Codigo = M.Reserva_Codigo 
	AND M2.Estadia_Cant_Noches IS NOT NULL
	AND M2.Estadia_Fecha_Inicio IS NOT NULL
	)
	GROUP BY M.Reserva_Codigo,M.Reserva_Fecha_Inicio,M.Reserva_Cant_Noches,LOS_NULL.ID_REGIMEN(M.Regimen_Descripcion)
	
	UNION
	
	SELECT M.Reserva_Codigo,M.Reserva_Fecha_Inicio,M.Reserva_Fecha_Inicio,M.Reserva_Cant_Noches,
	LOS_NULL.ID_ESTADORESERVA('Reserva Con Ingreso(Efectivizada)'),LOS_NULL.ID_REGIMEN(M.Regimen_Descripcion),'SuperUser'
	FROM gd_esquema.Maestra M
	WHERE M.Estadia_Cant_Noches IS NOT NULL 
	AND M.Estadia_Fecha_Inicio IS NOT NULL
	GROUP BY M.Reserva_Codigo,M.Reserva_Fecha_Inicio,M.Reserva_Cant_Noches,LOS_NULL.ID_REGIMEN(M.Regimen_Descripcion)
	)

	ORDER BY M.Reserva_Codigo
	--
	--
	SET IDENTITY_INSERT LOS_NULL.Reserva OFF;
	--
	--
	INSERT INTO LOS_NULL.ReservaXHabitacion (ID_Reserva,ID_Habitacion)
	
	SELECT R.Codigo_Reserva,LOS_NULL.ID_HABITACION
	(LOS_NULL.ID_HOTEL(M.Hotel_Ciudad,M.Hotel_Calle,M.Hotel_Nro_Calle,M.Hotel_CantEstrella,M.Hotel_Recarga_Estrella)
	,M.Habitacion_Numero,M.Habitacion_Piso,M.Habitacion_Frente)
	FROM LOS_NULL.Reserva R JOIN gd_esquema.Maestra M ON (R.Codigo_Reserva = M.Reserva_Codigo)
	GROUP BY R.Codigo_Reserva,LOS_NULL.ID_HABITACION
	((LOS_NULL.ID_HOTEL(M.Hotel_Ciudad,M.Hotel_Calle,M.Hotel_Nro_Calle,M.Hotel_CantEstrella,M.Hotel_Recarga_Estrella))
	,M.Habitacion_Numero,M.Habitacion_Piso,M.Habitacion_Frente)
	
	
	
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[CERRAR_ESTADIA]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [LOS_NULL].[BAJATEMPORALDEHOTEL]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[BAJATEMPORALDEHOTEL]
	@ID_HOTEL NUMERIC(18,0),
	@FECHA_INICIO DATETIME,
	@FECHA_FIN DATETIME,
	@DESCRIPCION NVARCHAR(255)
AS
BEGIN
    
    DECLARE @CANTIDAD_RESERVAS_EXISTENTES NUMERIC(18,0)           
            
	SET @CANTIDAD_RESERVAS_EXISTENTES = 
	(
	SELECT COUNT(*) Reservas_Existentes_Entre_Fechas
	FROM LOS_NULL.Hotel H 
			JOIN LOS_NULL.Habitacion HA ON (H.ID_Hotel = HA.ID_Hotel)
			JOIN LOS_NULL.ReservaXHabitacion RHA ON (RHA.ID_Habitacion = HA.ID_Habitacion)
			JOIN LOS_NULL.Reserva R ON (R.Codigo_Reserva = RHA.ID_Reserva)
	WHERE H.ID_Hotel = @ID_HOTEL	
		AND 
		(
		(R.Fecha_Inicio BETWEEN @FECHA_INICIO AND @FECHA_FIN AND DATEADD(D,R.Cant_Noches,R.Fecha_Inicio) BETWEEN @FECHA_INICIO AND @FECHA_FIN)	
		OR
		((DATEADD(D,R.Cant_Noches,R.Fecha_Inicio) BETWEEN @FECHA_INICIO AND @FECHA_FIN) AND R.Fecha_Inicio < @FECHA_INICIO)	
		OR	
		(R.Fecha_Inicio BETWEEN @FECHA_INICIO AND @FECHA_FIN) AND (DATEADD(D,R.Cant_Noches,R.Fecha_Inicio) > @FECHA_FIN)
		)		
	)		
	
	IF (@CANTIDAD_RESERVAS_EXISTENTES = 0)
	BEGIN
		INSERT INTO BajaTemporalHotel(ID_Hotel,Fecha_Inicio,Fecha_Fin,Descripcion)
		VALUES(@ID_HOTEL,@FECHA_INICIO,@FECHA_FIN,@DESCRIPCION)	
	END
	
	SELECT @CANTIDAD_RESERVAS_EXISTENTES
	           
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[CANTIDADPERSONAS_RESERVA]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  UserDefinedFunction [LOS_NULL].[CANTIDAD_VECES_OCUPADA]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [LOS_NULL].[CANTIDAD_VECES_OCUPADA]
(
@ID_HABITACION numeric (18,0),
@FECHA datetime
)

RETURNS numeric (18,0)

AS
BEGIN	
	
	RETURN
	(
		SELECT COUNT(*)
			FROM  
				(SELECT ID_Habitacion FROM LOS_NULL.Habitacion WHERE ID_Habitacion=@ID_HABITACION) HA
				JOIN LOS_NULL.ReservaXHabitacion RH ON (HA.ID_Habitacion = RH.ID_Habitacion)
				JOIN LOS_NULL.Reserva R ON (RH.ID_Reserva = R.Codigo_Reserva)
				JOIN LOS_NULL.Estadia E ON (R.Codigo_Reserva = E.Codigo_Reserva) 
		WHERE DATEDIFF (QUARTER,R.Fecha_Inicio,@FECHA)=0 AND (R.ID_Estado = 6)
	)
	
		
END
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[CANTIDAD_RESERVAS_CANCELADAS]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [LOS_NULL].[CANTIDAD_RESERVAS_CANCELADAS]
(
	@ID_HOTEL numeric(18,0),
	@FECHA nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	
	RETURN 
	(
	SELECT COUNT(*)
	FROM LOS_NULL.Habitacion HA JOIN LOS_NULL.ReservaXHabitacion RH ON (HA.ID_Habitacion = RH.ID_Habitacion)
			JOIN LOS_NULL.Reserva R ON (R.Codigo_Reserva = RH.ID_Reserva)
	WHERE @ID_HOTEL = HA.ID_Hotel 
			AND (R.ID_Estado = 3 
			OR R.ID_Estado = 4 
			OR R.ID_Estado = 5)
			AND DATEDIFF(QUARTER,@FECHA,R.Fecha_Inicio) = 0		
	)

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[CANCELARRESERVA]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
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
	DECLARE @ESTADO_ORIG numeric (18,0)
	
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
		SELECT @FECHA_INICIO=R.Fecha_Inicio, @ESTADO_ORIG=R.ID_Estado FROM LOS_NULL.Reserva R WHERE R.Codigo_Reserva=@CODIGO_RESERVA
		IF (DATEADD(DAY,-1,@FECHA) > @FECHA_INICIO AND @ESTADO_ORIG BETWEEN 1 AND 2)
		BEGIN
			IF EXISTS(SELECT * FROM LOS_NULL.Usuario U WHERE U.ID_Usuario = @USUARIO)
			BEGIN
				UPDATE LOS_NULL.Reserva 
				SET ID_Estado=@ESTADO, Usuario=@USUARIO WHERE Codigo_Reserva=@CODIGO_RESERVA
				SET @MENSAJE = 'Reserva cancelada por '+@USUARIO
			END
		END
		ELSE
		BEGIN
			SELECT @MENSAJE = E.Descripcion FROM LOS_NULL.EstadoReserva E WHERE E.ID_Estado = @ESTADO_ORIG
			SET @MENSAJE = @MENSAJE +'. Ya no puede cancelar la reserva.'
		END
	END
	ELSE SET @MENSAJE = 'La reserva no existe.'
	
	SELECT @MENSAJE
END
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[CANTIDAD_DIAS_OCUPADA]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [LOS_NULL].[CANTIDAD_DIAS_OCUPADA]
(
@ID_HABITACION numeric (18,0),
@FECHA datetime
)

RETURNS numeric (18,0)

AS
BEGIN	
	
	RETURN
	(
		SELECT SUM (E.Cant_Noches)  --ver si aca hacemos algo con la fecha limite
			FROM  
				(SELECT ID_Habitacion FROM LOS_NULL.Habitacion WHERE ID_Habitacion=@ID_HABITACION) HA
				JOIN LOS_NULL.ReservaXHabitacion RH ON (HA.ID_Habitacion = RH.ID_Habitacion)
				JOIN LOS_NULL.Reserva R ON (RH.ID_Reserva = R.Codigo_Reserva)
				JOIN LOS_NULL.Estadia E ON (R.Codigo_Reserva = E.Codigo_Reserva) 
		WHERE DATEDIFF (QUARTER,R.Fecha_Inicio,@FECHA)=0 AND (R.ID_Estado = 6)
	)
	
		
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLHABITACIONPORHOTELPORFECHAYCANTIDAD]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETALLHABITACIONPORHOTELPORFECHAYCANTIDAD] 
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
-- ALTER Procedure (New Menu).SQL
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
/****** Object:  StoredProcedure [LOS_NULL].[GETRESERVAVIGENTE_HOTEL]    Script Date: 11/11/2014 21:57:10 ******/
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
				OR
				R.ID_Estado = 6
				)
				AND (NOT EXISTS (
					SELECT * FROM LOS_NULL.Estadia E
					WHERE E.Codigo_Reserva=@COD_RESERVA)
					OR
					EXISTS (
					SELECT * FROM LOS_NULL.Estadia E
					WHERE E.Usuario_Egreso IS NULL AND E.Codigo_Reserva=@COD_RESERVA))
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETRESERVAS_HOTEL]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETRESERVAS_HOTEL]
	@HOTEL numeric(18,0)
	
AS 
BEGIN
	
	SELECT R.Cant_Noches,R.Codigo_Reserva,R.Fecha_Inicio,R.Fecha_Realizada,R.ID_Estado,R.ID_Regimen,R.Usuario
	FROM LOS_NULL.Reserva R JOIN LOS_NULL.ReservaXHabitacion RHA ON (R.Codigo_Reserva=RHA.ID_Reserva)
	JOIN LOS_NULL.Habitacion H ON (RHA.ID_Habitacion=H.ID_Habitacion)
	JOIN LOS_NULL.Hotel HO ON (H.ID_Hotel=HO.ID_Hotel)
	WHERE HO.ID_Hotel=@HOTEL

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETRESERVAHOTEL]    Script Date: 11/11/2014 21:57:10 ******/
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
/****** Object:  StoredProcedure [LOS_NULL].[GETREGIMENBORRABLESHOTEL]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETREGIMENBORRABLESHOTEL]
	@ID_HOTEL NUMERIC(18,0)
AS
BEGIN
	
	SELECT R.ID_Regimen,R.Descripcion,R.Estado,R.Precio
	FROM LOS_NULL.RegimenXHotel RH JOIN LOS_NULL.Regimen R ON (RH.ID_Regimen = R.ID_Regimen)
	WHERE RH.ID_Hotel = @ID_HOTEL
		  AND (SELECT COUNT(*) FROM LOS_NULL.Habitacion H 
		  JOIN LOS_NULL.ReservaXHabitacion RH ON (H.ID_Habitacion = RH.ID_Habitacion)
		  JOIN LOS_NULL.Reserva RE ON (RE.Codigo_Reserva = RH.ID_Reserva)
		  WHERE @ID_HOTEL = H.ID_Hotel AND RE.ID_Regimen = R.ID_Regimen
		  )= 0
		
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETHABITACIONPORCODIGORESERVA]    Script Date: 11/11/2014 21:57:10 ******/
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
/****** Object:  StoredProcedure [LOS_NULL].[GETESTADIA_X_RESERVA]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETESTADIA_X_RESERVA]
	@RESERVA numeric(18,0)
AS
BEGIN

	SELECT ID_Estadia FROM LOS_NULL.Estadia WHERE Codigo_Reserva=@RESERVA

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETESTADIA]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETESTADIA]
	@ID_ESTADIA NUMERIC(18,0)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [LOS_NULL].Estadia E WHERE E.ID_Estadia = @ID_ESTADIA
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETCLIENTE_GENERADOR_RESERVA]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETCLIENTE_GENERADOR_RESERVA]
	@RESERVA numeric(18,0)
AS
BEGIN

	SELECT Nro_Cliente FROM LOS_NULL.ReservaXCliente
	WHERE Codigo_Reserva=@RESERVA AND Flag_Reserva='1'

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETCONSUMIBLESXRESERVA]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETCONSUMIBLESXRESERVA]
	@COD_RESERVA numeric (18,0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT C.ID_Consumible, C.Descripcion, C.Precio
	FROM LOS_NULL.Estadia E, LOS_NULL.Item_Factura I, LOS_NULL.Consumible C
	WHERE E.ID_Estadia = I.ID_Estadia
	AND I.Codigo_Consumible = C.ID_Consumible
	AND E.Codigo_Reserva = @COD_RESERVA
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLITEMSFACTURADEESTADIA]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- ALTER date: <ALTER Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[GETALLITEMSFACTURADEESTADIA]
	@ID_ESTADIA NUMERIC(18,0)
AS
BEGIN
	SELECT Cantidad,ISNULL(Codigo_Consumible,0) Codigo_Consumible,Detalle,ID_Estadia,ID_Item_Factura,Monto,Nro_Factura
	FROM LOS_NULL.Item_Factura 
	WHERE ID_Estadia = @ID_ESTADIA
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLESTADIASSINFACTURAR]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETALLESTADIASSINFACTURAR]
	@ID_HOTEL numeric(18,0)
AS
BEGIN

	SELECT E.ID_Estadia,E.Fecha_Inicio,E.Cant_Noches,E.Codigo_Reserva,E.Usuario_Egreso,E.Usuario_Ingreso
	FROM LOS_NULL.Estadia E JOIN LOS_NULL.Reserva R ON (E.Codigo_Reserva = R.Codigo_Reserva) 
		JOIN LOS_NULL.ReservaXHabitacion RH ON (RH.ID_Reserva = R.Codigo_Reserva)
		JOIN LOS_NULL.Habitacion H ON (H.ID_Habitacion = RH.ID_Habitacion)
	WHERE (SELECT COUNT(*) FROM LOS_NULL.Item_Factura I 
			WHERE E.ID_Estadia = I.ID_Estadia AND I.Nro_Factura IS NOT NULL) = 0
	AND H.ID_Hotel = @ID_HOTEL
	
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLESTADIASPORHOTEL]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[GETALLESTADIASPORHOTEL]
	@ID_HOTEL numeric(18,0)
AS
BEGIN

	SELECT E.ID_Estadia,E.Fecha_Inicio,E.Cant_Noches,E.Codigo_Reserva,E.Usuario_Egreso,E.Usuario_Ingreso
	FROM LOS_NULL.Estadia E JOIN LOS_NULL.Reserva R ON (E.Codigo_Reserva = R.Codigo_Reserva) 
		JOIN LOS_NULL.ReservaXHabitacion RH ON (RH.ID_Reserva = R.Codigo_Reserva)
		JOIN LOS_NULL.Habitacion H ON (H.ID_Habitacion = RH.ID_Habitacion)
	WHERE (SELECT COUNT(*) FROM LOS_NULL.Item_Factura I WHERE E.ID_Estadia = I.ID_Estadia) = 0
	AND H.ID_Hotel = @ID_HOTEL
	
END
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[CANTIDAD_CONSUMIBLES_FACTURADOS]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [LOS_NULL].[CANTIDAD_CONSUMIBLES_FACTURADOS]
(
	@Id_Hotel numeric (18,0),
	@Fecha datetime
)
RETURNS numeric (18,0)	

AS
BEGIN
	
	RETURN 
	(
		SELECT SUM (IT.Cantidad) FROM
			(SELECT Id_Hotel FROM LOS_NULL.Hotel WHERE ID_Hotel = @Id_Hotel) HO
				JOIN LOS_NULL.Habitacion HA ON (HO.ID_Hotel = HA.ID_Hotel)
				JOIN LOS_NULL.ReservaXHabitacion RH ON (HA.ID_Habitacion = RH.ID_Habitacion)
				JOIN LOS_NULL.Reserva RE ON (RH.ID_Reserva = RE.Codigo_Reserva)
				JOIN LOS_NULL.Estadia ES ON (RE.Codigo_Reserva = ES.Codigo_Reserva)
				JOIN LOS_NULL.Item_Factura IT ON (ES.ID_Estadia = IT.ID_Estadia)
				JOIN LOS_NULL.Consumible CO ON (IT.Codigo_Consumible = CO.ID_Consumible)
				JOIN LOS_NULL.Factura FA ON (IT.Nro_Factura = FA.Nro_Factura)
		WHERE DATEDIFF (QUARTER,@fecha,FA.Fecha) = 0
		
	)

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[DAMEVALORFINALESATADIA]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[DAMEVALORFINALESATADIA]
	@ID_ESTADIA NUMERIC(18,0)
AS
BEGIN	
	SELECT F.Total
	FROM LOS_NULL.Factura F
	WHERE (
		SELECT TOP 1(I.Nro_Factura)
		FROM LOS_NULL.Estadia E	JOIN LOS_NULL.Item_Factura I ON (E.ID_Estadia = I.ID_Estadia)
		WHERE E.ID_Estadia = @ID_ESTADIA
		) = F.Nro_Factura
END
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[DAMETODOLOCONSUMIDO]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [LOS_NULL].[DAMETODOLOCONSUMIDO]
(
	@ID_ESTADIA NUMERIC(18,0)
)
RETURNS NUMERIC(18,2)
AS
BEGIN
	RETURN 
	(
		SELECT SUM(E.Monto)
		FROM LOS_NULL.Item_Factura E
		WHERE E.ID_Estadia = @ID_ESTADIA
	)

END
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[CANTIDAD_PUNTOS_X_CLIENTE]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [LOS_NULL].[CANTIDAD_PUNTOS_X_CLIENTE]
(
	@ID_CLIENTE numeric(18,0),
	@FECHA nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	
	RETURN 
	--Consumibles
	(
	SELECT SUM(I.Cantidad*I.Monto)
	FROM LOS_NULL.ReservaXCliente RC JOIN LOS_NULL.Reserva RE ON (RC.Codigo_Reserva = RE.Codigo_Reserva)
	JOIN LOS_NULL.Estadia E ON (E.Codigo_Reserva = RE.Codigo_Reserva)
	JOIN LOS_NULL.Item_Factura I ON (E.Codigo_Reserva = I.ID_Estadia)
	WHERE I.Codigo_Consumible IS NOT NULL
		AND RC.Nro_Cliente = @ID_CLIENTE
		AND DATEDIFF(QUARTER,@FECHA,E.Fecha_Inicio) = 0	
	)
	/5
	+
	--Estadias
	(
	SELECT SUM(I.Monto*E.Cant_Noches)
	FROM LOS_NULL.ReservaXCliente RC JOIN LOS_NULL.Reserva RE ON (RC.Codigo_Reserva = RE.Codigo_Reserva)
	JOIN LOS_NULL.Estadia E ON (E.Codigo_Reserva = RE.Codigo_Reserva)
	JOIN LOS_NULL.Item_Factura I ON (E.Codigo_Reserva = I.ID_Estadia)
	WHERE I.Codigo_Consumible IS NULL
		AND RC.Nro_Cliente = @ID_CLIENTE
		AND DATEDIFF(QUARTER,@FECHA,E.Fecha_Inicio) = 0	
	)
	/10

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[MIGRAR_FACTURAS_ITEM_FACTURAS]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[MIGRAR_FACTURAS_ITEM_FACTURAS]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--
	-- El comando de abajo permite ingresar facturas en la tabla sin usar el IDENTITY, luego se reactiva
	-- para que cuando se inserte desde C# no rompa porque no pusiste un numero de factura
	--
	SET IDENTITY_INSERT LOS_NULL.Factura ON;
	--
	--
	INSERT INTO LOS_NULL.Factura (Nro_Factura,Fecha,Total,Forma_De_Pago)
	--
	SELECT M.Factura_Nro,M.Factura_Fecha,M.Factura_Total,'Efectivo'
	FROM gd_esquema.Maestra M
	WHERE M.Estadia_Cant_Noches IS NOT NULL AND M.Estadia_Fecha_Inicio IS NOT NULL
		AND M.Item_Factura_Cantidad IS NOT NULL AND M.Item_Factura_Monto IS NOT NULL
	GROUP BY M.Factura_Nro,M.Factura_Fecha,M.Factura_Total
	ORDER BY M.Factura_Nro
	--
	--Se reactiva el insert de IDENTITY
	--
	SET IDENTITY_INSERT LOS_NULL.Factura OFF;
	--
	--
	INSERT INTO LOS_NULL.Item_Factura(ID_Estadia,Cantidad,Codigo_Consumible,Monto,Nro_Factura,Detalle)
	--
	SELECT E.ID_Estadia,M.Item_Factura_Cantidad,M.Consumible_Codigo,M.Item_Factura_Monto,M.Factura_Nro,'Migradas de BD original'
	FROM LOS_NULL.Estadia E JOIN gd_esquema.Maestra M ON (E.Codigo_Reserva = M.Reserva_Codigo)
	WHERE M.Estadia_Cant_Noches IS NOT NULL 
		AND M.Estadia_Fecha_Inicio IS NOT NULL 
		AND M.Item_Factura_Cantidad IS NOT NULL
		AND M.Item_Factura_Monto IS NOT NULL
	GROUP BY E.ID_Estadia,M.Item_Factura_Cantidad,M.Item_Factura_Monto,M.Consumible_Codigo,M.Factura_Nro
	ORDER BY E.ID_Estadia
	--
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[INGRESARCONSUMIBLESITEMSFACTURA]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[INGRESARCONSUMIBLESITEMSFACTURA]
	@ID_ESTADIA NUMERIC(18,0),
	@MONTO NUMERIC(18,2),
	@ID_CONSUMIBLE NUMERIC(18,0),
	@CANTIDAD NUMERIC(18,0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	INSERT INTO Item_Factura(ID_Estadia,Monto,Codigo_Consumible,Cantidad,Detalle)
	VALUES(@ID_ESTADIA,@MONTO,@ID_CONSUMIBLE,@CANTIDAD,'Consumibles')

END
GO
/****** Object:  StoredProcedure [LOS_NULL].[TOP5RESERVASCANCELADAS]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[TOP5RESERVASCANCELADAS]
	@FECHA DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT TOP 5 H.ID_Hotel,H.Ciudad,H.Calle,H.Nro_Calle,H.Cant_Estrellas,H.Pais,H.Telefono
		,LOS_NULL.CANTIDAD_RESERVAS_CANCELADAS(H.ID_Hotel,@FECHA) Reservas_Canceladas
	FROM LOS_NULL.Hotel H
	ORDER BY Reservas_Canceladas DESC 

    
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[TOP5PUNTOSXCLIENTE]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[TOP5PUNTOSXCLIENTE]
	@FECHA DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT TOP 5 C.Nro_Cliente,C.Nro_Pasaporte,C.ID_Nacionalidad,C.Apellido,C.Nombre,C.Mail,
	(ISNULL(ROUND((SELECT SUM(I.Cantidad*I.Monto)
	FROM LOS_NULL.ReservaXCliente RC JOIN LOS_NULL.Reserva RE ON (RC.Codigo_Reserva = RE.Codigo_Reserva)
	JOIN LOS_NULL.Estadia E ON (E.Codigo_Reserva = RE.Codigo_Reserva)
	JOIN LOS_NULL.Item_Factura I ON (E.Codigo_Reserva = I.ID_Estadia)
	WHERE I.Codigo_Consumible IS NOT NULL
		AND RC.Nro_Cliente = C.Nro_Cliente
		AND DATEDIFF(QUARTER,@FECHA,E.Fecha_Inicio) = 0	
	)/5+(	
	SELECT SUM(I.Monto*E.Cant_Noches)
	FROM LOS_NULL.ReservaXCliente RC JOIN LOS_NULL.Reserva RE ON (RC.Codigo_Reserva = RE.Codigo_Reserva)
	JOIN LOS_NULL.Estadia E ON (E.Codigo_Reserva = RE.Codigo_Reserva)
	JOIN LOS_NULL.Item_Factura I ON (E.Codigo_Reserva = I.ID_Estadia)
	WHERE I.Codigo_Consumible IS NULL
		AND RC.Nro_Cliente = C.Nro_Cliente
		AND DATEDIFF(QUARTER,@FECHA,E.Fecha_Inicio) = 0)
	/10,0),0)) PUNTOS
	FROM LOS_NULL.Cliente C
	ORDER BY PUNTOS DESC

    
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[TOP5HABITACIONESOCUPADAS]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [LOS_NULL].[TOP5HABITACIONESOCUPADAS]
	@FECHA datetime

AS
BEGIN

	SELECT TOP 5 HO.ID_Hotel,HA.ID_Habitacion,HA.Numero, LOS_NULL.CANTIDAD_VECES_OCUPADA (HA.ID_Habitacion,@FECHA) Veces_Ocupada, LOS_NULL.CANTIDAD_DIAS_OCUPADA (HA.ID_Habitacion,@FECHA) Dias_ocupada
	 FROM LOS_NULL.Habitacion HA JOIN LOS_NULL.Hotel HO ON (HA.ID_Hotel=HO.ID_Hotel)
	ORDER BY Veces_Ocupada DESC, Dias_ocupada DESC
	 
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[TOP5CONSUMIBLESFACTURADOS]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[TOP5CONSUMIBLESFACTURADOS]
	-- Add the parameters for the stored procedure here
	@FECHA datetime
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 5 H.ID_Hotel,H.Ciudad,H.Calle,H.Nro_Calle,H.Cant_Estrellas,H.Pais,H.Telefono
		,LOS_NULL.CANTIDAD_CONSUMIBLES_FACTURADOS(H.ID_Hotel,@FECHA) Consumibles_Facturados
	FROM LOS_NULL.Hotel H
	ORDER BY Consumibles_Facturados DESC 
END
GO
/****** Object:  StoredProcedure [LOS_NULL].[INSERTARESTADIAITEMFACTURA]    Script Date: 11/11/2014 21:57:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[INSERTARESTADIAITEMFACTURA]
	@ID_ESTADIA NUMERIC(18,0),
	@FORMA_DE_PAGO NVARCHAR(255),
	@FECHA DATETIME,
	@CUOTAS NUMERIC(18,0),
	@ID_TARJETA NUMERIC(18,0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @VALOR_HABITACION NUMERIC(18,2)
	SET @VALOR_HABITACION =(	
							SELECT SUM([LOS_NULL].[DAMEVALORHABITACION](H.ID_Hotel,H.Numero,R.ID_Regimen))
							FROM LOS_NULL.Estadia E 
								JOIN LOS_NULL.Reserva R ON (E.Codigo_Reserva = R.Codigo_Reserva)
								JOIN LOS_NULL.ReservaXHabitacion RH ON (RH.ID_Reserva = R.Codigo_Reserva)
								JOIN LOS_NULL.Habitacion H ON (RH.ID_Habitacion = H.ID_Habitacion)		
							WHERE E.ID_Estadia = @ID_ESTADIA
							)
	DECLARE @SET_DESCUENTO NUMERIC(18,0);
	SET @SET_DESCUENTO = 0;
	SET @SET_DESCUENTO = (
						SELECT COUNT(*)
						FROM LOS_NULL.Estadia E
						JOIN LOS_NULL.Reserva R ON (E.Codigo_Reserva = R.Codigo_Reserva)
						WHERE E.ID_Estadia = @ID_ESTADIA AND R.ID_Regimen = [LOS_NULL].[ID_REGIMEN]('All inclusive')
						)	

	DECLARE @DIAS_QUE_SEQUEDO NUMERIC(18,0);
	DECLARE @DIAS_QUE_TOTAL NUMERIC(18,0);
	SET @DIAS_QUE_SEQUEDO = (SELECT E.Cant_Noches_Estadia FROM LOS_NULL.Estadia E WHERE E.ID_Estadia = @ID_ESTADIA)
	SET @DIAS_QUE_TOTAL = (SELECT E.Cant_Noches FROM LOS_NULL.Estadia E WHERE E.ID_Estadia = @ID_ESTADIA)
		IF (@DIAS_QUE_TOTAL = 0)
		SET @DIAS_QUE_TOTAL = 1
		IF (@DIAS_QUE_SEQUEDO = 0)
		SET @DIAS_QUE_SEQUEDO = 1
	IF (@DIAS_QUE_TOTAL - @DIAS_QUE_SEQUEDO = 0)
	BEGIN
		--Ingreso los datos de la estadia
		INSERT INTO Item_Factura (ID_Estadia,Cantidad,Monto,Detalle)
		VALUES (@ID_ESTADIA,@DIAS_QUE_TOTAL,@VALOR_HABITACION*@DIAS_QUE_SEQUEDO,'Dias que se hospedo')	
		--Me fijo si hace falta cargar los consumibles
		IF(@SET_DESCUENTO = 0)
		BEGIN
			INSERT INTO LOS_NULL.Factura(Total,Fecha,Forma_De_Pago,Cuotas)
			VALUES (@VALOR_HABITACION*@DIAS_QUE_SEQUEDO,@FECHA,@FORMA_DE_PAGO,@CUOTAS)
		END
		ELSE
		BEGIN
			INSERT INTO LOS_NULL.Factura(Total,Fecha,Forma_De_Pago,Cuotas)
			VALUES (@VALOR_HABITACION*@DIAS_QUE_SEQUEDO+LOS_NULL.DAMETODOLOCONSUMIDO(@ID_ESTADIA)
					,@FECHA,@FORMA_DE_PAGO,@CUOTAS)
		END
		
		--
	END
	ELSE
	BEGIN
		--Ingreso los datos de la estadia y los dias que pago y no se hospedo
		INSERT INTO Item_Factura (ID_Estadia,Cantidad,Monto,Detalle)
		VALUES (@ID_ESTADIA,@DIAS_QUE_SEQUEDO,@VALOR_HABITACION*@DIAS_QUE_SEQUEDO,'Dias que se hospedo')
		INSERT INTO Item_Factura (ID_Estadia,Cantidad,Monto,Detalle)
		VALUES (@ID_ESTADIA,(@DIAS_QUE_TOTAL-@DIAS_QUE_SEQUEDO),@VALOR_HABITACION*(@DIAS_QUE_TOTAL-@DIAS_QUE_SEQUEDO),'Dias que se pago y no se hospedo')
				--Me fijo si hace falta cargar los consumibles
		IF(@SET_DESCUENTO = 0)
		BEGIN
			INSERT INTO LOS_NULL.Factura(Total,Fecha,Forma_De_Pago,Cuotas)
			VALUES (@VALOR_HABITACION*@DIAS_QUE_TOTAL,@FECHA,@FORMA_DE_PAGO,@CUOTAS)
		END
		ELSE
		BEGIN
			INSERT INTO LOS_NULL.Factura(Total,Fecha,Forma_De_Pago,Cuotas)
			VALUES (@VALOR_HABITACION*@DIAS_QUE_TOTAL+LOS_NULL.DAMETODOLOCONSUMIDO(@ID_ESTADIA)
					,@FECHA,@FORMA_DE_PAGO,@CUOTAS)
		END
	END		

	
	--CARGO EL NUMERO DE TARJETA SI NO ES NULL
	IF (@ID_TARJETA > 0 AND @CUOTAS > 0)
	BEGIN	
		UPDATE LOS_NULL.Factura
		SET ID_Tarjeta_Credito = LOS_NULL.ID_TARJETA(@FORMA_DE_PAGO,@ID_TARJETA)
		WHERE Nro_Factura = @@IDENTITY		
	END
	
	--UPDATE DE TODOS LOS ITEMS DE LA FACTURA -> EL ULTIMO @@IDENTITY SIEMPRE ES LA FACTURA QUE CREO
	UPDATE LOS_NULL.Item_Factura
	SET Nro_Factura = @@IDENTITY
	WHERE ID_Estadia = @ID_ESTADIA	
	
	RETURN 
END

-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
/****** Object:  Default [DF_Cliente_Baja_Logica]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Cliente] ADD  CONSTRAINT [DF_Cliente_Baja_Logica]  DEFAULT ((0)) FOR [Baja_Logica]
GO
/****** Object:  Default [DF_Cliente_Duplicado]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Cliente] ADD  CONSTRAINT [DF_Cliente_Duplicado]  DEFAULT ((0)) FOR [Duplicado_Pasaporte]
GO
/****** Object:  Default [DF_Cliente_Duplicado_Mail]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Cliente] ADD  CONSTRAINT [DF_Cliente_Duplicado_Mail]  DEFAULT ((0)) FOR [Duplicado_Mail]
GO
/****** Object:  Default [DF_Habitacion_Baja_Logica]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Habitacion] ADD  CONSTRAINT [DF_Habitacion_Baja_Logica]  DEFAULT ((0)) FOR [Baja_Logica]
GO
/****** Object:  Default [DF_Regimen_Estado]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Regimen] ADD  CONSTRAINT [DF_Regimen_Estado]  DEFAULT ((0)) FOR [Estado]
GO
/****** Object:  Default [DF_ReservaXCliente_Flag_Reserva]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[ReservaXCliente] ADD  CONSTRAINT [DF_ReservaXCliente_Flag_Reserva]  DEFAULT ((0)) FOR [Flag_Reserva]
GO
/****** Object:  Default [DF_Rol_Baja_Logica]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Rol] ADD  CONSTRAINT [DF_Rol_Baja_Logica]  DEFAULT ((0)) FOR [Baja_Logica]
GO
/****** Object:  Default [DF_Usuario_Intentos]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Usuario] ADD  CONSTRAINT [DF_Usuario_Intentos]  DEFAULT ((0)) FOR [Intentos]
GO
/****** Object:  Default [DF_Usuario_Baja_Logica]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Usuario] ADD  CONSTRAINT [DF_Usuario_Baja_Logica]  DEFAULT ((0)) FOR [Baja_Logica]
GO
/****** Object:  ForeignKey [FK_BajaTemporalHotel_Hotel]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[BajaTemporalHotel]  WITH CHECK ADD  CONSTRAINT [FK_BajaTemporalHotel_Hotel] FOREIGN KEY([ID_Hotel])
REFERENCES [LOS_NULL].[Hotel] ([ID_Hotel])
GO
ALTER TABLE [LOS_NULL].[BajaTemporalHotel] CHECK CONSTRAINT [FK_BajaTemporalHotel_Hotel]
GO
/****** Object:  ForeignKey [FK_CancelacionReserva_Reserva]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[CancelacionReserva]  WITH CHECK ADD  CONSTRAINT [FK_CancelacionReserva_Reserva] FOREIGN KEY([Codigo_Reserva])
REFERENCES [LOS_NULL].[Reserva] ([Codigo_Reserva])
GO
ALTER TABLE [LOS_NULL].[CancelacionReserva] CHECK CONSTRAINT [FK_CancelacionReserva_Reserva]
GO
/****** Object:  ForeignKey [FK_CancelacionReserva_Usuario]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[CancelacionReserva]  WITH CHECK ADD  CONSTRAINT [FK_CancelacionReserva_Usuario] FOREIGN KEY([Usuario])
REFERENCES [LOS_NULL].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [LOS_NULL].[CancelacionReserva] CHECK CONSTRAINT [FK_CancelacionReserva_Usuario]
GO
/****** Object:  ForeignKey [FK_Cliente_Nacionalidad]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Nacionalidad] FOREIGN KEY([ID_Nacionalidad])
REFERENCES [LOS_NULL].[Nacionalidad] ([ID_Nacionalidad])
GO
ALTER TABLE [LOS_NULL].[Cliente] CHECK CONSTRAINT [FK_Cliente_Nacionalidad]
GO
/****** Object:  ForeignKey [FK_Estadia_Reserva]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Estadia]  WITH CHECK ADD  CONSTRAINT [FK_Estadia_Reserva] FOREIGN KEY([Codigo_Reserva])
REFERENCES [LOS_NULL].[Reserva] ([Codigo_Reserva])
GO
ALTER TABLE [LOS_NULL].[Estadia] CHECK CONSTRAINT [FK_Estadia_Reserva]
GO
/****** Object:  ForeignKey [FK_Estadia_Usuario]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Estadia]  WITH CHECK ADD  CONSTRAINT [FK_Estadia_Usuario] FOREIGN KEY([Usuario_Egreso])
REFERENCES [LOS_NULL].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [LOS_NULL].[Estadia] CHECK CONSTRAINT [FK_Estadia_Usuario]
GO
/****** Object:  ForeignKey [FK_Estadia_Usuario1]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Estadia]  WITH CHECK ADD  CONSTRAINT [FK_Estadia_Usuario1] FOREIGN KEY([Usuario_Ingreso])
REFERENCES [LOS_NULL].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [LOS_NULL].[Estadia] CHECK CONSTRAINT [FK_Estadia_Usuario1]
GO
/****** Object:  ForeignKey [FK_Factura_Tarjeta]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Tarjeta] FOREIGN KEY([ID_Tarjeta_Credito])
REFERENCES [LOS_NULL].[Tarjeta] ([ID_Tarjeta])
GO
ALTER TABLE [LOS_NULL].[Factura] CHECK CONSTRAINT [FK_Factura_Tarjeta]
GO
/****** Object:  ForeignKey [FK_FuncionalidadXRol_Funcionalidad]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[FuncionalidadXRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadXRol_Funcionalidad] FOREIGN KEY([ID_Funcionalidad])
REFERENCES [LOS_NULL].[Funcionalidad] ([ID_Funcionalidad])
GO
ALTER TABLE [LOS_NULL].[FuncionalidadXRol] CHECK CONSTRAINT [FK_FuncionalidadXRol_Funcionalidad]
GO
/****** Object:  ForeignKey [FK_FuncionalidadXRol_Rol]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[FuncionalidadXRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadXRol_Rol] FOREIGN KEY([ID_Rol])
REFERENCES [LOS_NULL].[Rol] ([ID_Rol])
GO
ALTER TABLE [LOS_NULL].[FuncionalidadXRol] CHECK CONSTRAINT [FK_FuncionalidadXRol_Rol]
GO
/****** Object:  ForeignKey [FK_Habitacion_Hotel1]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Habitacion]  WITH CHECK ADD  CONSTRAINT [FK_Habitacion_Hotel1] FOREIGN KEY([ID_Hotel])
REFERENCES [LOS_NULL].[Hotel] ([ID_Hotel])
GO
ALTER TABLE [LOS_NULL].[Habitacion] CHECK CONSTRAINT [FK_Habitacion_Hotel1]
GO
/****** Object:  ForeignKey [FK_Habitacion_TipoHabitacion]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Habitacion]  WITH CHECK ADD  CONSTRAINT [FK_Habitacion_TipoHabitacion] FOREIGN KEY([Codigo_Tipo])
REFERENCES [LOS_NULL].[TipoHabitacion] ([Codigo_Tipo])
GO
ALTER TABLE [LOS_NULL].[Habitacion] CHECK CONSTRAINT [FK_Habitacion_TipoHabitacion]
GO
/****** Object:  ForeignKey [FK_Item_Factura_Consumible]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Item_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura_Consumible] FOREIGN KEY([Codigo_Consumible])
REFERENCES [LOS_NULL].[Consumible] ([ID_Consumible])
GO
ALTER TABLE [LOS_NULL].[Item_Factura] CHECK CONSTRAINT [FK_Item_Factura_Consumible]
GO
/****** Object:  ForeignKey [FK_Item_Factura_Estadia]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Item_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura_Estadia] FOREIGN KEY([ID_Estadia])
REFERENCES [LOS_NULL].[Estadia] ([ID_Estadia])
GO
ALTER TABLE [LOS_NULL].[Item_Factura] CHECK CONSTRAINT [FK_Item_Factura_Estadia]
GO
/****** Object:  ForeignKey [FK_Item_Factura_Factura]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Item_Factura]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura_Factura] FOREIGN KEY([Nro_Factura])
REFERENCES [LOS_NULL].[Factura] ([Nro_Factura])
GO
ALTER TABLE [LOS_NULL].[Item_Factura] CHECK CONSTRAINT [FK_Item_Factura_Factura]
GO
/****** Object:  ForeignKey [FK_RegimenXHotel_Hotel]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[RegimenXHotel]  WITH CHECK ADD  CONSTRAINT [FK_RegimenXHotel_Hotel] FOREIGN KEY([ID_Hotel])
REFERENCES [LOS_NULL].[Hotel] ([ID_Hotel])
GO
ALTER TABLE [LOS_NULL].[RegimenXHotel] CHECK CONSTRAINT [FK_RegimenXHotel_Hotel]
GO
/****** Object:  ForeignKey [FK_RegimenXHotel_Regimen]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[RegimenXHotel]  WITH CHECK ADD  CONSTRAINT [FK_RegimenXHotel_Regimen] FOREIGN KEY([ID_Regimen])
REFERENCES [LOS_NULL].[Regimen] ([ID_Regimen])
GO
ALTER TABLE [LOS_NULL].[RegimenXHotel] CHECK CONSTRAINT [FK_RegimenXHotel_Regimen]
GO
/****** Object:  ForeignKey [FK_Reserva_EstadoReserva]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_EstadoReserva] FOREIGN KEY([ID_Estado])
REFERENCES [LOS_NULL].[EstadoReserva] ([ID_Estado])
GO
ALTER TABLE [LOS_NULL].[Reserva] CHECK CONSTRAINT [FK_Reserva_EstadoReserva]
GO
/****** Object:  ForeignKey [FK_Reserva_Regimen]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Regimen] FOREIGN KEY([ID_Regimen])
REFERENCES [LOS_NULL].[Regimen] ([ID_Regimen])
GO
ALTER TABLE [LOS_NULL].[Reserva] CHECK CONSTRAINT [FK_Reserva_Regimen]
GO
/****** Object:  ForeignKey [FK_Reserva_Usuario]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Usuario] FOREIGN KEY([Usuario])
REFERENCES [LOS_NULL].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [LOS_NULL].[Reserva] CHECK CONSTRAINT [FK_Reserva_Usuario]
GO
/****** Object:  ForeignKey [FK_ReservaXCliente_Cliente]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[ReservaXCliente]  WITH CHECK ADD  CONSTRAINT [FK_ReservaXCliente_Cliente] FOREIGN KEY([Nro_Cliente])
REFERENCES [LOS_NULL].[Cliente] ([Nro_Cliente])
GO
ALTER TABLE [LOS_NULL].[ReservaXCliente] CHECK CONSTRAINT [FK_ReservaXCliente_Cliente]
GO
/****** Object:  ForeignKey [FK_ReservaXCliente_Reserva]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[ReservaXCliente]  WITH CHECK ADD  CONSTRAINT [FK_ReservaXCliente_Reserva] FOREIGN KEY([Codigo_Reserva])
REFERENCES [LOS_NULL].[Reserva] ([Codigo_Reserva])
GO
ALTER TABLE [LOS_NULL].[ReservaXCliente] CHECK CONSTRAINT [FK_ReservaXCliente_Reserva]
GO
/****** Object:  ForeignKey [FK_ReservaXHabitacion_Reserva]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[ReservaXHabitacion]  WITH CHECK ADD  CONSTRAINT [FK_ReservaXHabitacion_Reserva] FOREIGN KEY([ID_Reserva])
REFERENCES [LOS_NULL].[Reserva] ([Codigo_Reserva])
GO
ALTER TABLE [LOS_NULL].[ReservaXHabitacion] CHECK CONSTRAINT [FK_ReservaXHabitacion_Reserva]
GO
/****** Object:  ForeignKey [FK_UsuarioXHotel_Hotel]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[UsuarioXHotel]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioXHotel_Hotel] FOREIGN KEY([ID_Hotel])
REFERENCES [LOS_NULL].[Hotel] ([ID_Hotel])
GO
ALTER TABLE [LOS_NULL].[UsuarioXHotel] CHECK CONSTRAINT [FK_UsuarioXHotel_Hotel]
GO
/****** Object:  ForeignKey [FK_UsuarioXHotel_Usuario]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[UsuarioXHotel]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioXHotel_Usuario] FOREIGN KEY([ID_Usuario])
REFERENCES [LOS_NULL].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [LOS_NULL].[UsuarioXHotel] CHECK CONSTRAINT [FK_UsuarioXHotel_Usuario]
GO
/****** Object:  ForeignKey [FK_UsuarioXRol_Rol]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[UsuarioXRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioXRol_Rol] FOREIGN KEY([ID_Rol])
REFERENCES [LOS_NULL].[Rol] ([ID_Rol])
GO
ALTER TABLE [LOS_NULL].[UsuarioXRol] CHECK CONSTRAINT [FK_UsuarioXRol_Rol]
GO
/****** Object:  ForeignKey [FK_UsuarioXRol_Usuario]    Script Date: 11/11/2014 21:57:08 ******/
ALTER TABLE [LOS_NULL].[UsuarioXRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioXRol_Usuario] FOREIGN KEY([ID_Usuario])
REFERENCES [LOS_NULL].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [LOS_NULL].[UsuarioXRol] CHECK CONSTRAINT [FK_UsuarioXRol_Usuario]
GO























print 'Creadas las Tablas'
--Indices

USE [GD2C2014]
GO
CREATE NONCLUSTERED INDEX [Estadia] ON [LOS_NULL].[Item_Factura] 
(
	[ID_Estadia] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

USE [GD2C2014]
GO
CREATE UNIQUE NONCLUSTERED INDEX [ReservaEstadia] ON [LOS_NULL].[Estadia] 
(
	[Codigo_Reserva] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

USE [GD2C2014]
GO
CREATE UNIQUE NONCLUSTERED INDEX [ClienteReserva] ON [LOS_NULL].[ReservaXCliente] 
(
	[Codigo_Reserva] ASC,
	[Nro_Cliente] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

USE [GD2C2014]
GO
CREATE NONCLUSTERED INDEX [Habitacion_Hotel_Numero] ON [LOS_NULL].[Habitacion] 
(
	[ID_Habitacion] ASC,
	[Numero] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

print 'Creados los Indices'

--Triggers
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [LOS_NULL].[Baja_Logica_Habitaciones] 
   ON  [LOS_NULL].[Habitacion]
   INSTEAD OF DELETE
AS 
BEGIN
	UPDATE H
	SET	Baja_Logica = 1
	FROM LOS_NULL.Habitacion H JOIN deleted D ON (H.ID_Habitacion = D.ID_Habitacion)
END
GO

print 'Creados los Triggers'

print 'Inicio Migracion'
print 'Migracion de Nacionalidades'
EXEC LOS_NULL.MIGRAR_NACIONALIDADES
print 'Migracion de Hoteles'
EXEC LOS_NULL.MIGRAR_HOTELES
print 'Migracion de Regimenes'  
EXEC LOS_NULL.MIGRAR_REGIMENES
print 'Migracion de Consumibles'
EXEC LOS_NULL.MIGRAR_CONSUMIBLES
print 'Migracion de Tipo_Habitacion'
EXEC LOS_NULL.MIGRAR_TIPO_HABITACION
print 'Migracion de Funcionalidades-Roles-Usuarios+Creacion de Usuario por defecto -> LOS_NULL.MIGRAR_USUARIOSROLESFUNCIONALIDADES'
EXEC LOS_NULL.MIGRAR_USUARIOSROLESFUNCIONALIDADES
print 'Migracion de Habitaciones'
EXEC LOS_NULL.MIGRAR_HABITACIONES
print 'Migracion de Reservas'
EXEC LOS_NULL.MIGRAR_RESERVAS
print 'Migracion de Estadias'
EXEC LOS_NULL.MIGRAR_ESTADIAS
print 'Migracion de Item_Facturas-Facturas'
EXEC LOS_NULL.MIGRAR_FACTURAS_ITEM_FACTURAS
print 'Migracion de Clientes'
EXEC LOS_NULL.MIGRAR_CLIENTES


print 'Se agregaron las capacidades de las habitaciones'
UPDATE LOS_NULL.TipoHabitacion SET Capacidad = 1 WHERE Codigo_Tipo = 1001
UPDATE LOS_NULL.TipoHabitacion SET Capacidad = 2 WHERE Codigo_Tipo = 1002
UPDATE LOS_NULL.TipoHabitacion SET Capacidad = 3 WHERE Codigo_Tipo = 1003
UPDATE LOS_NULL.TipoHabitacion SET Capacidad = 4 WHERE Codigo_Tipo = 1004
UPDATE LOS_NULL.TipoHabitacion SET Capacidad = 5 WHERE Codigo_Tipo = 1005

print 'Fin de Migracion'