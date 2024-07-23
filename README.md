**Đặc tả đề tài**
(English below)
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

**Topic Specification**

A bookstore manages multiple employees. Each employee has information: Employee ID, Full Name, Salary; and is provided with an account to log into the system. Employees can enter goods, sell goods, and create membership cards for customers.

Employee login information includes: Username, Password. This information is dependent on the Employee entity.

Goods have attributes: Goods ID, Price; and are divided into two categories: Books and Stationery.

Book attributes, in addition to the inherited attributes from Goods, include: Title, Author, Publisher, Genre.

Stationery attributes, in addition to the inherited attributes from Goods, include: Item Name.

A book can belong to many genres, and a genre can include many books. Genre attributes include Genre ID and Genre Name.

Author has Author ID and Author Name.

Publisher has the following information: Publisher ID, Publisher Name, Address, Contact Information. Each publisher can publish many books, but each book is only published by one publisher.

Customer information includes: Customer ID (using phone number), Full Name, Date of Birth, Membership Card Type.

Membership Card Type includes Card ID, Points Accumulated, Membership Level Name. Membership Level Name can be None, Bronze, Silver, Gold.

Employees can create membership cards for customers. The card creation date and the Employee ID who created the card will be recorded.

When an Employee sells goods to a Customer, an Invoice is needed. Invoice attributes include: Invoice ID, Invoice Creation Date (purchase date), Promotion.

Employees can enter goods. When entering goods, a receipt is needed which includes: Receipt ID, Entry Time, and Employee ID who entered the goods.

**Conceptual Database Design:**

From the problem specification, we obtain the entity-relationship diagram (ERD):

![](https://i.imgur.com/vBis5QH.png)

**Logical Database Design:**

From the entity-relationship diagram (ERD), we get the relational schemas:

1. PUBLISHER (PublisherID, PublisherName, Address, Phone)
2. GOODS (GoodsID, Price, Quantity)
3. STATIONERY (GoodsID, ItemName)
4. BOOK (GoodsID, Title, PublisherID, YearPublished)
5. AUTHOR (AuthorID, AuthorName)
6. BOOK_AUTHOR (BookID, AuthorID)
7. GENRE (GenreID, GenreName)
8. BOOK_GENRE (BookID, GenreID)
9. CUSTOMER (CustomerID, LastName, MiddleName, FirstName, DateOfBirth, Gender)
10. MEMBERSHIP_CARD (CardID, Points, MembershipLevel, CustomerID)
11. EMPLOYEE (EmployeeID, IDNumber, LastName, MiddleName, FirstName, Gender, Salary, Username, Password)
12. LOGIN_HISTORY (EmployeeID, LoginTime)
13. CREATE_CARD (EmployeeID, CardID, CustomerID, CreationDate)
14. ENTRY_RECEIPT (ReceiptID, EntryTime)
15. ENTER_GOODS (ReceiptID, EmployeeID, GoodsID, Quantity, EmployeeID)
16. SALE_INVOICE (InvoiceID, SaleTime, Promotion)
17. SELL_GOODS (InvoiceID, EmployeeID, CustomerID, GoodsID, Quantity)

**Required Constraints:**

| **No.** | **RELATIONSHIP** | **CONSTRAINTS** |
| --- | --- | --- |
| 1   | PUBLISHER | Primary key constraint on PublisherID |
| 2   | GOODS | Primary key constraint on GoodsID<br><br>Domain constraint on Quantity must be greater than 0.<br><br>Quantity value constraint, increase when goods are entered, decrease when goods are sold. |
| 3   | STATIONERY | Primary key constraint on GoodsID<br>Foreign key constraint on GoodsID references **GOODS** |
| 4   | BOOK | Primary key constraint on GoodsID<br>Foreign key constraint on PublisherID references PUBLISHER<br>Foreign key constraint on GoodsID references **GOODS** |
| 5   | AUTHOR | Primary key constraint on AuthorID |
| 6   | BOOK_AUTHOR | Primary key constraint on (BookID, AuthorID)<br>Foreign key constraint on BookID references **BOOK**<br>Foreign key constraint on AuthorID references **AUTHOR** |
| 7   | GENRE | Primary key constraint on GenreID |
| 8   | BOOK_GENRE | Primary key constraint on (BookID, GenreID)<br>Foreign key constraint on BookID references **BOOK**<br>Foreign key constraint on GenreID references **GENRE** |
| 9   | CUSTOMER | Primary key constraint on CustomerID |
| 10  | MEMBERSHIP_CARD | Primary key constraint on CardID<br>Foreign key constraint on CustomerID references **CUSTOMER** |
| 11  | EMPLOYEE | Primary key constraint on EmployeeID.<br>Domain constraint on Salary must be greater than 1000.<br>Unique constraint on IDNumber. |
| 12  | LOGIN_HISTORY | Primary key constraint on (EmployeeID, LoginTime)<br>Foreign key constraint on EmployeeID references **EMPLOYEE** |
| 13  | CREATE_CARD | Primary key constraint on (EmployeeID, CardID)<br>Unique constraint on CardID and CustomerID<br>Foreign key constraint on EmployeeID references **EMPLOYEE**<br>Foreign key constraint on CardID references **MEMBERSHIP_CARD**<br>Foreign key constraint on CustomerID references **CUSTOMER** |
| 14  | ENTRY_RECEIPT | Primary key constraint on ReceiptID<br>Foreign key constraint on EmployeeID references **EMPLOYEE** |
| 15  | ENTER_GOODS | Primary key constraint on (ReceiptID, EmployeeID, GoodsID)<br>Foreign key constraint on ReceiptID references **ENTRY_RECEIPT**<br>Foreign key constraint on EmployeeID references **EMPLOYEE**<br>Foreign key constraint on GoodsID references **GOODS** |
| 16  | SALE_INVOICE | Primary key constraint on InvoiceID |
| 17  | SELL_GOODS | Primary key constraint on (InvoiceID, EmployeeID, CustomerID, GoodsID)<br>Foreign key constraint on InvoiceID references **SALE_INVOICE**<br>Foreign key constraint on EmployeeID references **EMPLOYEE**<br>Foreign key constraint on CustomerID references **CUSTOMER**<br>Foreign key constraint on GoodsID references **GOODS** |

**![](https://i.imgur.com/jeZhEwK.png)**
