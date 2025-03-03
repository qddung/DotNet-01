USE db_QLBanSach;
GO

-- Thêm 10 khách hàng
INSERT INTO KhachHang (TaiKhoan, MatKhau, Email, DiaChi, DienThoai, GioiTinh, NgaySinh, HoTen)
VALUES 
('user1', 'password1', 'user1@example.com', 'Hà Nội', '0123456789', 0, '1995-06-15', N'Nguyễn Văn A'),
('user2', 'password2', 'user2@example.com', 'TP. Hồ Chí Minh', '0987654321', 1, '1998-03-20', N'Trần Thị B'),
('user3', 'password3', 'user3@example.com', 'Đà Nẵng', '0345678901', 0, '1993-09-10', N'Lê Minh C'),
('user4', 'password4', 'user4@example.com', 'Cần Thơ', '0456789012', 1, '2000-01-25', N'Hoàng Thị D'),
('user5', 'password5', 'user5@example.com', 'Hải Phòng', '0567890123', 2, '1997-07-30', N'Phạm Văn E'),
('user6', 'password6', 'user6@example.com', 'Quảng Ninh', '0678901234', 1, '1996-05-05', N'Bùi Thị F'),
('user7', 'password7', 'user7@example.com', 'Huế', '0789012345', 0, '1994-02-14', N'Đặng Minh G'),
('user8', 'password8', 'user8@example.com', 'Nha Trang', '0890123456', 1, '1999-12-31', N'Nguyễn Thị H'),
('user9', 'password9', 'user9@example.com', 'Đà Lạt', '0901234567', 0, '1992-08-20', N'Võ Văn I'),
('user10', 'password10', 'user10@example.com', 'Vũng Tàu', '0912345678', 1, '1991-11-11', N'Ngô Thị J');

-- Thêm 10 chủ đề sách
INSERT INTO ChuDe (TenChuDe)
VALUES 
(N'Khoa học'), (N'Văn học'), (N'Tin học'), (N'Lịch sử'), (N'Kinh tế'),
(N'Y học'), (N'Nghệ thuật'), (N'Chính trị'), (N'Tâm lý học'), (N'Tôn giáo');

-- Thêm 10 nhà xuất bản
INSERT INTO NhaXuatBan (TenNSB, DiaChi, DienThoai)
VALUES 
(N'NXB Kim Đồng', N'Hà Nội', '0123456789'),
(N'NXB Trẻ', N'TP. Hồ Chí Minh', '0987654321'),
(N'NXB Giáo Dục', N'Đà Nẵng', '0345678901'),
(N'NXB Văn Học', N'Cần Thơ', '0456789012'),
(N'NXB Khoa Học', N'Hải Phòng', '0567890123'),
(N'NXB Lao Động', N'Quảng Ninh', '0678901234'),
(N'NXB Nghệ Thuật', N'Huế', '0789012345'),
(N'NXB Chính Trị', N'Nha Trang', '0890123456'),
(N'NXB Y Học', N'Đà Lạt', '0901234567'),
(N'NXB Tâm Lý', N'Vũng Tàu', '0912345678');

-- Thêm 10 tác giả
INSERT INTO TacGia (TenTacGia, DienThoai, TieuSu, DiaChi)
VALUES 
(N'Paulo Coelho', '0123456788', N'Nhà văn người Brazil', N'Brazil'),
(N'Bjarne Stroustrup', '0123456799', N'Cha đẻ của ngôn ngữ C++', N'Đan Mạch'),
(N'George Orwell', '0345678910', N'Tác giả của 1984', N'Anh Quốc'),
(N'J.K. Rowling', '0456789021', N'Tác giả của Harry Potter', N'Anh Quốc'),
(N'Haruki Murakami', '0567890132', N'Tác giả nổi tiếng Nhật Bản', N'Nhật Bản'),
(N'Nguyễn Nhật Ánh', '0678901243', N'Tác giả sách thiếu nhi nổi tiếng', N'Việt Nam'),
(N'Nguyễn Du', '0789012354', N'Tác giả Truyện Kiều', N'Việt Nam'),
(N'Dale Carnegie', '0890123465', N'Tác giả Đắc Nhân Tâm', N'Mỹ'),
(N'Adam Smith', '0901234576', N'Tác giả Của Cải Của Các Quốc Gia', N'Anh Quốc'),
(N'Carl Jung', '0912345687', N'Tâm lý học phân tích', N'Thụy Sĩ');

-- Thêm 10 sách
INSERT INTO Sach (TenSach, MoTa, GiaBan, AnhBia, NgayCapNhat, SoLuongTon, MaChuDe, MaNSX)
VALUES 
(N'Lập trình C++', N'Sách hướng dẫn lập trình C++', 150000, 'cplus.jpg', '2025-01-20', 50, 3, 1),
(N'Nhà giả kim', N'Tiểu thuyết của Paulo Coelho', 100000, 'nhagiakim.jpg', '2025-02-10', 30, 2, 2),
(N'1984', N'Tiểu thuyết viễn tưởng của George Orwell', 120000, '1984.jpg', '2025-03-01', 40, 2, 3),
(N'Harry Potter', N'Tiểu thuyết giả tưởng của J.K. Rowling', 200000, 'harry.jpg', '2025-04-15', 60, 2, 4),
(N'Rừng Na Uy', N'Tiểu thuyết tình cảm của Haruki Murakami', 180000, 'rungnauy.jpg', '2025-05-10', 25, 2, 5),
(N'Tôi thấy hoa vàng trên cỏ xanh', N'Tác phẩm nổi tiếng của Nguyễn Nhật Ánh', 90000, 'hoavang.jpg', '2025-06-20', 35, 2, 6),
(N'Truyện Kiều', N'Tác phẩm nổi tiếng của Nguyễn Du', 110000, 'truyen_kieu.jpg', '2025-07-10', 20, 2, 7),
(N'Đắc Nhân Tâm', N'Sách kỹ năng sống của Dale Carnegie', 95000, 'dacnhantam.jpg', '2025-08-15', 45, 9, 8),
(N'Wealth of Nations', N'Sách kinh tế học của Adam Smith', 220000, 'wealth.jpg', '2025-09-05', 15, 5, 9),
(N'Psychology and Alchemy', N'Sách tâm lý học của Carl Jung', 175000, 'psychology.jpg', '2025-10-25', 10, 10, 10);

-- Thêm 10 đơn hàng
INSERT INTO DonHang (MaKH, NgayGiao, NgayDat, DaThanhToan, TinhTrangGH)
VALUES 
(1, '2025-03-10', '2025-03-01', 1, N'Đã giao'),
(2, '2025-03-15', '2025-03-05', 0, N'Chưa giao'),
(3, '2025-03-12', '2025-03-02', 1, N'Đã giao'),
(4, NULL, '2025-03-06', 0, N'Đang xử lý'),
(5, '2025-03-20', '2025-03-10', 1, N'Đã giao');

-- Thêm dữ liệu vào bảng Gom
INSERT INTO Gom (MaDonHang, MaSach, SoLuong, DonGia)
VALUES 
(1, 1, 2, 150000),
(2, 2, 1, 100000),
(3, 3, 3, 120000),
(4, 4, 1, 200000),
(5, 5, 2, 180000);
