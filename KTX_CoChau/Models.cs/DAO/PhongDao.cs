using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.cs.DAO
{
    public class PhongDao
    {
        public KtxDbContext db = null;
        public PhongDao()
        {
            db = new KtxDbContext();
        }
        public static int demphongmoithem()
        {
            KtxDbContext db1 = new KtxDbContext();
            return db1.Phongs.Where(x => x.Isread == false || x.Isread == null).Count();
        }
        public int? DemsoSV(long maphong)
        {
            var phong = db.Phongs.SingleOrDefault(x=>x.STT==maphong);
            return phong.SoSV;
        }
        public bool EditIsread()
        {
            List<Phong> listphong = db.Phongs.ToList();
            foreach (var ph in listphong)
            {
                ph.Isread = true;

            }
            db.SaveChanges();
            return true;
        }
        public long Insert(Phong phong, long manhanvien)
        {
            try
            {
                if(phong.SoSV==null)
                {
                    phong.SoSV =0;
                }
                phong.MaNhanVien = manhanvien;
                   
                db.Phongs.Add(phong);
                db.SaveChanges();
                return phong.STT;
            }
            catch
            {
                return 0;
            }
        }
        public IEnumerable<Phong> danhsachphongtrong()
        {
            try
            {
                return db.Phongs.Where(x => x.SoSV < x.SoGiuong).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Phong Timphong(int id)
        {
            return db.Phongs.Find(id);
        }
        public static string Timkhu(string maphong)
        {
            KtxDbContext db1 = new KtxDbContext();
            var phong= db1.Phongs.SingleOrDefault(x=>x.MaPhong==maphong);
            return phong.Khu;
        }
        public List<Phong> Danhsachphong()
        {
            return db.Phongs.OrderByDescending(x=>x.STT).ToList();
        }
        public List <Phong> Danhsachphongchuadusv()
        {
          return db.Phongs.Where(x=>x.SoSV<x.SoGiuong||x.SoSV==null||x.SoSV==0).ToList();
        }
        public List<Phong> ThongKePhong(string thamso)
        {
            try
            {
                switch (thamso)
                {
                    case "C1":
                        return db.Phongs.Where(x => x.Khu == "C1").ToList();
                    case "C2":
                        return db.Phongs.Where(x => x.Khu == "C2").ToList();
                    case "C3":
                        return db.Phongs.Where(x => x.Khu == "C3").ToList();

                    case "C4":
                        return db.Phongs.Where(x => x.Khu == "C4").ToList();

                    case "Lao":
                        return db.Phongs.Where(x => x.Khu == "Lao").ToList();
                    case "tc":
                        return db.Phongs.ToList();
                    default:
                        return db.Phongs.Where(x => x.SoSV < x.SoGiuong || x.SoSV == null || x.SoSV == 0).ToList();

                }
            }
            catch
            {
                return null;
            }
           

            
        }
        public long Delete(int id)

        {
            try
            {
                
                var phong = db.Phongs.Find(id);
                if(phong.SoSV>0)
                {
                    return 2;
                }
                db.Phongs.Remove(phong);
                db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool Edit(Phong entity, long macanbo, FormCollection col)
        {
            var phong = db.Phongs.Find(entity.STT);
            phong.Khu = entity.Khu;
            phong.MaPhong = entity.MaPhong;
            phong.SoGiuong = entity.SoGiuong;
            phong.MaNhanVien = macanbo;
            phong.MaLoaiPhong = col["MaLoaiPhong"];
            db.SaveChanges();
            return true;
        }
       
    }

}
