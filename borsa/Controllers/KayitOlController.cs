using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using borsa.Models.entity;

namespace borsa.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        borsaEntities1 db = new borsaEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KayitOl(string id)
        {
            return View(db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi== id));
        }
        [HttpPost]
        public ActionResult KayitOl(string Adi, string Soyadi, string kullaniciadi, string sifre, string Tel, string tc,string email,string adres)
        {
            Kullanicilar k = new Kullanicilar();
            k.Adi = Adi;
            k.Soyadi = Soyadi;
            k.KullaniciAdi = kullaniciadi;
            k.Sifre = sifre;
            k.Tel = Tel;
            k.Tc = tc;
            k.Adres = adres;
            k.Email = email;
            k.Unvan = false;
            db.Kullanicilar.Add(k);
            db.SaveChanges();
            return Redirect("/");
        }


    }
}