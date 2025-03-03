-- Cập nhật thông tin khách hàng
UPDATE KhachHang 
SET Email = 'newemail@example.com', 
    DienThoai = '0987123456' 
WHERE MaKH = 7;

-- Cập nhật trạng thái và ngày giao hàng của đơn hàng có MaDonHang = 15
UPDATE DonHang 
SET DaThanhToan = 1, 
    NgayGiao = '2025-03-25' 
WHERE MaDonHang = 15;

-- Tăng giá sách thuộc chủ đề MaChuDe = 2 lên 10%
UPDATE Sach 
SET GiaBan = GiaBan * 1.1 
WHERE MaChuDe = 2;
