USE Proj_DBMS_BookStore
GO
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
SELECT tenTG , COUNT (MaSach)
FROM dbo.VIEW_SACH
GROUP BY (tenTG)
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
