namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonDienNuoc")]
    public partial class HoaDonDienNuoc
    {
        [Key]
        public long SoHoaDon { get; set; }

        public int? ChiSoNuocDau { get; set; }
        [Required(ErrorMessage = "Chỉ số nước không được để trống")]
        public int? ChiSoNuocuoi { get; set; }

        public int? ChiSoDienDau { get; set; }
        [Required(ErrorMessage = "Chỉ số điện không được để trống")]
        public int? ChiSoDienCuoi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }

        public bool? TinhTrang { get; set; }


        [StringLength(50)]
        public string MaSinhVien { get; set; }


        public long MaNhanVien { get; set; }

        [StringLength(50)]
        public string MaDongHoDien { get; set; }

        [StringLength(50)]
        public string MaDongHoNuoc { get; set; }

        [StringLength(50)]
        public string MaPhong { get; set; }
    }
}
