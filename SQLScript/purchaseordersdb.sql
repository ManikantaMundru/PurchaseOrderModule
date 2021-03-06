USE [PurchaseOrders]
GO
/****** Object:  Table [dbo].[tblProductOrders]    Script Date: 2019/10/07 02:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProductOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseOrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_tblProductOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProducts]    Script Date: 2019/10/07 02:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Price] [money] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tblProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPurchaseOrders]    Script Date: 2019/10/07 02:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPurchaseOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[OrderCode] [nvarchar](10) NOT NULL,
	[OrderDescription] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[TotalPrice] [money] NULL,
 CONSTRAINT [PK_tblPurchaseOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSuppliers]    Script Date: 2019/10/07 02:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSuppliers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tblSuppliers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblProducts] ADD  CONSTRAINT [DF_tblProducts_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblPurchaseOrders] ADD  CONSTRAINT [DF_tblPurchaseOrders_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblSuppliers] ADD  CONSTRAINT [DF_tblSuppliers_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tblProductOrders]  WITH CHECK ADD  CONSTRAINT [FK_tblProductOrders_tblPurchaseOrders] FOREIGN KEY([PurchaseOrderId])
REFERENCES [dbo].[tblPurchaseOrders] ([Id])
GO
ALTER TABLE [dbo].[tblProductOrders] CHECK CONSTRAINT [FK_tblProductOrders_tblPurchaseOrders]
GO
ALTER TABLE [dbo].[tblProductOrders]  WITH CHECK ADD  CONSTRAINT [FK_tblProductOrders_tblPurchaseOrders_ProductID] FOREIGN KEY([ProductId])
REFERENCES [dbo].[tblProducts] ([Id])
GO
ALTER TABLE [dbo].[tblProductOrders] CHECK CONSTRAINT [FK_tblProductOrders_tblPurchaseOrders_ProductID]
GO
ALTER TABLE [dbo].[tblProducts]  WITH CHECK ADD  CONSTRAINT [FK_TblProducts_TblSuppliers] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[tblSuppliers] ([Id])
GO
ALTER TABLE [dbo].[tblProducts] CHECK CONSTRAINT [FK_TblProducts_TblSuppliers]
GO
ALTER TABLE [dbo].[tblPurchaseOrders]  WITH CHECK ADD  CONSTRAINT [FK_tblPurchaseOrders_tblSuppliers] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[tblSuppliers] ([Id])
GO
ALTER TABLE [dbo].[tblPurchaseOrders] CHECK CONSTRAINT [FK_tblPurchaseOrders_tblSuppliers]
GO
/****** Object:  StoredProcedure [dbo].[spAddProduct]    Script Date: 2019/10/07 02:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[spAddProduct] 

@Name nvarchar(100),
@Code nvarchar(10),
@Price Money,
@Description nvarchar(max),
@SupplierId int

AS
BEGIN

SET NOCOUNT ON;

INSERT Into tblProducts(
 Name, Description, Code, Price, SupplierId
 ) 
values (
@Name, @Description, @Code, @Price, @SupplierId
)

END
GO
/****** Object:  StoredProcedure [dbo].[spAddProductOrders]    Script Date: 2019/10/07 02:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[spAddProductOrders] 

@PurchaseOrderId int,
@ProductId int,
@Quantity int

AS
BEGIN

SET NOCOUNT ON;

INSERT Into tblProductOrders(
PurchaseOrderId, ProductId, Quantity
 ) 
values (
@PurchaseOrderId, @ProductId, @Quantity
)

END
GO
/****** Object:  StoredProcedure [dbo].[spAddPurchaseOrder]    Script Date: 2019/10/07 02:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddPurchaseOrder] 

@SupplierId int,
@OrderCode nvarchar(10),
@OrderDescription nvarchar(max),
@TotalPrice money

AS
BEGIN

SET NOCOUNT ON;

INSERT Into tblPurchaseOrders(
SupplierId, OrderCode, OrderDescription, TotalPrice
 ) 
values (
@SupplierId, @OrderCode, @OrderDescription, @TotalPrice
)

SELECT SCOPE_IDENTITY() as PurchaseOrderId

END
GO
/****** Object:  StoredProcedure [dbo].[spAddSupplier]    Script Date: 2019/10/07 02:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddSupplier] 

@Name nvarchar(100)

AS
BEGIN

SET NOCOUNT ON;

INSERT Into tblSuppliers (Name) values (@Name)

END
GO
/****** Object:  StoredProcedure [dbo].[spGetProducts]    Script Date: 2019/10/07 02:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetProducts]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT  TP.Id,
	        TP.Name,
			TP.Code,
			TP.Price,
			TP.Description,
			TP.SupplierId,
			TS.Name as SupplierName
  FROM tblProducts TP
  INNER JOIN tblSuppliers TS ON TP.SupplierId = TS.Id
  order by TP.CreatedDate DESC

END
GO
/****** Object:  StoredProcedure [dbo].[spGetProductsBySupplierId]    Script Date: 2019/10/07 02:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spGetProductsBySupplierId]

@SupplierId int

AS

BEGIN

	SET NOCOUNT ON;

    SELECT  TP.Id,
	        TP.Name,
			TP.Code,
			TP.Price,
			TP.Description,
			TP.SupplierId,
			TS.Name as SupplierName
  FROM tblProducts TP
  INNER JOIN tblSuppliers TS ON TP.SupplierId = TS.Id
  where TP.SupplierId = @SupplierId

END
GO
/****** Object:  StoredProcedure [dbo].[spGetPurchaseOrderProducts]    Script Date: 2019/10/07 02:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spGetPurchaseOrderProducts]
@PurchaseOrderId int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT  TPS.OrderCode,
			TPS.OrderDescription,
			TPS.TotalPrice,
			TPO.Id,
	        TPO.PurchaseOrderId,
			TPO.Quantity,
			TPO.ProductId,
			TP.Name as ProductName,
			TP.Price as UnitPrice,
			TP.SupplierId					
  FROM tblProductOrders TPO
  INNER JOIN tblProducts TP ON TPO.ProductId = TP. Id
  INNER JOIN tblSuppliers TS ON TP.SupplierId = TS.Id
  INNER JOIN tblPurchaseOrders TPS ON TPO.PurchaseOrderId = TPS.Id
  where TPO.PurchaseOrderId = @PurchaseOrderId

END
GO
/****** Object:  StoredProcedure [dbo].[spGetPurchaseOrders]    Script Date: 2019/10/07 02:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetPurchaseOrders]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT  TP.Id,
	        TP.OrderCode,
			TP.OrderDescription,
			TP.CreatedDate,
			TP.TotalPrice,
			TP.SupplierId,
			TS.Name as SupplierName
  FROM tblPurchaseOrders TP
  INNER JOIN tblSuppliers TS ON TP.SupplierId = TS.Id
  Order by CreatedDate DESC

END
GO
/****** Object:  StoredProcedure [dbo].[spGetSuppliers]    Script Date: 2019/10/07 02:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetSuppliers] 


AS
BEGIN

SET NOCOUNT ON;

SELECT Id, Name, CreatedDate from tblSuppliers order by CreatedDate desc

END
GO
