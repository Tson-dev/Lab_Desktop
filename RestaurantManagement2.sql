USE [master]
GO
/****** Object:  Database [RestaurantManagement]    Script Date: 11/12/2025 1:07:22 PM ******/
CREATE DATABASE [RestaurantManagement]
GO
USE [RestaurantManagement]
GO
/****** Object:  UserDefinedFunction [dbo].[Cal_Subtotal]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create function [dbo].[Cal_Subtotal]
(
	@InvoiceID int
)
returns int
as
begin
	return (
		Select SUM(Details.Price * Details.Quantity)
		from dbo.InvoiceDetails as Details
		where Details.InvoiceID = @InvoiceID
	);
end
GO
/****** Object:  UserDefinedFunction [dbo].[Total]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Total]
(
    @InvoiceID INT
)
RETURNS int
AS
BEGIN
    DECLARE @Subtotal int;
    DECLARE @TaxRate FLOAT;
    DECLARE @DiscountRate FLOAT;
	declare @TotalTax int

	set @Subtotal = [dbo].[Cal_Subtotal](@InvoiceID);

    SELECT 
        @TaxRate = ISNULL(Inv.Tax, 0),
        @DiscountRate = ISNULL(Inv.Discount, 0)
    FROM dbo.Invoice AS Inv
    WHERE Inv.ID = @InvoiceID;

    SET @TotalTax = @Subtotal + @Subtotal / 100 * @TaxRate;

    RETURN @TotalTax - @TotalTax / 100 * @DiscountRate;
END
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[FullName] [nvarchar](1000) NOT NULL,
	[Email] [nvarchar](1000) NULL,
	[Phone] [nvarchar](200) NOT NULL,
	[DateCreated] [smalldatetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Unit] [nvarchar](100) NOT NULL,
	[FoodCategoryID] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Notes] [nvarchar](3000) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hall]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hall](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NULL,
	[RestaurantID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[TableID] [int] NOT NULL,
	[Total] [int] NOT NULL,
	[Discount] [float] NULL,
	[Tax] [float] NULL,
	[Status] [int] NOT NULL,
	[Account] [nvarchar](100) NOT NULL,
	[CheckoutDate] [smalldatetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[FoodID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restaurant]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurant](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Address] [nvarchar](3000) NOT NULL,
	[Phone] [nvarchar](100) NOT NULL,
	[Website] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](1000) NOT NULL,
	[Path] [nvarchar](3000) NULL,
	[Notes] [nvarchar](3000) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleAccount]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAccount](
	[AccountName] [nvarchar](100) NOT NULL,
	[RoleID] [int] NOT NULL,
	[Actived] [bit] NOT NULL,
	[Notes] [nvarchar](3000) NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountName] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TableCode] [nvarchar](200) NOT NULL,
	[Name] [nvarchar](1000) NULL,
	[Status] [int] NOT NULL,
	[Seats] [int] NULL,
	[HallID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Phone], [DateCreated]) VALUES (N'accountant', N'123', N'Lê Văn Kế Toán', N'accountant@res.com', N'0900000003', CAST(N'2025-10-29T17:12:00' AS SmallDateTime))
GO
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Phone], [DateCreated]) VALUES (N'admin', N'123', N'Nguyễn Văn Admin', N'admin@res.com', N'0900000001', CAST(N'2025-10-29T17:12:00' AS SmallDateTime))
GO
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Phone], [DateCreated]) VALUES (N'manager', N'123', N'Trần Thị Quản Lý', N'manager@res.com', N'0900000002', CAST(N'2025-10-29T17:12:00' AS SmallDateTime))
GO
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Phone], [DateCreated]) VALUES (N'staff', N'123', N'Phạm Thị Nhân Viên', N'staff@res.com', N'0900000004', CAST(N'2025-10-29T17:12:00' AS SmallDateTime))
GO
INSERT [dbo].[Account] ([AccountName], [Password], [FullName], [Email], [Phone], [DateCreated]) VALUES (N'Tie', N'123', N'Tien', N'T@gmail.com', N'098765432', CAST(N'2025-11-06T08:26:00' AS SmallDateTime))
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (1, N'Món chính', 1)
GO
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (2, N'Nước uống', 0)
GO
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (3, N'Gà', 1)
GO
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (4, N'Cơm', 1)
GO
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (5, N'Thịt', 1)
GO
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (6, N'Rau', 1)
GO
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (8, N'Canh', 1)
GO
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (9, N'Lẩu', 1)
GO
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (10, N'Bia', 0)
GO
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (11, N'Nước ngọt', 0)
GO
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (12, N'Cà phê', 0)
GO
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (13, N'Trà đá', 0)
GO
INSERT [dbo].[Category] ([ID], [Name], [Type]) VALUES (14, N'aa', 0)
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 
GO
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (1, N'Cơm chiên hải sản', N'Đĩa', 1, 50000, N'Món phổ biến')
GO
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (2, N'Bò lúc lắc', N'Đĩa', 1, 75000, N'Món đặc biệt')
GO
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (3, N'Nước cam', N'Ly', 2, 25000, N'Tươi mát')
GO
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (4, N'Coca-Cola', N'Lon', 2, 20000, N'Đồ uống phổ thông')
GO
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (6, N'Càng cua hấp', N'Đĩa', 2, 100000, NULL)
GO
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (7, N'Canh cải', N'Tô', 8, 20000, NULL)
GO
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (8, N'Gà nướng muối ớt', N'Con', 3, 180000, NULL)
GO
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (9, N'Bia 333', N'Chai', 10, 12000, NULL)
GO
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (10, N'Bia Heniken', N'Chai', 10, 20000, NULL)
GO
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (11, N'Súp cua', N'Tô', 1, 15000, NULL)
GO
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (12, N'Thịt kho', N'Đĩa', 5, 25000, N'Theo thời giá')
GO
INSERT [dbo].[Food] ([ID], [Name], [Unit], [FoodCategoryID], [Price], [Notes]) VALUES (14, N'bb', N'cc', 14, 3636, N'werty')
GO
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[Hall] ON 
GO
INSERT [dbo].[Hall] ([ID], [Name], [RestaurantID]) VALUES (1, N'Sảnh 1', 1)
GO
INSERT [dbo].[Hall] ([ID], [Name], [RestaurantID]) VALUES (2, N'Sảnh 2', 1)
GO
INSERT [dbo].[Hall] ([ID], [Name], [RestaurantID]) VALUES (3, N'Sảnh VIP', 2)
GO
SET IDENTITY_INSERT [dbo].[Hall] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 
GO
INSERT [dbo].[Invoice] ([ID], [Name], [TableID], [Total], [Discount], [Tax], [Status], [Account], [CheckoutDate]) VALUES (1, N'Hóa đơn bàn VIP 1', 1, 125000, 0, 10, 1, N'admin', CAST(N'2025-10-29T17:12:00' AS SmallDateTime))
GO
INSERT [dbo].[Invoice] ([ID], [Name], [TableID], [Total], [Discount], [Tax], [Status], [Account], [CheckoutDate]) VALUES (2, N'Hóa đơn bàn 2 sảnh 1', 2, 78375, 5, 10, 0, N'nhanvien1', CAST(N'2024-10-28T17:12:00' AS SmallDateTime))
GO
SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceDetails] ON 
GO
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [FoodID], [Quantity], [Price]) VALUES (1, 1, 1, 2, 50000)
GO
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [FoodID], [Quantity], [Price]) VALUES (2, 1, 3, 1, 25000)
GO
INSERT [dbo].[InvoiceDetails] ([ID], [InvoiceID], [FoodID], [Quantity], [Price]) VALUES (3, 2, 2, 1, 75000)
GO
SET IDENTITY_INSERT [dbo].[InvoiceDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Restaurant] ON 
GO
INSERT [dbo].[Restaurant] ([ID], [Name], [Address], [Phone], [Website]) VALUES (1, N'Nhà hàng Biển Xanh', N'123 Nguyễn Huệ, TP. HCM', N'0901234567', N'www.bienxanh.vn')
GO
INSERT [dbo].[Restaurant] ([ID], [Name], [Address], [Phone], [Website]) VALUES (2, N'Nhà hàng Hoa Mai', N'45 Lê Lợi, Đà Nẵng', N'0907654321', N'www.hoamai.com')
GO
SET IDENTITY_INSERT [dbo].[Restaurant] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (1, N'Admin', NULL, N'Toàn quyền hệ thống')
GO
INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (2, N'Quản lý', NULL, N'Quản lý nhân viên, thực đơn, doanh thu')
GO
INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (3, N'Kế toán', N'', N'Theo dõi hóa đơn')
GO
INSERT [dbo].[Role] ([ID], [RoleName], [Path], [Notes]) VALUES (4, N'Nhân viên', NULL, N'Nhân viên phục vụ, nhập hóa đơn')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[RoleAccount] ([AccountName], [RoleID], [Actived], [Notes]) VALUES (N'accountant', 3, 1, N'Theo dõi doanh thu')
GO
INSERT [dbo].[RoleAccount] ([AccountName], [RoleID], [Actived], [Notes]) VALUES (N'admin', 1, 1, N'Toàn quyền hệ thống')
GO
INSERT [dbo].[RoleAccount] ([AccountName], [RoleID], [Actived], [Notes]) VALUES (N'manager', 2, 1, N'Quản lý chính nhà hàng')
GO
INSERT [dbo].[RoleAccount] ([AccountName], [RoleID], [Actived], [Notes]) VALUES (N'staff', 4, 0, N'Nhân viên phục vụ')
GO
INSERT [dbo].[RoleAccount] ([AccountName], [RoleID], [Actived], [Notes]) VALUES (N'Tie', 4, 1, N'')
GO
SET IDENTITY_INSERT [dbo].[Table] ON 
GO
INSERT [dbo].[Table] ([ID], [TableCode], [Name], [Status], [Seats], [HallID]) VALUES (1, N'B1.01', N'Bàn VIP 1', 0, 10, 3)
GO
INSERT [dbo].[Table] ([ID], [TableCode], [Name], [Status], [Seats], [HallID]) VALUES (2, N'B1.02', N'Bàn Khách 2', 1, 6, 1)
GO
INSERT [dbo].[Table] ([ID], [TableCode], [Name], [Status], [Seats], [HallID]) VALUES (3, N'B2.01', N'Bàn 1 Sảnh 2', 2, 8, 2)
GO
SET IDENTITY_INSERT [dbo].[Table] OFF
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT (N'Chưa đặt tên') FOR [Name]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT (N'Chưa đặt tên') FOR [Name]
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Hall] ADD  DEFAULT (N'Chưa đặt tên') FOR [Name]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT (N'Hóa đơn chưa thanh toán') FOR [Name]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ((0)) FOR [Total]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ((0)) FOR [Tax]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT (getdate()) FOR [CheckoutDate]
GO
ALTER TABLE [dbo].[InvoiceDetails] ADD  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[InvoiceDetails] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Restaurant] ADD  DEFAULT (N'Chưa đặt tên') FOR [Name]
GO
ALTER TABLE [dbo].[Restaurant] ADD  DEFAULT (N'Chưa có địa chỉ') FOR [Address]
GO
ALTER TABLE [dbo].[Restaurant] ADD  DEFAULT (N'02633…') FOR [Phone]
GO
ALTER TABLE [dbo].[RoleAccount] ADD  DEFAULT ((1)) FOR [Actived]
GO
ALTER TABLE [dbo].[Table] ADD  DEFAULT (N'Không đặt tên') FOR [Name]
GO
ALTER TABLE [dbo].[Table] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([FoodCategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([FoodCategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Hall]  WITH CHECK ADD FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurant] ([ID])
GO
ALTER TABLE [dbo].[Hall]  WITH CHECK ADD FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurant] ([ID])
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD FOREIGN KEY([TableID])
REFERENCES [dbo].[Table] ([ID])
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD FOREIGN KEY([TableID])
REFERENCES [dbo].[Table] ([ID])
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD FOREIGN KEY([FoodID])
REFERENCES [dbo].[Food] ([ID])
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD FOREIGN KEY([FoodID])
REFERENCES [dbo].[Food] ([ID])
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoice] ([ID])
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoice] ([ID])
GO
ALTER TABLE [dbo].[RoleAccount]  WITH CHECK ADD FOREIGN KEY([AccountName])
REFERENCES [dbo].[Account] ([AccountName])
GO
ALTER TABLE [dbo].[RoleAccount]  WITH CHECK ADD FOREIGN KEY([AccountName])
REFERENCES [dbo].[Account] ([AccountName])
GO
ALTER TABLE [dbo].[RoleAccount]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[RoleAccount]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[Table]  WITH CHECK ADD FOREIGN KEY([HallID])
REFERENCES [dbo].[Hall] ([ID])
GO
ALTER TABLE [dbo].[Table]  WITH CHECK ADD FOREIGN KEY([HallID])
REFERENCES [dbo].[Hall] ([ID])
GO
/****** Object:  StoredProcedure [dbo].[Account_GetAll]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_GetAll]
AS
BEGIN
    SELECT * FROM Account;
END;
GO
/****** Object:  StoredProcedure [dbo].[Account_InsertUpdateDelete]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Account_InsertUpdateDelete]
    @AccountName NVARCHAR(100),
    @Password NVARCHAR(200),
    @FullName NVARCHAR(1000),
    @Email NVARCHAR(1000),
    @Phone NVARCHAR(200),
    @Action INT
AS
BEGIN
    IF (@Action = 0) -- INSERT
    BEGIN
        INSERT INTO Account (AccountName, Password, FullName, Email, Phone)
        VALUES (@AccountName, @Password, @FullName, @Email, @Phone);
    END
    ELSE IF (@Action = 1) -- UPDATE
    BEGIN
        UPDATE Account
        SET Password = @Password,
            FullName = @FullName,
            Email = @Email,
            Phone = @Phone
        WHERE AccountName = @AccountName;
    END
    ELSE IF (@Action = 2) -- DELETE
    BEGIN
		DELETE FROM RoleAccount WHERE AccountName = @AccountName;
        DELETE FROM Account WHERE AccountName = @AccountName;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[Category_GetAll]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Category_GetAll]
As
	Select * From Category

GO
/****** Object:  StoredProcedure [dbo].[Category_InsertUpdateDelete]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Category_InsertUpdateDelete]
	@ID int Output,
	@Name nvarchar(200),
	@Type int,
	@Action int
As
	If @Action = 0
		Begin
			Insert Into [Category] ([Name],[Type]) 
			Values (@Name, @Type)
			Set @ID = @@IDENTITY
		End
	Else If @Action = 1
		Begin
			Update [Category] Set [Name] = @Name, [Type] = @Type
			Where ID = @ID
		End
	Else If @Action = 2
		Begin
			Delete From Category Where ID = @ID
		End
GO
/****** Object:  StoredProcedure [dbo].[Food_GetAll]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Food_GetAll]
As
	Select * From Food

GO
/****** Object:  StoredProcedure [dbo].[Food_InsertUpdateDelete]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[Food_InsertUpdateDelete]
	@ID int output,
	@Name nvarchar(1000),
	@Unit nvarchar(100),
	@FoodCategoryID int,
	@Price int,
	@Notes nvarchar(3000),
	@Action int
As
	If @Action = 0
		Begin
			Insert Into [Food] ([Name],[Unit],[FoodCategoryID],[Price],[Notes])
			Values (@Name, @Unit, @FoodCategoryID, @Price, @Notes)
			Set @ID = @@IDENTITY
		End
	Else If @Action = 1
		Begin
			Update [Food]
			Set [Name] = @Name, [Unit] = @Unit, [FoodCategoryID] = @FoodCategoryID, [Price] = @Price, [Notes] = @Notes
			Where [ID] = @ID
		End
	Else if @Action = 2
		Begin
			Delete from [Food] where [ID] = @ID
	End
GO
/****** Object:  StoredProcedure [dbo].[Hall_GetAll]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create  Proc [dbo].[Hall_GetAll]
As
	Select * from Hall
GO
/****** Object:  StoredProcedure [dbo].[Hall_InsertUpdateDelete]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Hall_InsertUpdateDelete]
    @ID INT OUTPUT,
    @Name NVARCHAR(1000),
    @RestaurantID INT,
    @Action INT
AS
BEGIN
    IF @Action = 0
    BEGIN
        INSERT INTO Hall ([Name], [RestaurantID])
        VALUES (@Name, @RestaurantID)
        SET @ID = SCOPE_IDENTITY()
    END
    ELSE IF @Action = 1
    BEGIN
        UPDATE Hall
        SET [Name] = @Name,
            [RestaurantID] = @RestaurantID
        WHERE [ID] = @ID
    END
    ELSE IF @Action = 2
    BEGIN
        DELETE FROM Hall
        WHERE [ID] = @ID
    END
END
GO
/****** Object:  StoredProcedure [dbo].[InsertFood]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[InsertFood]
	@ID int Output,
	@Name nvarchar(3000), 
	@Unit nvarchar(3000), 
	@FoodCategoryID int, 
	@Price int,  
	@Notes nvarchar(3000)
As
	Insert Into Food (Name, Unit, FoodCategoryID, Price,  Notes)
	Values ( @Name, @Unit, @FoodCategoryID, @Price,  @Notes)

	Select @ID = Scope_Identity()

GO
/****** Object:  StoredProcedure [dbo].[Invoice_Checkout]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Invoice_Checkout]
    @InvoiceID INT,
    @Discount FLOAT,
    @Tax FLOAT,
    @PaidAmount FLOAT,
    @Account NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN
    BEGIN TRY
        DECLARE @Total FLOAT;
        SELECT @Total = SUM(Quantity * Price) FROM InvoiceDetails WHERE InvoiceID = @InvoiceID;

        IF @Total IS NULL SET @Total = 0;

        SET @Total = @Total - ISNULL(@Discount,0) + ISNULL(@Tax, 0);

        UPDATE Invoice
        SET Total = @Total, Discount = ISNULL(@Discount,0), Tax = ISNULL(@Tax,0), Status = 1, Account = @Account, CheckoutDate = GETDATE()
        WHERE ID = @InvoiceID;

        -- set table status empty (assume one invoice per table active)
        DECLARE @TableID INT;
        SELECT @TableID = TableID FROM Invoice WHERE ID = @InvoiceID;
        IF @TableID IS NOT NULL
            UPDATE [Table] Set Status = N'Trống' WHERE ID = @TableID;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[Invoice_CreateForTable]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Invoice_CreateForTable]
    @TableID INT,
    @Account NVARCHAR(100),
    @NewInvoiceID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN
    BEGIN TRY
        INSERT INTO Invoice(Name, TableID, Total, Discount, Tax, Status, Account, CheckoutDate)
        VALUES(CONCAT(N'HĐ_', @TableID,'_',REPLACE(CONVERT(VARCHAR(23), GETDATE(), 121),':','-')), @TableID, 0, 0, 0, 0, @Account, GETDATE());
        SET @NewInvoiceID = SCOPE_IDENTITY();

        UPDATE [Table] SET Status = N'Có khách' WHERE ID = @TableID;

        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[Invoice_GetAll]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Invoice_GetAll]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT i.*, t.Name AS TableName, a.FullName AS AccountName
    FROM Invoice i
    LEFT JOIN [Table] t ON i.TableID = t.ID
    LEFT JOIN Account a ON i.Account = a.AccountName;
END;
GO
/****** Object:  StoredProcedure [dbo].[Invoice_GetByDate]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Invoice_GetByDate]
	@From smallDateTime,
	@To smallDateTime,
	@Action int
As
Begin
	If @Action = 1
	Begin
		Set @To = GETDATE();
	End
	Else if @Action = 2
	Begin
		Select @From = MIN(CheckoutDate)
		From [dbo].[Invoice];
	End
		Select *
		From Invoice
		Where CheckoutDate between @From and @To
		Order by CheckoutDate asc;
End
GO
/****** Object:  StoredProcedure [dbo].[Invoice_InsertUpdateDelete]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Invoice_InsertUpdateDelete]
    @ID INT,
    @Name NVARCHAR(500),
    @TableID INT,
    @Total FLOAT,
    @Discount FLOAT,
    @Tax FLOAT,
    @Status INT,
    @Account NVARCHAR(100),
    @CheckoutDate SMALLDATETIME,
    @Action INT  -- 0: Insert, 1: Update, 2: Delete
AS
BEGIN
    SET NOCOUNT ON;
    IF @Action = 0
    BEGIN
        INSERT INTO Invoice (Name, TableID, Total, Discount, Tax, Status, Account, CheckoutDate)
        VALUES (@Name, @TableID, @Total, @Discount, @Tax, @Status, @Account, @CheckoutDate);

        SELECT SCOPE_IDENTITY() AS NewID;
    END
    ELSE IF @Action = 1
    BEGIN
        UPDATE Invoice
        SET Name=@Name, TableID=@TableID, Total=@Total, Discount=@Discount, Tax=@Tax,
            Status=@Status, Account=@Account, CheckoutDate=@CheckoutDate
        WHERE ID=@ID;
    END
    ELSE IF @Action = 2
    BEGIN
        DELETE FROM Invoice WHERE ID=@ID;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[InvoiceDetail_DeleteByInvoiceID]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InvoiceDetail_DeleteByInvoiceID]
    @InvoiceID INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM InvoiceDetails WHERE InvoiceID = @InvoiceID;
END;
GO
/****** Object:  StoredProcedure [dbo].[InvoiceDetail_GetByInvoiceID]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InvoiceDetail_GetByInvoiceID]
    @InvoiceID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        d.ID,
        d.InvoiceID,
        d.FoodID,
        f.Name AS FoodName,
        d.Quantity,
        d.Price
    FROM InvoiceDetails d
    INNER JOIN Food f ON d.FoodID = f.ID
    WHERE d.InvoiceID = @InvoiceID;
END;
GO
/****** Object:  StoredProcedure [dbo].[InvoiceDetail_InsertUpdateDelete]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InvoiceDetail_InsertUpdateDelete]
    @ID INT,
    @InvoiceID INT,
    @FoodID INT,
    @Quantity INT,
    @Price FLOAT,
    @Action INT -- 0: Insert, 1: Update, 2: Delete
AS
BEGIN
    SET NOCOUNT ON;
    IF @Action = 0
    BEGIN
        INSERT INTO InvoiceDetails(InvoiceID, FoodID, Quantity, Price)
        VALUES(@InvoiceID, @FoodID, @Quantity, @Price);
    END
    ELSE IF @Action = 1
    BEGIN
        UPDATE InvoiceDetails
        SET FoodID=@FoodID, Quantity=@Quantity, Price=@Price
        WHERE ID=@ID;
    END
    ELSE IF @Action = 2
    BEGIN
        DELETE FROM InvoiceDetails WHERE ID=@ID;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[Restaurant_GetAll]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Restaurant_GetAll]
as
begin
select * from dbo.Restaurant
end
GO
/****** Object:  StoredProcedure [dbo].[Restaurant_InsertUpdateDelete]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Restaurant_InsertUpdateDelete]
    @ID INT OUTPUT,
    @Name NVARCHAR(1000),
    @Address NVARCHAR(3000),
    @Phone NVARCHAR(100),
    @Website NVARCHAR(1000),
    @Action INT
AS
BEGIN
    IF @Action = 0
    BEGIN
        INSERT INTO Restaurant ([Name],[Address],[Phone],[Website])
        VALUES (@Name,@Address,@Phone,@Website)
        SET @ID = @@IDENTITY
    END
    ELSE IF @Action = 1
    BEGIN
        UPDATE Restaurant
        SET [Name] = @Name, [Address] = @Address, [Phone] = @Phone, [Website] = @Website
        WHERE [ID] = @ID
    END
    ELSE IF @Action = 2
    BEGIN
        DELETE FROM Restaurant WHERE [ID] = @ID
    END
END
GO
/****** Object:  StoredProcedure [dbo].[Role_GetAll]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_GetAll]
AS
BEGIN
    SELECT * FROM Role;
END;
GO
/****** Object:  StoredProcedure [dbo].[Role_InsertUpdateDelete]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_InsertUpdateDelete]
    @ID INT,
    @RoleName NVARCHAR(1000),
    @Path NVARCHAR(3000),
    @Notes NVARCHAR(3000),
    @Action INT
AS
BEGIN
    IF (@Action = 0) -- INSERT
    BEGIN
        INSERT INTO Role (RoleName, Path, Notes)
        VALUES (@RoleName, @Path, @Notes);
    END
    ELSE IF (@Action = 1) -- UPDATE
    BEGIN
        UPDATE Role
        SET RoleName = @RoleName,
            Path = @Path,
            Notes = @Notes
        WHERE ID = @ID;
    END
    ELSE IF (@Action = 2) -- DELETE
    BEGIN
        DELETE FROM Role WHERE ID = @ID;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[RoleAccount_GetAll]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleAccount_GetAll]
AS
BEGIN
    SELECT 
        ra.AccountName,
        ra.RoleID,
        a.FullName,
        r.RoleName,
        ra.Actived,
        ra.Notes
    FROM RoleAccount ra
    INNER JOIN Account a ON ra.AccountName = a.AccountName
    INNER JOIN Role r ON ra.RoleID = r.ID;
END;
GO
/****** Object:  StoredProcedure [dbo].[RoleAccount_GetByAccountName]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RoleAccount_GetByAccountName]
    @AccountName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ra.AccountName,
        ra.RoleID,
        r.RoleName,
        ra.Actived,
        ra.Notes
    FROM RoleAccount ra
    INNER JOIN Role r ON ra.RoleID = r.ID
    WHERE ra.AccountName = @AccountName;
END
GO
/****** Object:  StoredProcedure [dbo].[RoleAccount_InsertUpdateDelete]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleAccount_InsertUpdateDelete]
    @AccountName NVARCHAR(100),
    @RoleID INT,
    @Actived BIT,
    @Notes NVARCHAR(3000),
    @Action INT
AS
BEGIN
    IF (@Action = 0)
    BEGIN
        INSERT INTO RoleAccount (AccountName, RoleID, Actived, Notes)
        VALUES (@AccountName, @RoleID, @Actived, @Notes);
    END
    ELSE IF (@Action = 1)
    BEGIN
        UPDATE RoleAccount
        SET Actived = @Actived,
            Notes = @Notes
        WHERE AccountName = @AccountName AND RoleID = @RoleID;
    END
    ELSE IF (@Action = 2)
    BEGIN
        DELETE FROM RoleAccount WHERE AccountName = @AccountName AND RoleID = @RoleID;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[Table_GetAll]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[Table_GetAll]
As
Select * from [Table]
GO
/****** Object:  StoredProcedure [dbo].[Table_InsertUpdateDelete]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Table_InsertUpdateDelete]
    @ID INT OUTPUT,
    @TableCode NVARCHAR(200),
    @Name NVARCHAR(1000),
    @Status INT,
    @Seats INT,
    @HallID INT,
    @Action INT
AS
BEGIN
    IF @Action = 0
    BEGIN
        INSERT INTO [Table] (TableCode, Name, Status, Seats, HallID)
        VALUES (@TableCode, @Name, @Status, @Seats, @HallID)
        SET @ID = @@IDENTITY
    END
    ELSE IF @Action = 1
    BEGIN
        UPDATE [Table]
        SET TableCode = @TableCode,
            Name = @Name,
            Status = @Status,
            Seats = @Seats,
            HallID = @HallID
        WHERE ID = @ID
    END
    ELSE IF @Action = 2
    BEGIN
        DELETE FROM [Table] WHERE ID = @ID
    END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateFood]    Script Date: 11/12/2025 1:07:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateFood]
	@ID int,
	@Name nvarchar(1000),
	@Unit nvarchar(100),
	@FoodCategoryID int,
	@Price int,
	@Notes nvarchar(3000)
As
	Update [Food]
	Set
		[Name] = @Name,
		[Unit] = @Unit,
		[FoodCategoryID] = @FoodCategoryID,
		[Price] = @Price,
		[Notes] = @Notes
	Where ID = @ID

	If @@Error <> 0
		Return 0
	Else
		Return 1
GO
USE [master]
GO
ALTER DATABASE [RestaurantManagement] SET  READ_WRITE 
GO
