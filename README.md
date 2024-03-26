**Đặc tả đề tài**

Một cửa hàng sách quản lý nhiều nhân viên. Mỗi nhân viên gồm các thông tin: Mã nhân viên, Họ và tên, Lương; và được cấp một tài khoản để đăng nhập hệ thống. Nhân viên có thể nhập hàng hoá, bán hàng hoá, và tạo thẻ thành viên cho khách hàng.

Thông tin đăng nhập của nhân viên gồm: Tài khoản đăng nhập, mật khẩu. Thông tin này phụ thuộc vào thực thể Nhân viên.

Hàng hoá gồm các thuộc tính: Mã hàng hoá, Đơn giá; và được chia thành hai loại: Sách và Văn phòng phẩm.

Các thuộc tính của Sách ngoài các thuộc tính kế thừa từ Hàng hoá gồm: Tiêu đề, Tác giả, Nhà xuất bản, Thể loại.

Các thuộc tính của Văn phòng phẩm ngoài các thuộc tính kế thừa từ Hàng hoá gồm: Tên vật phẩm.

Một quyển sách có thể thuộc nhiều thể loại, và một thể loại bao gồm nhiều quyển sách. Các thuộc tính của thể loại sách gồm Mã thể loại và Tên thể loại.

Tác giả có Mã tác giả và Tên tác giả.

Nhà xuất bản có các thông tin: Mã nhà xuất bản, Tên nhà xuất bản, Địa chỉ, Thông tin liên lạc. Mỗi nhà xuất bản có thể xuất bản nhiều quyển sách, nhưng mỗi quyển sách chỉ được xuất bản bởi một nhà xuất bản.

Khách hàng gồm các thông tin: Mã khách hàng (dùng số điện thoại), Họ và tên, Ngày sinh, Loại thẻ thành viên.

Loại thẻ thành viên gồm Mã thẻ, Số điểm tích được, Tên bậc thành viên. Tên bậc thành viên có thể là Không có, Đồng, Bạc, Vàng.

Nhân viên có thể tạo thẻ thành viên cho khách hàng. Ngày tạo thẻ và Mã nhân viên thực hiện việc tạo thẻ sẽ được lưu lại.

Khi Nhân viên bán hàng hoá cho Khách hàng cần có Hoá đơn. Các thuộc tính của Hoá đơn gồm: Mã hoá đơn, Ngày tạo hoá đơn (ngày mua), khuyến mãi.

Nhân viên có thể nhập hàng. Khi nhập hàng cũng cần có biên nhận gồm: Mã đơn nhập, Thời gian nhập, và Mã nhân viên thực hiện việc nhập hàng.

**Thiết kế cơ sở dữ liệu mức quan niệm:**

Từ đặc tả bài toán, ta có được sơ đồ thực thể kết hợp (ERD):

![](https://i.imgur.com/vBis5QH.png)

**Thiết kế cơ sở dữ liệu mức logic:**

Từ sơ đồ thực thể kết hợp (ERD), ta có các lược đồ quan hệ:

1. NXB(MaNXB, TenNXB, DiaChi, SDT)
2. HANG_HOA(MaHang, DonGia, SoLuong)
3. VAN_PHONG_PHAM(MaHang, TenHang)
4. SACH(MaHang, TieuDe, MaNXB, NamXB)
5. TAC_GIA(MaTG, TenTG)
6. TAC_GIA_SACH(MaSach, MaTG)
7. THE_LOAI(MaLoai, TenLoai)
8. THE_LOAI_SACH(MaSach, MaLoai)
9. KHACH_HANG(MaKH, Ho, TenLot, Ten, NgaySinh, GioiTinh)
10. THE_TV(MaThe, SoDiem, TenBacTV, MaKH)
11. NHAN_VIEN(MaNV, CMND, Ho, TenLot, Ten, GioiTinh, Luong, TenDN, MK)
12. LS_DANG_NHAP(MaNV, ThoiGianDN)
13. TAO_TV(MaNV, MaThe, MaKH, NgayTao)
14. HOA_DON_NHAP(MaDonNhap, ThoiGianNhap)
15. NHAP_HANG(MaDonNhap, MaNV, MaHang, SoLuong, MaNV)
16. HOA_DON_BAN(MaHoaDon, ThoiGianBan, KhuyenMai)
17. BAN_HANG(MaHoaDon, MaNV, MaKH, MaHang, SoLuong)

**Các ràng buộc cần có:**

| **STT** | **QUAN HỆ** | **RÀNG BUỘC** |
| --- | --- | --- |
| 1   | NXB | Ràng buộc khoá chính MaNXB |
| 2   | HANG_HOA | Ràng buộc khoá chính MaHang<br><br>Ràng buộc miền giá trị cột SoLuong phải lớn hơn 0.<br><br>Ràng buộc giá trị của cột SoLuong, khi nhập hàng thì SoLuong tăng lên, khi bán hàng thì SoLuong giảm xuống. |
| 3   | VAN_PHONG_PHAM | Ràng buộc khoá chính MaHang  <br>Ràng buộc khoá ngoại MaHang tham chiếu đến **HANG_HOA** |
| 4   | SACH | Ràng buộc khoá chính MaHang  <br>Ràng buộc khoá ngoại MaNXB tham chiếu đến NXB  <br>Rànng buộc khoá ngoại MaHang tham chiếu đến **HANG_HOA** |
| 5   | TAC_GIA | Ràng buộc khoá chính MaTG |
| 6   | TAC_GIA_SACH | Ràng buộc khoá chính (MaSach, MaTG)  <br>Ràng buộc khoá ngoại MaSach tham chiếu đến **SACH**  <br>Ràng buộc khoá ngoại MaTG tham chiếu đến **TAC_GIA** |
| 7   | THE_LOAI | Ràng buộc khoá chính MaLoai |
| 8   | THE_LOAI_SACH | Ràng buộc khoá chính (MaSach, MaLoai)  <br>Ràng buộc khoá ngoại MaSach tham chiếu đến **SACH**  <br>Ràng buộc khoá ngoại MaLoai tham chiếu đến **THE_LOAI** |
| 9   | KHACH_HANG | Ràng buộc khoá chính MaKH |
| 10  | THE_TV | Ràng buộc khoá chính MaThe  <br>Ràng buộc khoá ngoại MaKH tham chiếu đến **KHACH_HANG** |
| 11  | NHAN_VIEN | Ràng buộc khoá chính MaNV.<br><br>Ràng buộc miền giá trị cột Luong phải lớn hơn 1000.<br><br>Ràng buộc duy nhất cột CMND. |
| 12  | LS_DANG_NHAP | Ràng buộc khoá chính (MaNV, ThoiGianDN)  <br>Ràng buộc khoá ngoại MaNV tham chiếu đến **NHAN_VIEN** |
| 13  | TAO_TV | Ràng buộc khoá chính (MaNV, MaThe)<br><br>Ràng buộc duy nhất cột MaThe và cột MaKH  <br>Ràng buộc khoá ngoại MaNV tham chiếu đến **NHAN_VIEN**<br><br>Ràng buộc khoá ngoại MaThe tham chiếu đến **THE_TV**<br><br>Ràng buộc khoá ngoại MaKH tham chiếu đến **KHACH_HANG** |
| 14  | HOA_DON_NHAP | Ràng buộc khoá chính MaDonNhap  <br>Ràng buộc khoá ngoại MaNV tham chiếu đến **NHAN_VIEN** |
| 15  | NHAP_HANG | Ràng buộc khoá chính (MaDonNhap, MaNV, MaHang)  <br>Ràng buộc khoá ngoại MaDonNhap tham chiếu đến **HOA_DON_NHAP**  <br>Ràng buộc khoá ngoại MaNV tham chiếu đến **NHAN_VIEN**  <br>Ràng buộc khoá ngoại MaHang tham chiếu đến **HANG_HOA** |
| 16  | HOA_DON_BAN | Ràng buộc khoá chính MaHoaDon |
| 17  | BAN_HANG | Ràng buộc khoá chính (MaHoaDon, MaNV, MaKH, MaHang)  <br>Ràng buộc khoá ngoại MaHoaDon tham chiếu đến **HOA_DON_BAN**  <br>Ràng buộc khoá ngoại MaNV tham chiếu đến **NHAN_VIEN**  <br>Ràng buộc khoá ngoại MaKH tham chiếu đến **KHACH_HANG**  <br>Ràng buộc khoá ngoại MaHang tham chiếu đến **HANG_HOA** |

**![](https://i.imgur.com/jeZhEwK.png)**
