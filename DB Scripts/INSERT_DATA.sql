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
('TL-079', N'Bút bi Thiên Long TL-079'), -- Bút bi thiên long 
('TL-089', N'Bút bi Thiên Long TL-089'),
('TL-090', N'Bút bi Thiên Long TL-090'),
('TL-093', N'Bút bi Thiên Long TL-093'),
('TL-095', N'Bút bi Thiên Long TL-095'),
('TL-097', N'Bút bi Thiên Long TL-097'),
('TL-008', N'Bút bi Thiên Long TL-008'),
('SR-002', N'Thước kẻ Thiên Long nhựa cứng 15cm'), -- Thước kẻ
('SR-003', N'Thước kẻ Thiên Long nhựa cứng 20cm'),
('SR-024', N'Thước kẻ Thiên Long nhựa dẻo 20cm'),
('SR-026', N'Thước kẻ Thiên Long nhựa cứng 50cm'),
('SR-031', N'Thước kẻ Thiên Long nhựa cứng 30cm'),
('GP-027', N'Bút chì gỗ 2B lục giác'), -- Bút chì gỗ 2B
('GP-026', N'Bút chì gỗ HB lục giác'), -- HB
('GP-025', N'Bút chì gỗ 6B lục giác'), -- 6B
('GP-024', N'Bút chì gỗ 5B lục giác'), -- 5B
('GP-023', N'Bút chì gỗ 4B lục giác'), -- 4B
('GP-022', N'Bút chì gỗ 3B lục giác'), -- 3B
('GP-020', N'Bút chì gỗ 2B lục giác'), -- 2B
('GP-018', N'Bút chì gỗ 2B tam giác'), -- 2B
('GP-016', N'Bút chì gỗ HB tam giác'), -- HB
('GP-004', N'Bút chì gỗ HB lục giác'), -- HB
('PC-024', N'Bút chì bấm HB 0.05mm'), -- Bút chì bấm HB
('PC-026', N'Bút chì bấm 2B 0.5mm'), -- Bút chì bấm 2B
('PC-018', N'Bút chì bấm HB 0.07mm'), -- HB
('NB-096', N'Tập học sinh kẻ ngang 200 trang'), -- Tập học sinh
('NB-095', N'Tập học sinh kẻ ngang 98 trang'),
('NB-094', N'Tập học sinh kẻ ô 200 trang'),
('NB-066', N'Tập học sinh kẻ ô 98 trang'),
('NB-061', N'Tập học sinh kẻ ô 98 trang'),
('NB-053', N'Tập học sinh kẻ ô 98 trang'),
('NB-039', N'Tập học sinh kẻ ô 98 trang'),
('E-033', N'Gôm hình Pikachu'), -- Gôm
('E-032', N'Gôm hình gấu Pooh'),
('E-031', N'Gôm hình BlackPink'),
('E-026', N'Gôm hình Pikachu'),
('E-010', N'Gôm hình Bạch Tuyết'),
('E-011', N'Gôm hình Gấu Lotso'),
('E-030', N'Gôm hình Buzz Lightyear'),
('E-028', N'Gôm vệ sinh LifeBouy'),
('E-029', N'Gôm hình Doraemon')
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
('TT', N'Tiểu thuyết'),
('TTr',N'Truyện tranh'),
('KD',N'Kinh doanh'),
('SGK',N'Sách giáo khoa'),
('NN',N'Ngoại ngữ')
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
('NV-001', '045203001353', N'Nguyễn', N'Văn', N'Vũ', N'Nam', 4000000, 1),
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
