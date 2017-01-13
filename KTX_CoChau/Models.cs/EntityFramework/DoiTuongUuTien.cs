namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoiTuongUuTien")]
    public partial class DoiTuongUuTien
    {
        [StringLength(50)]
        public string MaDoiTuongUuTien { get; set; }

        [StringLength(50)]
        public string TenDoiTuongUuTien { get; set; }

        [Key]
        public long STT { get; set; }
    }
}
