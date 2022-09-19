create database QLTS
go
use [QLTS] 
go

CREATE TABLE [dbo].[DangNhap](
	[maNV] [char](50) NOT NULL,
	[Pword] [char](20) NOT NULL,
	[IDLoaiQuyen] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maNV] ASC,
	[Pword] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[HoaDon](
	[IDhoadon] [char](20) NOT NULL,
	[NgayTao] [date] NOT NULL,
	[IDkh] [char](20) NOT NULL,
	[IDsanpham] [char](30) NOT NULL,
	[SLsanpham] [int] NOT NULL,
	[TongTien] [char] (30) NOT NULL,
	[maNV] [char](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDhoadon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[KhachHang](
	[IDkh] [char](20) NOT NULL,
	[tenkh] [nvarchar](50) NOT NULL,
	[Dchi] [nvarchar](50) NOT NULL,
	[SDT] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDkh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



CREATE TABLE [dbo].[SanPham](
	[IDsanpham] [char](30) NOT NULL,
	[Tensp] [nvarchar](50) NULL,
	[Giatien] [char](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDsanpham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[ThongTinNV](
	[maNV] [char](50) NOT NULL,
	[tenNV] [nvarchar](30) NOT NULL,
	[Gtinh] [char](10) NOT NULL,
	[Nsinh] [date] NOT NULL,
	[SDt] [char](30) NOT NULL,
	[Dchi] [nvarchar](50) NOT NULL,
	[LoaiNV] [nvarchar](20) NOT NULL,
	[Luong] [char](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO

use QLTS
go
INSERT INTO ThongTinNV(maNV,tenNV,Gtinh,Nsinh,SDt,Dchi,LoaiNV,Luong)
VALUES ('admin', N'Tien','nam','2001-01-01','038823728',N'Vung Tau',N'admin','200000');
go
INSERT INTO ThongTinNV(maNV,tenNV,Gtinh,Nsinh,SDt,Dchi,LoaiNV,Luong)
VALUES ('NV01', N'Vu','nam','02-05-2001','038231243',N'Ha Tinh',N'Nhan Vien','100000');
go

INSERT INTO DangNhap (maNV,Pword,IDLoaiQuyen)
VALUES ('admin', '123', 1);
go
INSERT INTO DangNhap (maNV,Pword,IDLoaiQuyen)
VALUES ('NV01', '123', 2);
go
INSERT INTO KhachHang(IDkh,tenkh,Dchi,SDT)
VALUES ('KH01', N'Lê Thị Trang',N'Vung Tau','0378873232');
go
INSERT INTO KhachHang(IDkh,tenkh,Dchi,SDT)
VALUES ('KH02', N'Lê Hòa',N'Vung Tau','0378273732');
go
INSERT INTO SanPham(IDsanpham,Tensp,Giatien)
VALUES ('SP01', N'Cơm','30000');
go
INSERT INTO SanPham(IDsanpham,Tensp,Giatien)
VALUES ('SP02', N'Bún','35000');
go
INSERT INTO SanPham(IDsanpham,Tensp,Giatien)
VALUES ('SP03', N'Phở Hà Nội','40000');
go
Create function [dbo].[F_ThuNhapByNgay](@ngay Datetime)
returns table
as
	return
(
select NgayTao,Sum(CAST (TongTien as int) )as thunhap
from HoaDon
where NgayTao=@ngay
group by NgayTao 
)
go 
--function kiểm tra đăng nhập
Create function [dbo].[F_KTDangNhap](@ten char(15),@pass char(15))
returns table
as
	return
(
select *
from DangNhap
where maNV=@ten and Pword=@pass

)
go
---function trả về bảng nhân viên tìm kiếm theo id nhân viên
Create function [dbo].[F_NVById](@IDnv char(15))
returns table
as
	return
(
SELECT * 
FROM ThongTinNV 
WHERE maNV = @IDnv
)
go
---function trả về bảng sản phẩm tìm kiếm theo id sản phẩm
Create function [dbo].[F_SPById](@IDsp char(15))
returns table
as
	return
(
SELECT * 
FROM SanPham 
WHERE IDsanpham = @IDsp

)
go
---function trả về bảng hóa đơn tìm kiếm thông qua theo id hóa đơn
Create function [dbo].[F_HoaDonById](@IDhd char(15))
returns table
as
	return
(
SELECT 
* FROM HoaDon 
WHERE IDhoadon = @IDhd

)
go
---function trả về bảng khách hàng thông qua tìm kiếm theo id khách hàng

Create function [dbo].[F_KhachHangById](@IDkh char(15))
returns table
as
	return
(
SELECT * FROM KhachHang 
WHERE IDkh = @IDkh)

go

---trigger đảm bảo nhập giá sản phẩm hợp lệ
Create TRIGGER [dbo].[Check_Gia] --Tên Trigger
ON [dbo].[SanPham]
FOR UPDATE,INSERT
AS
 BEGIN
 DECLARE @gia AS INT
SELECT @gia=inserted.Giatien FROM inserted
IF (@gia<0)
	BEGIN
		PRINT N'Giá KHÔNG HỢP LỆ'
		ROLLBACK TRANSACTION
	 END
END
GO
---trigger đảm bảo không trùng tài khoản
Create TRIGGER [dbo].[CHECK_USERS] --Tên Trigger
ON [dbo].[DangNhap]
FOR UPDATE,INSERT
AS
 BEGIN
 DECLARE @manv AS NCHAR(50), @TEMP AS INT
SELECT @manv=inserted.maNV FROM inserted
SELECT @TEMP=COUNT(*) FROM dbo.DangNhap
WHERE maNV=@manv
IF (@TEMP>1)
	 BEGIN
		 PRINT N'TÀI KHOẢN Đã Tồn Tại'
		 ROLLBACK TRANSACTION
	 END
END
Go


--------------PROCEDURE-------------
--proc tìm món theo giá
-----Insert dữ liệu vào bảng hóa đơn
CREATE OR ALTER PROCEDURE spThemHoaDon
	(@IDhoadon CHAR(20), @NgayTao DATE, @IDkh CHAR(20),
	@IDsanpham CHAR(30), @SLsanpham INT, @TongTien CHAR(30), @maNV CHAR(10))
AS
BEGIN 
	IF(EXISTS (SELECT * FROM HoaDon
				WHERE (IDhoadon = @IDhoadon)))
				return -1;
	ELSE 
		BEGIN TRAN;
			BEGIN TRY
				INSERT INTO dbo.HoaDon VALUES(@IDhoadon , @NgayTao, @IDkh,@IDsanpham , @SLsanpham, @TongTien, @maNV);
				COMMIT TRAN;
			END TRY
			BEGIN CATCH
				ROLLBACK TRAN
			END CATCH
END
GO
---Xoa hoa don-----
CREATE OR ALTER PROCEDURE spXoaHoaDon_TheoMaHoaDon  (@IDhoadon CHAR(20) ) AS
	DELETE FROM dbo.HoaDon  WHERE IDhoadon = @IDhoadon;
Go
---Cap nhap hoa don----

CREATE OR ALTER PROCEDURE spCapNhatHoaDon (@IDhoadon CHAR(20), @NgayTao DATE, @IDkh CHAR(20),
	@IDsanpham CHAR(30), @SLsanpham INT, @TongTien CHAR(30), @maNV CHAR(10))
AS
BEGIN
	BEGIN TRAN;
		BEGIN TRY
			UPDATE dbo.HoaDon SET NgayTao= @NgayTao,@IDkh = @IDkh,
								IDsanpham = @IDsanpham,SLsanpham = @SLsanpham,TongTien = @TongTien,
								maNV= @maNV
			WHERE HoaDon.IDHoaDon= @IDhoadon;
			COMMIT TRAN;
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN
		END CATCH
END
GO 
----------------Procedure KhachHang------------------
CREATE OR ALTER PROCEDURE spThemKhachHang
	(@IDkh CHAR(10),
	@tenkh CHAR(20),
	@Dchi Char (20),
	@SDT char(10))
AS
BEGIN 
	IF(EXISTS (SELECT * FROM KhachHang
				WHERE (IDkh =@IDkh)))
				return -1;
	ELSE 
		BEGIN TRAN;
			BEGIN TRY
				INSERT INTO dbo.KhachHang VALUES(@IDkh,@tenkh,@Dchi,@SDT);
				COMMIT TRAN;
			END TRY
			BEGIN CATCH
				ROLLBACK TRAN
			END CATCH
END
GO

---Xoa KH
CREATE OR ALTER PROCEDURE spXoaKH_TheoID  (@IDkh CHAR(10) ) AS
	DELETE FROM dbo.KhachHang  WHERE IDkh = @IDkh;
GO


CREATE OR ALTER PROCEDURE spCapNhatKhachHang ( @IDkh CHAR(10),
											@tenkh NVARCHAR(50),
											@Dchi nvarchar(50),
											@SDT char(10))
											
AS
BEGIN
	BEGIN TRAN;
		BEGIN TRY
				UPDATE dbo.KhachHang SET tenkh= @tenkh,Dchi = @Dchi,SDT = @SDT
				WHERE IDkh= @IDkh;
			COMMIT TRAN;
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN
		END CATCH
END
GO 
----------------Procedure SanPham--------------------------
CREATE OR ALTER PROCEDURE spSanPham (@IDsanpham char(30), @Tensp NVARCHAR(50),@GiaTien char(50))
AS
BEGIN 
	IF(EXISTS (SELECT * FROM SanPham
				WHERE (IDsanpham = @IDsanpham)))
				return -1;
	ELSE 
		BEGIN TRAN;
			BEGIN TRY
				INSERT INTO dbo.SanPham VALUES (@IDsanpham , @Tensp,@GiaTien);
				COMMIT TRAN;
			END TRY
			BEGIN CATCH
				ROLLBACK TRAN
			END CATCH
END
GO
---Xoa KH-------
CREATE OR ALTER PROCEDURE spXoaSanPham_TheoID  (@IDsanpham CHAR(30) ) AS
	DELETE FROM dbo.SanPham  WHERE IDsanpham = @IDsanpham;
GO
--sua thong tin sanPham-----
CREATE OR ALTER PROCEDURE spCapNhatSanPham (@IDsanpham CHAR(30),@Tensp NVARCHAR(50),@Giatien CHAR(30))
AS
BEGIN
	BEGIN TRAN;
		BEGIN TRY
			UPDATE dbo.SanPham SET Tensp= @Tensp,Giatien = @Giatien
			WHERE IDsanpham= @IDsanpham;
			COMMIT TRAN;
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN
		END CATCH
END
GO 

----------------Procedure BLNHanVien------------------
CREATE OR ALTER PROCEDURE spThemNhanVien
    (@maNV CHAR(10), @tenNV NVARCHAR(50), @Gtinh nvarchar(10),
    @Nsinh DATETIME,  @SDt char(10),@Dchi NVARCHAR(50),@LoaiNV nvarchar (20),@Luong char(10))
AS
BEGIN 
	IF(EXISTS (SELECT * FROM ThongTinNV
				WHERE (MaNV = @MaNV)))
				return -1;
	ELSE 
		BEGIN TRAN;
			BEGIN TRY
				 INSERT INTO dbo.ThongTinNV VALUES(@maNV, @tenNV , @Gtinh, @Nsinh, @Dchi, @SDt, @LoaiNV,@Luong);
				COMMIT TRAN;
			END TRY
			BEGIN CATCH
				ROLLBACK TRAN
			END CATCH
END
GO

CREATE OR ALTER PROCEDURE spXoaNhanVien_MaNV (@maNV CHAR(10) ) AS
	DELETE FROM dbo.ThongTinNV  WHERE maNV = @maNV;
Go


CREATE OR ALTER PROCEDURE spCapNhatNhanVien (	@maNV char(10),@tenNV nvarchar(50),
@Gtinh nvarchar(10),@Nsinh date,@Dchi nvarchar(50),@SDt char(10),@LoaiNV nvarchar (20),@Luong char (10))
AS
BEGIN
	BEGIN TRAN;
		BEGIN TRY
			UPDATE dbo.ThongTinNV SET tenNV=@tenNV, Gtinh = @Gtinh, Nsinh = @Nsinh,Dchi = @Dchi, SDt = @SDt, LoaiNV = @LoaiNV, Luong = @Luong
					WHERE maNV= @maNV;
			COMMIT TRAN;
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN
		END CATCH
END
GO 

----------------Procedure BLDoiMatKhau------------------
CREATE OR ALTER PROCEDURE spCapNhatMatKhau(@MatKhauMoi char(10),
                                            @maNV char(20),
                                            @MatKhauCu char(20))
AS
BEGIN
	BEGIN TRAN;
		BEGIN TRY
					 UPDATE dbo.DangNhap SET Pword = @MatKhauMoi
					WHERE maNV = @maNV AND Pword = @MatKhauCu;
			COMMIT TRAN;
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN
		END CATCH
END
---Procedure Tai Khoan----
GO
CREATE OR ALTER PROCEDURE spSuaTaiKhoan_TheoTenTK
(@maNV CHAR(15), @Pword CHAR(10), @IDLoaiQuyen INT) AS
BEGIN
	BEGIN TRANSACTION SuaTaiKhoan;
	UPDATE dbo.DangNhap SET Pword= @Pword, IDLoaiQuyen = @IDLoaiQuyen
	WHERE maNV = @maNV;
	COMMIT TRANSACTION SuaTaiKhoan;
END
GO
---Procedure Thêm Tài Khoản----

CREATE OR ALTER PROCEDURE spThemTaiKhoan
(@maNV CHAR(15), @Pword CHAR(10), @IDLoaiQuyen INT) AS
	INSERT INTO dbo.DangNhap VALUES(@maNV, @Pword, @IDLoaiQuyen);
GO

CREATE OR ALTER PROCEDURE spXoaTaiKhoan_TheoTenTK (@maNV CHAR(10)) AS
	IF (@maNV <> 'admin') DELETE FROM dbo.DangNhap WHERE maNV = @maNV;
	ELSE RAISERROR('Không xóa được tài khoản Admin!', 16, 1);
GO



---Tạo view hiển thị thông tin nhân viên
CREATE OR ALTER VIEW viewNhanVien AS
	SELECT [maNV], [tenNV], [Gtinh], [Nsinh], [Dchi], [SDt],[LoaiNV],[Luong] FROM dbo.ThongTinNV;
GO
----Tạo view hiển thị thông tin khách hàng
CREATE OR ALTER VIEW viewKhachHang AS
	SELECT [IDkh], [tenkh],[Dchi],[SDT] FROM dbo.KhachHang;
GO
----Tạo view hiển thị thông tin Sản phẩm
CREATE OR ALTER VIEW viewSanPham AS
	SELECT [IDsanpham], [Tensp], [Giatien] FROM dbo.SanPham;
GO
---Tạo view  hiển thị thông tin hóa đơn
CREATE OR ALTER VIEW viewHoaDon AS
	SELECT [IDhoadon], [NgayTao], [IDkh],[IDsanpham],[SLsanpham], [TongTien],[maNV] FROM dbo.HoaDon;

GO
----Tạo view hiển thị thông tin user
CREATE OR ALTER VIEW viewUser AS
	SELECT [maNV], [Pword], [IDLoaiQuyen] FROM dbo.DangNhap;
GO



