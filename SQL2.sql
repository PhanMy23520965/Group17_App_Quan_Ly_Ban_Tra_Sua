CREATE TABLE ThanhToan
(
	MaTT NVARCHAR(30) PRIMARY KEY,
	MaDH NVARCHAR(10) NOT NULL,
	PhuongThucTT NVARCHAR(30) CHECK (PhuongThucTT IN (N'Tiền mặt', N'Chuyển khoản',N'Thẻ tín dụng')),
	TrangThaiTT NVARCHAR(30) CHECK (TrangThaiTT IN (N'Chưa thanh toán', N'Đã thanh toán')),
	CONSTRAINT FK_ThanhToan_DonHang FOREIGN KEY (MaDH) REFERENCES DonHang(MaDH) ON DELETE CASCADE
)

CREATE TABLE DanhGia
(
	MaDG NVARCHAR(10) PRIMARY KEY,
	MaKH NVARCHAR(10) NOT NULL,
	MaDH NVARCHAR(10) NOT NULL, 
	NoiDung NVARCHAR(255),
	SaoDG INT CHECK (SaoDG BETWEEN 1 AND 5),
	CONSTRAINT FK_DanhGia_DonHang FOREIGN KEY (MaDH) REFERENCES DonHang(MaDH),
	CONSTRAINT FK_DanhGia_KhachHang FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH) ON DELETE CASCADE,
);

CREATE TABLE Ban (
    MaBan NVARCHAR(10) PRIMARY KEY,
    TenBan NVARCHAR(10) NOT NULL,
    SucChua INT NOT NULL CHECK (SucChua > 0),
    TrangThaiBan NVARCHAR(20) CHECK (TrangThaiBan IN (N'Còn trống', N'Đã được đặt trước', N'Đang được sử dụng'))
);

CREATE TABLE DatBan (
    MaDB NVARCHAR(10) PRIMARY KEY,
    MaKH NVARCHAR(10) NOT NULL, 
    MaBan NVARCHAR(10) NOT NULL, 
    ThoiGianDB SMALLDATETIME  DEFAULT GETDATE(),
    TrangThaiDB NVARCHAR(20) CHECK (TrangThaiDB IN (N'Đang chờ xác nhận', N'Đã xác nhận', N'Đã hủy')),
	SoNguoi INT NOT NULL CHECK (SoNguoi > 0),
	CONSTRAINT FK_DatBan_KhachHang FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH) ON DELETE CASCADE,
    CONSTRAINT FK_DatBan_Ban FOREIGN KEY (MaBan) REFERENCES BAN(MaBan) ON DELETE CASCADE
);


INSERT INTO Ban (MaBan, TenBan, SucChua, TrangThaiBan) VALUES
('B001', N'Bàn 1', 4, N'Còn trống'),
('B002', N'Bàn 2', 6, N'Còn trống'),
('B003', N'Bàn 3', 2, N'Còn trống'),
('B004', N'Bàn 4', 8, N'Còn trống'),
('B005', N'Bàn 5', 4, N'Còn trống'),
('B006', N'Bàn 6', 10, N'Còn trống'),
('B007', N'Bàn 7', 3, N'Còn trống'),
('B008', N'Bàn 8', 5, N'Còn trống'),
('B009', N'Bàn 9', 6, N'Còn trống'),
('B010', N'Bàn 10', 4, N'Còn trống');