USE [GD2C2014]
GO
/****** Object:  StoredProcedure [LOS_NULL].[TOP5CONSUMIBLESFACTURADOS]    Script Date: 10/19/2014 23:59:59 ******/
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

USE [GD2C2014]
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[CANTIDAD_CONSUMIBLES_FACTURADOS]    Script Date: 10/20/2014 00:01:07 ******/
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