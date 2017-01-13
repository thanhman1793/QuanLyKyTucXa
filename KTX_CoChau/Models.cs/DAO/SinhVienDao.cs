using Models.cs.ViewModel;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.cs.DAO
{
    public class SinhVienDao
    {
        public KtxDbContext db = null;
        public SinhVienDao()
        {
            db = new KtxDbContext();
        }
        //public static int Demsvhethopdong()
        //{
        //    var db1 = new KtxDbContext();
        //    return db1.SinhViens.Where(x=>x.NgayThem)
        //}
        public bool giahan(int masv)
        {
            try
            {
                var sv = db.SinhViens.Find(masv);
                sv.NgayThem = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public int timmasv(string masinhvien)
        {
            return db.SinhViens.Where(x => x.Masinhvien == masinhvien).ToList().Count();
        }

        public static List<SinhVien> TimDSSinhVienTheoMaPhong(string maphong)
        {
            KtxDbContext db1 = new KtxDbContext();

            return db1.SinhViens.Where(x => x.MaPhong == maphong).ToList();
        }
        public List<SinhVien> DanhSachSinhVien()
        {
            return db.SinhViens.OrderByDescending(x => x.STT).ToList();
        }

        public SinhVien timsinhvien(int id)
        {
            return db.SinhViens.Find(id);
        }
        public long ThemSinhVien(SinhVien sinhvien, long macanbo, FormCollection col)
        {
            using (System.Data.Entity.DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var canbo = db.NhanVienns.Find(macanbo);
                    //INSERT công việc into table công việc
                    sinhvien.Ten = sinhvien.Ten;
                    sinhvien.NgaySinh = sinhvien.NgaySinh;
                    sinhvien.GioiTinh = sinhvien.GioiTinh;
                    sinhvien.DiaChi = sinhvien.DiaChi;
                    sinhvien.NgayThem = DateTime.Now;
                    sinhvien.SoDT = sinhvien.SoDT;
                    sinhvien.Masinhvien = sinhvien.Masinhvien;
                    sinhvien.MaNhanVien = macanbo;
                    sinhvien.Lop = sinhvien.Lop;
                    sinhvien.MaPhong = col["MaPhong"];
                    sinhvien.MaDoiTuongUuTien = col["MaDoiTuongUuTien"];
                    db.SinhViens.Add(sinhvien);

                    db.SaveChanges();
                    //insert vào bảng người nhận cv
                    var phong = db.Phongs.Where(x => x.MaPhong == sinhvien.MaPhong).ToList();
                    foreach (var item in phong)
                    {
                        item.SoSV = (item.SoSV + 1);
                        db.SaveChanges();
                    }
                    transaction.Commit();
                    db.Dispose();
                    return sinhvien.STT;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    db.Dispose();
                    return 0;
                }
            }
        }
        public static int demsvmoithem()
        {
            KtxDbContext db1 = new KtxDbContext();
            return db1.SinhViens.Where(x => x.Isread == false || x.Isread == null).Count();
        }
        public bool EditIsread()
        {
            List<SinhVien> listsv = db.SinhViens.ToList();
            foreach (var sv in listsv)
            {
                sv.Isread = true;

            }
            db.SaveChanges();
            return true;
        }
        public bool Edit(SinhVien entity, long manhanvien, FormCollection col)
        {
            using (System.Data.Entity.DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var sinhvien = db.SinhViens.Find(entity.STT);
                    sinhvien.Ten = entity.Ten;
                    sinhvien.DiaChi = entity.DiaChi;
                    sinhvien.GioiTinh = entity.GioiTinh;
                    sinhvien.NgaySinh = entity.NgaySinh;
                    sinhvien.SoDT = entity.SoDT;
                    sinhvien.Lop = entity.Lop;
                    var mapm = col["MaPhong1"];
                    if (col["MaDoiTuongUuTien"] != "")
                    {
                        sinhvien.MaDoiTuongUuTien = col["MaDoiTuongUuTien"];

                    }

                    if (col["MaPhong1"] != "")
                    {

                        var sv = db.SinhViens.SingleOrDefault(x => x.Masinhvien == entity.Masinhvien);
                        var phongcu = db.Phongs.Where(x => x.MaPhong == sv.MaPhong).ToList();
                        if (phongcu != null)
                        {
                            foreach (var item in phongcu)
                            {
                                item.SoSV = item.SoSV - 1;
                                db.SaveChanges();
                            }
                            var phongmoi = db.Phongs.Where(x => x.MaPhong == mapm).ToList();
                            foreach (var item in phongmoi)
                            {
                                item.SoSV = (item.SoSV + 1);
                                db.SaveChanges();
                            }
                        }
                        sinhvien.MaPhong = col["MaPhong1"];
                    }

                    sinhvien.Masinhvien = entity.Masinhvien;
                    sinhvien.MaNhanVien = manhanvien;
                    db.SaveChanges();
                    transaction.Commit();
                    return true;

                }
                catch (Exception)
                {
                    transaction.Rollback();

                    return false;
                }

            }
        }
        public bool Delete(int id, string maphong)

        {
            try
            {
                var sinhvien = db.SinhViens.Find(id);
                db.SinhViens.Remove(sinhvien);
                db.SaveChanges();
                List<Phong> phong = db.Phongs.Where(x => x.MaPhong == maphong).ToList();
                foreach (var item in phong)
                {
                    item.SoSV = (item.SoSV - 1);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string TimMaPhong(int id)
        {
            var list = db.SinhViens.SingleOrDefault(x => x.STT == id);
            return list.MaPhong;
        }
        public List<SinhVien_Phong> ThongKeSinhVien(string thamso)
        {
            try
            {
                switch (thamso)
                {
                    case "C1":
                        {
                            var ds = from a in db.SinhViens
                                     join b in db.Phongs on a.MaPhong equals b.MaPhong
                                     where b.Khu == "C1"
                                     select new SinhVien_Phong()
                                     {
                                         DiaChi = a.DiaChi,
                                         SoDT = a.SoDT,
                                         NgaySinh = a.NgaySinh,
                                         GioiTinh = a.GioiTinh,
                                         Lop = a.Lop,
                                         MaDoiTuongUuTien = a.MaDoiTuongUuTien,
                                         MaNhanVien = a.MaNhanVien,
                                         Masinhvien = a.Masinhvien,
                                         MaPhong = a.MaPhong,
                                         Khu = b.Khu,
                                         Ten = a.Ten,
                                     
                                         STT = a.STT,

                                     };
                            string td = ds.ToString();
                            return ds.ToList();
                           
                        }

                    case "C2":
                        {
                            var ds = from a in db.SinhViens
                                     join b in db.Phongs on a.MaPhong equals b.MaPhong
                                     where b.Khu == "C2"
                                     select new SinhVien_Phong()
                                     {
                                         DiaChi = a.DiaChi,
                                         SoDT = a.SoDT,
                                         NgaySinh = a.NgaySinh,
                                         GioiTinh = a.GioiTinh,
                                         Lop = a.Lop,
                                         MaDoiTuongUuTien = a.MaDoiTuongUuTien,
                                         MaNhanVien = a.MaNhanVien,
                                         Masinhvien = a.Masinhvien,
                                         MaPhong = a.MaPhong,
                                         Khu = b.Khu,
                                         Ten = a.Ten,
                                        
                                         STT = a.STT,

                                     };
                            return ds.ToList();
                        }
                    case "C3":
                        {
                            var ds = from a in db.SinhViens
                                     join b in db.Phongs on a.MaPhong equals b.MaPhong
                                     where b.Khu == "C3"
                                     select new SinhVien_Phong()
                                     {
                                         DiaChi = a.DiaChi,
                                         SoDT = a.SoDT,
                                         NgaySinh = a.NgaySinh,
                                         GioiTinh = a.GioiTinh,
                                         Lop = a.Lop,
                                         MaDoiTuongUuTien = a.MaDoiTuongUuTien,
                                         MaNhanVien = a.MaNhanVien,
                                         Masinhvien = a.Masinhvien,
                                         MaPhong = a.MaPhong,
                                         Khu = b.Khu,
                                         Ten = a.Ten,
                                   
                                         STT = a.STT,

                                     };
                            return ds.ToList();
                        }
                    case "C4":
                        {
                            var ds = from a in db.SinhViens
                                     join b in db.Phongs on a.MaPhong equals b.MaPhong
                                     where b.Khu == "C4"
                                     select new SinhVien_Phong()
                                     {
                                         DiaChi = a.DiaChi,
                                         SoDT = a.SoDT,
                                         NgaySinh = a.NgaySinh,
                                         GioiTinh = a.GioiTinh,
                                         Lop = a.Lop,
                                         MaDoiTuongUuTien = a.MaDoiTuongUuTien,
                                         MaNhanVien = a.MaNhanVien,
                                         Masinhvien = a.Masinhvien,
                                         MaPhong = a.MaPhong,
                                         Khu = b.Khu,
                                         Ten = a.Ten,
                                 
                                         STT = a.STT,

                                     };
                            return ds.ToList();
                        }
                    case "Lào":
                        {
                            var ds = from a in db.SinhViens
                                     join b in db.Phongs on a.MaPhong equals b.MaPhong
                                     where b.Khu == "Lào"
                                     select new SinhVien_Phong()
                                     {
                                         DiaChi = a.DiaChi,
                                         SoDT = a.SoDT,
                                         NgaySinh = a.NgaySinh,
                                         GioiTinh = a.GioiTinh,
                                         Lop = a.Lop,
                                         MaDoiTuongUuTien = a.MaDoiTuongUuTien,
                                         MaNhanVien = a.MaNhanVien,
                                         Masinhvien = a.Masinhvien,
                                         MaPhong = a.MaPhong,
                                         Khu = b.Khu,
                                         Ten = a.Ten,
                           
                                         STT = a.STT,
                                     };
                            return ds.ToList();
                        }
                    default:
                        {
                            var ds = from a in db.SinhViens
                                     join b in db.Phongs on a.MaPhong equals b.MaPhong

                                     select new SinhVien_Phong()
                                     {
                                         DiaChi = a.DiaChi,
                                         SoDT = a.SoDT,
                                         NgaySinh = a.NgaySinh,
                                         GioiTinh = a.GioiTinh,
                                         Lop = a.Lop,
                                         MaDoiTuongUuTien = a.MaDoiTuongUuTien,
                                         MaNhanVien = a.MaNhanVien,
                                         Masinhvien = a.Masinhvien,
                                         MaPhong = a.MaPhong,
                                         Khu = b.Khu,
                                         Ten = a.Ten,
                                         STT = a.STT,

                                     };
                            return ds.ToList();
                        }
                }
            }
            catch
            {
                return null;
            }

            return null;
        }
    }
}
