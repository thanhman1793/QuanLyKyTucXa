using Models.EntityFramework;
using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eoffice.Controllers;

namespace QUANLYCONGVAN.Controllers
{
    public class NhanVienController : BaseController
    {
        KtxDbContext db = new KtxDbContext();
        // GET: NhanVien
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanhSachNhanVien()
        {
            ViewBag.ketqua = "không có nhân viên nào ! ";
            var data = new NhanVienDao().DanhSachNhanVien();
            if(data!=null)
            {
                return View(data);
            }
            else
            {
                return ViewBag.ketqua;
            }
            
        }
        [HttpGet]
        public ActionResult ThemNhanVien( )
        {
            var maquyenhan = (string)Session["MAQUYENHAN"];
          
            if (maquyenhan == "Giám Đốc")
            {
               
                return View();

            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền thêm nhân viên !");

                return View("Index");
            }

        }
        [HttpPost]
        public ActionResult ThemNhanVien(NhanVienn cv)

        {
            string tk = cv.TaiKhoan;
            int kq = db.NhanVienns.Where(x => x.TaiKhoan == tk).Count();
            if (kq>0)
            {
                SetAlert("Tên tài khoản đã tồn tại ! ", "error");
                return RedirectToAction("ThemNhanvien", "NhanVien");
            }
            if(cv.NgaySinh.Value.Year>1999 ||cv.NgaySinh.Value.Year<1800)
            {
                SetAlert(" Năm sinh tầm bậy rồi =)))) Vui lòng kiểm tra lại năm sinh ! ", "error");
                return RedirectToAction("DanhSachNhanVien", "NhanVien");
            }
            var maquyenhan = (string)Session["MAQUYENHAN"];
            if (maquyenhan == "Giám Đốc")
            {
                if (ModelState.IsValid)
                {
                    var dao = new NhanVienDao();
                    long id = dao.Insert(cv);
                    if (id > 0)
                    {
                        SetAlert("Thêm nhân viên thành công ! ", "error");
                        return RedirectToAction("DanhSachNhanVien", "NhanVien");
                    }



                }
                else
                {
                    SetAlert("Thêm nhân viên thất bại !", "error");
                    ModelState.AddModelError("", "Thêm nhân viên thất bại");
                }

            }
            else
            {
                ModelState.AddModelError("message", "Bạn không có quyền thêm nhân viên !");
                SetAlert("Bạn không có quyền thêm nhân viên !", "error");
                return RedirectToAction("Index","Index");
            }
            
            return RedirectToAction("DanhSachNhanVien", "NhanVien");
        }
        public ActionResult Delete(int id)
        {
            string result = "Xóa thất bại!";
            var maquyenhan = (string)Session["MAQUYENHAN"];
            if(maquyenhan=="Giám Đốc")
            {
             
                if (new NhanVienDao().Delete(id)==true)
                {
                    SetAlert("Xóa thành công!", "error");
                    return RedirectToAction("DanhSachSinhVien", "QLSinhVien");
                }
                return Json(result);
            }
            else
            {


                SetAlert("bạn không phải là quản trị viên hoặc nhân viên quản lý sinh viên !", "error");

                return RedirectToAction("DanhSachSinhVien", "NhanVien");
            }
            return Json(result);
           
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var nhanvien = new NhanVienDao().Timnhanvien(id);// chắc chắn có  id 

            var maquyenhan = (string)Session["MAQUYENHAN"]; 
            if (maquyenhan =="Giám Đốc")
            {
                
                return View(nhanvien);
            }
            else
            {
                SetAlert("bạn không phải là quản trị viên !", "error");

                return RedirectToAction("DanhSachNhanVien", "NhanVien");
            }


        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NhanVienn nhanvien)
        {
           
            var maquyenhan = (string)Session["MAQUYENHAN"];
            if (maquyenhan =="Giám Đốc")
            {
                string tentktruoc = db.NhanVienns.SingleOrDefault(x => x.STT == nhanvien.STT).TaiKhoan;
                string tk = nhanvien.TaiKhoan;
                if(tentktruoc!=tk)
                {
                    int kq1 = db.NhanVienns.Where(x => x.TaiKhoan == tk).Count();
                    int kq2 = 1 + kq1;
                    if (kq2 > 1)
                    {
                        SetAlert("Tên tài khoản đã tồn tại ! ", "error");
                        return RedirectToAction("DanhSachNhanVien", "NhanVien");
                    }
                }
               
                if (nhanvien.NgaySinh.Value.Year > 1999 || nhanvien.NgaySinh.Value.Year < 1800)
                {
                    SetAlert(" Năm sinh tầm bậy rồi =)))) Vui lòng kiểm tra lại năm sinh ! ", "error");
                    return RedirectToAction("DanhSachNhanVien", "NhanVien");
                }
                //     if (ModelState.IsValid)
                {
                    var dao = new NhanVienDao();

                    {
                        var kq = dao.Edit(nhanvien);
                        if (kq)
                        {
                            SetAlert("Sửa thành công ! ", "error");
                            return RedirectToAction("DanhSachNhanVien", "NhanVien");
                        }
                        else
                        {
                            SetAlert("Sửa thất bại ! ", "error");
                            ModelState.AddModelError("", "sửa thất bại !");
                        }

                    }


                }
            }
            else
            {
                SetAlert("bạn không phải là quản trị viên !", "error");
                ModelState.AddModelError("", "sửa nhân viên thất bại");

                return View();
            }

           return RedirectToAction("DanhSachNhanVien", "NhanVien");

        }
    }
}