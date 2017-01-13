using Eoffice.Controllers;
using Models.cs.DAO;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANLYCONGVAN.Controllers
{
    public class QLSinhVienController : BaseController
    {
        KtxDbContext db = new KtxDbContext();
        // GET: QLSinhVien
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Giahan(int masv)
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý sinh viên")
            {
                var kq = new SinhVienDao().giahan(masv);
                if (kq==true)
                {
                    SetAlert("Gia hạn thành công ! ", "error");
                    return RedirectToAction("DanhSachSinhVien", "QLSinhVien");
                }
                else
                {
                    SetAlert("Gia hạn thất bại ! ", "error");
                    return RedirectToAction("DanhSachSinhVien", "QLSinhVien");
                }
            }
            return View();
        }
        public ActionResult InHoaDon(int ID)
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý sinh viên")
            {
                var hoadon = new SinhVienDao().timsinhvien(ID);
                if (hoadon != null)
                {
                    return View(hoadon);
                }
               
            }
            return View();

        }
        public ActionResult DemSV()
        {
            var kq = new SinhVienDao().EditIsread();
            return View();
        }
      
        public ActionResult Danhsachsinhvien()
        {
            ViewBag.ketqua = "không có sinh viên nào ! ";
            var data = new SinhVienDao().DanhSachSinhVien();
            if (data != null)
            {
                return View(data);
            }
            else
            {
                return ViewBag.ketqua;
            }

        }
        public ActionResult ThongKeSinhVien()
        {
            ViewBag.ketqua = "không có sinh viên nào ! ";
            string thamso = Request.QueryString["tinhhinh"];
            var data = new SinhVienDao().ThongKeSinhVien(thamso);
            if (data != null)
            {
                return View(data);
            }
            else
            {
                return ViewBag.ketqua;
            }

        }
        [HttpGet]
        public ActionResult Themsinhvien()
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý sinh viên")
            {
                var DoiTuongUuTien = new DoiTuongUuTienDao().danhsachdoituongut();
                var phong = new PhongDao().danhsachphongtrong();
                if (phong != null)
                {
                    ViewBag.DTUT = new SelectList(DoiTuongUuTien, "MaDoiTuongUuTien", "TenDoiTuongUuTien");
                    ViewBag.Phong = new SelectList(phong, "MaPhong", "MaPhong");
                }
                return View();
            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền thêm sinh viên !");
                return View("Index");
            }

        }
        [HttpPost]
        public ActionResult Themsinhvien(SinhVien sv, Phong phong, FormCollection col)
        {
            if ( 1999< sv.NgaySinh.Value.Year||sv.NgaySinh.Value.Year<1800)
            {
                SetAlert(" Năm sinh tầm bậy rồi =)))) Vui lòng kiểm tra lại năm sinh ! ", "error");
                return RedirectToAction("DanhSachSinhVien", "QLSinhVien");
            }
            var maquyenhan = (string)Session["MAQUYENHAN"];
             var  masv = sv.Masinhvien;
            var ketqua = new SinhVienDao().timmasv(masv);
            if(ketqua!=0)
            {
                SetAlert("Mã sinh viên đã có ! ", "error");
                return RedirectToAction("ThemSInhVien", "QLSinhVien");
            }
            var macanbo = (long)Session["MANHANVIEN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý sinh viên")
            {
                var result = new SinhVienDao().ThemSinhVien(sv, macanbo, col);
                if(result>0)
                {
                    SetAlert("Đăng ký sinh viên mới thành công ! ", "error");
                    return RedirectToAction("DanhSachSinhVien", "QLSinhVien");
                }
                else
                {
                    SetAlert("Đăng ký sinh viên mới thất bại ! ", "error");
                    return RedirectToAction("DanhSachSinhVien", "QLSinhVien");
                }
              
            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền thêm sinh viên !");
                return View("Index");
            }

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];

            var sinhvien = new SinhVienDao().timsinhvien(id);
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý sinh viên")
            {
                var DoiTuongUuTien = new DoiTuongUuTienDao().danhsachdoituongut();
                var phong = new PhongDao().danhsachphongtrong();
                if (phong != null)
                {
                    ViewBag.DTUT = new SelectList(DoiTuongUuTien, "MaDoiTuongUuTien", "TenDoiTuongUuTien");
                    ViewBag.Phong = new SelectList(phong, "MaPhong", "MaPhong");
                }
                else
                {
                    SetAlert("Đã hết phòng trống ! ", "error");
                    return RedirectToAction("DanhSachSinhVien", "QLSinhVien");

                }

                return View(sinhvien);

            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền thêm sinh viên !");
                return View("Index");
            }
        }
        [HttpPost]
        public ActionResult Edit(SinhVien sv, FormCollection col)
        {

            var maquyenhan = (string)Session["MAQUYENHAN"];

            var macanbo = (long)Session["MANHANVIEN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý sinh viên")
            {
                if (1999 < sv.NgaySinh.Value.Year || sv.NgaySinh.Value.Year < 1980)
                {
                    SetAlert(" Năm sinh tầm bậy rồi =)))) Vui lòng kiểm tra lại năm sinh ! ", "error");
                    return RedirectToAction("DanhSachSinhVien", "QLSinhVien");
                }
                var result = new SinhVienDao().Edit(sv, macanbo, col);
                if(result==true)
                {
                    SetAlert("Sửa thành công ! ", "error");
                    return RedirectToAction("DanhSachSinhVien", "QLSinhVien");
                }
                else
                {
                    SetAlert("Sửa thất bại ! ", "error");
                    return RedirectToAction("DanhSachSinhVien", "QLSinhVien");
                }
            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền thêm sinh viên !");
                return View("Index");
            }
        }
        public ActionResult Delete(int id)
        {
            string result = "Xóa thất bại!";
            var maquyenhan = (string)Session["MAQUYENHAN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý sinh viên")
            {
                string maphong = new SinhVienDao().TimMaPhong(id);

                if (new SinhVienDao().Delete(id,maphong))
                {
                    result = "Xóa thành công!";
                    SetAlert("Xóa thành công", "error");
                    return RedirectToAction("DanhSachSinhVien", "QLSinhVien");
                }
          
                return Json(result);
             
            }
            else
            {
                SetAlert("bạn không phải là quản trị viên hoặc nhân viên quản lý sinh viên !", "error");
                return RedirectToAction("DanhSachSinhVien", "QLSinhVien");
            }
            return Json(result);

        }
    }
}