use master
go
if DB_ID('QLBanHang') is not null
	drop database QLBanHang
go
CREATE DATABASE [QLBanHang]
GO
USE [QLBanHang]
GO
--Tạo bảng LoaiSanPham
CREATE TABLE [dbo].[LoaiSanPham](
[MaLoai] [nchar](10) NOT NULL PRIMARY KEY,
[TenLoai] [nvarchar](50) NULL)
GO
--Tạo bảng Hang
CREATE TABLE [dbo].[SanPham](
[MaSP] [nchar](10) NOT NULL PRIMARY KEY,
[TenSP] [nvarchar](50) NULL,
[MaLoai] [nchar](10) NULL,
[DonGia] [float] NULL,
[SoLuong] [int] NULL)
GO
--Tạo các khóa ngoài
ALTER TABLE [dbo].[SanPham] WITH CHECK ADD CONSTRAINT [FK_SanPham_LoaiSP]
FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiSanPham] ([MaLoai])
GO
--Chèn dữ liệu cho bảng LoaiSanPham
Insert into LoaiSanPham values('L01',N'Quần áo')
Insert into LoaiSanPham values('L02',N'Điện tử')
--Chèn dữ liệu cho bảng SanPham
Insert into SanPham values('01',N'Áo sơ mi nam','L01',400000,100)
Insert into SanPham values('02',N'Quần bò nữ','L01',500000,200)
Insert into SanPham values('03',N'Lò vi sóng','L02',2000000,160)
Insert into SanPham values('04',N'Nồi cơm điện','L02',3000000,150)

--Select * From LoaiSanPham
--Select * From SanPham