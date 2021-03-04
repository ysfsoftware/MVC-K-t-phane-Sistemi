using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models.Entity;
using System.Web.Security;

namespace MVCKUTUPHANE.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        MvcDbKutuphaneEntities db = new MvcDbKutuphaneEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUYE p)
        {
            var bilgiler = db.TBLUYE.FirstOrDefault(x=>x.MAIL == p.MAIL && x.SIFRE==p.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                return RedirectToAction("Index","Panelim");
            }
            else {
                return View();
            }
        }
    }
}