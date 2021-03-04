using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
using MVCKUTUPHANE.Models.Sınıflarım;

namespace MVCKUTUPHANE.Controllers
{
    [AllowAnonymous]
    public class VitrinController : Controller
    {
        // GET: Vitrin
        MvcDbKutuphaneEntities db = new MvcDbKutuphaneEntities();
         [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBLKITAP.ToList();
            cs.Deger2 = db.TBLHAKKİMİZDA.ToList();
            //var degerler = db.TBLKITAP.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLİLETİSİM t)
        {
            db.TBLİLETİSİM.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}