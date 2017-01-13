namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dien")]
    public partial class Dien
    {
        [StringLength(50)]
        public string MaDongHo { get; set; }

      
        public int Gia { get; set; }

        [Key]
        public long STT { get; set; }
    }
}
