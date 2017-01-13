namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiPhong")]
    public partial class LoaiPhong
    {
        [StringLength(50)]
        public string MaLoaiPhong { get; set; }

        [StringLength(50)]
        public string TenLoaiPhong { get; set; }

        public decimal Gia { get; set; }

        [Key]
        public long STT { get; set; }
    }
}
