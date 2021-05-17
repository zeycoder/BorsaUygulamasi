using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using borsa.Models.entity;

namespace borsa.Controllers
{
    public class UrunSatinAlController : Controller
    {
        // GET: UrunSatinAl
        borsaEntities1 db = new borsaEntities1();
        public ActionResult Index()
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");

            }
            var asd = db.Item.Where(x => x.ItemOnay == true).ToList();
            ViewBag.Deneme = asd;
            return View();
        }

        public ActionResult SatinAl(/*string UrunAdi, string UrunMiktar*/ int UrunMiktar)
        {
            //Item ki = new Item();
            //ki.KullaniciId = Convert.ToInt32(Session["KullaniciId"]);
            //ki.ItemAdi = UrunAdi;
            //ki.ItemMiktari -= UrunMiktar;
            //db.Item.Add(ki);
            //db.SaveChanges();
            //return Redirect("/");

            Item a = new Item();
            a.ItemMiktari = a.ItemMiktari - UrunMiktar;
            db.Item.Add(a);
            db.SaveChanges();
            return Redirect("/");
        }
    }
}