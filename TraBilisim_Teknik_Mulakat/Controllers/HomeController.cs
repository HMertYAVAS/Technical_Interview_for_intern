using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraBilisim_Teknik_Mulakat.Models;

namespace TraBilisim_Teknik_Mulakat.Controllers
{
    public class HomeController : Controller
    {
        //salt okunması için readonly
        private readonly TRABILISIMEntities1 db;
        public HomeController(){
        db = new TRABILISIMEntities1();
    }
    public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SarkiKaydet(Muzik muzik)
        {
            if (ModelState.IsValid) { 
            db.Muziks.Add(muzik);
                //kayıt işlemi
            db.SaveChanges();
            return Content("Başarılı");
            }
            else
                return Content("Başarısız");

        }

        [HttpGet]
        public JsonResult SarkiListele()
        {
            return Json(db.Muziks.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SarkiSil(int id)
        {
                var muzik = db.Muziks.Where(x => x.Id == id).FirstOrDefault();
                if (muzik != null)
                {
                    db.Entry(muzik).State = EntityState.Deleted;
                    db.SaveChanges();  
                    return Content("Silindi.");
                }
            return Content("Silinemedi.");
        }
    }
}
