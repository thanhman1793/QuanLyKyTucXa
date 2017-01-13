namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nuoc")]
    public partial class Nuoc
    {
        [StringLength(50)]
        public string MaDongHo { get; set; }

      
        public int Gia { get; set; }

        [Key]
        public long STT { get; set; }
    }
}
