using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using borsa.Models.entity;


namespace borsa.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        borsaEntities1 db = new borsaEntities1();
        public ActionResult Index()
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            var deger = db.Para.Where(x=>x.ParaOnay==false).ToList();
            var urunler = db.Item.Where(x => x.ItemOnay == false).ToList();
            ViewBag.Urunler = urunler;
            return View(deger);
        }
        
    }
}