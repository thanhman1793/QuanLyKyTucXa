using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.cs.DAO
{
    public class LoaiPhongDao
    {
        public KtxDbContext db = null;
        public LoaiPhongDao()
        {
            db = new KtxDbContext();
        }
        public long Insert(LoaiPhong loaiphong)
        {
            try
            {

                db.LoaiPhongs.Add(loaiphong);

                db.SaveChanges();
                return loaiphong.STT;

            }
            catch
            {
                return 0;
            }


        }
        public IEnumerable<LoaiPhong> danhsachloaiphong()
        {
            try
            {
                return db.LoaiPhongs.ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<Phong> danhsachphong()
        {
            try
            {
                return db.Phongs.ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<LoaiPhong> timloaiphong(string maloaiphong)
        {
            var malp = maloaiphong.Trim();
            return db.LoaiPhongs.Where(x => x.MaLoaiPhong == malp).ToList();
        }
        public static decimal timgia(string maphong)
        {
            KtxDbContext db1 = new KtxDbContext();
            var phong = db1.Phongs.SingleOrDefault(x => x.MaPhong == maphong);

            var loaiphong= db1.LoaiPhongs.SingleOrDefault(x => x.MaLoaiPhong == phong.MaLoaiPhong);
            return loaiphong.Gia;
        }
        public List<Phong> timmaloaiphong(string maphong)
        {
            return db.Phongs.Where(x => x.MaPhong == maphong).ToList();
        }
    }

}
