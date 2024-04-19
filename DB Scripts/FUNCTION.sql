﻿USE Proj_DBMS_BookStore
GO
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