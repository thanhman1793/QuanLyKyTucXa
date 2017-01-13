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
    public class QLPhongController : BaseController
    {
        KtxDbContext db = new KtxDbContext();
        // GET: QLPhong
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DemPhong()
        {
            var kq = new PhongDao().EditIsread();
            return View();
        }
        [HttpGet]
        public ActionResult ThemLoaiPhong()
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];

            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý phòng")
            {

                return View();

            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền thêm phòng !");

                return View("Index");
            }

        }
        public ActionResult Thongkephong()
        {
             string thamso = Request.QueryString["tinhhinh"];
            var dao = new PhongDao();
            var listphong = dao.ThongKePhong(thamso);
            return View(listphong);

        }
        public ActionResult Delete(int id)
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];

            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý phòng")
            {

                string result = "Xóa thất bại!";
                var ketqua = new PhongDao().Delete(id);

                if (ketqua == 1)
                {
                    SetAlert("Xóa thành công ! ", "error");
                    return RedirectToAction("DanhSachPhong", "QLphong");
                }
                if (ketqua == 2)
                {
                    SetAlert("Phòng này đang có sinh viên ở ! vui lòng chuyển sinh viên đi phòng khác ", "error");
                    return RedirectToAction("DanhSachPhong", "QLphong");

                }
                return Json(result);

            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền xóa phòng  !");
                SetAlert("Bạn không có quyền xóa phòng  !", "error");
                return RedirectToAction("DanhSachPhong", "QLphong");
            }
           
        }

        public ActionResult TimGiaPhong(string maloaiphong)
        {
            var malp = maloaiphong.Trim();
            var dao = new LoaiPhongDao();
            var loaiphong = dao.timloaiphong(malp);
            if (loaiphong != null)
            {
                return Json(loaiphong, JsonRequestBehavior.AllowGet);
            }
            else return View();
        }
        public ActionResult TimMaloaiPhong(string maphong)
        {
            var dao = new LoaiPhongDao();
            var maloaiphong = dao.timmaloaiphong(maphong);
            if (maloaiphong != null)
            {
                return Json(maloaiphong, JsonRequestBehavior.AllowGet);
            }
            else return View();
        }

        [HttpGet]
        public ActionResult ThemPhong()
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];

            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý phòng")
            {
                var phong = new LoaiPhongDao().danhsachloaiphong();
                if (phong != null)
                {
                    ViewBag.LoaiPhong = new SelectList(phong, "MaLoaiPhong", "TenLoaiPhong");
                }

                return View();

            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền thêm phòng !");

                return View("Index");
            }

        }
        [HttpPost]
        public ActionResult ThemPhong(Phong entity)
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];
            var manhanvien = (long)Session["MANHANVIEN"];
            var phong1 = new PhongDao().Danhsachphong();
            foreach (var maphong in phong1)
            {
                if (entity.MaPhong == maphong.MaPhong)
                {
                    SetAlert("Mã phòng đã có ! ", "error");
                    return RedirectToAction("DanhSachPhong", "QLphong");
                }
            }
            if (maquyenhan == "Giám Đốc" || maquyenhan == "Nhân viên quản lý phòng")
            {
                if (ModelState.IsValid)
                {
                    var dao = new PhongDao();
                    long id = dao.Insert(entity, manhanvien);
                    if (id > 0)
                    {
                        SetAlert("Thêm phòng mới thành công ! ", "error");
                        return RedirectToAction("DanhSachPhong", "QLPhong");
                    }

                }
                else
                {
                    SetAlert("Thêm phòng thất bại !", "error");
                    ModelState.AddModelError("", "Thêm phòng thất bại");
                }
            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền thêm phòng !");
                return View("Index");
            }
            return View();

        }
        public ActionResult Danhsachphong()
        {
            var dao = new PhongDao();
            var listphong = dao.Danhsachphong();
            return View(listphong);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var phong = new PhongDao().Timphong(id);// chắc chắn có  id 

            var maquyenhan = (string)Session["MAQUYENHAN"];
            if (maquyenhan == "Nhân viên quản lý phòng" || maquyenhan == "Giám Đốc")
            {
                var phong1 = new LoaiPhongDao().danhsachloaiphong();
                if (phong1 != null)
                {
                    ViewBag.LoaiPhong1 = new SelectList(phong1, "MaLoaiPhong", "TenLoaiPhong");
                }
                return View(phong);
            }
            else
            {
                SetAlert("Bạn không phải nhân viên quản lý phòng !", "error");
                return RedirectToAction("DanhSachPhong", "QLphong");

                return View("Index");
            }


        }
        [HttpPost]
        public ActionResult Edit(Phong phong, FormCollection col)
        {

            var maquyenhan = (string)Session["MAQUYENHAN"];
            var macanbo = (long)Session["MANHANVIEN"];
           
            if (maquyenhan == "Nhân viên quản lý phòng" || maquyenhan == "Giám Đốc")
            {
                string maphongtruoc = db.Phongs.SingleOrDefault(x => x.STT == phong.STT).MaPhong;
                string maphong = phong.MaPhong;
                if (maphongtruoc != maphong)
                {
                    int kq1 = db.Phongs.Where(x => x.MaPhong == maphong).Count();
                    int kq2 = 1 + kq1;
                    if (kq2 > 1)
                    {
                        SetAlert("Mã phòng đã tồn tại ! ", "error");
                        return RedirectToAction("DanhSachPhong", "QLphong");
                    }
                }
                var sogiuong = phong.SoGiuong;
                var sosvhientai = new PhongDao().DemsoSV(phong.STT);
                if(sosvhientai>sogiuong)
                {
                    SetAlert(" Sửa thất bại vì Phòng này đang có số sinh viên nhiều hơn số giường ! ", "error");
                    return RedirectToAction("DanhSachPhong", "QLphong");
                }
                var result = new PhongDao().Edit(phong, macanbo, col);
                if (result == true)
                {
                    SetAlert("Sửa thành công ! ", "error");
                    return RedirectToAction("DanhSachPhong","QLphong");
                }
                else return View();
            }
             else 
            {
                SetAlert("Bạn không phải nhân viên quản lý phòng !", "error");
                ModelState.AddModelError("", "sửa nhân viên thất bại");

                return View("Index");
            }
            
        }
    }
}