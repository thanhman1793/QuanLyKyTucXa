using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.cs.DAO
{
    public class DoiTuongUuTienDao
    {
        public KtxDbContext db = null;
        public DoiTuongUuTienDao()
        {
            db = new KtxDbContext();
        }
        public List<DoiTuongUuTien> danhsachdoituongut()
        {
            try
            {
                return db.DoiTuongUuTiens.ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
