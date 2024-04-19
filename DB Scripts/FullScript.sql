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
	TenLot NVARCHAR(10) NULL DEFAULT '',
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
	-- TenBacTV NVARCHAR(10) NOT NULL DEFAULT 'Không có',
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

-- Hàm lấy thông tin hàng hoá dựa vào mã
CREATE FUNCTION FUNC_Get_HangHoa(@MaHang VARCHAR(20))
RETURNS TABLE
AS
	RETURN (SELECT * FROM VIEW_HANG_HOA WHERE MaHang = @MaHang)
GO

-- Hàm lấy tên của bậc dựa vào số điểm nhập vào
CREATE FUNCTION FUNC_Get_TenBac(@SoDiem INT)
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @TenBac NVARCHAR(10)
	SET @TenBac = 
		CASE 
			WHEN @SoDiem = 0 THEN N'Bạc'
			WHEN @SoDiem > 0 AND @SoDiem < 200 THEN N'Đồng'
			WHEN @SoDiem >= 200 AND @SoDiem < 400 THEN N'Bạc'
			WHEN @SoDiem >= 400 AND @SoDiem < 600 THEN N'Vàng'
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






