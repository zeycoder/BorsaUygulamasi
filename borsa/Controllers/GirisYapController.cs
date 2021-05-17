using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using borsa.Models.entity;

namespace borsa.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        borsaEntities1 db = new borsaEntities1();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Kullanicilar k)
        {
            var kullanici = db.Kullanicilar.FirstOrDefault(x=>x.KullaniciAdi==k.KullaniciAdi&&x.Sifre==k.Sifre);
            if (kullanici != null)
            {
                
                Session["KullaniciId"] = kullanici.KullaniciId;
                Session["Unvan"] = kullanici.Unvan;
                return RedirectToAction("Index","AnaSayfa");

            }
            else
            {
                return View();
            }
            

        }
        public ActionResult CikisYap()
        {
            Session.Clear();
            return RedirectToAction("Index", "GirisYap");

        }

    }
}