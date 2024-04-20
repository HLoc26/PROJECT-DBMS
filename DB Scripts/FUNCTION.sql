USE Proj_DBMS_BookStore
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
--Hàm lấy sách rồi cho ra bảng kq
CREATE PROCEDURE SearchSACHByMaHang
    @MaHang VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT s.MaSach, s.TieuDe, hh.DonGia, hh.SoLuong, tg.TenTG, tl.TenLoai, nxb.TenNXB
    FROM dbo.SACH s
    JOIN dbo.HANG_HOA hh ON s.MaSach = hh.MaHang
    JOIN dbo.NXB nxb ON nxb.MaNXB = s.MaNXB
    JOIN dbo.TAC_GIA_SACH tg_s ON tg_s.MaSach = s.MaSach
    JOIN dbo.TAC_GIA tg ON tg.MaTG = tg_s.MaTG
    JOIN dbo.THE_LOAI_SACH tl_s ON tl_s.MaSach = s.MaSach 
    JOIN dbo.THE_LOAI tl ON tl.MaLoai = tl_s.MaLoai
    WHERE s.MaSach = @MaHang;
END;
