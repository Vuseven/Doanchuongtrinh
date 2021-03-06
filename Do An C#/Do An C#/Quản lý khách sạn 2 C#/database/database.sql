USE [qlks3lop]
GO
/****** Object:  Table [dbo].[dichvu]    Script Date: 04/14/2011 23:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dichvu](
	[madichvu] [varchar](10) NOT NULL,
	[tendichvu] [nvarchar](50) NULL,
	[gia] [money] NULL,
	[donvitinh] [nchar](10) NULL,
 CONSTRAINT [PK_service] PRIMARY KEY CLUSTERED 
(
	[madichvu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_dichvu] ON [dbo].[dichvu] 
(
	[tendichvu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[dichvu] ([madichvu], [tendichvu], [gia], [donvitinh]) VALUES (N'A1', N'Điểm Tâm', 15000.0000, N'phần      ')
INSERT [dbo].[dichvu] ([madichvu], [tendichvu], [gia], [donvitinh]) VALUES (N'A2', N'Cơm trưa', 20000.0000, N'phần      ')
INSERT [dbo].[dichvu] ([madichvu], [tendichvu], [gia], [donvitinh]) VALUES (N'B1', N'Cocacola lon', 7000.0000, N'lon       ')
INSERT [dbo].[dichvu] ([madichvu], [tendichvu], [gia], [donvitinh]) VALUES (N'B2', N'Cocacola chai', 5000.0000, N'chai      ')
INSERT [dbo].[dichvu] ([madichvu], [tendichvu], [gia], [donvitinh]) VALUES (N'GU', N'Giặt Ủi', 5000.0000, N'kg        ')
INSERT [dbo].[dichvu] ([madichvu], [tendichvu], [gia], [donvitinh]) VALUES (N'LV', N'Lavie', 6000.0000, N'chai      ')
/****** Object:  Table [dbo].[khachhang]    Script Date: 04/14/2011 23:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[khachhang](
	[makhachhang] [varchar](10) NOT NULL,
	[tenkhachhang] [nvarchar](50) NULL,
	[gioitinh] [bit] NULL,
	[cmnd_passport] [varchar](10) NULL,
	[diachi] [nvarchar](100) NULL,
	[coquan] [nvarchar](50) NULL,
	[sodienthoai] [varchar](11) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Custumer] PRIMARY KEY CLUSTERED 
(
	[makhachhang] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'001', N'Nguyễn Minh Phương', 1, N'98765432', N'Long An', N'Long An', N'987654567', N'minhphuong12@sedff')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH00014', N'Thành Lương', 1, N'98765432', N'Long An', N'Long An', N'987654567', N'minhphuong12@sedff')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH001', N'Nguyễn Thị Mai', 0, N'3566767788', N'123 Lý Chính Thắng, Q.3', N'dfd', N'232323', N'mrjone_07@yahoo.com')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'kh0010', N'hung', 1, N'999990091', N'Lý Thường Kiệt, Quận 11', N'', N'0902685483', N'mrjone_07@yahoo.com')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH0013', N'Trọng Hoàng', 1, N'123456', N'Nghệ An', N'Sông LAm Nghệ An', N'43464', N'mrjone_07@yahoo.com')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH0018', N'Tâm', 1, N'2323434', N'Cao Lỗ', N'Cao Lỗ', N'012234', N'asasdsff')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH0019', N'Tý', 1, N'2323434', N'Cao Lỗ', N'Cao Lỗ', N'012234', N'asasdsff')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH002', N'Mai Xuân Hợp', 1, N'3566767788', N'123 Lý Chính Thắng, Q.3', N'dfd', N'232323', N'mrjone_07@yahoo.com')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH003', N'Trần Văn H', 1, N'6676', N'123 Lý Chính Thắng, Q.3', N'hghj', N'232323', N'mrjone_07@yahoo.com')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH004', N'Nguyễn Văn Lang', 1, N'123456789', N'Phạm Thế Hiển', N'Công An quận', N'234567', N'mrjone_07@yahoo.com')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'Kh005', N'Ngô Tâm Ca', 1, N'1234567', N'Âu Dương Lân', N'STU', N'23456', N'mrjone_07@yahoo.com')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH006', N'trần Thanh hậu', 0, N'12345678', N'Cao Lỗ', N'UTS', N'43', N'mrjone_07@yahoo.com')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH007', N'Vũ Huy Tuấn', 0, N'7654321', N'Lỗ Cao', N'abc', N'23412321', N'mrjone_07@yahoo.com')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH008', N'Nguyễn Thị CD', 0, N'3566767788', N'123 Lý Chính Thắng, Q.3', N'dfd', N'232323', N'mrjone_07@yahoo.com')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH009', N'Bùi Tú San', 0, N'23456789', N'Dương Bá Trạc', N'STU', N'2312313421', N'mrjone_07@yahoo.com')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH010', N'Thành mưu', 1, N'123456', N'Bình Thạnh', N'qwe', N'21312313', N'mrjone_07@yahoo.com')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH011', N'Nguyễn Văn A', 0, N'12345678', N'Cao van a', N'13123', N'23123123', N'mrjone_07@yahoo.com')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH012', N'Ngọc', 0, N'12345678', N'Cao Lỗ', N'UTS', N'43', N'mrjone_07@yahoo.com')
INSERT [dbo].[khachhang] ([makhachhang], [tenkhachhang], [gioitinh], [cmnd_passport], [diachi], [coquan], [sodienthoai], [email]) VALUES (N'KH100', N'Nguyễn Thị M', 0, N'3566767788', N'123 Lý Chính Thắng, Q.3', N'dfd', N'232323', N'mrjone_07@yahoo.com')
/****** Object:  Table [dbo].[nhanvien]    Script Date: 04/14/2011 23:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nhanvien](
	[manhanvien] [varchar](10) NOT NULL,
	[tennhanvien] [nvarchar](50) NULL,
	[ngaysinh] [datetime] NULL,
	[phai] [bit] NULL,
	[diachi] [nvarchar](100) NULL,
	[phone] [varchar](11) NULL,
	[chucvu] [nvarchar](50) NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[manhanvien] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[nhanvien] ([manhanvien], [tennhanvien], [ngaysinh], [phai], [diachi], [phone], [chucvu]) VALUES (N'admin', N'admin', CAST(0x0000803400000000 AS DateTime), 1, N'45/36/27/2 Cao Lỗ, P.4, Q.8', N'01267064050', N'admin')
INSERT [dbo].[nhanvien] ([manhanvien], [tennhanvien], [ngaysinh], [phai], [diachi], [phone], [chucvu]) VALUES (N'NV001', N'Lý Tuyết Mai', CAST(0x00007EF500000000 AS DateTime), 0, N'123 Lý Thường Kiệt, P.6, Q.5', N'098562898', N'Nhân viên')
INSERT [dbo].[nhanvien] ([manhanvien], [tennhanvien], [ngaysinh], [phai], [diachi], [phone], [chucvu]) VALUES (N'NV002', N'Nguyễn Thị Kiều Mai', CAST(0x0000726300000000 AS DateTime), 0, N'234 Lý Thái Tổ, Quận 1, TP Hồ Chí Minh', N'098562898', N'Nhân viên')
INSERT [dbo].[nhanvien] ([manhanvien], [tennhanvien], [ngaysinh], [phai], [diachi], [phone], [chucvu]) VALUES (N'NV003', N'Lý Thị Tuyết Sương', CAST(0x0000787D00000000 AS DateTime), 0, N'234 Lê Văn Lương, Quận 7, TP Hồ Chí Minh', N'098562898', N'Nhân viên')
INSERT [dbo].[nhanvien] ([manhanvien], [tennhanvien], [ngaysinh], [phai], [diachi], [phone], [chucvu]) VALUES (N'NV006', N'Nguyễn Thị Kim', CAST(0x0000726300000000 AS DateTime), 0, N'234 Lý Thái Tổ, Quận 1, TP Hồ Chí Minh', N'098562898', N'Nhân viên')
INSERT [dbo].[nhanvien] ([manhanvien], [tennhanvien], [ngaysinh], [phai], [diachi], [phone], [chucvu]) VALUES (N'NV007', N'Thái Hồng Hoa', CAST(0x0000851200C4B33C AS DateTime), 1, N'234 Lê Văn Sỹ, Quận 7, TP Hồ Chí Minh', N'098562898', N'Nhân viên')
INSERT [dbo].[nhanvien] ([manhanvien], [tennhanvien], [ngaysinh], [phai], [diachi], [phone], [chucvu]) VALUES (N'NV008', N'Thái Hồng Hoa', CAST(0x0000851200C1249A AS DateTime), 1, N'234 Lê Văn Sỹ, Quận 7, TP Hồ Chí Minh', N'098562898', N'Quản lý')
INSERT [dbo].[nhanvien] ([manhanvien], [tennhanvien], [ngaysinh], [phai], [diachi], [phone], [chucvu]) VALUES (N'NV0999', N'gan V A ', CAST(0x00007EF200000000 AS DateTime), 1, N'wswswsw', N'0907876426', N'Quản lý')
INSERT [dbo].[nhanvien] ([manhanvien], [tennhanvien], [ngaysinh], [phai], [diachi], [phone], [chucvu]) VALUES (N'QL005', N'Cao Văn Nam', CAST(0x0000724600000000 AS DateTime), 1, N'234 Lê Văn Lương, Quận 7, TP Hồ Chí Minh', N'098562898', N'Quản lý')
INSERT [dbo].[nhanvien] ([manhanvien], [tennhanvien], [ngaysinh], [phai], [diachi], [phone], [chucvu]) VALUES (N'QL009', N'Trần Thanh Hậu', CAST(0x0000803400000000 AS DateTime), 1, N'45//36/27/2 Cao Lỗ, Quận 8, TP Hồ Chí Minh', N'01267064050', N'Quản lý')
INSERT [dbo].[nhanvien] ([manhanvien], [tennhanvien], [ngaysinh], [phai], [diachi], [phone], [chucvu]) VALUES (N'QL010', N'Ngô Tâm Ca', CAST(0x00007F1800000000 AS DateTime), 1, N'Âu Dương Lân, Quận 8', N'123214242', N'Quản lý')
INSERT [dbo].[nhanvien] ([manhanvien], [tennhanvien], [ngaysinh], [phai], [diachi], [phone], [chucvu]) VALUES (N'QL011', N'Cao Văn Nam', CAST(0x0000724600000000 AS DateTime), 1, N'234 Lê Văn Lương, Quận 7, TP Hồ Chí Minh', N'098562898', N'Quản lý')
INSERT [dbo].[nhanvien] ([manhanvien], [tennhanvien], [ngaysinh], [phai], [diachi], [phone], [chucvu]) VALUES (N'trws', N'Lý Tuyết Mai', CAST(0x00007EF500000000 AS DateTime), 0, N'123 Lý Thường Kiệt, P.6, Q.5', N'098562898', N'Nhân viên')
/****** Object:  Table [dbo].[loaiphong]    Script Date: 04/14/2011 23:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaiphong](
	[maloai] [nvarchar](50) NOT NULL,
	[gia] [money] NULL,
	[songuoi] [int] NULL,
 CONSTRAINT [PK_loaiphong] PRIMARY KEY CLUSTERED 
(
	[maloai] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[loaiphong] ([maloai], [gia], [songuoi]) VALUES (N'Loại 1', 20000.0000, 3)
INSERT [dbo].[loaiphong] ([maloai], [gia], [songuoi]) VALUES (N'Loại 2', 30000.0000, 5)
INSERT [dbo].[loaiphong] ([maloai], [gia], [songuoi]) VALUES (N'Loại 3', 30000.0000, 2)
INSERT [dbo].[loaiphong] ([maloai], [gia], [songuoi]) VALUES (N'Loại 4', 30000.0000, 4)
/****** Object:  Table [dbo].[vattu]    Script Date: 04/14/2011 23:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[vattu](
	[mavattu] [varchar](10) NOT NULL,
	[tenvattu] [nvarchar](50) NULL,
 CONSTRAINT [PK_thietbi] PRIMARY KEY CLUSTERED 
(
	[mavattu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_vattu] ON [dbo].[vattu] 
(
	[tenvattu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[vattu] ([mavattu], [tenvattu]) VALUES (N'G2', N'Bàn ủi')
INSERT [dbo].[vattu] ([mavattu], [tenvattu]) VALUES (N'G4', N'Giường Đôi')
INSERT [dbo].[vattu] ([mavattu], [tenvattu]) VALUES (N'G1', N'Giường Đơn')
INSERT [dbo].[vattu] ([mavattu], [tenvattu]) VALUES (N'ML', N'Máy Lạnh')
INSERT [dbo].[vattu] ([mavattu], [tenvattu]) VALUES (N'QM', N'Quạt')
INSERT [dbo].[vattu] ([mavattu], [tenvattu]) VALUES (N'TV', N'Tivi')
INSERT [dbo].[vattu] ([mavattu], [tenvattu]) VALUES (N'TL', N'Tủ Lạnh')
/****** Object:  Table [dbo].[phieudatphong]    Script Date: 04/14/2011 23:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[phieudatphong](
	[maphieudat] [varchar](10) NOT NULL,
	[makhachhang] [varchar](10) NOT NULL,
	[ngayden] [datetime] NULL,
	[ngaydi] [datetime] NULL,
	[sotiendatcoc] [money] NULL,
	[username] [varchar](10) NULL,
	[tinhtrang] [varchar](10) NULL,
	[songuoi] [int] NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[maphieudat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[phieudatphong] ([maphieudat], [makhachhang], [ngayden], [ngaydi], [sotiendatcoc], [username], [tinhtrang], [songuoi]) VALUES (N'PDP001', N'001', CAST(0x00009EC50083C866 AS DateTime), CAST(0x00009EC50083C7F0 AS DateTime), 1.0000, NULL, N'finish', 1)
INSERT [dbo].[phieudatphong] ([maphieudat], [makhachhang], [ngayden], [ngaydi], [sotiendatcoc], [username], [tinhtrang], [songuoi]) VALUES (N'PDP002', N'001', CAST(0x00009EC60083C7F0 AS DateTime), CAST(0x00009EC60083C7F0 AS DateTime), 1.0000, N'admin', N'waitting', 1)
INSERT [dbo].[phieudatphong] ([maphieudat], [makhachhang], [ngayden], [ngaydi], [sotiendatcoc], [username], [tinhtrang], [songuoi]) VALUES (N'PDP003', N'001', CAST(0x00009ED30083C7F0 AS DateTime), CAST(0x00009ED30083C7F0 AS DateTime), 1.0000, N'admin', N'waitting', 1)
INSERT [dbo].[phieudatphong] ([maphieudat], [makhachhang], [ngayden], [ngaydi], [sotiendatcoc], [username], [tinhtrang], [songuoi]) VALUES (N'PDP004', N'001', CAST(0x00009EC500866BF7 AS DateTime), CAST(0x00009EC500866AF0 AS DateTime), 1.0000, NULL, N'finish', 1)
INSERT [dbo].[phieudatphong] ([maphieudat], [makhachhang], [ngayden], [ngaydi], [sotiendatcoc], [username], [tinhtrang], [songuoi]) VALUES (N'PDP005', N'001', CAST(0x00009EC600866AF0 AS DateTime), CAST(0x00009EC600866AF0 AS DateTime), 1.0000, N'admin', N'waitting', 1)
INSERT [dbo].[phieudatphong] ([maphieudat], [makhachhang], [ngayden], [ngaydi], [sotiendatcoc], [username], [tinhtrang], [songuoi]) VALUES (N'PDP006', N'001', CAST(0x00009EC5009DF67D AS DateTime), CAST(0x00009EC7009DF5E4 AS DateTime), 9.0000, NULL, N'finish', 8)
/****** Object:  Table [dbo].[phong]    Script Date: 04/14/2011 23:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[phong](
	[maphong] [varchar](10) NOT NULL,
	[maloai] [nvarchar](50) NOT NULL,
	[dadat] [bit] NULL,
	[danhan] [bit] NULL,
 CONSTRAINT [PK_phong] PRIMARY KEY CLUSTERED 
(
	[maphong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[phong] ([maphong], [maloai], [dadat], [danhan]) VALUES (N'A101', N'Loại 1', 1, 0)
INSERT [dbo].[phong] ([maphong], [maloai], [dadat], [danhan]) VALUES (N'A103', N'Loại 1', 1, 0)
INSERT [dbo].[phong] ([maphong], [maloai], [dadat], [danhan]) VALUES (N'A104', N'Loại 1', 0, 0)
INSERT [dbo].[phong] ([maphong], [maloai], [dadat], [danhan]) VALUES (N'A105', N'Loại 1', 0, 0)
INSERT [dbo].[phong] ([maphong], [maloai], [dadat], [danhan]) VALUES (N'A106', N'Loại 1', 0, 0)
INSERT [dbo].[phong] ([maphong], [maloai], [dadat], [danhan]) VALUES (N'A123', N'Loại 1', 0, 0)
INSERT [dbo].[phong] ([maphong], [maloai], [dadat], [danhan]) VALUES (N'A201', N'Loại 1', 0, 0)
INSERT [dbo].[phong] ([maphong], [maloai], [dadat], [danhan]) VALUES (N'B102', N'Loại 2', 0, 0)
INSERT [dbo].[phong] ([maphong], [maloai], [dadat], [danhan]) VALUES (N'B109', N'Loại 2', 0, 0)
INSERT [dbo].[phong] ([maphong], [maloai], [dadat], [danhan]) VALUES (N'C100', N'Loại 3', 0, 0)
/****** Object:  Table [dbo].[hethong]    Script Date: 04/14/2011 23:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[hethong](
	[username] [varchar](10) NOT NULL,
	[manhanvien] [varchar](10) NULL,
	[password] [varchar](200) NULL,
 CONSTRAINT [PK_system] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[hethong] ([username], [manhanvien], [password]) VALUES (N'13', N'NV0999', N'zqeEOWgRcj96TAoc2F9ZMA==')
INSERT [dbo].[hethong] ([username], [manhanvien], [password]) VALUES (N'14', N'NV002', N'1JCDCoEvFVVjWhqZLbiC0Q==')
INSERT [dbo].[hethong] ([username], [manhanvien], [password]) VALUES (N'22', N'NV007', N'fvLW1cHMM/uVVVoCwtxHVA==')
INSERT [dbo].[hethong] ([username], [manhanvien], [password]) VALUES (N'23', N'NV003', N'FEYGFeNjU4e/xj8TlOmL5w==')
INSERT [dbo].[hethong] ([username], [manhanvien], [password]) VALUES (N'32', N'QL005', N'4cwWSEQofDwvjXOoDqPzpA==')
INSERT [dbo].[hethong] ([username], [manhanvien], [password]) VALUES (N'56', N'NV008', N'fQ4xYaaorCR0Vos0V2FuMg==')
INSERT [dbo].[hethong] ([username], [manhanvien], [password]) VALUES (N'admin', N'admin', N'GaKFQUS2Oo92F6byJQGbEg==')
INSERT [dbo].[hethong] ([username], [manhanvien], [password]) VALUES (N'hau', N'QL009', N'mAOCaPJy0S6+XW8Hxfrvgg==')
INSERT [dbo].[hethong] ([username], [manhanvien], [password]) VALUES (N'kaka', N'QL010', N'HFhKJb5C6nVuucskSb5GoA==')
INSERT [dbo].[hethong] ([username], [manhanvien], [password]) VALUES (N'mai', N'NV001', N'NNPRNWH8/DhgVgrA//Qriw==')
INSERT [dbo].[hethong] ([username], [manhanvien], [password]) VALUES (N'nv', N'NV006', N'TcewUV4nlMUJM4w5Sflu1g==')
INSERT [dbo].[hethong] ([username], [manhanvien], [password]) VALUES (N'sas', N'QL011', N'MpT/WEH1CJSaxNcjzjbN7A==')
/****** Object:  StoredProcedure [dbo].[DanhsachNV]    Script Date: 04/14/2011 23:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DanhsachNV] 
	-- Add the parameters for the stored procedure here
	@chucvu nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @chucvu=N'Tất cả'
SELECT * FROM NHANVIEN order by chucvu
else
SELECT * FROM NHANVIEN WHERE chucvu=@CHUCVU order by chucvu
END
GO
/****** Object:  Table [dbo].[chitietvattu]    Script Date: 04/14/2011 23:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[chitietvattu](
	[mavattu] [varchar](10) NOT NULL,
	[maloaiphong] [nvarchar](50) NOT NULL,
	[soluong] [int] NULL,
 CONSTRAINT [PK_chitietvattu] PRIMARY KEY CLUSTERED 
(
	[mavattu] ASC,
	[maloaiphong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[chitietvattu] ([mavattu], [maloaiphong], [soluong]) VALUES (N'G1', N'Loại 1', 2)
INSERT [dbo].[chitietvattu] ([mavattu], [maloaiphong], [soluong]) VALUES (N'G1', N'Loại 3', 1)
INSERT [dbo].[chitietvattu] ([mavattu], [maloaiphong], [soluong]) VALUES (N'G1', N'Loại 4', 2)
INSERT [dbo].[chitietvattu] ([mavattu], [maloaiphong], [soluong]) VALUES (N'G2', N'Loại 1', 5)
INSERT [dbo].[chitietvattu] ([mavattu], [maloaiphong], [soluong]) VALUES (N'G2', N'Loại 2', 3)
INSERT [dbo].[chitietvattu] ([mavattu], [maloaiphong], [soluong]) VALUES (N'G2', N'Loại 3', 1)
INSERT [dbo].[chitietvattu] ([mavattu], [maloaiphong], [soluong]) VALUES (N'G2', N'Loại 4', 5)
INSERT [dbo].[chitietvattu] ([mavattu], [maloaiphong], [soluong]) VALUES (N'G4', N'Loại 1', 4)
INSERT [dbo].[chitietvattu] ([mavattu], [maloaiphong], [soluong]) VALUES (N'ML', N'Loại 4', 2)
INSERT [dbo].[chitietvattu] ([mavattu], [maloaiphong], [soluong]) VALUES (N'QM', N'Loại 1', 1)
INSERT [dbo].[chitietvattu] ([mavattu], [maloaiphong], [soluong]) VALUES (N'QM', N'Loại 2', 1)
INSERT [dbo].[chitietvattu] ([mavattu], [maloaiphong], [soluong]) VALUES (N'TL', N'Loại 4', 5)
INSERT [dbo].[chitietvattu] ([mavattu], [maloaiphong], [soluong]) VALUES (N'TV', N'Loại 2', 1)
/****** Object:  Table [dbo].[chitietdatphong]    Script Date: 04/14/2011 23:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[chitietdatphong](
	[maphieudat] [varchar](10) NOT NULL,
	[maphong] [varchar](10) NOT NULL,
 CONSTRAINT [PK_chitietdondatphong] PRIMARY KEY CLUSTERED 
(
	[maphieudat] ASC,
	[maphong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[chitietdatphong] ([maphieudat], [maphong]) VALUES (N'PDP001', N'A101')
INSERT [dbo].[chitietdatphong] ([maphieudat], [maphong]) VALUES (N'PDP002', N'A101')
INSERT [dbo].[chitietdatphong] ([maphieudat], [maphong]) VALUES (N'PDP003', N'A101')
INSERT [dbo].[chitietdatphong] ([maphieudat], [maphong]) VALUES (N'PDP004', N'A103')
INSERT [dbo].[chitietdatphong] ([maphieudat], [maphong]) VALUES (N'PDP005', N'A103')
INSERT [dbo].[chitietdatphong] ([maphieudat], [maphong]) VALUES (N'PDP006', N'A104')
INSERT [dbo].[chitietdatphong] ([maphieudat], [maphong]) VALUES (N'PDP006', N'A201')
INSERT [dbo].[chitietdatphong] ([maphieudat], [maphong]) VALUES (N'PDP006', N'B102')
/****** Object:  Table [dbo].[phieuthuephong]    Script Date: 04/14/2011 23:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[phieuthuephong](
	[maphieuthue] [varchar](10) NOT NULL,
	[maphieudat] [varchar](10) NULL,
	[username] [varchar](10) NULL,
 CONSTRAINT [PK_phieuthuephong] PRIMARY KEY CLUSTERED 
(
	[maphieuthue] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[phieuthuephong] ([maphieuthue], [maphieudat], [username]) VALUES (N'PT001', N'PDP001', N'admin')
INSERT [dbo].[phieuthuephong] ([maphieuthue], [maphieudat], [username]) VALUES (N'PT002', N'PDP004', N'admin')
INSERT [dbo].[phieuthuephong] ([maphieuthue], [maphieudat], [username]) VALUES (N'PT003', N'PDP006', N'admin')
/****** Object:  Table [dbo].[trangthaiphong]    Script Date: 04/14/2011 23:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[trangthaiphong](
	[maphong] [varchar](10) NOT NULL,
	[trangthai] [varchar](10) NOT NULL,
 CONSTRAINT [PK_trangthaiphong] PRIMARY KEY CLUSTERED 
(
	[maphong] ASC,
	[trangthai] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[hoadon]    Script Date: 04/14/2011 23:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[hoadon](
	[mahoadon] [varchar](10) NOT NULL,
	[ngaythanhtoan] [datetime] NOT NULL,
	[tongtien] [money] NULL,
	[maphieuthue] [varchar](10) NULL,
	[makhachhang] [varchar](10) NULL,
	[username] [varchar](10) NULL,
 CONSTRAINT [PK_hoadon] PRIMARY KEY CLUSTERED 
(
	[mahoadon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[hoadon] ([mahoadon], [ngaythanhtoan], [tongtien], [maphieuthue], [makhachhang], [username]) VALUES (N'HD001', CAST(0x00009EC500843F9A AS DateTime), 19999.0000, N'PT001', N'001', N'admin')
INSERT [dbo].[hoadon] ([mahoadon], [ngaythanhtoan], [tongtien], [maphieuthue], [makhachhang], [username]) VALUES (N'HD002', CAST(0x00009EC50086B8AD AS DateTime), 19999.0000, N'PT002', N'001', N'admin')
INSERT [dbo].[hoadon] ([mahoadon], [ngaythanhtoan], [tongtien], [maphieuthue], [makhachhang], [username]) VALUES (N'HD003', CAST(0x00009EC5009E7BFF AS DateTime), 249991.0000, N'PT003', N'001', N'admin')
/****** Object:  StoredProcedure [dbo].[thongkedatphong]    Script Date: 04/14/2011 23:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[thongkedatphong]
	-- Add the parameters for the stored procedure here
	@thang int,@nam int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     derivedtbl_1.Solan, dbo.phong.maphong
FROM         dbo.phong LEFT OUTER JOIN
                          (SELECT     COUNT(phong_1.maphong) AS Solan, phong_1.maphong
                            FROM          dbo.chitietdatphong INNER JOIN
                                                   dbo.phieudatphong ON dbo.chitietdatphong.maphieudat = dbo.phieudatphong.maphieudat RIGHT OUTER JOIN
                                                   dbo.phong AS phong_1 ON dbo.chitietdatphong.maphong = phong_1.maphong
                            WHERE      (MONTH(dbo.phieudatphong.ngayden) = @thang) AND (YEAR(dbo.phieudatphong.ngayden) = @nam)
                            GROUP BY phong_1.maphong) AS derivedtbl_1 ON dbo.phong.maphong = derivedtbl_1.maphong
END
GO
/****** Object:  StoredProcedure [dbo].[kiemtraphong]    Script Date: 04/14/2011 23:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[kiemtraphong] 
	-- Add the parameters for the stored procedure here
	@ngayden datetime, 
	@ngaydi datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT     dbo.chitietdatphong.maphieudat, dbo.chitietdatphong.maphong, dbo.phieudatphong.ngayden,dbo.phieudatphong.ngaydi,dbo.phieudatphong.tinhtrang
FROM         dbo.phieudatphong INNER JOIN
                      dbo.chitietdatphong ON dbo.phieudatphong.maphieudat = dbo.chitietdatphong.maphieudat INNER JOIN
                      dbo.phong ON dbo.chitietdatphong.maphong = dbo.phong.maphong
where  
(	
					(@ngayden<dbo.phieudatphong.ngayden and dbo.phieudatphong.ngayden<@ngaydi)
				or	(@ngayden<dbo.phieudatphong.ngaydi and dbo.phieudatphong.ngaydi<@ngaydi)
				or	(
						(dbo.phieudatphong.ngayden<@ngayden)
						and (@ngaydi<dbo.phieudatphong.ngaydi)
					)
		)
	and (dbo.phieudatphong.tinhtrang='busy' or dbo.phieudatphong.tinhtrang='waitting')
END
GO
/****** Object:  Table [dbo].[chitietthuephong]    Script Date: 04/14/2011 23:36:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[chitietthuephong](
	[maphieuthue] [varchar](10) NOT NULL,
	[maphong] [varchar](10) NOT NULL,
	[ngay] [datetime] NOT NULL,
	[madichvu] [varchar](10) NOT NULL,
	[soluong] [int] NULL,
 CONSTRAINT [PK_chitietthuephong_1] PRIMARY KEY CLUSTERED 
(
	[maphieuthue] ASC,
	[maphong] ASC,
	[ngay] ASC,
	[madichvu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[chitietthuephong] ([maphieuthue], [maphong], [ngay], [madichvu], [soluong]) VALUES (N'PT003', N'A104', CAST(0x00009EC5009E307C AS DateTime), N'A1', 1)
INSERT [dbo].[chitietthuephong] ([maphieuthue], [maphong], [ngay], [madichvu], [soluong]) VALUES (N'PT003', N'A104', CAST(0x00009EC5009E352C AS DateTime), N'A2', 1)
INSERT [dbo].[chitietthuephong] ([maphieuthue], [maphong], [ngay], [madichvu], [soluong]) VALUES (N'PT003', N'A104', CAST(0x00009EC5009E38B0 AS DateTime), N'B2', 1)
/****** Object:  StoredProcedure [dbo].[InhoadonPhong]    Script Date: 04/14/2011 23:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE  [dbo].[InhoadonPhong]
	-- Add the parameters for the stored procedure here
	@mahoadon varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     dbo.hoadon.mahoadon, dbo.khachhang.tenkhachhang, DATEDIFF(dd, dbo.phieudatphong.ngayden, dbo.phieudatphong.ngaydi)+1 AS ngayo, 
                      dbo.khachhang.cmnd_passport, dbo.khachhang.diachi, dbo.khachhang.coquan, dbo.khachhang.sodienthoai, dbo.khachhang.email, dbo.phieudatphong.ngayden, 
                      dbo.phieudatphong.ngaydi, dbo.phieudatphong.sotiendatcoc, dbo.loaiphong.gia, dbo.phong.maphong, dbo.nhanvien.tennhanvien, dbo.hoadon.tongtien
FROM         dbo.hoadon INNER JOIN
                      dbo.khachhang ON dbo.hoadon.makhachhang = dbo.khachhang.makhachhang INNER JOIN
                      dbo.phieuthuephong ON dbo.hoadon.maphieuthue = dbo.phieuthuephong.maphieuthue INNER JOIN
                      dbo.phieudatphong ON dbo.phieuthuephong.maphieudat = dbo.phieudatphong.maphieudat INNER JOIN
                      dbo.chitietdatphong ON dbo.phieudatphong.maphieudat = dbo.chitietdatphong.maphieudat INNER JOIN
                      dbo.phong ON dbo.chitietdatphong.maphong = dbo.phong.maphong INNER JOIN
                      dbo.loaiphong ON dbo.phong.maloai = dbo.loaiphong.maloai INNER JOIN
                      dbo.hethong ON dbo.hoadon.username = dbo.hethong.username AND dbo.phieuthuephong.username = dbo.hethong.username INNER JOIN
                      dbo.nhanvien ON dbo.hethong.manhanvien = dbo.nhanvien.manhanvien
WHERE     (dbo.hoadon.mahoadon = @mahoadon)
END
GO
/****** Object:  StoredProcedure [dbo].[InhoadonDichVu]    Script Date: 04/14/2011 23:36:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InhoadonDichVu] 
	-- Add the parameters for the stored procedure here
	@mahoadon varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT     dbo.chitietthuephong.maphieuthue, dbo.dichvu.tendichvu, dbo.dichvu.gia, dbo.dichvu.donvitinh, dbo.chitietthuephong.soluong, dbo.chitietthuephong.maphong, 
                      dbo.hoadon.mahoadon, dbo.chitietthuephong.ngay
FROM         dbo.hoadon INNER JOIN
                      dbo.phieuthuephong ON dbo.hoadon.maphieuthue = dbo.phieuthuephong.maphieuthue INNER JOIN
                      dbo.chitietthuephong ON dbo.phieuthuephong.maphieuthue = dbo.chitietthuephong.maphieuthue INNER JOIN
                      dbo.dichvu ON dbo.chitietthuephong.madichvu = dbo.dichvu.madichvu
WHERE     (dbo.hoadon.mahoadon = @mahoadon)
END
GO
/****** Object:  ForeignKey [FK_chitietdatphong_phieudatphong]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[chitietdatphong]  WITH CHECK ADD  CONSTRAINT [FK_chitietdatphong_phieudatphong] FOREIGN KEY([maphieudat])
REFERENCES [dbo].[phieudatphong] ([maphieudat])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[chitietdatphong] CHECK CONSTRAINT [FK_chitietdatphong_phieudatphong]
GO
/****** Object:  ForeignKey [FK_chitietdatphong_phong]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[chitietdatphong]  WITH CHECK ADD  CONSTRAINT [FK_chitietdatphong_phong] FOREIGN KEY([maphong])
REFERENCES [dbo].[phong] ([maphong])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[chitietdatphong] CHECK CONSTRAINT [FK_chitietdatphong_phong]
GO
/****** Object:  ForeignKey [FK_chitietthuephong_dichvu]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[chitietthuephong]  WITH CHECK ADD  CONSTRAINT [FK_chitietthuephong_dichvu] FOREIGN KEY([madichvu])
REFERENCES [dbo].[dichvu] ([madichvu])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[chitietthuephong] CHECK CONSTRAINT [FK_chitietthuephong_dichvu]
GO
/****** Object:  ForeignKey [FK_chitietthuephong_phieuthuephong]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[chitietthuephong]  WITH CHECK ADD  CONSTRAINT [FK_chitietthuephong_phieuthuephong] FOREIGN KEY([maphieuthue])
REFERENCES [dbo].[phieuthuephong] ([maphieuthue])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[chitietthuephong] CHECK CONSTRAINT [FK_chitietthuephong_phieuthuephong]
GO
/****** Object:  ForeignKey [FK_chitietthuephong_phong]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[chitietthuephong]  WITH CHECK ADD  CONSTRAINT [FK_chitietthuephong_phong] FOREIGN KEY([maphong])
REFERENCES [dbo].[phong] ([maphong])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[chitietthuephong] CHECK CONSTRAINT [FK_chitietthuephong_phong]
GO
/****** Object:  ForeignKey [FK_chitietvattu_loaiphong]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[chitietvattu]  WITH CHECK ADD  CONSTRAINT [FK_chitietvattu_loaiphong] FOREIGN KEY([maloaiphong])
REFERENCES [dbo].[loaiphong] ([maloai])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[chitietvattu] CHECK CONSTRAINT [FK_chitietvattu_loaiphong]
GO
/****** Object:  ForeignKey [FK_chitietvattu_vattu]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[chitietvattu]  WITH CHECK ADD  CONSTRAINT [FK_chitietvattu_vattu] FOREIGN KEY([mavattu])
REFERENCES [dbo].[vattu] ([mavattu])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[chitietvattu] CHECK CONSTRAINT [FK_chitietvattu_vattu]
GO
/****** Object:  ForeignKey [FK_hethong_nhanvien]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[hethong]  WITH CHECK ADD  CONSTRAINT [FK_hethong_nhanvien] FOREIGN KEY([manhanvien])
REFERENCES [dbo].[nhanvien] ([manhanvien])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[hethong] CHECK CONSTRAINT [FK_hethong_nhanvien]
GO
/****** Object:  ForeignKey [FK_hoadon_hethong]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[hoadon]  WITH CHECK ADD  CONSTRAINT [FK_hoadon_hethong] FOREIGN KEY([username])
REFERENCES [dbo].[hethong] ([username])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[hoadon] CHECK CONSTRAINT [FK_hoadon_hethong]
GO
/****** Object:  ForeignKey [FK_hoadon_khachhang]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[hoadon]  WITH CHECK ADD  CONSTRAINT [FK_hoadon_khachhang] FOREIGN KEY([makhachhang])
REFERENCES [dbo].[khachhang] ([makhachhang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[hoadon] CHECK CONSTRAINT [FK_hoadon_khachhang]
GO
/****** Object:  ForeignKey [FK_hoadon_phieuthuephong]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[hoadon]  WITH CHECK ADD  CONSTRAINT [FK_hoadon_phieuthuephong] FOREIGN KEY([maphieuthue])
REFERENCES [dbo].[phieuthuephong] ([maphieuthue])
GO
ALTER TABLE [dbo].[hoadon] CHECK CONSTRAINT [FK_hoadon_phieuthuephong]
GO
/****** Object:  ForeignKey [FK_phieudatphong_khachhang1]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[phieudatphong]  WITH CHECK ADD  CONSTRAINT [FK_phieudatphong_khachhang1] FOREIGN KEY([makhachhang])
REFERENCES [dbo].[khachhang] ([makhachhang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[phieudatphong] CHECK CONSTRAINT [FK_phieudatphong_khachhang1]
GO
/****** Object:  ForeignKey [FK_phieuthuephong_hethong]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[phieuthuephong]  WITH CHECK ADD  CONSTRAINT [FK_phieuthuephong_hethong] FOREIGN KEY([username])
REFERENCES [dbo].[hethong] ([username])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[phieuthuephong] CHECK CONSTRAINT [FK_phieuthuephong_hethong]
GO
/****** Object:  ForeignKey [FK_phieuthuephong_phieudatphong]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[phieuthuephong]  WITH CHECK ADD  CONSTRAINT [FK_phieuthuephong_phieudatphong] FOREIGN KEY([maphieudat])
REFERENCES [dbo].[phieudatphong] ([maphieudat])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[phieuthuephong] CHECK CONSTRAINT [FK_phieuthuephong_phieudatphong]
GO
/****** Object:  ForeignKey [FK_phong_loaiphong]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[phong]  WITH CHECK ADD  CONSTRAINT [FK_phong_loaiphong] FOREIGN KEY([maloai])
REFERENCES [dbo].[loaiphong] ([maloai])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[phong] CHECK CONSTRAINT [FK_phong_loaiphong]
GO
/****** Object:  ForeignKey [FK_trangthaiphong_phong]    Script Date: 04/14/2011 23:36:23 ******/
ALTER TABLE [dbo].[trangthaiphong]  WITH CHECK ADD  CONSTRAINT [FK_trangthaiphong_phong] FOREIGN KEY([maphong])
REFERENCES [dbo].[phong] ([maphong])
GO
ALTER TABLE [dbo].[trangthaiphong] CHECK CONSTRAINT [FK_trangthaiphong_phong]
GO
