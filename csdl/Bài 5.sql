--Đếm số lượng đơn hàng của từng khách hàng

SELECT MaKH, COUNT(*) AS SoLuongDonHang
FROM DonHang
GROUP BY MaKH;


--Tổng tiền từng đơn hàng

SELECT MaDonHang, SUM(SoLuong * DonGia) AS TongTien
FROM ChiTietDonHang
GROUP BY MaDonHang;
