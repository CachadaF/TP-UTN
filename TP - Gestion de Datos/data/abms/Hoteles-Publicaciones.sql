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
CREATE PROCEDURE [LOS_NULL].[GETALLITEMSFACTURADEESTADIA]
	@ID_ESTADIA NUMERIC(18,0)
AS
BEGIN
	SELECT Cantidad,ISNULL(Codigo_Consumible,0) Codigo_Consumible,Detalle,ID_Estadia,ID_Item_Factura,Monto,Nro_Factura
	FROM LOS_NULL.Item_Factura 
	WHERE ID_Estadia = @ID_ESTADIA
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

USE [GD2C2014]
GO
/****** Object:  StoredProcedure [LOS_NULL].[FILTRARHOTELESPORCAMPOS]    Script Date: 11/01/2014 18:25:36 ******/
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

USE [GD2C2014]
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLREGIMENPORHOTEL]    Script Date: 11/01/2014 21:50:45 ******/
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

USE [GD2C2014]
GO
/****** Object:  StoredProcedure [LOS_NULL].[GETALLREGIMENPORHOTEL]    Script Date: 11/01/2014 21:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
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
CREATE PROCEDURE [LOS_NULL].[ELIMINARREGIMENHOTEL] 
	@ID_HOTEL NUMERIC(18,0),
	@DESCRIPCION NVARCHAR(255)
AS
BEGIN
	DELETE FROM LOS_NULL.RegimenXHotel
	WHERE ID_Hotel = @ID_HOTEL AND ID_Regimen = LOS_NULL.ID_REGIMEN(@DESCRIPCION)	

END
GO