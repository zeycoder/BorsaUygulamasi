using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using borsa.Models.entity;

namespace borsa.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        borsaEntities1 db = new borsaEntities1();
        public ActionResult Index()
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            int KullaniciId = Convert.ToInt32(Session["KullaniciId"]);
            var deger = db.Para.Where(x => x.ParaOnay == true && x.KullaniciId ==KullaniciId).ToList();
            var urunler = db.Item.Where(x => x.ItemOnay == true && x.KullaniciId == KullaniciId).ToList();
            
            ViewBag.Urunler = urunler;
            return View(deger);
        }
        
    }
}