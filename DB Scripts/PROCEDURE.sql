USE Proj_DBMS_BookStore
GO
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

