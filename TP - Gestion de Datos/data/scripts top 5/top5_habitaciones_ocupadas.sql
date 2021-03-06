USE [GD2C2014]
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[CANTIDAD_VECES_OCUPADA]    Script Date: 10/23/2014 22:51:37 ******/
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

USE [GD2C2014]
GO
/****** Object:  UserDefinedFunction [LOS_NULL].[CANTIDAD_VECES_OCUPADA]    Script Date: 10/23/2014 22:51:37 ******/
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


/****** Object:  StoredProcedure [LOS_NULL].[TOP5HABITACIONESOCUPADAS]    Script Date: 10/23/2014 01:16:00 ******/
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

