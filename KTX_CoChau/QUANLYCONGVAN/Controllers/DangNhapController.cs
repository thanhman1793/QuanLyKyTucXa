
using Eoffice.Common;

using Models.Dao;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EntityFramework;

namespace Eoffice.Controllers
{
    public class DangNhapController : Controller
    {
        //
        KtxDbContext _db = new KtxDbContext();
        // GET: /TaiKhoan/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dangxuat()
        {
            Session[CommonConstants.CANBO_SESSION] = null;
            return RedirectToAction("DangNhap","Dangnhap");
        }


        public ActionResult DangNhap(QuanLyKyTucXa.Models.DangNhapModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new NhanVienDao();
                var result = dao.DangNhap(model.TaiKhoan,model.MatKhau);
                var login = new CanBoLogin();
                if (result)
                {
                    var taikhoan = dao.GetById(model.TaiKhoan);
                    login.MaCanBo = taikhoan.STT;
                    //login.TaiKhoan = taikhoan.TaiKhoan;
                    Session["MANHANVIEN"] = taikhoan.STT;
                    Session["TENNHANVIEN"] = taikhoan.Ten;
                    Session["MAQUYENHAN"] = taikhoan.ChucVu;
                    Session["HINHANH"] = taikhoan.HinhAnh;
                    Session.Add(Common.CommonConstants.CANBO_SESSION, login.MaCanBo);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("message", "Vui lòng kiểm tra lại tài khoản hoặc mật khẩu !");
                }
            }
            return View("Index");
        }
    }
}