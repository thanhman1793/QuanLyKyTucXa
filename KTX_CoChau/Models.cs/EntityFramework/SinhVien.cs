namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [StringLength(50)]
        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        public string Masinhvien { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Tên sinh viên không được để trống")]
        public string Ten { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Địa chỉ sinh viên không được để trống")]
        public string DiaChi { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        public DateTime? NgaySinh { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgayThem { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Giới tính không được để trống")]
        public string GioiTinh { get; set; }

        public int? SoDT { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = " Lớp không được để trống")]
        public string Lop { get; set; }

        [StringLength(50)]
        public string MaDoiTuongUuTien { get; set; }

        [StringLength(50)]
        public string MaPhong { get; set; }

        public long MaNhanVien { get; set; }

        [Key]
        public long STT { get; set; }
        public bool? Isread { get; set; }
    }
}
