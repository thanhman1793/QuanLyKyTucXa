using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.cs.DAO
{
   public class HoaDonDienNuocDao
    {
        public KtxDbContext db = null;
        public HoaDonDienNuocDao()
        {
            db = new KtxDbContext();
        }
        public bool Thutien (int id)
        {
            try
            {
                var hoadon = db.HoaDonDienNuocs.Find(id);
                hoadon.TinhTrang = true;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
        }
        public static int DemDNchuathanhtoan()
        {
           KtxDbContext db1 = new KtxDbContext();
            return db1.HoaDonDienNuocs.Where(x => x.TinhTrang == false).Count();
        }
        public List<Dien> ChuDien()
        {
            return db.Diens.ToList();
        }
        public List<Nuoc> ChuNuoc()
        {
            return db.Nuocs.ToList();
        }
        public List<HoaDonDienNuoc> Gethoahon( string maphong)
        {
            return db.HoaDonDienNuocs. Where(x => x.MaPhong==maphong).OrderByDescending(x => x.NgayLap).ToList();
        }
        public List<HoaDonDienNuoc> DanhSach()
        {
            return db.HoaDonDienNuocs.OrderByDescending(x=>x.SoHoaDon).ToList();
        }
        public HoaDonDienNuoc TimHoaDon(int id)
        {
            return db.HoaDonDienNuocs.Find(id);
        }
        public bool Edit(HoaDonDienNuoc hoadon,long manhanvien)
        {
            try
            {
                var hd = db.HoaDonDienNuocs.Find(hoadon.SoHoaDon);
                hd.ChiSoDienCuoi = hoadon.ChiSoDienCuoi;
                hd.ChiSoNuocuoi = hoadon.ChiSoNuocuoi;
                hd.NgayLap = DateTime.Now;
                hd.MaNhanVien = manhanvien;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
        }
        public long TinhTien(HoaDonDienNuoc hd, long manhanvien, FormCollection col)
        {
            try 
            {
                hd.ChiSoDienDau = int.Parse(col["giadiendau"]?.ToString());
                hd.ChiSoNuocDau = Convert.ToInt32(col["gianuocdau"]);
                hd.NgayLap = DateTime.Now;
                hd.TinhTrang = false;
                hd.MaNhanVien = manhanvien;

                db.HoaDonDienNuocs.Add(hd);
                db.SaveChanges();
                return hd.SoHoaDon;
            }
            catch
            {
                return 0;
            }
        }
        public Dien TimDien(int id)
        {
            return db.Diens.Find(id);
        }
        public Nuoc TimNuoc(int id)
        {
            return db.Nuocs.Find(id);
        }
        public bool Editd(Dien entity)
        {
            var dien = db.Diens.Find(entity.STT);
            dien.Gia = entity.Gia;
            db.SaveChanges();
            return true;
        }
        public bool Editn(Nuoc entity)
        {
            var dien = db.Nuocs.Find(entity.STT);
            dien.Gia = entity.Gia;
            db.SaveChanges();
            return true;
        }
    }
}
