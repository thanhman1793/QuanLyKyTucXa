namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVienn")]
    public partial class NhanVienn
    {
        [Key]
        public long STT { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Tên nhân viên không được để trống")]
        public string Ten { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string DiaChi { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Ngày sinh nhân viên không được để trống")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Giới tính nhân viên không được để trống")]
        public string GioiTinh { get; set; }

        public int? SoDT { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Chức vụ nhân viên không được để trống")]
        public string ChucVu { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Tên tài khoản nhân viên không được để trống")]
        public string TaiKhoan { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string MatKhau { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "date")]

        public DateTime? NgayThem { get; set; }
    }
}
