USE [GD2C2014]
GO
/****** Object:  StoredProcedure [LOS_NULL].[INSERTARESTADIAITEMFACTURA]    Script Date: 11/11/2014 13:29:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [LOS_NULL].[INSERTARESTADIAITEMFACTURA]
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



