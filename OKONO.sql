Create database Okono;

CREATE TABLE ChucVu
(
	MaChucVu varchar (30) NOT NULL PRIMARY KEY,
	TenChucVu nvarchar (50) NOT NULL,
);

CREATE TABLE CaLamViec
(
	MaCaLamViec varchar (30) NOT NULL PRIMARY KEY,
	TenCaLamViec nvarchar (20) NOT NULL,
	ThoiGianBatDau varchar (20) not null,
	ThoiGianKetThuc varchar (20) not null
);

CREATE TABLE CoSo
(
	MaCoSo varchar (30) NOT NULL PRIMARY KEY,
	TenCoSo nvarchar (50) NOT NULL,
	DiaChi nvarchar (100),
	SoDienThoai varchar (10)
);


CREATE TABLE NhanVien
(
	MaNhanVien varchar (30) NOT NULL PRIMARY KEY,
	MaChucVu varchar (30) NOT NULL,
	MaCoSo varchar (30) NOT NULL,
	MaCaLamViec varchar (30) NOT NULL,
	TenTaiKhoan varchar (20) NOT NULL unique,
	MatKhau varchar(20) not null,
	TenNhanVien nvarchar (50) NOT NULL,
	GioiTinh nvarchar (10) CHECK (GioiTinh = N'Nam' OR GioiTinh = N'Nữ'),
	NgaySinh date,
	SoDienThoai varchar (10),
	DiaChi nvarchar (100),
	LuongCoBan float CHECK (LuongCoBan >= 0),
	DaXoa int default 0 check(DaXoa=0 or DaXoa=1),
	CONSTRAINT FK_NV_CV FOREIGN KEY (MaChucVu) REFERENCES ChucVu (MaChucVu),
	CONSTRAINT FK_NV_CLV FOREIGN KEY (MaCaLamViec) REFERENCES CaLamViec (MaCaLamViec),
	CONSTRAINT FK_NV_CN FOREIGN KEY (MaCoSo) REFERENCES CoSo (MaCoSo)
);

CREATE TABLE LoaiSanPham
(
	MaLoaiSanPham varchar (30) NOT NULL PRIMARY KEY,
	TenLoaiSanPham nvarchar (50) NOT NULL
);

CREATE TABLE DonViTinh
(
	MaDonViTinh varchar (30) NOT NULL PRIMARY KEY,
	TenDonViTinh nvarchar (50) NOT NULL
);

CREATE TABLE SanPham
(
	MaSanPham varchar (30) NOT NULL PRIMARY KEY,
	MaLoaiSanPham varchar (30) NOT NULL,
	MaDonViTinh varchar (30) NOT NULL,
	TenSanPham nvarchar (100) NOT NULL,
	SoLuongTon int CHECK (SoLuongTon >= 0) default 0,
	DonGiaBan float CHECK (DonGiaBan >= 0),
	DaXoa int default 0 check(DaXoa=0 or DaXoa=1),
	CONSTRAINT FK_SP_LSP FOREIGN KEY (MaLoaiSanPham) REFERENCES LoaiSanPham (MaLoaiSanPham),
	CONSTRAINT FK_SP_DVT FOREIGN KEY (MaDonViTinh) REFERENCES DonViTinh (MaDonViTinh)
);

CREATE TABLE HoaDonBan
(
	MaHoaDonBan varchar (30) NOT NULL PRIMARY KEY,
	MaNhanVien varchar (30)	NOT NULL,
	NgayBan date,
	GiamGia float CHECK(GiamGia>=0),
	TongTien float,
	CONSTRAINT FK_HDB_NV FOREIGN KEY (MaNhanVien) REFERENCES NhanVien (MaNhanVien)
);

CREATE TABLE ChiTietHDB
(
	MaHoaDonBan varchar (30) NOT NULL,
	MaSanPham varchar (30) NOT NULL,
	SoLuongBan int CHECK (SoLuongBan >= 0),
	CONSTRAINT FK_HDB FOREIGN KEY (MaHoaDonBan) REFERENCES HoaDonBan (MaHoaDonBan),
	CONSTRAINT FK_HDB_SP FOREIGN KEY (MaSanPham) REFERENCES SanPham (MaSanPham)
);


CREATE TABLE PhieuDieuChuyen
(
	MaPhieuDieuChuyen varchar (30) NOT NULL PRIMARY KEY,
	MaNhanVien varchar (30)	NOT NULL,
	MaNhanVienNhap varchar(30), 
	MaCoSo varchar (30) NOT NULL,
	NgayXuat date,
	NgayNhap date,
	CONSTRAINT FK_PDC_NV FOREIGN KEY (MaNhanVien) REFERENCES NhanVien (MaNhanVien),
	CONSTRAINT FK_PDC_CN FOREIGN KEY (MaCoSo) REFERENCES CoSo (MaCoSo),
);

CREATE TABLE ChiTietPDC
(
	MaPhieuDieuChuyen varchar (30) NOT NULL,
	MaSanPham varchar (30) NOT NULL,
	SoLuongDC int CHECK (SoLuongDC >= 0),
	CONSTRAINT FK_PDC FOREIGN KEY (MaPhieuDieuChuyen) REFERENCES PhieuDieuChuyen (MaPhieuDieuChuyen),
	CONSTRAINT FK_PDC_SP FOREIGN KEY (MaSanPham) REFERENCES SanPham (MaSanPham)
);

CREATE TABLE PhieuDatHang
(
	MaPhieuDatHang varchar(30) primary key,
	MaNhanVien varchar(30) NOT NULL,
	NgayDat date NOT NULL,
	GhiChu nvarchar(500)
	CONSTRAINT FK_PDH_NV FOREIGN KEY (MaNhanVien) REFERENCES NhanVien (MaNhanVien),
)

CREATE TABLE ChiTietPDH
(
	MaPhieuDatHang varchar(30) not null,
	MaSanPham varchar (30) NOT NULL,
	SoLuongDat float NOT NULL,
	CONSTRAINT FK_PDH_SP FOREIGN KEY (MaSanPham) REFERENCES SanPham (MaSanPham),
	CONSTRAINT FK_PDH_PDH FOREIGN KEY (MaPhieuDatHang) REFERENCES PhieuDatHang (MaPhieuDatHang)

)

ALTER TABLE PhieuDieuChuyen ADD TrangThai nvarchar (30);

										--Insert Data

INSERT INTO ChucVu
VALUES ('OKONO01_CV01', N'Nhân viên bán hàng');
INSERT INTO ChucVu
VALUES ('OKONO01_CV02', N'Quản lý của hàng');
INSERT INTO ChucVu
VALUES ('SYS_ADMIN', N'Quản trị hệ thống');


INSERT INTO CaLamViec
VALUES ('CLV01', N'Ca sáng', N'06:00', N'12:00');
INSERT INTO CaLamViec
VALUES ('CLV02', N'Ca chiều', N'12:00', N'18:00');
INSERT INTO CaLamViec
VALUES ('CLV03', N'Ca tối', N'18:00', N'24:00');
INSERT INTO CaLamViec
VALUES ('CLV04', N'Ca đêm', N'00:00', N'06:00');
INSERT INTO CaLamViec
VALUES ('CLV05', N'Hành chính', N'08:00', N'17:30');

INSERT INTO CoSo
VALUES ('OKONO_CS01', N'Okono 72 Khương Trung', N'71 Khương Trung - Thanh Xuân - Hà Nội', '0992648293');
INSERT INTO CoSo
VALUES ('OKONO_CS02', N'Okono 87 Hoàng Mai', N'87 Hoàng Mai - Hà Nội', '0992646958');

INSERT INTO NhanVien
VALUES ('OKONO01_NVQL02', 'OKONO01_CV02', 'OKONO_CS01', 'CLV05', 'huyen', 'huyen', N'Nguyễn Thị Huyền', N'Nữ', '2000-06-08', '0395292836', N'Hà Đông - Hà Nội', 5200000,0);
INSERT INTO NhanVien
VALUES ('OKONO01_NVQL01', 'OKONO01_CV02', 'OKONO_CS01', 'CLV01', 'nhuyen8620', 'nhuyen8620', N'Nguyễn Thị Huyền', N'Nữ', '2000-06-08', '0395292836', N'Hà Đông - Hà Nội', 20000,0);
INSERT INTO NhanVien
VALUES ('OKONO1_NVBH01', 'OKONO01_CV01', 'OKONO_CS01', 'CLV04', 'caomai', 'caomai', N'Cao Thị Mai', N'Nữ', '2000-06-08', '0395292836', N'Hà Đông - Hà Nội', 20000,0);


INSERT INTO LoaiSanPham
VALUES ('OKONO_LSP01', N'Bánh kẹo');
INSERT INTO LoaiSanPham
VALUES ('OKONO_LSP02', N'Thực phẩm');
INSERT INTO LoaiSanPham
VALUES ('OKONO_LSP03', N'Đồ uống');

INSERT INTO DonViTinh
VALUES ('OKONO_DVT01', N'Cái');
INSERT INTO DonViTinh
VALUES ('OKONO_DVT02', N'Hộp');
INSERT INTO DonViTinh
VALUES ('OKONO_DVT03', N'Chai');
INSERT INTO DonViTinh
VALUES ('OKONO_DVT04', N'Gói');


INSERT INTO SanPham
VALUES ('OKONO01_SP001', 'OKONO_LSP01', 'OKONO_DVT01', N'Bánh gạo', 30, 14000,0);
INSERT INTO SanPham
VALUES ('OKONO01_SP002', 'OKONO_LSP01', 'OKONO_DVT01', N'Bánh Cosi', 76, 43000,0);

