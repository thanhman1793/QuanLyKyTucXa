namespace Models.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KtxDbContext : DbContext
    {
        public KtxDbContext()
            : base("name=KtxDbContext")
        {
        }

        public virtual DbSet<Dien> Diens { get; set; }
        public virtual DbSet<DoiTuongUuTien> DoiTuongUuTiens { get; set; }
        public virtual DbSet<HoaDonDienNuoc> HoaDonDienNuocs { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<NhanVienn> NhanVienns { get; set; }
        public virtual DbSet<Nuoc> Nuocs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<LoaiPhong>()
                .Property(e => e.Gia)
                .HasPrecision(18, 0);
        }
    }
}
