
--thêm một nhân viên
create proc Them(@manv int , @hoten nvarchar(50),@ngaysinh Date, @diachi nvarchar(50), @sdt char(12))
as
begin 
insert into NhanVien(MaNV , HoTen, NgaySinh,DiaChi,SDT) values
(@manv  , @hoten ,@ngaysinh , @diachi, @sdt )
end
exec Them '21','tung','1999-08-1','hoàng quốc việt','00000'

--xóa một nhân viên
create proc xoanv(@manv int)
as 
begin
      delete  PhieuDatNL where PhieuDatNL.MaNV= @manv
	  delete  ChiTietHDN where MaHD = (select HoaDonNhapNL.MaHDN from HoaDonNhapNL
												join NhanVien on HoaDonNhapNL.MaNV = @manv)
      delete ChiTietBBTL where MaBB = (select BienBanThanhLy.MaBB from BienBanThanhLy
												join NhanVien on BienBanThanhLy.MaNV = @manv)
	  delete  ChiTietPTK where MaPTK = (select PhieuThongKe.MaPTK from PhieuThongKe
												join NhanVien on PhieuThongKe.MaNV = @manv)
	  delete  PhieuThongKe where MaNV= @manv
	  delete  BienBanThanhLy where MaNV= @manv
	  delete  HoaDonNhapNL where MaNV= @manv
	  delete PhieuDatNL where MaNV= @manv
	  delete  NhanVien where MaNV= @manv
end
-- sửa một nhân viên   
	create proc xoanv(@manv int , @hoten nvarchar(50),@ngaysinh Date, @diachi nvarchar(50), @sdt char(12))
	as
	begin
	update NhanVien set HoTen=@hoten,NgaySinh=@ngaysinh,DiaChi=@diachi,SDT=@sdt where MaNV= @manv
	end
  
-- lấy về danh sách nhân viên
create proc laydsnv
as
begin
	select * from NhanVien
end

------------------Bảng Nguyên Liệu

--lấy vè danh sách bảng nguyên liệu
create proc laydsnl
as
begin
    select * from NguyenLieu
end
exec laydsnl


--thêm một nguyên liệu
create proc themnl(@manl int,@tennl nvarchar(30),@giatien int,@soluong float)
as
begin 
insert into NguyenLieu(MaNL, TenNL,GiaTien,SoLuong) values
(@manl ,@tennl ,@giatien,@soluong )
end

--sửa một nguyên liệu
create proc suanl(@manl int, @tennl nvarchar(30), @giatien int, @soluong float)
as
begin
   update NguyenLieu set TenNL=@tennl ,GiaTien=@giatien,SoLuong=@soluong where MaNL=@manl
 end
 --Xóa Nguyên Liệu
 create proc xoanl(@manl int)
 as
 begin
 delete ChiTietBBTL where MaNL=@manl
 delete ChiTietPTK where MaNL=@manl
 delete ChiTietHDN where MaNL=@manl
 delete ChiTietPDNL where MaNL=@manl
 delete NguyenLieu where MaNL=@manl
 end
 exec xoanl '1'