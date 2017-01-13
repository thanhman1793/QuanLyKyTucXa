namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [Key]
        public long STT { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Mã phòng không được để trống")]
        public string MaPhong { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Khu không được để trống")]
        public string Khu { get; set; }

        [Required(ErrorMessage = "Số giường không được để trống")]
        public int? SoGiuong { get; set; }

        public bool? TinhTrang { get; set; }

        [StringLength(50)]
        public string MaLoaiPhong { get; set; }

        public long MaNhanVien { get; set; }

        public int? SoSV { get; set; }
        public bool? Isread { get; set; }
    }
}
