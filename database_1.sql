﻿CREATE DATABASE QL_BANTRASUA
GO

-- Tạo bảng TaiKhoan
CREATE TABLE TaiKhoan (
    MaTK NVARCHAR(10) PRIMARY KEY,  -- Mã tài khoản (khóa chính)
    TenDangNhap NVARCHAR(50) NOT NULL, -- Tên đăng nhập (khóa chính)
    MatKhau NVARCHAR(255) NOT NULL,       -- Mật khẩu (nên hash trước khi lưu)
    Quyen NVARCHAR(20) CHECK (Quyen IN ('Admin', 'User')) -- Quyền truy cập
);
GO

-- Tạo bảng KhachHang
CREATE TABLE KhachHang (
    MaTK NVARCHAR(10) NULL,
    MaKH NVARCHAR(10) PRIMARY KEY,   -- Mã khách hàng (khóa chính)
    TenKH NVARCHAR(100) NOT NULL,    -- Tên khách hàng
    SDT NVARCHAR(15) NOT NULL,       -- Số điện thoại
    DiemTichLuy INT DEFAULT 0 CHECK(DiemTichLuy >= 0)   -- Điểm tích lũy

);
GO

-- Tạo bảng SanPham
CREATE TABLE SanPham (
    MaSP NVARCHAR(10) PRIMARY KEY,   -- Mã sản phẩm (khóa chính)
    TenSP NVARCHAR(200) NOT NULL,    -- Tên sản phẩm
    Gia MONEY NOT NULL,              -- Giá sản phẩm
    LoaiSP NVARCHAR(50),             -- Loại sản phẩm
    TrangThai NVARCHAR(20) CHECK (TrangThai IN (N'Còn hàng', N'Hết hàng')), -- Trạng thái
    HinhAnh NVARCHAR(255) NULL       -- Link hình ảnh sản phẩm
);
GO

-- Tạo bảng DonHang
CREATE TABLE DonHang (
    MaDH NVARCHAR(10) PRIMARY KEY,   -- Mã đơn hàng (khóa chính)
    MaKH NVARCHAR(10) NULL,      -- Mã khách hàng (khóa ngoại)
    NgayDat SMALLDATETIME NOT NULL,           -- Ngày đặt hàng
    TongTien MONEY DEFAULT 0 NOT NULL,        -- Tổng tiền đơn hàng
    TrangThai NVARCHAR(20) CHECK (TrangThai IN (N'Chờ xác nhận', N'Đang giao', N'Hoàn thành', N'Đã hủy')), -- Trạng thái đơn hàng
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH) ON DELETE CASCADE, -- Ràng buộc khóa ngoại
	GhiChu NVARCHAR(300) NULL
);
GO


-- Tạo bảng ChiTietDonHang
CREATE TABLE ChiTietDonHang (
    MaDH NVARCHAR(10),   -- Mã đơn hàng (khóa ngoại)
    MaSP NVARCHAR(10),   -- Mã sản phẩm (khóa ngoại)
    SoLuong INT CHECK (SoLuong > 0) DEFAULT 1, -- Số lượng sản phẩm
    GiaBan MONEY, 
	Size CHAR(1) CHECK (Size IN ('S', 'M', 'L')),
	ThanhTien MONEY DEFAULT 0 NOT NULL,
    PRIMARY KEY (MaDH, MaSP),  -- Khóa chính (kết hợp 2 trường)
    FOREIGN KEY (MaDH) REFERENCES DonHang(MaDH) ON DELETE CASCADE,
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP) ON DELETE CASCADE
);
GO


-- Ràng buộc
ALTER TABLE KhachHang ADD CONSTRAINT FK_KhachHang_TaiKHoan FOREIGN KEY (MaTK) REFERENCES TaiKhoan(MaTK);
GO

ALTER TABLE DonHang ADD CONSTRAINT CK_DH_TongTien CHECK (TongTien >= 0)
GO

ALTER TABLE DonHang
ADD CONSTRAINT DF_NgayDat DEFAULT GETDATE() FOR NgayDat; -- Ngày đặt hàng mặc định là ngày giờ lúcđặt hàng
GO

ALTER TABLE ChiTietDonHang ADD CONSTRAINT CK_CTDH_ThanhTien CHECK(ThanhTien >=0);
GO
-- Trigger giá bán trong bảng ChitietDonHang bằng giá trong SanPham
CREATE TRIGGER trg_GiaBan ON ChiTietDonHang
AFTER INSERT, UPDATE
AS
BEGIN
UPDATE ChiTietDonHang
SET GiaBan = SP.Gia
FROM ChiTietDonHang CTDH
JOIN INSERTED I ON CTDH.MaDH = I.MaDH AND CTDH.MaSP=I.MaSP
JOIN SANPHAM SP ON SP.MaSP=I.MaSP
END
GO

--Trigger kiểm tra sản phẩm còn hàng không trước khi thêm vào đơn hàng
CREATE TRIGGER trg_KiemTraConHang ON ChiTietDonHang
FOR INSERT, UPDATE 
AS
BEGIN
IF EXISTS (
SELECT 1 
FROM INSERTED I INNER JOIN SanPham SP ON I.MaSP=SP.MaSP
WHERE SP.TrangThai = N'Hết hàng'
)
BEGIN
RAISERROR (N'Sản phẩm đã hết hàng', 16, 1);
ROLLBACK TRANSACTION;
END
END
GO

-- Trigger tự động tính tổng tiền đơn hàng theo ThanhTien
CREATE TRIGGER trg_CapNhatTongTien
ON ChiTietDonHang
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra nếu trigger bị gọi lặp quá mức
    IF TRIGGER_NESTLEVEL() > 1
        RETURN;

    -- Cập nhật tổng tiền đơn hàng dựa trên tổng ThanhTien của các sản phẩm
    UPDATE DonHang
    SET TongTien = COALESCE((
        SELECT SUM(CT.ThanhTien)
        FROM ChiTietDonHang CT
        WHERE CT.MaDH = DonHang.MaDH
    ), 0)
    WHERE MaDH IN (
        SELECT DISTINCT MaDH FROM INSERTED
        UNION
        SELECT DISTINCT MaDH FROM DELETED
    );
END;
GO

-- Trigger tự động tính thành  tiền sản phẩm theo size S(Giá bán), M(Giá bán x 1.2), L(Giá bán x 1,4)
CREATE TRIGGER trg_CapNhatThanhTien
ON ChiTietDonHang
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Ngăn chặn vòng lặp vô hạn
    IF TRIGGER_NESTLEVEL() > 1
        RETURN;

    -- Cập nhật ThanhTien dựa trên số lượng, giá bán và size
    UPDATE CTDH
    SET ThanhTien = CTDH.SoLuong * SP.Gia * 
        CASE 
            WHEN CTDH.Size = 'S' THEN 1.0
            WHEN CTDH.Size = 'M' THEN 1.2
            WHEN CTDH.Size = 'L' THEN 1.4
            ELSE 1.0
        END
    FROM ChiTietDonHang CTDH
    JOIN SanPham SP ON CTDH.MaSP = SP.MaSP
    WHERE EXISTS (
        SELECT 1 FROM INSERTED I WHERE I.MaDH = CTDH.MaDH AND I.MaSP = CTDH.MaSP
    );
END;
GO


-- Trigger cộng điểm tích lũy cho khách mỗi khi mua hàng 
CREATE TRIGGER trg_diemtichluy ON DonHang
AFTER INSERT, UPDATE
AS
BEGIN
UPDATE KhachHang
SET DiemTichLuy = DiemTichLuy + (
SELECT COUNT(*)
FROM INSERTED I
WHERE I.MaKH = KhachHang.MaKH AND I.TrangThai = N'Hoàn Thành'
)
WHERE MaKH IN (
SELECT MaKH FROM INSERTED WHERE TrangThai = N'hoàn thành' AND MaKH IS NOT NULL )
END
GO



-- Dữ liệu mẫu 
INSERT INTO TaiKhoan (MaTK, TenDangNhap, MatKhau, Quyen) VALUES
('TK001', 'admin01', 'hashed_password_1', 'Admin'),
('TK002', 'user01', 'hashed_password_2', 'User'),
('TK003', 'user02', 'hashed_password_3', 'User');

INSERT INTO KhachHang (MaKH, TenKH, SDT, DiemTichLuy, MaTK) VALUES
('KH001', N'Nguyễn Văn A', '0987654321', 100, 'TK002'),
('KH002', N'Trần Thị B', '0912345678', 50, 'TK003'),
('KH003', N'Lê Văn C', '0933445566', 200, 'TK001');

INSERT INTO SanPham (MaSP, TenSP, Gia, LoaiSP, TrangThai, HinhAnh) VALUES
('SP001', N'Cà phê đen', 10000, N'Cà Phê', N'Còn hàng', ''),
('SP002', N'Cà phê sữa', 12000, N'Cà Phê', N'Còn hàng', ''),
('SP003', N'Bạc xỉu', 15000, N'Cà Phê', N'Còn hàng', ''),
('SP004', N'Cam vắt', 10000, N'Nước ép', N'Còn hàng', ''),
('SP005', N'Cà rốt ép', 10000, N'Nước ép', N'Còn hàng', ''),
('SP006', N'Thơm ép', 10000, N'Nước ép', N'Còn hàng', ''),
('SP007', N'Trà sữa truyền thống', 12000, N'Trà sữa', N'Còn hàng', ''),
('SP008', N'Trà sữa khoai môn', 25000, N'Trà sữa', N'Còn hàng', ''),
('SP009', N'Matcha Latte', 30000, N'Thức uống khác', N'Còn hàng', ''),
('SP010', N'Kem tươi', 5000, N'Thức uống khác', N'Còn hàng', ''),
('SP012', N'Sinh tố bơ', 15000, N'Sinh tố', N'Còn hàng', ''),
('SP013', N'Sinh tố chuối', 12000, N'Sinh tố', N'Còn hàng', ''),
('SP014', N'Sinh tố xoài', 10000, N'Sinh tố', N'Còn hàng', ''),
('SP015', N'Trà sữa gạo rang', 10000, N'Trà sữa', N'Hết hàng', ''),
('SP016', N'Sữa chua đá', 10000, N'Sữa chua', N'Còn hàng', ''),
('SP017', N'Sữa chua việt quốc', 10000, N'Sữa chua', N'Còn hàng', ''),
('SP018', N'Sữa chua dâu', 10000, N'Sữa chua', N'Còn hàng', ''),
('SP019', N'Sữa tươi trân châu đường đen', 10000, N'Thức uống khác', N'Còn hàng', ''),
('SP020', N'Bánh táo', 10000, N'Bánh ngọt', N'Còn hàng', ''),
('SP021', N'Tiramisu', 10000, N'Bánh ngọt', N'Hết hàng', ''),
('SP022', N'Bánh kếp', 10000, N'Bánh ngọt', N'Còn hàng', ''),
('SP023', N'Phô mai chanh dây', 10000, N'Bánh ngọt', N'Còn hàng', '');

INSERT INTO DonHang (MaDH, MaKH, TrangThai, GhiChu) VALUES
('DH00000001', 'KH001', N'Chờ xác nhận', N'Khách yêu cầu ít đường'),
('DH00000002', 'KH002', N'Chờ xác nhận', NULL),
('DH00000003', 'KH003', N'Chờ xác nhận', N'Giao hàng trước 18h');


INSERT INTO ChiTietDonHang (MaDH, MaSP, SoLuong, Size) VALUES
('DH00000001', 'SP001', 2, 'M'), -- Cà phê đen, Size M (giá x1.25)
('DH00000001', 'SP007', 1, 'L'), -- Trà sữa truyền thống, Size L (giá x1.5)
('DH00000002', 'SP003', 3, 'S'), -- Bạc xỉu, Size S (giữ nguyên giá)
('DH00000002', 'SP008', 1, 'M'), -- Trà sữa khoai môn, Size M (giá x1.25)
('DH00000003', 'SP010', 2, 'L'); -- Kem tươi, Size L (giá x1.5)

select * from DonHang
delete from ChiTietDonHang
select * from ChiTietDonHang
select * from KhachHang
select * from SanPham
