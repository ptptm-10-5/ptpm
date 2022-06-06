using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinHocNgoiSao.Models;
namespace TinHocNgoiSao.Controllers
{
    public class TinHocNgoiSaoController : Controller
    {
        //
        // GET: /Home/
        QL_LinhKienDataContext data = new QL_LinhKienDataContext();
        public ActionResult Home()
        {
            List<THIETBI> dstl = data.THIETBIs.Take(4).ToList();
            return View(dstl);
        }
        public ActionResult HTTENLOAI()
        {
            List<LOAITB> dsL = data.LOAITBs.ToList();
            return PartialView(dsL);
        }
        public ActionResult HTSP(int ml)
        {
            List<THIETBI> dsSP = data.THIETBIs.Where(t => t.MALOAI == ml).ToList();
            ViewBag.lst1 = dsSP;
            return View("Home", dsSP);
        }
        [HttpPost]//bắt buộc có để tìm kiếm
        public ActionResult XuLiTK(FormCollection col)
        {
            string tk = col["txtTuKhoa"].ToString();

            List<THIETBI> dsS = data.THIETBIs.Where(s => s.TENTB.Contains(tk) == true).ToList();

            return View("Home", dsS);
        }
        public ActionResult ChiTietSP(int id)
        {
            THIETBI s = data.THIETBIs.FirstOrDefault(t => t.MATB == id);

            return View(s);
        }
        [HttpGet]
        public ActionResult DangNhap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult XLDN(FormCollection co)
        {
            string ten = co["txtTendn"];
            string matkhau = co["txtPass"];
            TKKH kh = data.TKKHs.SingleOrDefault(k => k.TaiKhoan == ten && k.MaKhau == matkhau);
            if (kh == null)
            {
                return View();
            }

            Session["khachhang"] = kh;
            return RedirectToAction("Home", "TinHocNgoiSao");
        }
        public ActionResult DangXuat()
        {
            Session["khachhang"] = null;
            return RedirectToAction("Home", "TinHocNgoiSao");
        }
        public ActionResult XemGioHang()
        {
            GioHang gh = (GioHang)Session["gh"];
            return View(gh);
        }
    }
}
   