-- Lấy danh sách đơn hàng của khách hàng có tên "Nguyễn Văn A"
SELECT * 
FROM DonHang 
WHERE MaKH = (SELECT MaKH FROM KhachHang WHERE HoTen = N'Nguyễn Văn A');
-- Lấy danh sách sách có giá bán lớn hơn giá trung bình
SELECT * 
FROM Sach 
WHERE GiaBan > (SELECT AVG(GiaBan) FROM Sach);



