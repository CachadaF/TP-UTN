USE [GD2C2014]
GO
/****** Object:  StoredProcedure [LOS_NULL].[TOP5PUNTOSXCLIENTE]    Script Date: 10/19/2014 23:22:35 ******/
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

USE [GD2C2014]
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[CANTIDAD_PUNTOS_X_CLIENTE]    Script Date: 10/19/2014 23:22:23 ******/
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
