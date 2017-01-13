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
    public class DienNuocController : BaseController
    {
        KtxDbContext db = new KtxDbContext();
        // GET: DienNuoc
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Thutien (int id)
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý điện nước")
            {
                var result = new HoaDonDienNuocDao().Thutien(id);
                if(result ==true)
                {
                    return RedirectToAction("DanhSachDienNuoc", "DienNuoc");
                }
                else
                {
                    SetAlert("có lỗi  ! ", "error");
                    return RedirectToAction("DanhSachDienNuoc", "DienNuoc");
                }
            }
            else
            {
                SetAlert("Bạn không phải nhân viên điện nước  ! ", "error");
                return RedirectToAction("DanhSachDienNuoc", "DienNuoc");
            }
          
        }
        public ActionResult TimSoDienCu(string maphong)
        {
            var hoadon = new HoaDonDienNuocDao().Gethoahon(maphong).FirstOrDefault();
            return Json(hoadon, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DanhSachDienNuoc()
        {
            var hoadon = new HoaDonDienNuocDao().DanhSach();
            if (hoadon != null)
            {
                var chudien = new HoaDonDienNuocDao().ChuDien();
                var chunuoc = new HoaDonDienNuocDao().ChuNuoc();
                foreach (var cd in chudien)
                {
                    ViewBag.giadien = cd.Gia;
                }
                foreach (var cn in chunuoc)
                {
                    ViewBag.gianuoc = cn.Gia;
                }
                return View(hoadon);
            }
            return View();

        }
        public ActionResult InHoaDon(int ID)
        {
            var hoadon = new HoaDonDienNuocDao().TimHoaDon(ID);
            if (hoadon != null)
            {
                var chudien = new HoaDonDienNuocDao().ChuDien();
                var chunuoc = new HoaDonDienNuocDao().ChuNuoc();
                foreach (var cd in chudien)
                {
                    ViewBag.giadien = cd.Gia;
                }
                foreach (var cn in chunuoc)
                {
                    ViewBag.gianuoc = cn.Gia;
                }
                return View(hoadon);
            }
            return View();

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý điện nước")
            {
                var chudien = new HoaDonDienNuocDao().ChuDien();
                var chunuoc = new HoaDonDienNuocDao().ChuNuoc();
                if (chudien != null && chunuoc != null)
                {
                    foreach (var cd in chudien)
                    {
                        ViewBag.giadien = cd.Gia;
                    }
                    foreach (var cn in chunuoc)
                    {
                        ViewBag.gianuoc = cn.Gia;
                    }

                    var phong = new PhongDao().Danhsachphong();
                    if (phong != null)
                    {
                        ViewBag.Phong = new SelectList(phong, "MaPhong", "MaPhong");
                    }

                }
                var hoadon = new HoaDonDienNuocDao().TimHoaDon(id);
                return View(hoadon);
            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền tính tiền điện nước !");
                return View("Index");
            }
        }
        [HttpPost]
        public ActionResult Edit(HoaDonDienNuoc hoadon)
        {
           

            if (hoadon.ChiSoDienCuoi < hoadon.ChiSoDienDau)
            {
                SetAlert("Chỉ số điện cuối phải lớn hơn số điện đầu ! ", "error");
                return RedirectToAction("DanhSachDienNuoc", "DienNuoc");
            }
            if (hoadon.ChiSoNuocuoi < hoadon.ChiSoNuocDau)
            {
                SetAlert("Chỉ số nước cuối phải lớn hơn số nước đầu ! ", "error");
                return RedirectToAction("DanhSachDienNuoc", "DienNuoc");
            }
            var maquyenhan = (string)Session["MAQUYENHAN"];
            var manhanvien = (long)Session["MANHANVIEN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý điện nước")
            {

                var result = new HoaDonDienNuocDao().Edit(hoadon,manhanvien);
                if (result==true)
                {
                    SetAlert("Sửa hóa đơn thành công ! ", "error");
                    return RedirectToAction("DanhSachDienNuoc", "DienNuoc");
                }
                else
                {
                    SetAlert("Sửa hóa đơn thất bại ! ", "error");
                    return RedirectToAction("DanhSachDienNuoc", "DienNuoc");

                }

            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền tính tiền điện nước !");

                return View("Index");
            }
        }
        [HttpGet]
        public ActionResult TinhTien()
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý điện nước")
            {
                var chudien = new HoaDonDienNuocDao().ChuDien();
                var chunuoc = new HoaDonDienNuocDao().ChuNuoc();
                if (chudien != null && chunuoc != null)
                {
                    foreach (var cd in chudien)
                    {
                        ViewBag.giadien = cd.Gia;
                    }
                    foreach (var cn in chunuoc)
                    {
                        ViewBag.gianuoc = cn.Gia;
                    }

                    var phong = new PhongDao().Danhsachphong();
                    if (phong != null)
                    {
                        ViewBag.Phong = new SelectList(phong, "MaPhong", "MaPhong");
                    }

                }

                return View();

            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền tính tiền điện nước !");
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult TinhTien(HoaDonDienNuoc hoadon, FormCollection col)
        {
            int thang = DateTime.Now.Month ;
            int nam = DateTime.Now.Year;
            int kq = db.HoaDonDienNuocs.Where(x => x.MaPhong == hoadon.MaPhong&&x.NgayLap.Value.Month==thang&&x.NgayLap.Value.Year==nam).Count();
            if(kq>0)
            {
                SetAlert("Phòng này đã được lập hóa đơn trong tháng này rồi ! Vui lòng kiểm tra lại !", "error");
                return RedirectToAction("TinhTien", "DienNuoc");
            }

            if(hoadon.ChiSoDienCuoi< int.Parse(col["giadiendau"]?.ToString()))
            {
                SetAlert("Chỉ số điện cuối phải lớn hơn số điện đầu ! ", "error");
                return RedirectToAction("TinhTien", "DienNuoc");
            }
            if (hoadon.ChiSoNuocuoi < int.Parse(col["gianuocdau"]?.ToString()))
            {
                SetAlert("Chỉ số nước cuối phải lớn hơn số nước đầu ! ", "error");
                return RedirectToAction("TinhTien", "DienNuoc");
            }

            var maquyenhan = (string)Session["MAQUYENHAN"];
            var manhanvien = (long)Session["MANHANVIEN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý điện nước")
            {

                var result = new HoaDonDienNuocDao().TinhTien(hoadon, manhanvien, col);
                if(result>0)
                {
                    SetAlert("Tạo hóa đơn thành công ! ", "error");
                    return RedirectToAction("DanhSachDienNuoc", "DienNuoc");
                }
                else
                {
                    SetAlert("Tạo hóa đơn thất bại ! ", "error");
                    return RedirectToAction("DanhSachDienNuoc", "DienNuoc");

                }

            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền tính tiền điện nước !");

                return View("Index");
            }
        }
        [HttpGet]
        public ActionResult SuaDien(int id)
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý điện nước")
            {
                var dien = new HoaDonDienNuocDao().TimDien(id);

                return View(dien);

            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền sửa giá điện  !");
                return View("Index");
            }
        }
        [HttpPost]
        public ActionResult SuaDien(Dien dien)
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý điện nước")
            {
                var giadien = new HoaDonDienNuocDao().Editd(dien);
                if (giadien == true)
                {
                    SetAlert("Sửa thành công ! ", "error");
                    return View();
                }

                return View(dien);

            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền tính tiền điện nước !");
                return View("Index");
            }
        }
        [HttpGet]
        public ActionResult SuaNuoc(int id)
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý điện nước")
            {
                var nuoc = new HoaDonDienNuocDao().TimNuoc(id);

                return View(nuoc);

            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền sửa giá nước !");
                return View("Index");
            }
        }
        [HttpPost]
        public ActionResult SuaNuoc(Nuoc nuoc)
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý điện nước")
            {
                var giadien = new HoaDonDienNuocDao().Editn(nuoc);
                if (giadien == true)
                {
                    SetAlert("Sửa thành công ! ", "error");
                    return View();
                }

                return View(nuoc);

            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền tính tiền điện nước !");

                return View();
            }
        }


    }
}