--UNION – Kết hợp & loại bỏ trùng lặp
SELECT HoTen, DienThoai FROM KhachHang
UNION
SELECT TenNSB, DienThoai FROM NhaXuatBan;
-- UNION ALL - Kết hợp nhưng giữ nguyên trùng lặp
SELECT HoTen, DienThoai FROM KhachHang
UNION ALL
SELECT TenNSB, DienThoai FROM NhaXuatBan;
-- INTERSECT – Lấy phần chung giữa hai tập dữ liệu
SELECT DienThoai FROM KhachHang
INTERSECT
SELECT DienThoai FROM NhaXuatBan;
--EXCEPT – Lấy dữ liệu có trong tập A nhưng không có trong tập B

SELECT DienThoai FROM KhachHang
EXCEPT
SELECT DienThoai FROM NhaXuatBan;
