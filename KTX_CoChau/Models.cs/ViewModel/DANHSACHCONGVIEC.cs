
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.cs.ViewModel
{
    public class DANHSACHCONGVIEC
    {
        public long STT { get; set; }
        public string ID_CongViec { get; set; }

        public string NoiDungCongViec { get; set; }

        public string GhiChuCongViec { get; set; }
        public string GhiChuBaoCao { get; set; }
        public bool? TrangThaiGiaoViec { get; set; }

        public bool? TrangThaiBaoCao { get; set; }

   


        [StringLength(50)]
        public string TenCongViec { get; set; }

        [StringLength(50)]
        public string NguoiGiaoViec { get; set; }

        [StringLength(50)]
        public string NguoiNhanviec { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGiaoViec { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayBaoCao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHetHan { get; set; }
        public string NoiDungBaoCao { get; set; }
    }
}
