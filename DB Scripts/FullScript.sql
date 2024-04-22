-- =========================================================================================================================== --
-- =========================================================================================================================== --
-- ==========================   ____ ____  _____    _  _____ _____   _____  _    ____  _     _____  ========================== --
-- ==========================  / ___|  _ \| ____|  / \|_   _| ____| |_   _|/ \  | __ )| |   | ____| ========================== --
-- ========================== | |   | |_) |  _|   / _ \ | | |  _|     | | / _ \ |  _ \| |   |  _|   ========================== --
-- ========================== | |___|  _ <| |___ / ___ \| | | |___    | |/ ___ \| |_) | |___| |___  ========================== --
-- ==========================  \____|_| \_\_____/_/   \_\_| |_____|   |_/_/   \_\____/|_____|_____| ========================== --
-- =========================================================================================================================== --
-- =========================================================================================================================== --

USE master;
-- If DB exists, delete and create a new one
IF DB_ID('Proj_DBMS_BookStore') IS NOT NULL
	DROP DATABASE Proj_DBMS_BookStore
GO
CREATE DATABASE Proj_DBMS_BookStore
GO
USE Proj_DBMS_BookStore;
GO

-- MaNXB VARCHAR(10)
-- MaHang VARCHAR(20)
-- MaTG VARCHAR(10)
-- MaLoai VARCHAR(10)
-- MaNV VARCHAR(10)
-- MaThe VARCHAR(10) = MaKH


CREATE TABLE dbo.NXB(
	MaNXB VARCHAR(10) NOT NULL,
	TenNXB NVARCHAR(50) NOT NULL,
	DiaChi NVARCHAR(100) NOT NULL,
	SDT VARCHAR(15) NOT NULL CHECK(LEN(SDT) >= 10),
	
	PRIMARY KEY(MaNXB)
);
GO

CREATE TABLE dbo.HANG_HOA(
	MaHang VARCHAR(20) NOT NULL,
	DonGia INT NOT NULL CHECK(DonGia >= 1000),
	SoLuong INT NOT NULL CHECK(SoLuong >= 0),

	PRIMARY KEY(MaHang)
);
GO

CREATE TABLE dbo.VAN_PHONG_PHAM(
	MaHang VARCHAR(20) NOT NULL,
	TenHang NVARCHAR(50) NOT NULL,

	PRIMARY KEY (MaHang),
	FOREIGN KEY (MaHang) REFERENCES dbo.HANG_HOA(MaHang)
);
GO

CREATE TABLE dbo.SACH(
	MaSach VARCHAR(20) NOT NULL,
	TieuDe NVARCHAR(50) NOT NULL,
	MaNXB VARCHAR(10) NOT NULL,
	NamXB INT NOT NULL CHECK(NamXB > 1000),

	PRIMARY KEY (MaSach),
	FOREIGN KEY (MaSach) REFERENCES dbo.HANG_HOA(MaHang),
	FOREIGN KEY (MaNXB) REFERENCES dbo.NXB(MaNXB)
);
GO

CREATE TABLE dbo.TAC_GIA(
	MaTG VARCHAR(10) NOT NULL,
	TenTG NVARCHAR(50) NOT NULL,

	PRIMARY KEY (MaTG)
);
GO

CREATE TABLE dbo.TAC_GIA_SACH(
	MaSach VARCHAR(20) NOT NULL,
	MaTG VARCHAR(10) NOT NULL,

	PRIMARY KEY (MaSach, MaTG),
	FOREIGN KEY (MaSach) REFERENCES dbo.SACH(MaSach),
	FOREIGN KEY (MaTG) REFERENCES dbo.TAC_GIA(MaTG)
);
GO

CREATE TABLE dbo.THE_LOAI(
	MaLoai VARCHAR(10) NOT NULL,
	TenLoai NVARCHAR(20) NOT NULL,

	PRIMARY KEY (MaLoai)
);
GO

CREATE TABLE dbo.THE_LOAI_SACH(
	MaSach VARCHAR(20) NOT NULL,
	MaLoai VARCHAR(10) NOT NULL,

	PRIMARY KEY (MaSach, MaLoai),
	FOREIGN KEY (MaSach) REFERENCES dbo.SACH(MaSach),
	FOREIGN KEY (MaLoai) REFERENCES dbo.THE_LOAI(MaLoai)
);
GO

CREATE TABLE dbo.KHACH_HANG(
	MaKH VARCHAR(10) NOT NULL, -- Dung SDT lam ma KH
	Ho NVARCHAR(10) NOT NULL,
	TenLot NVARCHAR(20) NULL DEFAULT '',
	Ten NVARCHAR(10) NOT NULL,
	NgaySinh DATETIME NULL,
	GioiTinh NVARCHAR(3) NULL

	PRIMARY KEY (MaKH)
);
GO

-- Changed
CREATE TABLE dbo.THE_TV(
	MaThe VARCHAR(10) NOT NULL,
	SoDiem INT NOT NULL CHECK(SoDiem >= 0),
	--TenBacTV NVARCHAR(10) NOT NULL DEFAULT 'None',
	MaKH VARCHAR(10) NOT NULL UNIQUE,

	PRIMARY KEY (MaThe),
	FOREIGN KEY (MaKH) REFERENCES dbo.KHACH_HANG(MaKH)
);
GO
-- ALTER TABLE dbo.THE_TV
-- ADD TenBacTV AS dbo.FUNC_Get_TenBac(SoDiem)

CREATE TABLE dbo.NHAN_VIEN(
	MaNV VARCHAR(10) NOT NULL,
	CMND VARCHAR(15) NOT NULL UNIQUE,
	Ho NVARCHAR(10) NOT NULL,
	TenLot NVARCHAR(10) NULL DEFAULT '',
	Ten NVARCHAR(10) NOT NULL,
	GioiTinh NVARCHAR(3) NULL,
	Luong INT NOT NULL DEFAULT 3000000 CHECK(Luong >= 1000),
	TinhTrangLamViec BIT NOT NULL,	-- 0: nghỉ; 1: đang làm

	PRIMARY KEY (MaNV)
);
GO

-- new table
CREATE TABLE dbo.TAI_KHOAN_DN(
	MaNV VARCHAR(10) NOT NULL,
	TenDN VARCHAR(20) NOT NULL UNIQUE,
	MK VARCHAR(30) NOT NULL CHECK(LEN(MK) >= 8),

	PRIMARY KEY (MaNV),
	FOREIGN KEY (MaNV) REFERENCES dbo.NHAN_VIEN(MaNV)
)

-- new table
CREATE TABLE dbo.LS_DANG_NHAP(
	TenDN VARCHAR(20) NOT NULL,
	ThoiGianDN DATETIME NOT NULL,

	PRIMARY KEY (TenDN, ThoiGianDN),
	FOREIGN KEY (TenDN) REFERENCES dbo.TAI_KHOAN_DN(TenDN)
);
GO

CREATE TABLE dbo.TAO_TV(
	MaNV VARCHAR(10) NOT NULL,
	MaThe VARCHAR(10) NOT NULL UNIQUE,
	MaKH VARCHAR(10) NOT NULL UNIQUE,
	NgayTao DATETIME NOT NULL,

	PRIMARY KEY (MaNV, MaThe, MaKH),
	FOREIGN KEY (MaNV) REFERENCES dbo.NHAN_VIEN(MaNV),
	FOREIGN KEY (MaThe) REFERENCES dbo.THE_TV(MaThe),
	FOREIGN KEY (MaKH) REFERENCES dbo.KHACH_HANG(MaKH)
);
GO

CREATE TABLE dbo.HOA_DON_NHAP(
	MaDonNhap VARCHAR(10) NOT NULL,
	ThoiGianNhap DATETIME NOT NULL,

	PRIMARY KEY (MaDonNhap),
);
GO

CREATE TABLE dbo.NHAP_HANG(
	MaDonNhap VARCHAR(10) NOT NULL,
	MaNVNhap VARCHAR(10) NOT NULL,
	MaHang VARCHAR(20) NOT NULL,
	SoLuong INT NOT NULL,

	PRIMARY KEY (MaDonNhap, MaNVNhap, MaHang),
	FOREIGN KEY (MaDonNhap) REFERENCES dbo.HOA_DON_NHAP(MaDonNhap),
	FOREIGN KEY (MaNVNhap) REFERENCES dbo.NHAN_VIEN(MaNV),
	FOREIGN KEY (MaHang) REFERENCES dbo.HANG_HOA(MaHang),
);
GO

CREATE TABLE dbo.HOA_DON_BAN(
	MaHoaDon VARCHAR(10) NOT NULL,
	ThoiGianBan DATETIME NOT NULL,
	KhuyenMai REAL NOT NULL,
	
	PRIMARY KEY (MaHoaDon)
);
GO

CREATE TABLE dbo.BAN_HANG(
	MaHoaDon VARCHAR(10) NOT NULL,
	MaNVBan VARCHAR(10) NOT NULL,
	MaKH VARCHAR(10) DEFAULT '0000000000' NOT NULL,
	MaHang VARCHAR(20) NOT NULL,
	SoLuong INT NOT NULL

	PRIMARY KEY(MaHoaDon, MaNVBan, MaKH, MaHang),
	FOREIGN KEY (MaHoaDon) REFERENCES dbo.HOA_DON_BAN(MaHoaDon),
	FOREIGN KEY (MaNVBan) REFERENCES dbo.NHAN_VIEN(MaNV),
	FOREIGN KEY (MaKH) REFERENCES dbo.KHACH_HANG(MaKH),
	FOREIGN KEY (MaHang) REFERENCES dbo.HANG_HOA(MaHang),
);
GO

-- ========================================================================================================================== --
-- ========================================================================================================================== --
-- ============================================= __     _____ _______        __ ============================================= --
-- ============================================= \ \   / /_ _| ____\ \      / / ============================================= --
-- =============================================  \ \ / / | ||  _|  \ \ /\ / /  ============================================= --
-- =============================================   \ V /  | || |___  \ V  V /   ============================================= --
-- =============================================    \_/  |___|_____|  \_/\_/    ============================================= --
-- ========================================================================================================================== --
-- ========================================================================================================================== --

-- VIEW xem thông tin nhân viên 
CREATE VIEW dbo.VIEW_NV_TK
AS
	SELECT nv.MaNV, nv.CMND, nv.Ho, nv.TenLot, nv.Ten, nv.GioiTinh, nv.Luong, tkdn.TenDN, tkdn.MK, nv.TinhTrangLamViec FROM
	dbo.NHAN_VIEN nv INNER JOIN dbo.TAI_KHOAN_DN tkdn 
	ON nv.MaNV = tkdn.MaNV
GO

-- VIEW xem thông tin sách
CREATE VIEW dbo.VIEW_SACH
AS
	SELECT s.MaSach, s.TieuDe, hh.DonGia, hh.SoLuong, tg.tenTG, tl.TenLoai, nxb.TenNXB
	FROM
	dbo.HANG_HOA hh RIGHT JOIN dbo.SACH s ON s.MaSach = hh.MaHang
	JOIN dbo.NXB nxb ON nxb.MaNXB = s.MaNXB
	JOIN dbo.TAC_GIA_SACH tg_s ON tg_s.MaSach = s.MaSach
	JOIN dbo.TAC_GIA tg ON tg.MaTG = tg_s.MaTG
	JOIN dbo.THE_LOAI_SACH tl_s ON tl_s.MaSach = s.MaSach 
	JOIN dbo.THE_LOAI tl ON tl.MaLoai = tl_s.MaLoai
GO

-- VIEW xem thông tin VPP
CREATE VIEW VIEW_VPP
AS
	SELECT hh.MaHang, vpp.TenHang, hh.DonGia, hh.SoLuong
	FROM
	dbo.HANG_HOA hh RIGHT JOIN dbo.VAN_PHONG_PHAM vpp ON vpp.MaHang = hh.MaHang
GO

-- View xem mã hàng, tên hàng hoá, đơn giá, số lượng còn lại
-- COALESCE trả về giá trị not null đầu tiên trong (s.TieuDe, vpp.TenHang), nếu tiêu đề null thì sẽ in ra tên hàng và ngược lại
CREATE VIEW VIEW_HANG_HOA
AS 
	SELECT hh.MaHang, COALESCE(s.TieuDe, vpp.TenHang) AS 'TenHang', hh.DonGia, hh.SoLuong
	FROM
	dbo.HANG_HOA hh LEFT JOIN dbo.SACH s ON s.MaSach = hh.MaHang
	LEFT JOIN dbo.VAN_PHONG_PHAM vpp ON vpp.MaHang = hh.MaHang
GO
-- View thông tin khách hàng
CREATE VIEW dbo.VIEW_KH
AS
	SELECT kh.MaKH, kh.Ho, kh.TenLot, kh.Ten, kh.NgaySinh, kh.GioiTinh FROM dbo.KHACH_HANG kh 
	INNER JOIN dbo.THE_TV tv
	ON kh.MaKH = tv.MaKH
GO
-- View kiểm tra khách hàng có bao nhiêu điểm thành viên
CREATE VIEW VIEW_KH_DiemTV
AS
	SELECT kh.MaKH, kh.Ho, kh.TenLot, kh.Ten, the.MaThe, the.SoDiem --, the.TenBacTV
	FROM dbo.KHACH_HANG kh JOIN dbo.THE_TV the ON the.MaKH = kh.MaKH
GO
-- ========================================================================================================================== --
-- ========================================================================================================================== --
-- =====================================  _____ _   _ _   _  ____ _____ ___ ___  _   _  ===================================== --
-- ===================================== |  ___| | | | \ | |/ ___|_   _|_ _/ _ \| \ | | ===================================== --
-- ===================================== | |_  | | | |  \| | |     | |  | | | | |  \| | ===================================== --
-- ===================================== |  _| | |_| | |\  | |___  | |  | | |_| | |\  | ===================================== --
-- ===================================== |_|    \___/|_| \_|\____| |_| |___\___/|_| \_| ===================================== --
-- =====================================                                                ===================================== --
-- ========================================================================================================================== --
-- ========================================================================================================================== --

-- Tự động tạo mã nhân viên
CREATE FUNCTION FUNC_Create_MaNV()
RETURNS VARCHAR(10)
AS
BEGIN
	RETURN 'NV-' + FORMAT((SELECT COUNT(CMND) FROM dbo.NHAN_VIEN) + 1, '0000')
END;
GO
--Hàm lấy danh sách thông tin nhân viên còn đang làm việc
CREATE FUNCTION FUNC_Get_DSNhanVien (@MaNV VARCHAR(10))
RETURNS TABLE
AS
	RETURN(SELECT * FROM NHAN_VIEN WHERE MaNV = @MaNV AND TinhTrangLamViec = 1)
GO
-- Hàm lấy thông tin hàng hoá dựa vào mã
CREATE FUNCTION FUNC_Get_HangHoa(@MaHang VARCHAR(20))
RETURNS TABLE
AS
	RETURN (SELECT * FROM VIEW_HANG_HOA WHERE MaHang = @MaHang)
GO
-- Hàm tạo mã thẻ thành viên tự động
CREATE FUNCTION FUNC_Create_MaThe()
RETURNS VARCHAR(10)
AS 
BEGIN
	RETURN 'MB-' + FORMAT((SELECT COUNT(MaKH) FROM dbo.THE_TV) +1, '0000')
END;
GO
-- Hàm lấy tên của bậc dựa vào số điểm nhập vào
CREATE FUNCTION FUNC_Get_TenBac(@SoDiem INT)
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @TenBac NVARCHAR(10)
	SET @TenBac = 
		CASE 
			WHEN @SoDiem = 0 THEN N'None'
			WHEN @SoDiem > 0 AND @SoDiem < 200 THEN N'Bronze'
			WHEN @SoDiem >= 200 AND @SoDiem < 400 THEN N'Silver'
			WHEN @SoDiem >= 400 AND @SoDiem < 600 THEN N'Gold'
			ELSE N'VIP'
		END
	RETURN @TenBac
END;
GO

ALTER TABLE dbo.THE_TV
ADD TenBacTV AS dbo.FUNC_Get_TenBac(SoDiem)
GO

-- Hàm lấy giá trị giảm dựa vào điểm thành viên
CREATE FUNCTION FUNC_GetDiscount(@MaKH VARCHAR(10))
RETURNS REAL
AS
BEGIN 
	DECLARE @Discount REAL
	DECLARE @SoDiem INT
	SELECT @SoDiem = SoDiem FROM dbo.THE_TV WHERE MaKH = @MaKH
	SET @Discount = 
		CASE
			WHEN @SoDiem = 0 THEN 0.0
			WHEN @SoDiem > 0 AND @SoDiem < 200 THEN 0.1
			WHEN @SoDiem >= 200 AND @SoDiem < 400 THEN 0.2
			WHEN @SoDiem >= 400 AND @SoDiem < 600 THEN 0.3
			ELSE 0.4
		END
	RETURN @Discount
END;
GO 
-- =========================================================================================================================== --
-- =========================================================================================================================== --
-- ====================================  ____  ____   ___   ____ ____  _   _ ____  _____  ==================================== --
-- ==================================== |  _ \|  _ \ / _ \ / ___|  _ \| | | |  _ \| ____| ==================================== --
-- ==================================== | |_) | |_) | | | | |   | | | | | | | |_) |  _|   ==================================== --
-- ==================================== |  __/|  _ <| |_| | |___| |_| | |_| |  _ <| |___  ==================================== --
-- ==================================== |_|   |_| \_\\___/ \____|____/ \___/|_| \_\_____| ==================================== --
-- =========================================================================================================================== --
-- =========================================================================================================================== --

-- Register
CREATE PROC PROC_Register
@CMND VARCHAR(15),
@Ho NVARCHAR(10),
@TenLot NVARCHAR(10),
@Ten NVARCHAR(10),
@GioiTinh NVARCHAR(10),
@TenDN VARCHAR(20),
@MK VARCHAR(30)
AS
BEGIN
	-- Check if any record have that info
	IF EXISTS (SELECT CMND, TenDN FROM VIEW_NV_TK WHERE CMND = @CMND OR TenDN = @TenDN)
	BEGIN
		RAISERROR('Employee with the same ID or ID card number already exists.', 16, 1)
		RETURN -1; -- EXIT
	END

	-- Tạo mã NV tự động	
	DECLARE @NewMaNV VARCHAR(10) = dbo.FUNC_Create_MaNV()
	
	-- Thêm vào bảng NHAN_VIEN
	INSERT dbo.NHAN_VIEN(MaNV, CMND, Ho, TenLot, Ten, GioiTinh, TinhTrangLamViec)
	VALUES(@NewMaNV, @CMND, @Ho, @TenLot, @Ten, @GioiTinh, 1)

	-- Thêm vào bảng TAI_KHOAN_DN
	INSERT dbo.TAI_KHOAN_DN (MaNV, TenDN, MK)
	VALUES(@NewMaNV, @TenDN, @MK)

	SELECT MaNV FROM dbo.NHAN_VIEN WHERE MaNV = @NewMaNV
END;
GO


-- Login: Get info of user by TenDN
CREATE PROC PROC_Login
@TenDN VARCHAR(20),
@MK VARCHAR(30)
AS
BEGIN
	-- Select the user id from table NHAN_VIEN that match @TenDN and @MK
	-- If not found, raise error "Wrong username or password"
	IF NOT EXISTS(SELECT * FROM VIEW_NV_TK WHERE TenDN = @TenDN AND MK = @MK)
	BEGIN
		RAISERROR('Wrong username or password!', 16, 1)
		RETURN -1;
	END
	
	INSERT dbo.LS_DANG_NHAP (TenDN, ThoiGianDN)
	VALUES (@TenDN, GETDATE())

	SELECT * FROM dbo.VIEW_NV_TK WHERE TenDN = @TenDN
END;
GO

-- Get NV by Employee ID
CREATE PROC PROC_GetNV_ByEmpID
@MaNV VARCHAR(10)
AS
BEGIN
	SELECT * FROM dbo.NHAN_VIEN WHERE MaNV = @MaNV
END;
GO

-- Get NV by Cityzen ID
CREATE PROC PROC_GetNV_ByCityZID
@CMND VARCHAR(15)
AS
BEGIN
	SELECT * FROM dbo.NHAN_VIEN WHERE CMND = @CMND
END;
GO

-- Get NV by Username
CREATE PROC PROC_GetNV_ByUsername
@TenDN VARCHAR(20)
AS
BEGIN
	SELECT * FROM dbo.VIEW_NV_TK WHERE TenDN = @TenDN
END;
GO

-- Lấy thông tin hàng hoá dựa vào mã
CREATE PROC PROC_GetProduct_Info_ByID
@MaHang VARCHAR(20)
AS
BEGIN
	-- Kiểm tra mã đó là của vpp hay sách
	IF EXISTS (SELECT * FROM VIEW_VPP WHERE MaHang = @MaHang)
	BEGIN
		SELECT * FROM VIEW_VPP WHERE MaHang = @MaHang
	END

	ELSE IF EXISTS (SELECT * FROM VIEW_SACH WHERE MaSach = @MaHang)
	BEGIN
		SELECT * FROM VIEW_SACH WHERE MaSach = @MaHang
	END
END;
GO
--Create Customer
CREATE PROCEDURE PROC_Create_Customer
@MaKH VARCHAR(10),
@Ho VARCHAR (10),
@TenLot VARCHAR (20),
@Ten VARCHAR(10),
@NgaySinh DATETIME,
@GioiTinh VARCHAR(3),
@MaThe VARCHAR (10),
@SoDiem INT
AS 
BEGIN
	--Check if exist that customer or not
	IF EXISTS (SELECT MaKH FROM KHACH_HANG WHERE MaKH = @MaKH )
	BEGIN
		RAISERROR('Customer with the same ID number already exists.', 16, 1)
		RETURN -1; -- EXIT
	END
	-- Tạo mã thẻ thành viên tự động
	DECLARE @NewMaThe VARCHAR(10) = dbo.FUNC_Create_MaThe()

	-- Thêm vào bảng KHACH_HANG
	INSERT dbo.KHACH_HANG(MaKH, Ho, TenLot, Ten, NgaySinh, GioiTinh)
	VALUES(@MaKH, @Ho, @TenLot, @Ten, @NgaySinh, @GioiTinh)

	-- Thêm vào bảng THE_TV
	INSERT dbo.THE_TV(MaThe, SoDiem, MaKH)
	VALUES(@NewMaThe, 0, @MaKH)

	SELECT MaThe FROM dbo.THE_TV WHERE MaThe = @NewMaThe
END;
GO

CREATE PROCEDURE PROC_GetKH_ByCusID
@MaKH VARCHAR(10)
AS
BEGIN
	IF EXISTS (SELECT MaKH FROM THE_TV WHERE MaKH != @MaKH)
	BEGIN
		RAISERROR('Does not exist customer ID, Please create account!', 16, 1)
		RETURN -1;
	END
	SELECT * FROM dbo.THE_TV WHERE MaKH = @MaKH
END;
GO

CREATE PROCEDURE PROC_GetKH_ByMemID
@MaThe VARCHAR(10)
AS 
BEGIN
	IF EXISTS (SELECT MaKH FROM THE_TV WHERE MaThe != @MaThe)
	BEGIN
		RAISERROR('Does not exist Membership ID, Please create account!', 16, 1)
		RETURN -1;
	END
	SELECT * FROM dbo.THE_TV WHERE MaThe = @MaThe
END;
GO

-- ========================================================================================================================== --
-- ========================================================================================================================== --
-- ========================================  _____ ____  ___ ____  ____ _____ ____   ======================================== --
-- ======================================== |_   _|  _ \|_ _/ ___|/ ___| ____|  _ \  ======================================== --
-- ========================================   | | | |_) || | |  _| |  _|  _| | |_) | ======================================== --
-- ========================================   | | |  _ < | | |_| | |_| | |___|  _ <  ======================================== --
-- ========================================   |_| |_| \_\___\____|\____|_____|_| \_\ ======================================== --
-- ========================================================================================================================== --
-- ========================================================================================================================== --

USE Proj_DBMS_BookStore
GO
-- Trigger khi bán hàng: Tự động giảm số lượng của vật phẩm trong bảng HANG_HOA bằng với số lượng bán ra
CREATE TRIGGER DecreaseProductCount ON dbo.BAN_HANG
AFTER INSERT
AS
BEGIN
	-- Lấy số lượng bán ra của sản phẩm 
	DECLARE @SoLuongBan INT;
	SELECT @SoLuongBan = (SELECT SoLuong FROM Inserted);

	-- Giảm số lượng của sản phẩm đó trong bảng HANG_HOA
	UPDATE dbo.HANG_HOA
	SET SoLuong = SoLuong - @SoLuongBan
	WHERE MaHang = (SELECT MaHang FROM Inserted);
END;
GO

-- Trigger khi nhập hàng: Tự động tăng số lượng của vật phẩm trong bảng HANG_HOA bằng với số lượng nhập vào
CREATE TRIGGER IncreaseProductCount ON dbo.NHAP_HANG
AFTER INSERT
AS
BEGIN
	-- Lấy số lượng nhập vào của sản phẩm 
	DECLARE @SoLuongNhap INT;
	SELECT @SoLuongNhap = (SELECT SoLuong FROM Inserted);

	-- Tăng số lượng của sản phẩm đó trong bảng HANG_HOA
	UPDATE dbo.HANG_HOA
	SET SoLuong = SoLuong + @SoLuongNhap
	WHERE MaHang = (SELECT MaHang FROM Inserted);
END;
GO

-- Trigger tự động xoá lịch sử đăng nhập của nhân viên khi xoá thông tin nhân viên (Nghỉ việc)
CREATE TRIGGER DeleteLoginHistory ON dbo.NHAN_VIEN 
INSTEAD OF DELETE
AS
DECLARE @MaNVXoa VARCHAR(10), @Err NVARCHAR(MAX)
SELECT @MaNVXoa = ol.MaNV FROM Deleted ol
BEGIN
	-- Tự động rollback nếu gặp lỗi
	SET XACT_ABORT ON
		BEGIN TRAN
			-- TRY - CATCH
			BEGIN TRY
				-- Chỉnh sửa tình trạng làm việc của nhân viên thành 'nghỉ làm'
				UPDATE dbo.NHAN_VIEN SET TinhTrangLamViec = 0 WHERE MaNV = @MaNVXoa

				-- Xoá lịch sử đăng nhập của nhân viên
				DECLARE @username VARCHAR(20)
				SELECT @username = TenDN FROM TAI_KHOAN_DN WHERE MaNV = @MaNVXoa
				DELETE FROM dbo.LS_DANG_NHAP WHERE TenDN = @username

				-- Xoá tên đăng nhập
				DELETE FROM TAI_KHOAN_DN WHERE MaNV = @MaNVXoa

				COMMIT TRAN
			END TRY
			-- CATCH Lỗi
			BEGIN CATCH
				ROLLBACK
				SELECT @Err = 'ERR: ' + ERROR_MESSAGE()
			END CATCH
END;
GO

CREATE TRIGGER CreateReceipt ON dbo.BAN_HANG
INSTEAD OF INSERT
AS
DECLARE @MaHoaDon VARCHAR(10),
		@MaKH VARCHAR(10),
		@MaNV VARCHAR(10),
		@MaHang VARCHAR(20),
		@SoLuong INT
SELECT	@MaHoaDon = new.MaHoaDon,
		@MaKH = new.MaKH,
		@MaNV = new.MaNVBan,
		@MaHang = new.MaHang,
		@SoLuong = new.SoLuong
		FROM Inserted new
BEGIN
	SET XACT_ABORT ON
	BEGIN TRAN
		BEGIN TRY
			-- Nếu mã hoá đơn chưa có trong bảng hoá đơn bán thì thêm vào 
			IF NOT EXISTS (SELECT * FROM dbo.HOA_DON_BAN WHERE MaHoaDon = @MaHoaDon)
			BEGIN
				DECLARE @Discount REAL
				SET @Discount = dbo.FUNC_GetDiscount(@MaKH)
				INSERT dbo.HOA_DON_BAN (MaHoaDon, KhuyenMai, ThoiGianBan)
				VALUES (@MaHoaDon, @Discount, GETDATE())
			END

			-- Thêm mã hàng vào trong bảng bán hàng
			INSERT dbo.BAN_HANG (MaHoaDon, MaNVBan, MaKH, MaHang, SoLuong)
			VALUES (@MaHoaDon, @MaNV, @MaKH, @MaHang, @SoLuong)

			COMMIT TRAN
		END TRY

		BEGIN CATCH
			ROLLBACK
			DECLARE @err NVARCHAR(MAX)
			SET @err = 'ERROR FROM Trigger CreateReceipt: ' + ERROR_MESSAGE()
			RAISERROR(@err, 16, 1)
		END CATCH
END;
GO

-- =========================================================================================================================== --
-- =========================================================================================================================== --
-- ===============================  ___ _   _ ____  _____ ____ _____   ____    _  _____  _     =============================== --
-- =============================== |_ _| \ | / ___|| ____|  _ \_   _| |  _ \  / \|_   _|/ \    =============================== --
-- ===============================  | ||  \| \___ \|  _| | |_) || |   | | | |/ _ \ | | / _ \   =============================== --
-- ===============================  | || |\  |___) | |___|  _ < | |   | |_| / ___ \| |/ ___ \  =============================== --
-- =============================== |___|_| \_|____/|_____|_| \_\|_|   |____/_/   \_\_/_/   \_\ =============================== --
-- =========================================================================================================================== --
-- =========================================================================================================================== --

USE Proj_DBMS_BookStore
INSERT dbo.NXB(MaNXB, TenNXB, DiaChi, SDT)
VALUES
('GDVN', N'Nhà xuất bản Giáo dục Việt Nam', N'Số 81 Trần Hưng Đạo, Hoàn Kiếm, Hà Nội', '02438220801'),
('KD', N'Nhà xuất bản Kim Đồng', N'55 Quang Trung, Hai Bà Trưng, Hà Nội', '1900571595'),
('TRE', N'Nhà xuất bản Trẻ', N'161B Lý Chính Thắng, Phường Võ Thị Sáu, Quận 3 , TP. Hồ Chí Minh', '02839316289'),
('TN', N'Nhà xuất bản Thanh Niên', N'270 Nguyễn Đình Chiểu, P. 6, Q. 3,Tp. Hồ Chí Minh,', '02839303262'),
('NEU', N'Nhà xuất bản Đại Học Kinh Tế Quốc Dân', N'207 Đường Giải Phóng - Hà Nội', '02436282487'),
('HN', N'Nhà xuất bản Hà Nội', N'Số 4, phố Tống Duy Tân, quận Hoàn Kiếm, Hà Nội', '02438252916'),
('CAM', N'Cambridge University Press & Assessment', N'Shaftesbury Road, Cambridge CB2 8BS, England', '01223358331')
GO

INSERT dbo.HANG_HOA(MaHang, DonGia, SoLuong)
VALUES
('HP01', 116000, 5), -- Harry Potter - Trẻ
('HP02', 144500, 6),
('HP03', 159000, 6),
('HP04', 252000, 5),
('HP05', 312000, 4),
('HP06', 189000,2),
('HP07', 228000,7),
('TLCC', 75000,8), -- Những tấm lòng cao cả - Kim đồng
('CB01', 38000,5), -- Charlie Bone - Trẻ
('CB02', 38000,9),
('CB03', 39000,10),
('CB04', 54000,3),
('CB05', 62000,8),
('CH06', 52000,9),
('CB07', 66000,12),
('CB08', 71000,3),
('TA001', 200000,6), -- Ngữ pháp tiếng anh
('TA002', 66000,99), -- 2000 từ vựng tiếng anh - NXB Hà nội
('TA003', 135000,12), -- từ vựng 8.0 ielts - NXB Hà nội
('TA004', 250000,12 ), -- 4000 từ vựng và mẫu câu cho trẻ em - NXB Hà nội
('TA005', 105000,17), -- Mover từ vựng - NXB Hà nội
('IELTS01', 85000,12), -- Cambridge IELTS 1 - Cambridge
('IELTS02', 85000,8),-- Cambridge IELTS 2
('IELTS03', 99000,12),-- Cambridge IELTS 3
('IELTS04', 99000,7),-- Cambridge IELTS 4
('IELTS05', 105000,9),-- Cambridge IELTS 5
('IELTS06', 135000,12),-- Cambridge IELTS 6
('IELTS07', 135000,6),-- Cambridge IELTS 7
('IELTS08', 153000,12),-- Cambridge IELTS 8
('CONAN01', 25000,23), -- Thám tử Conan tập 1 - Kim đồng
('CONAN02', 25000,32),-- Thám tử Conan tập 2
('CONAN03', 25000,66),-- Thám tử Conan tập 3
('CONAN04', 25000,61),-- Thám tử Conan tập 4
('DB001', 25000,15), -- 7 viên ngọc rồng tập 1
('DB002', 25000,12),-- 7 viên ngọc rồng tập 2
('DB003', 25000,15),-- 7 viên ngọc rồng tập 3
('DB004', 25000,15),-- 7 viên ngọc rồng tập 4
('DB005', 25000,17),-- 7 viên ngọc rồng tập 5
('DST01', 25000,31), -- Dr.Stone tập 1
('DST02', 25000,52),-- Dr.Stone tập 2
('DST03', 25000,53),-- Dr.Stone tập 3
('OP001', 149000,0), -- One Piece tập 1
('OP002', 149000,31), -- One Piece tập 2
('OP003', 149000,52), -- One Piece tập 3
('OP004', 149000,14), -- One Piece tập 4
('OP005', 149000,32), -- One Piece tập 5
('NGK', 79000,81), -- Nhà giả kim
('NNA01', 90000,5), -- Cho tôi xin 1 vé đi tuổi thơ - Trẻ
('NNA02', 35000,2), -- Cô gái đến từ hôm qua
('NNA03', 110000,0), -- Cảm ơn người lớn
('NNA04', 43000, 0), -- Thằng quỷ nhỏ
('MKT01', 139000, 0), -- TikTok Marketing - Thanh niên
('MKT02', 999000,0), -- Nguyên lý marketing - Hà nội 
('MKT03', 120000,0), -- Tiếp thị 5.0 - Thanh niên
('MKT04', 188000,73), -- Định vị thương hiệu cá nhân - Thanh niên
('TV11', 33000,75), -- TV 1 T 1 - GDVN
('TV12', 31000,16), -- TV 1 T 2
('TOAN1', 28000,65), -- Toán 1
('TV21', 26000,54), -- TV 2 T 1
('TV22', 24000,32), -- TV 2 T 2
('TOAN2', 30000,13), -- Toán 2
('TV31', 31000,20), -- TV 3 T 1
('TV32', 28000,1), -- TV 3 T 1
('TOAN3', 33000,10), -- Toán 3
('TV41', 30000,32),
('TV42', 27000,21),
('TOAN4', 32000, 52),
('TIN4', 31000,62), -- Tin học 4
('TV51', 29000,15),
('TV52', 31000,14),
('TOAN5', 35000,13),
('TIN5', 34000,32), -- Tin học 5
('TL-079', 5500, 22), -- Bút bi thiên long 
('TL-089', 4500, 35),
('TL-090', 3500, 46),
('TL-093', 4000, 0),
('TL-095', 11000, 4),
('TL-097', 4000, 12),
('TL-008', 5500, 0),
('SR-002', 5000, 32), -- Thước kẻ
('SR-003', 7000, 0),
('SR-024', 10000, 0),
('SR-026', 26000, 12),
('SR-031', 18000, 87),
('GP-027', 4500, 32), -- Bút chì gỗ 2B
('GP-026', 3500, 31), -- HB
('GP-025', 8000, 81), -- 6B
('GP-024', 8000, 53), -- 5B
('GP-023', 6300, 91), -- 4B
('GP-022', 6300, 49), -- 3B
('GP-020', 4000, 124), -- 2B
('GP-018', 4500, 52), -- 2B
('GP-016', 2000,123), -- HB
('GP-004', 5500, 90), -- GB
('PC-024', 19800, 12), -- Bút chì bấm HB
('PC-026', 17500, 51), -- Bút chì bấm 2B
('PC-018', 9000,34), -- HB
('NB-096', 16200,65), -- Tập học sinh
('NB-095', 12600,10),
('NB-094', 15300,13),
('NB-066', 9900,30),
('NB-061', 8500,19),
('NB-053', 7000,67),
('NB-039', 5000, 25),
('E-033', 6000,0), -- Gôm
('E-032', 6000,1),
('E-031', 6500,12),
('E-026', 6000,9),
('E-010', 5000,10),
('E-011', 3900, 10),
('E-030', 5500, 7),
('E-028', 8000, 5),
('E-029', 7000, 2)
GO


INSERT dbo.VAN_PHONG_PHAM(MaHang, TenHang)
VALUES
('TL-079', 'Bút bi Thiên Long TL-079'), -- Bút bi thiên long 
('TL-089', 'Bút bi Thiên Long TL-089'),
('TL-090', 'Bút bi Thiên Long TL-090'),
('TL-093', 'Bút bi Thiên Long TL-093'),
('TL-095', 'Bút bi Thiên Long TL-095'),
('TL-097', 'Bút bi Thiên Long TL-097'),
('TL-008', 'Bút bi Thiên Long TL-008'),
('SR-002', 'Thước kẻ Thiên Long nhựa cứng 15cm'), -- Thước kẻ
('SR-003', 'Thước kẻ Thiên Long nhựa cứng 20cm'),
('SR-024', 'Thước kẻ Thiên Long nhựa dẻo 20cm'),
('SR-026', 'Thước kẻ Thiên Long nhựa cứng 50cm'),
('SR-031', 'Thước kẻ Thiên Long nhựa cứng 30cm'),
('GP-027', 'Bút chì gỗ 2B lục giác'), -- Bút chì gỗ 2B
('GP-026', 'Bút chì gỗ HB lục giác'), -- HB
('GP-025', 'Bút chì gỗ 6B lục giác'), -- 6B
('GP-024', 'Bút chì gỗ 5B lục giác'), -- 5B
('GP-023', 'Bút chì gỗ 4B lục giác'), -- 4B
('GP-022', 'Bút chì gỗ 3B lục giác'), -- 3B
('GP-020', 'Bút chì gỗ 2B lục giác'), -- 2B
('GP-018', 'Bút chì gỗ 2B tam giác'), -- 2B
('GP-016', 'Bút chì gỗ HB tam giác'), -- HB
('GP-004', 'Bút chì gỗ HB lục giác'), -- HB
('PC-024', 'Bút chì bấm HB 0.05mm'), -- Bút chì bấm HB
('PC-026', 'Bút chì bấm 2B 0.5mm'), -- Bút chì bấm 2B
('PC-018', 'Bút chì bấm HB 0.07mm'), -- HB
('NB-096', 'Tập học sinh kẻ ngang 200 trang'), -- Tập học sinh
('NB-095', 'Tập học sinh kẻ ngang 98 trang'),
('NB-094', 'Tập học sinh kẻ ô 200 trang'),
('NB-066', 'Tập học sinh kẻ ô 98 trang'),
('NB-061', 'Tập học sinh kẻ ô 98 trang'),
('NB-053', 'Tập học sinh kẻ ô 98 trang'),
('NB-039', 'Tập học sinh kẻ ô 98 trang'),
('E-033', 'Gôm hình Pikachu'), -- Gôm
('E-032', 'Gôm hình gấu Pooh'),
('E-031', 'Gôm hình BlackPink'),
('E-026', 'Gôm hình Pikachu'),
('E-010', 'Gôm hình Bạch Tuyết'),
('E-011', 'Gôm hình Gấu Lotso'),
('E-030', 'Gôm hình Buzz Lightyear'),
('E-028', 'Gôm vệ sinh LifeBouy'),
('E-029', 'Gôm hình Doraemon')
GO

INSERT dbo.SACH(MaSach, TieuDe, MaNXB, NamXB)
VALUES
('HP01', N'Harry Potter và Hòn Đá Phù Thuỷ', 'TRE', 2020), -- Harry Potter - Trẻ
('HP02', N'Hary Potter và Phòng Chứa Bí Mật', 'TRE', 2020),
('HP03', N'Hary Potter và Tên Tù Nhân Ngục Azkaban', 'TRE', 2020),
('HP04', N'Hary Potter và Chiếc Cốc Lửa', 'TRE', 2020),
('HP05', N'Hary Potter và Hội Phượng Hoàng', 'TRE', 2020),
('HP06', N'Hary Potter và Hoàng Tử Lai', 'TRE', 2020),
('HP07', N'Hary Potter và Bảo Bối Tử Thần', 'TRE', 2020),
('TLCC', N'Nhứng tấm lòng cao cả', 'KD', 2018), -- Những tấm lòng cao cả - Kim đồng
('CB01', N'Charlie Bone 1', 'TRE', 2010), -- Charlie Bone - Trẻ
('CB02', N'Charlie Bone 2', 'TRE', 2010),
('CB03', N'Charlie Bone 3', 'TRE', 2010),
('CB04', N'Charlie Bone 4', 'TRE', 2010),
('CB05', N'Charlie Bone 5', 'TRE', 2010),
('CH06', N'Charlie Bone 6', 'TRE', 2010),
('CB07', N'Charlie Bone 7', 'TRE', 2010),
('CB08', N'Charlie Bone 8', 'TRE', 2010),
('TA001', N'Ngữ pháp Tiếng Anh tái bản', 'HN', 2020), -- Ngữ pháp tiếng anh
('TA002', N'Tự học 2000 từ vựng tiếng Anh', 'HN', 2018), -- 2000 từ vựng tiếng anh - NXB Hà nội
('TA003', N'Nâng cấp từ vựng 8.0 IELTS', 'HN', 2021), -- từ vựng 8.0 ielts - NXB Hà nội
('TA004', N'4000 từ vựng và mẫu câu cho trẻ em', 'HN', 2022), -- 4000 từ vựng và mẫu câu cho trẻ em - NXB Hà nội
('TA005', N'Từ vựng Mover', 'HN', 2021), -- Mover từ vựng - NXB Hà nội
('IELTS01', N'Cambridge IELTS Academic 1', 'CAM', 2018), -- Cambridge IELTS 1 - Cambridge
('IELTS02', N'Cambridge IELTS Academic 2', 'CAM', 2018),-- Cambridge IELTS 2
('IELTS03', N'Cambridge IELTS Academic 3', 'CAM', 2018),-- Cambridge IELTS 3
('IELTS04', N'Cambridge IELTS Academic 4', 'CAM', 2018),-- Cambridge IELTS 4
('IELTS05', N'Cambridge IELTS Academic 5', 'CAM', 2018),-- Cambridge IELTS 5
('IELTS06', N'Cambridge IELTS Academic 6', 'CAM', 2018),-- Cambridge IELTS 6
('IELTS07', N'Cambridge IELTS Academic 7', 'CAM', 2018),-- Cambridge IELTS 7
('IELTS08', N'Cambridge IELTS Academic 8', 'CAM', 2018),-- Cambridge IELTS 8
('CONAN01', N'Thám tử lừng danh Conan tập 1', 'KD', 2022), -- Thám tử Conan tập 1 - Kim đồng
('CONAN02', N'Thám tử lừng danh Conan tập 2', 'KD', 2022),-- Thám tử Conan tập 2
('CONAN03', N'Thám tử lừng danh Conan tập 3', 'KD', 2022),-- Thám tử Conan tập 3
('CONAN04', N'Thám tử lừng danh Conan tập 4', 'KD', 2022),-- Thám tử Conan tập 4
('DB001', N'7 viên ngọc rồng tập 1', 'KD', 2018), -- 7 viên ngọc rồng tập 1
('DB002', N'7 viên ngọc rồng tập 2', 'KD', 2018),-- 7 viên ngọc rồng tập 2
('DB003', N'7 viên ngọc rồng tập 3', 'KD', 2018),-- 7 viên ngọc rồng tập 3
('DB004', N'7 viên ngọc rồng tập 4', 'KD', 2018),-- 7 viên ngọc rồng tập 4
('DB005', N'7 viên ngọc rồng tập 5', 'KD', 2018),-- 7 viên ngọc rồng tập 5
('DST01', N'Dr.Stone tập 1', 'KD', 2022), -- Dr.Stone tập 1
('DST02', N'Dr.Stone tập 2', 'KD', 2022),-- Dr.Stone tập 2
('DST03', N'Dr.Stone tập 3', 'KD', 2022),-- Dr.Stone tập 3
('OP001', N'One Piece tập 1', 'KD', 2021), -- One Piece tập 1
('OP002', N'One Piece tập 2', 'KD', 2021), -- One Piece tập 2
('OP003', N'One Piece tập 3', 'KD', 2021), -- One Piece tập 3
('OP004', N'One Piece tập 4', 'KD', 2021), -- One Piece tập 4
('OP005', N'One Piece tập 5', 'KD', 2021), -- One Piece tập 5
('NGK', N'Nhà giả kim', 'TN', 2020), -- Nhà giả kim
('NNA01', N'Cho tôi xin một vé đi tuổi thơ', 'TRE', 2018), -- Cho tôi xin 1 vé đi tuổi thơ - Trẻ
('NNA02', N'Cô gái đến từ hôm qua', 'TRE', 2019), -- Cô gái đến từ hôm qua
('NNA03', N'Cảm ơn người lớn', 'TRE', 2020), -- Cảm ơn người lớn
('NNA04', N'Thằng quỷ nhỏ', 'TRE', 2018 ), -- Thằng quỷ nhỏ
('MKT01', N'TikTok Marketing', 'TN', 2022), -- TikTok Marketing - Thanh niên
('MKT02', N'Nguyên lý marketing', 'HN', 2021), -- Nguyên lý marketing - Hà nội 
('MKT03', N'Tiếp thị 5.0', 'TN', 2022), -- Tiếp thị 5.0 - Thanh niên
('MKT04', N'Định vị thương hiệu cá nhân', 'TN', 2021), -- Định vị thương hiệu cá nhân - Thanh niên
('TV11', N'SGK Tiếng Việt lớp 1 - tập 1', 'GDVN', 2022), -- TV 1 T 1 - GDVN
('TV12', N'SGK Tiếng Việt lớp 1 - tập 2', 'GDVN', 2022), -- TV 1 T 2
('TOAN1', N'SGK Toán lớp 1', 'GDVN', 2022), -- Toán 1
('TV21', N'SGK Tiếng Việt lớp 2 - tập 1', 'GDVN', 2022), -- TV 2 T 1
('TV22', N'SGK Tiếng Việt lớp 2 - tập 2', 'GDVN', 2022), -- TV 2 T 2
('TOAN2', N'SGK Toán lớp 2', 'GDVN', 2022), -- Toán 2
('TV31', N'SGK Tiếng Việt lớp 3 - tập 1', 'GDVN', 2022), -- TV 3 T 1
('TV32', N'SGK Tiếng Việt lớp 3 - tập 2', 'GDVN', 2022), -- TV 3 T 1
('TOAN3', N'SGK Toán lớp 3', 'GDVN', 2022), -- Toán 3
('TV41', N'SGK Tiếng Việt lớp 4 - tập 1', 'GDVN', 2022),
('TV42', N'SGK Tiếng Việt lớp 4 - tập 2', 'GDVN', 2022),
('TOAN4', N'SGK Toán lớp 4', 'GDVN', 2022),
('TIN4', N'SGK Tin học lớp 4', 'GDVN', 2022), -- Tin học 4
('TV51', N'SGK Tiếng Việt lớp 5 - tập 1', 'GDVN', 2022),
('TV52', N'SGK Tiếng Việt lớp 5 - tập 2', 'GDVN', 2022),
('TOAN5', N'SGK Toán lớp 5', 'GDVN', 2022),
('TIN5', N'SGK Tin học lớp 5', 'GDVN', 2022) -- Tin học 5
GO

INSERT dbo.TAC_GIA(MaTG, TenTG)
VALUES
('JKR', N'J.K.Rowling'),
('EDA', N'Edmondo De Amicis'),
('JN', N'Jenny Nimmo'),
('MLH', N'Mai Lan Hương'),
('HTU', N'Hà Thanh Uyên'),
('TW', N'The Windy'),
('LTH', N'Lê Thu Hà'),
('MIS', N'Ban biên tập MIS'),
('NTG', N'Nhiều tác giả'),
('GA', N'Gosho Aoyama'),
('AT', N'Akira Toriyama'),
('IR', N'Inagaki Riichiro'),
('EO', N'Eiichiro Oda'),
('PC', N'Paulo Coelho'),
('NNA', N'Nguyễn Nhật Ánh')
GO

INSERT dbo.TAC_GIA_SACH(MaSach, MaTG)
VALUES
('HP01', 'JKR'), -- Harry Potter - Trẻ
('HP02', 'JKR'),
('HP03', 'JKR'),
('HP04', 'JKR'),
('HP05', 'JKR'),
('HP06', 'JKR'),
('HP07', 'JKR'),
('TLCC', 'EDA'), -- Những tấm lòng cao cả - Kim đồng
('CB01', 'JN'), -- Charlie Bone - Trẻ
('CB02', 'JN'),
('CB03', 'JN'),
('CB04', 'JN'),
('CB05', 'JN'),
('CH06', 'JN'),
('CB07', 'JN'),
('CB08', 'JN'),
('TA001', 'MLH'), -- Ngữ pháp tiếng anh
('TA001', 'HTU'), -- Ngữ pháp tiếng anh
('TA002', 'TW'), -- 2000 từ vựng tiếng anh - NXB Hà nội
('TA003', 'LTH'), -- từ vựng 8.0 ielts - NXB Hà nội
('TA004', 'MIS' ), -- 4000 từ vựng và mẫu câu cho trẻ em - NXB Hà nội
('TA005', 'MLH'), -- Mover từ vựng - NXB Hà nội
('IELTS01', 'NTG'), -- Cambridge IELTS 1 - Cambridge
('IELTS02', 'NTG'),-- Cambridge IELTS 2
('IELTS03', 'NTG'),-- Cambridge IELTS 3
('IELTS04', 'NTG'),-- Cambridge IELTS 4
('IELTS05', 'NTG'),-- Cambridge IELTS 5
('IELTS06', 'NTG'),-- Cambridge IELTS 6
('IELTS07', 'NTG'),-- Cambridge IELTS 7
('IELTS08', 'NTG'),-- Cambridge IELTS 8
('CONAN01', 'GA'), -- Thám tử Conan tập 1 - Kim đồng
('CONAN02', 'GA'),-- Thám tử Conan tập 2
('CONAN03', 'GA'),-- Thám tử Conan tập 3
('CONAN04', 'GA'),-- Thám tử Conan tập 4
('DB001', 'AT'), -- 7 viên ngọc rồng tập 1
('DB002', 'AT'),-- 7 viên ngọc rồng tập 2
('DB003', 'AT'),-- 7 viên ngọc rồng tập 3
('DB004', 'AT'),-- 7 viên ngọc rồng tập 4
('DB005', 'AT'),-- 7 viên ngọc rồng tập 5
('DST01', 'IR'), -- Dr.Stone tập 1
('DST02', 'IR'),-- Dr.Stone tập 2
('DST03', 'IR'),-- Dr.Stone tập 3
('OP001', 'EO'), -- One Piece tập 1
('OP002', 'EO'), -- One Piece tập 2
('OP003', 'EO'), -- One Piece tập 3
('OP004', 'EO'), -- One Piece tập 4
('OP005', 'EO'), -- One Piece tập 5
('NGK', 'PC'), -- Nhà giả kim
('NNA01', 'NNA'), -- Cho tôi xin 1 vé đi tuổi thơ - Trẻ
('NNA02', 'NNA'), -- Cô gái đến từ hôm qua
('NNA03', 'NNA'), -- Cảm ơn người lớn
('NNA04', 'NNA'), -- Thằng quỷ nhỏ
('MKT01', 'NTG'), -- TikTok Marketing - Thanh niên
('MKT02', 'NTG'), -- Nguyên lý marketing - Hà nội 
('MKT03', 'NTG'), -- Tiếp thị 5.0 - Thanh niên
('MKT04', 'NTG'), -- Định vị thương hiệu cá nhân - Thanh niên
('TV11', 'NTG'), -- TV 1 T 1 - GDVN
('TV12', 'NTG'), -- TV 1 T 2
('TOAN1', 'NTG'), -- Toán 1
('TV21', 'NTG'), -- TV 2 T 1
('TV22', 'NTG'), -- TV 2 T 2
('TOAN2', 'NTG'), -- Toán 2
('TV31', 'NTG'), -- TV 3 T 1
('TV32', 'NTG'), -- TV 3 T 1
('TOAN3', 'NTG'), -- Toán 3
('TV41', 'NTG'),
('TV42', 'NTG'),
('TOAN4', 'NTG'),
('TIN4', 'NTG'), -- Tin học 4
('TV51', 'NTG'),
('TV52', 'NTG'),
('TOAN5', 'NTG'),
('TIN5', 'NTG') -- Tin học 5
GO

INSERT dbo.THE_LOAI (MaLoai, TenLoai)
VALUES
('TT','Tiểu thuyết'),
('TTr','Truyện tranh'),
('KD','Kinh doanh'),
('SGK','Sách giáo khoa'),
('NN','Ngoại ngữ')
GO

INSERT dbo.THE_LOAI_SACH (MaSach, MaLoai)
VALUES
('HP01', 'TT'), -- Harry Potter - Trẻ
('HP02', 'TT'),
('HP03', 'TT'),
('HP04', 'TT'),
('HP05', 'TT'),
('HP06', 'TT'),
('HP07', 'TT'),
('TLCC', 'TT'), -- Những tấm lòng cao cả - Kim đồng
('CB01', 'TT'), -- Charlie Bone - Trẻ
('CB02', 'TT'),
('CB03', 'TT'),
('CB04', 'TT'),
('CB05', 'TT'),
('CH06', 'TT'),
('CB07', 'TT'),
('CB08', 'TT'),
('TA001', 'NN'), -- Ngữ pháp tiếng anh
('TA002', 'NN'), -- 2000 từ vựng tiếng anh - NXB Hà nội
('TA003', 'NN'), -- từ vựng 8.0 ielts - NXB Hà nội
('TA004', 'NN' ), -- 4000 từ vựng và mẫu câu cho trẻ em - NXB Hà nội
('TA005', 'NN'), -- Mover từ vựng - NXB Hà nội
('IELTS01', 'NN'), -- Cambridge IELTS 1 - Cambridge
('IELTS02', 'NN'),-- Cambridge IELTS 2
('IELTS03', 'NN'),-- Cambridge IELTS 3
('IELTS04', 'NN'),-- Cambridge IELTS 4
('IELTS05', 'NN'),-- Cambridge IELTS 5
('IELTS06', 'NN'),-- Cambridge IELTS 6
('IELTS07', 'NN'),-- Cambridge IELTS 7
('IELTS08', 'NN'),-- Cambridge IELTS 8
('CONAN01', 'TTr'), -- Thám tử Conan tập 1 - Kim đồng
('CONAN02', 'TTr'),-- Thám tử Conan tập 2
('CONAN03', 'TTr'),-- Thám tử Conan tập 3
('CONAN04', 'TTr'),-- Thám tử Conan tập 4
('DB001', 'TTr'), -- 7 viên ngọc rồng tập 1
('DB002', 'TTr'),-- 7 viên ngọc rồng tập 2
('DB003', 'TTr'),-- 7 viên ngọc rồng tập 3
('DB004', 'TTr'),-- 7 viên ngọc rồng tập 4
('DB005', 'TTr'),-- 7 viên ngọc rồng tập 5
('DST01', 'TTr'), -- Dr.Stone tập 1
('DST02', 'TTr'),-- Dr.Stone tập 2
('DST03', 'TTr'),-- Dr.Stone tập 3
('OP001', 'TTr'), -- One Piece tập 1
('OP002', 'TTr'), -- One Piece tập 2
('OP003', 'TTr'), -- One Piece tập 3
('OP004', 'TTr'), -- One Piece tập 4
('OP005', 'TTr'), -- One Piece tập 5
('NGK', 'TT'), -- Nhà giả kim
('NNA01', 'TT'), -- Cho tôi xin 1 vé đi tuổi thơ - Trẻ
('NNA02', 'TT'), -- Cô gái đến từ hôm qua
('NNA03', 'TT'), -- Cảm ơn người lớn
('NNA04', 'TT'), -- Thằng quỷ nhỏ
('MKT01', 'KD'), -- TikTok Marketing - Thanh niên
('MKT02', 'KD'), -- Nguyên lý marketing - Hà nội 
('MKT03', 'KD'), -- Tiếp thị 5.0 - Thanh niên
('MKT04', 'KD'), -- Định vị thương hiệu cá nhân - Thanh niên
('TV11', 'SGK'), -- TV 1 T 1 - GDVN
('TV12', 'SGK'), -- TV 1 T 2
('TOAN1', 'SGK'), -- Toán 1
('TV21', 'SGK'), -- TV 2 T 1
('TV22', 'SGK'), -- TV 2 T 2
('TOAN2', 'SGK'), -- Toán 2
('TV31', 'SGK'), -- TV 3 T 1
('TV32', 'SGK'), -- TV 3 T 1
('TOAN3', 'SGK'), -- Toán 3
('TV41', 'SGK'),
('TV42', 'SGK'),
('TOAN4', 'SGK'),
('TIN4', 'SGK'), -- Tin học 4
('TV51', 'SGK'),
('TV52', 'SGK'),
('TOAN5', 'SGK'),
('TIN5', 'SGK') -- Tin học 5
GO


INSERT dbo.NHAN_VIEN(MaNV, CMND, Ho, TenLot, Ten, GioiTinh, Luong, TinhTrangLamViec)
VALUES
('NV-001', '045203001353', N'Nguyễn', N'Văn', 'Vũ', N'Nam', 4000000, 1),
('NV-002', '014201003245', N'Hoàng', N'Ngọc Quang', N'Minh', N'Nam',4500000, 1),
('NV-003', '045302001521', N'Nguyễn', N'Trần Bảo', N'Ngọc', N'Nữ', 4500000, 1),
('NV-004', '035301003241', N'Trần', N'Thị', N'Nghỉ', N'Nữ', 3500000, 1),
('NV-005', '045599007671', N'Lê', N'Văn', N'Ngọc', N'Nam', 5000000, 1)
GO

INSERT dbo.TAI_KHOAN_DN (MaNV, TenDN, MK)
VALUES
('NV-001', 'nvv1353', 'MK123456'),
('NV-002', 'hnqm3245', 'MK123456'),
('NV-003', 'ntbn1521','MK123456'),
('NV-004', 'ttn3241','MK123456'),
('NV-005', 'nvnn7671','MK123456')
GO

INSERT dbo.LS_DANG_NHAP(TenDN, ThoiGianDN)
VALUES
('nvv1353','2024-03-13'),
('hnqm3245','2024-03-12'),
('ntbn1521','2024-03-11'),
('ttn3241','2024-03-06'),
('nvnn7671','2024-03-01')
GO

INSERT dbo.KHACH_HANG (MaKH, Ho, TenLot, Ten, NgaySinh, GioiTinh)
VALUES
('0837123647', N'Nguyễn', N'Công', N'Hoan', '1998-04-03', N'Nam'),
('0973034785', N'Huỳnh', N'Nguyễn Minh', N'Châu', '2003-11-17', N'Nữ'),
('0917654721', N'Đào', N'Toan', N'Tính', '2008-01-30', N'Nam'),
('0913133277', N'Nguyễn', N'Trần Công', N'Toản', '1999-02-28', N'Nam'),
('0892172333', N'Đoàn', N'Trần Thanh', N'Thanh', '2009-12-01', N'Nữ'),
('0888998903', N'Nguyễn', N'Huỳnh Quốc', N'Bảo', '2004-12-17', N'Nam'),
('0972377456', N'Nguyễn', N'Cát', N'Tường', '2005-11-02', N'Nữ')

INSERT dbo.THE_TV (MaThe, SoDiem, MaKH)
VALUES
('MB-0001', '320', '0837123647'),
('MB-0002', '550', '0973034785'),
('MB-0003', '660', '0917654721'),
('MB-0004', '130', '0913133277'),
('MB-0005', '0', '0892172333'),
('MB-0006', '440', '0888998903'),
('MB-0007', '230', '0972377456')