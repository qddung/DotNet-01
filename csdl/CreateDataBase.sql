CREATE DATABASE db_QLBanSach;
GO
USE db_QLBanSach;
GO

-- Bảng Khách hàng
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TaiKhoan NVARCHAR(50) UNIQUE NOT NULL,
    MatKhau NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    DiaChi NVARCHAR(255),
    DienThoai NVARCHAR(15),
    GioiTinh TINYINT NOT NULL, -- 0: Nam, 1: Nữ, 2: Khác
    NgaySinh DATE,
    HoTen NVARCHAR(100) NOT NULL
);
GO

-- Bảng Đơn hàng
CREATE TABLE DonHang (
    MaDonHang INT IDENTITY(1,1) PRIMARY KEY,
    MaKH INT,
    NgayGiao DATE,
    NgayDat DATE NOT NULL,
    DaThanhToan BIT DEFAULT 0, -- 0: Chưa thanh toán, 1: Đã thanh toán
    TinhTrangGH NVARCHAR(50),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH) ON DELETE CASCADE
);
GO

-- Bảng Chủ đề
CREATE TABLE ChuDe (
    MaChuDe INT IDENTITY(1,1) PRIMARY KEY,
    TenChuDe NVARCHAR(100) NOT NULL
);
GO

-- Bảng Nhà xuất bản
CREATE TABLE NhaXuatBan (
    MaNSX INT IDENTITY(1,1) PRIMARY KEY,
    TenNSB NVARCHAR(255) NOT NULL,
    DiaChi NVARCHAR(255),
    DienThoai NVARCHAR(15)
);
GO

-- Bảng Sách
CREATE TABLE Sach (
    MaSach INT IDENTITY(1,1) PRIMARY KEY,
    TenSach NVARCHAR(255) NOT NULL,
    MoTa NVARCHAR(MAX),
    GiaBan DECIMAL(10,2) NOT NULL,
    AnhBia NVARCHAR(255),
    NgayCapNhat DATE,
    SoLuongTon INT DEFAULT 0,
    MaChuDe INT,
    MaNSX INT,
    FOREIGN KEY (MaChuDe) REFERENCES ChuDe(MaChuDe) ON DELETE SET NULL,
    FOREIGN KEY (MaNSX) REFERENCES NhaXuatBan(MaNSX) ON DELETE SET NULL
);
GO

-- Bảng Tác giả
CREATE TABLE TacGia (
    MaTacGia INT IDENTITY(1,1) PRIMARY KEY,
    TenTacGia NVARCHAR(100) NOT NULL,
    DienThoai NVARCHAR(15),
    TieuSu NVARCHAR(MAX),
    DiaChi NVARCHAR(255)
);
GO

-- Bảng Gồm (Mối quan hệ giữa Đơn hàng và Sách)
CREATE TABLE Gom (
    MaDonHang INT,
    MaSach INT,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (MaDonHang, MaSach),
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang) ON DELETE CASCADE,
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach) ON DELETE CASCADE
);
GO

-- Bảng Tham gia (Mối quan hệ giữa Sách và Tác giả)
CREATE TABLE ThamGia (
    MaSach INT,
    MaTacGia INT,
    VaiTro NVARCHAR(50),
    ViTri NVARCHAR(50),
    PRIMARY KEY (MaSach, MaTacGia),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach) ON DELETE CASCADE,
    FOREIGN KEY (MaTacGia) REFERENCES TacGia(MaTacGia) ON DELETE CASCADE
);
GO
