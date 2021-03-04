using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;

namespace MVCKUTUPHANE.Controllers
{
    [AllowAnonymous]
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        MvcDbKutuphaneEntities db = new MvcDbKutuphaneEntities();

        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TBLUYE p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBLUYE.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}