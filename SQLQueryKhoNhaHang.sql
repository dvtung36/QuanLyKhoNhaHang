create database KhoNhaHang
go
use KhoNhaHang
go
create table NhaCungCap
(
	MaNCC int identity(1, 1) primary key,
	TenNCC nvarchar(50),
	DiaChi nvarchar(50),
	SDT nvarchar(12)
)
go



--Nhân viên (Mã nhân viên, Họ tên, Ngày sinh, Địa chỉ, Số điện thoại)
create table NhanVien
(
	MaNV int identity(1, 1) primary key,
	HoTen nvarchar(50),
	NgaySinh date,
	DiaChi nvarchar(50),
	SDT char(12)
)
go

--Nguyên liệu (Mã nguyên liệu, Tên nguyên liệu, Loại tươi/khô, Số lượng, Tên đơn vị)
create table NguyenLieu
(
	MaNL int identity(1, 1) primary key,
	TenNL nvarchar(30),
	LoaiTuoiKho bit, --1: tươi, 0: khô
	GiaTien int,
	SoLuong float default 0, --bình thường khi mới tạo thì số lượng là 0
	TenDonVi nvarchar(30)
)
go

--Phiếu đặt nguyên liệu (Mã phiếu đặt, Ngày lập, Mã nhà cung cấp, Mã nhân viên)
create table PhieuDatNL
(
	MaPDNL int identity(1, 1) primary key,
	NgayLap date default getdate(),
	MaNCC int foreign key references NhaCungCap(MaNCC),
	MaNV int foreign key references NhanVien(MaNV)
)
go

--Chi tiết phiếu đặt (Mã chi tiết, Mã phiếu, Mã nguyên liệu, Số lượng)
create table ChiTietPDNL
(
	MaPDNL int foreign key references PhieuDatNL(MaPDNL),
	MaNL int foreign key references NguyenLieu(MaNL),
	SoLuong float not null,

	primary key(MaPDNL, MaNL)
)
go

--Hóa đơn nhập nguyên liệu (Mã hóa đơn, Ngày lập, Mã phiếu đặt, Ngày lập, Mã nhân viên)
create table HoaDonNhapNL
(
	MaHDN int identity(1, 1) primary key,
	MaPDNL int foreign key references PhieuDatNL(MaPDNL),
	NgayLap date default getdate(),
	MaNV int foreign key references NhanVien(MaNV),
)
go





--Chi tiết hóa đơn nhập (Mã chi tiết, Mã hóa đơn, Mã khối)
create table ChiTietHDN
(
	MaHD int foreign key references HoaDonNhapNL(MaHDN),
	MaNL int foreign key references NguyenLieu(MaNL),
	GiaTien int not null,
	SoLuong float not null,

	primary key(MaHD, MaNL)
)
go

--Phiếu thống kê nguyên liệu (Mã phiếu thống kê, Ngày lập, Mã nhân viên)
create table PhieuThongKe
(
	MaPTK int identity(1, 1) primary key,
	NgayLap date default getdate(),
	MaNV int foreign key references NhanVien(MaNV)
)
go

--Chi tiết phiếu thống kê (Mã chi tiết, Mã phiếu, Mã khối)
create table ChiTietPTK
(
	MaPTK int foreign key references PhieuThongKe(MaPTK),
	MaNL int foreign key references NguyenLieu(MaNL),
	SoLuong float not null,

	primary key (MaPTK, MaNL)
)
go

--Biên bản thanh lý (Mã biên bản, Ngày lập, Mã nhân viên)
create table BienBanThanhLy
(
	MaBB int identity(1, 1) primary key,
	NgayLap date default getdate(),
	MaNV int foreign key references NhanVien(MaNV)
)
go

--Chi tiết biên bản thanh lý (Mã chi tiết, Mã biên bản, Mã khối, Giá trên một đơn vị, Số lượng)
create table ChiTietBBTL
(
	MaBB int foreign key references BienBanThanhLy(MaBB),
	MaNL int foreign key references NguyenLieu(MaNL),
	Gia int not null,
	SoLuong float not null,

	primary key(MaBB, MaNL)
)
go

/* Đàm Viết Tùng ,Nghiệp vụ tạo phiếu thống kê*/

use KhoNhaHang
go

--dữ liệu danh mục
insert into NhaCungCap(TenNCC, DiaChi, SDT) values
	(N'Chợ đầu mối', N'Hà Nội', '123'),
	(N'Siêu thị X.', N'Thăng Long', '456'),
	(N'Siêu thị Y.', N'Đông Đô', '789'),
	(N'Siêu thị Z.', N'Thanh Hóa', '888'),
	(N'Chợ A.', N'Nghệ An', '777')
go

insert into NhanVien(HoTen, NgaySinh, DiaChi, SDT) values
	(N'Nguyễn Văn A', '1/1/1991', N'Hà Nội', '123'), --mm/dd/yyyy
	(N'Ngã Vân Uyên', '2/2/1992', N'Hà Nội', '123'),
	(N'Nga Vân Uyển', '3/3/1993', N'Hà Nội', '123'),
	(N'Nguyễn Văn B', '4/4/1994', N'Hà Nội', '123'),
	(N'Nguyễn Văn D', '2/15/1995', N'Hà Nội', '123')
go

insert into NguyenLieu(TenNL, LoaiTuoiKho, GiaTien, SoLuong, TenDonVi) values
	(N'Thịt bò', 1, 10000, 3.5, 'cân'),
	(N'Thịt lợn', 1, 20000, 4, 'cân'),
	(N'Nước mắm', 0, 30000, 5, 'lít'),
	(N'Bột canh', 0, 15000, 6, 'cân'),
	(N'Mì chính', 1, 20000, 7, 'cân')
go

--tạo 3 phiếu thống kê
insert into PhieuThongKe(MaNV) values
	(1), (2), (3)
go

--với mỗi phiếu thống kê, đặt vào 3 chi tiết tương ứng
insert into ChiTietPTK(MaPTK, MaNL, SoLuong) values
	(1, 1, (select SoLuong from NguyenLieu where NguyenLieu.MaNL = 1)),
	(1, 2, (select SoLuong from NguyenLieu where NguyenLieu.MaNL = 2)),
	(1, 3, (select SoLuong from NguyenLieu where NguyenLieu.MaNL = 3)),

	(2, 2, (select SoLuong from NguyenLieu where NguyenLieu.MaNL = 2)),
	(2, 3, (select SoLuong from NguyenLieu where NguyenLieu.MaNL = 3)),
	(2, 4, (select SoLuong from NguyenLieu where NguyenLieu.MaNL = 4)),

	(3, 3, (select SoLuong from NguyenLieu where NguyenLieu.MaNL = 3)),
	(3, 4, (select SoLuong from NguyenLieu where NguyenLieu.MaNL = 4)),
	(3, 5, (select SoLuong from NguyenLieu where NguyenLieu.MaNL = 5))
go

/* Hà Lâm Giang, Nghiệp vụ nhập nguyên liệu tươi*/

--dữ liệu danh mục

go

INSERT INTO dbo.NhaCungCap
		(TenNCC, DiaChi, SDT)
VALUES	(N'Chợ Đồng Xa', 'Hà Tĩnh', '123'),--mm/dd/yyyy
		(N'Siêu thị A.', 'Hương Khê', '456'),
		(N'Siêu thị B.', 'Nam Định', '789'),
		(N'Siêu thị C.', 'Tiên Lãng', '999'),
		(N'Chợ X.', 'Hà Nội', '777')
GO

insert into NhanVien(HoTen, NgaySinh, DiaChi, SDT) values
	(N'Phan Huy Tiến', '1/1/1991', N'Hà Nội', '123'), --mm/dd/yyyy
	(N'Phan Văn Nhật', '2/2/1992', N'Hà Nội', '123'),
	(N'Đỗ Kim Phương', '3/3/1993', N'Hà Nội', '123'),
	(N'Lê Ngọc Trâm', '4/4/1994', N'Hà Nội', '123'),
	(N'Phạm Văn Thoại', '2/15/1995', N'Hà Nội', '123')
go

insert into NguyenLieu(TenNL, LoaiTuoiKho, GiaTien, TenDonVi) values
	(N'Gan trời', 1, 10000, 'm3'),
	(N'Thịt ngỗng', 1, 20000, 'hộp 10m3'),
	(N'Mỡ muỗi', 1, 30000, 'thùng 1m3'),
	(N'Gan ngỗng', 1, 15000, 'khối 3m3'),
	(N'Cá basa', 1, 20000, '8 lạng')
go

--tạo 3 phiếu đặt nguyên liệu
INSERT INTO dbo.PhieuDatNL
        ( MaNCC, MaNV )
VALUES  ( 1, 3 ),
		( 2, 4 ),
		( 3, 5 )
GO

--với mỗi phiếu đặt có 3 chi tiết tương ứng
--mã nguyên liệu từ 5 đến 10 là nguyên liệu tươi
INSERT INTO dbo.ChiTietPDNL
        ( MaPDNL, MaNL, SoLuong )
VALUES  ( 1, 6, 2 ),
		( 1, 7, 10 ),
		( 1, 8, 4 ),

		( 2, 9, 5 ),
		( 2, 6, 6 ),
		( 2, 7, 6 ),

		( 3, 8, 5 ),
		( 3, 9, 6 ),
		( 3, 10, 6 )
GO





--tạo 3 hóa đơn nhập liệu tương ứng với 3 phiếu đặt
INSERT INTO dbo.HoaDonNhapNL
        ( MaPDNL, MaNV )
VALUES  ( 1, 7 ),
		( 2, 8 ),
		( 3, 9 )
GO

--với mỗi hóa đơn nhập có 3 chi tiết tương ứng
INSERT INTO dbo.ChiTietHDN
        ( MaHD, MaNL, GiaTien, SoLuong )
VALUES  ( 1, 6, 10000, 2 ),
		( 1, 7, 11000, 3 ),
		( 1, 8, 12000, 4 ),

		( 2, 9, 13000, 5 ),
		( 2, 6, 14000, 5 ),
		( 2, 7, 15000, 5 ),

		( 3, 8, 16000, 5 ),
		( 3, 9, 17000, 6 ),
		( 3, 10, 18000, 6 )
GO

--sau khi nhập xong thì có các câu lệnh update tương ứng
--hóa đơn nhập thứ nhất
update NguyenLieu
set SoLuong += 2 where MaNL = 6
update NguyenLieu
set SoLuong += 3 where MaNL = 7
update NguyenLieu
set SoLuong += 4 where MaNL = 8

--hóa đơn nhập thứ hai
update NguyenLieu
set SoLuong += 5 where MaNL = 9
update NguyenLieu
set SoLuong += 5 where MaNL = 6
update NguyenLieu
set SoLuong += 5 where MaNL = 7

--hóa đơn nhập thứ ba
update NguyenLieu
set SoLuong += 5 where MaNL = 8
update NguyenLieu
set SoLuong += 6 where MaNL = 9
update NguyenLieu
set SoLuong += 6 where MaNL = 10

/*Đặng Quốc Khánh, Nghiệp vụ thanh lý*/


go

--dữ liệu danh mục
insert into NhaCungCap(TenNCC, DiaChi, SDT) values
	(N'Chợ AA', N'TP HCM', '123123123'),
	(N'Chợ BB', N'Sài Gòn', '456456789'),
	(N'Chợ CC', N'Số 7 Thiền Quang', '9876543'),
	(N'Nhà hàng ZZ', N'Số 8 Lê Duẩn', '212345267'),
	(N'Nhà hàng XX', N'Số 9 Bùi Viện', '3748674937')
go

insert into NhanVien(HoTen, NgaySinh, DiaChi, SDT) values
	(N'Nguyễn Huy Thành', '1/1/1991', N'Hà Nội', '123'), --mm/dd/yyyy
	(N'Hoàng Minh Đại', '2/2/1992', N'Hà Nội', '123'),
	(N'Kim Minh', '3/3/1993', N'Hà Nội', '123'),
	(N'Minh gầy', '4/4/1994', N'Hà Nội', '123'),
	(N'Minh nhỡ', '2/15/1995', N'Hà Nội', '123')
go

insert into NguyenLieu(TenNL, LoaiTuoiKho, GiaTien, SoLuong, TenDonVi) values
	(N'Mật ong hoa', 1, 40000, 8, 'lạng'),
	(N'Mật ong rừng', 1, 50000, 9, 'lạng'),
	(N'Dầu dứa', 1, 60000, 10, 'lạng'),
	(N'Dấm', 1, 70000, 11, 'lạng'),
	(N'Tương cà chua', 1, 80000, 12, 'lạng')
go

--Tạo biên bản thanh lý
insert into BienBanThanhLy(MaNV) values
	(6), (8), (9)
go

--Tạo các chi tiết tương ứng
insert into ChiTietBBTL(MaBB, MaNL, Gia, SoLuong) values
	(1, 11, 10000, 1),
	(1, 13, 20000, 2),
	(1, 15, 30000, 2),

	(2, 12, 40000, 2),
	(2, 13, 50000, 2),
	(2, 14, 55000, 3),

	(3, 11, 22000, 1),
	(3, 15, 23000, 1),
	(3, 12, 24000, 1)
go

--Sau khi thanh lý thì sửa lại số lượng ở các khối tương ứng

--cho biên bản thứ nhất
update NguyenLieu
set SoLuong -= 1 where MaNL = 11
update NguyenLieu
set SoLuong -= 2 where MaNL = 13
update NguyenLieu
set SoLuong -= 3 where MaNL = 15

--cho biên bản thứ hai
update NguyenLieu
set SoLuong -= 2 where MaNL = 12
update NguyenLieu
set SoLuong -= 1 where MaNL = 13
update NguyenLieu
set SoLuong -= 3 where MaNL = 14

--cho biên bản thứ ba
update NguyenLieu
set SoLuong -= 1 where MaNL = 11
update NguyenLieu
set SoLuong -= 1 where MaNL = 15
update NguyenLieu
set SoLuong -= 1 where MaNL = 12

/*Hoàng Công Khánh, Nghiệp vụ nhập nguyên liệu khô*/


go

--dữ liệu danh mục
insert into NhaCungCap(TenNCC, DiaChi, SDT) values
	(N'TVP Food', N'TP HCM', '123123123'),
	(N'Công ty Cổ phần Tôn Phan', N'Sài Gòn', '456456789'),
	(N'Thực phẩm Đại Thuận', N'Số 10 Thiền Quang', '9876543'),
	(N'San Hà Food', N'Số 11 Lê Duẩn', '212345267'),
	(N'G.C Food', N'Số 12 Bùi Viện', '3748674937')
go

insert into NhanVien(HoTen, NgaySinh, DiaChi, SDT) values
	(N'Nguyễn Minh Đức', '1/1/1991', N'Hà Nội', '123'), --mm/dd/yyyy
	(N'Mai Quốc Khánh', '2/2/1992', N'Hà Nội', '123'),
	(N'Lê Thị Diễm', '3/3/1993', N'Hà Nội', '123'),
	(N'Hoàng Thị Thảo', '4/4/1994', N'Hà Nội', '123'),
	(N'Mai Văn Trường', '2/15/1995', N'Hà Nội', '123')
go

insert into NguyenLieu(TenNL, LoaiTuoiKho, GiaTien, TenDonVi) values
	(N'Bột ca cao', 0, 10000, N'cân'),
	(N'Bột hạnh nhân', 0, 20000, N'cân'),
	(N'Bột kem sữa', 0, 30000, N'cân'),
	(N'Bột mỳ', 0, 40000, N'cân'),
	(N'Bột trà xanh', 0, 50000, N'cân')
go

--tạo 3 phiếu đặt nguyên liệu
INSERT INTO dbo.PhieuDatNL
        ( MaNCC, MaNV )
VALUES  ( 1, 3 ),
		( 2, 4 ),
		( 3, 5 )
GO

--với mỗi phiếu đặt có 3 chi tiết tương ứng
--mã nguyên liệu từ 16 đến 20 là nguyên liệu khô
INSERT INTO dbo.ChiTietPDNL
        ( MaPDNL, MaNL, SoLuong )
VALUES  ( 4, 16, 2 ),
		( 4, 17, 3 ),
		( 4, 18, 4 ),

		( 5, 19, 5 ),
		( 5, 16, 6 ),
		( 5, 17, 7 ),

		( 6, 18, 6 ),
		( 6, 19, 5 ),
		( 6, 20, 4 )
GO

--tạo 3 hóa đơn nhập liệu tương ứng với 3 phiếu đặt
INSERT INTO dbo.HoaDonNhapNL
        ( MaPDNL, MaNV)
VALUES  ( 4, 10 ),
		( 5, 11 ),
		( 6, 12 )
GO

--với mỗi hóa đơn nhập có 3 chi tiết tương ứng
INSERT INTO dbo.ChiTietHDN
        ( MaHD, MaNL, GiaTien, SoLuong )
VALUES  ( 4, 16, 10000, 2 ),
		( 4, 17, 11000, 3 ),
		( 4, 18, 12000, 4 ),

		( 5, 19, 13000, 5 ),
		( 5, 16, 14000, 6 ),
		( 5, 17, 15000, 7 ),

		( 6, 18, 16000, 6 ),
		( 6, 19, 17000, 5 ),
		( 6, 20, 18000, 4 )
GO


--sau khi nhập xong thì có các câu lệnh update tương ứng
--hóa đơn nhập thứ nhất
update NguyenLieu
set SoLuong += 2 where MaNL = 16
update NguyenLieu
set SoLuong += 3 where MaNL = 17
update NguyenLieu
set SoLuong += 4 where MaNL = 18

--hóa đơn nhập thứ hai
update NguyenLieu
set SoLuong += 5 where MaNL = 19
update NguyenLieu
set SoLuong += 6 where MaNL = 16
update NguyenLieu
set SoLuong += 7 where MaNL = 17

--hóa đơn nhập thứ ba
update NguyenLieu
set SoLuong += 6 where MaNL = 18
update NguyenLieu
set SoLuong += 5 where MaNL = 19
update NguyenLieu
set SoLuong += 4 where MaNL = 20
