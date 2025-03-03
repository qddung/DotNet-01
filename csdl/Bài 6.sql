--INNER JOIN

SELECT DonHang.MaDonHang, DonHang.NgayDat, KhachHang.HoTen, KhachHang.DienThoai
FROM DonHang
INNER JOIN KhachHang ON DonHang.MaKH = KhachHang.MaKH;


--LEFT JOIN
SELECT KhachHang.HoTen, DonHang.MaDonHang, DonHang.NgayDat
FROM KhachHang
LEFT JOIN DonHang ON KhachHang.MaKH = DonHang.MaKH;



--RIGHT JOIN

SELECT DonHang.MaDonHang, DonHang.NgayDat, KhachHang.HoTen
FROM DonHang
RIGHT JOIN KhachHang ON DonHang.MaKH = KhachHang.MaKH;


--FULL JOIN

SELECT KhachHang.HoTen, DonHang.MaDonHang, DonHang.NgayDat
FROM KhachHang
FULL JOIN DonHang ON KhachHang.MaKH = DonHang.MaKH;

