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
