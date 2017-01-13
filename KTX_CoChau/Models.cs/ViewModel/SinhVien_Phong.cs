using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.cs.ViewModel
{
  public  class SinhVien_Phong
    {
       
            [StringLength(50)]

            public string Masinhvien { get; set; }

            [StringLength(50)]

            public string Ten { get; set; }

            [StringLength(50)]

            public string DiaChi { get; set; }

            [Column(TypeName = "date")]

            public DateTime? NgaySinh { get; set; }

            [StringLength(50)]

            public string GioiTinh { get; set; }

            public int? SoDT { get; set; }
        
            [StringLength(50)]

            public string Lop { get; set; }

            [StringLength(50)]
            public string MaDoiTuongUuTien { get; set; }

            [StringLength(50)]
            public string MaPhong { get; set; }

            public long MaNhanVien { get; set; }

            [Key]
            public long STT { get; set; }
            [StringLength(50)]
            public string Khu { get; set; }
        }
    
}
