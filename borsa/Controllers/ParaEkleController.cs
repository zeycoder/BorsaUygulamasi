using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using borsa.Models.entity;

namespace borsa.Controllers
{
    public class ParaEkleController : Controller
    {
        // GET: ParaEkle
        borsaEntities1 db = new borsaEntities1();
        public ActionResult Index()
        {
            if (Session["KullaniciId"]==null)
            {
                return RedirectToAction("Index","GirisYap");
            }
            return View();
        }
        [HttpPost]
        public ActionResult ParaEkle(decimal ParaMiktar)
        {
            Para p = new Para();

            p.KullaniciId = Convert.ToInt32(Session["KullaniciId"]);
            p.ParaMiktar = ParaMiktar;
            p.ParaOnay = false;
            db.Para.Add(p);
            db.SaveChanges();
            return Redirect("/");
        }
        public ActionResult ONAYLA(int id)
        {
            var guncel = db.Para.Find(id);
            guncel.ParaOnay = true;
            db.SaveChanges();
            return Redirect("/");
        }
        public ActionResult ParaSil(int id)
        {
            var par = db.Para.Find(id);
            db.Para.Remove(par);
            db.SaveChanges();
            return Redirect("/");
        }


    }
}