/****** Object:  Table [LOS_NULL].[Tarjeta]    Script Date: 11/08/2014 16:54:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[Tarjeta](
	[ID_Tarjeta] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Numero] [numeric](18, 0) NOT NULL,
	[Tipo] [nvarchar](255) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_TarjetaDeCredito] PRIMARY KEY CLUSTERED 
(
	[ID_Tarjeta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  ForeignKey [FK_Factura_Tarjeta]    Script Date: 11/08/2014 16:54:04 ******/
ALTER TABLE [LOS_NULL].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Tarjeta] FOREIGN KEY([ID_Tarjeta_Credito])
REFERENCES [LOS_NULL].[Tarjeta] ([ID_Tarjeta])
GO
ALTER TABLE [LOS_NULL].[Factura] CHECK CONSTRAINT [FK_Factura_Tarjeta]
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
CREATE PROCEDURE [LOS_NULL].[GETALLTARJETAS]
	
AS
BEGIN
	
	SELECT *
	FROM LOS_NULL.Tarjeta
	
END
GO