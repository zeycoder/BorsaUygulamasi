using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using borsa.Models.entity;

namespace borsa.Controllers
{
    public class ItemAddController : Controller
    {
        // GET: ItemAdd
        borsaEntities1 db = new borsaEntities1();
        public ActionResult Index()
        {
            if (Session["KullaniciId"] == null)
            {
                return RedirectToAction("Index", "GirisYap");
            }
            return View();
        }
        [HttpPost]
        public ActionResult ItemAdd(string ItemAdi, int ItemMiktari, decimal Fiyat)
        {
            Item u = new Item();
            u.ItemAdi = ItemAdi;
            u.ItemMiktari = ItemMiktari;
            u.Fiyat = Fiyat;
            u.KullaniciId = Convert.ToInt32(Session["KullaniciId"]);
            u.ItemOnay = false;
            db.Item.Add(u);
            db.SaveChanges();
            return Redirect("/");
        }

        public ActionResult SIL(int id)
        {
            var urn = db.Item.Find(id);
            db.Item.Remove(urn);
            db.SaveChanges();
            return Redirect("/");
        }

        public ActionResult UrunOnay(int UrunId)
        {
            var guncel = db.Item.Find(UrunId);
            guncel.ItemOnay = true;
            db.SaveChanges();
            return Redirect("/");
        }

        public ActionResult ONAYLA(int id)
        {
            var guncel = db.Item.Find(id);
            guncel.ItemOnay = true;
            db.SaveChanges();
            return Redirect("/");
        }

    }
}