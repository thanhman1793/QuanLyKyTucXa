using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models.EntityFramework;

namespace Models.Dao
{
    public class NhanVienDao
    {
        public KtxDbContext db = null;
        public NhanVienDao()
        {
            db = new KtxDbContext();
        }

        public List<NhanVienn> DanhSachNhanVien()
        {
            return db.NhanVienns.OrderByDescending(x=>x.STT).ToList();
        }
        // insert
        public bool Delete(int id)

        {
            try
            {
                var nhanvien = db.NhanVienns.Find(id);
                db.NhanVienns.Remove(nhanvien);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public long Insert(NhanVienn nhanvien)
        {
            try
            {
                nhanvien.NgayThem = DateTime.Now;
                nhanvien.Status = true;
                db.NhanVienns.Add(nhanvien);

                db.SaveChanges();
                return nhanvien.STT;

            }
            catch
            {
                return 0;
            }


        }
        public NhanVienn GetById(string taikhoan)
        {
            return db.NhanVienns.SingleOrDefault(x => x.TaiKhoan == taikhoan);
        }



        public bool DangNhap(string TaiKhoan, string MatKhau)
        {
            int result = db.NhanVienns.Where(x => x.TaiKhoan == TaiKhoan && x.MatKhau == MatKhau).Count();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public NhanVienn Timnhanvien(int id)
        {

            return db.NhanVienns.Find(id);//chắc chắn có id
        }
        public static string Timtennhanvien(long manhanvien)
        {
            try
            {
                KtxDbContext db1 = new KtxDbContext();
                var nhanvien = db1.NhanVienns.SingleOrDefault(x => x.STT == manhanvien);//chắc chắn có id
                return nhanvien.Ten;
            }
            catch
            {
                return "";

            }


        }
       
        public bool Edit(NhanVienn entity)
        {
            try
            {
                var nhanvien = db.NhanVienns.Find(entity.STT);
                nhanvien.Ten = entity.Ten;
                nhanvien.TaiKhoan = entity.TaiKhoan;
                nhanvien.DiaChi = entity.DiaChi;
                nhanvien.GhiChu = entity.GhiChu;
                if(entity.ChucVu!=null)
                {
                    nhanvien.ChucVu = entity.ChucVu;
                }
                if (entity.GioiTinh != null)
                {
                    nhanvien.GioiTinh = entity.GioiTinh;
                }
                if (entity.MatKhau != null)
                {
                    nhanvien.MatKhau = entity.MatKhau;
                }
                nhanvien.NgaySinh = entity.NgaySinh;
                nhanvien.SoDT = entity.SoDT;
                //  nhanvien.TaiKhoan = entity.TaiKhoan;
               // nhanvien.HinhAnh = entity.HinhAnh;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


    }

}
