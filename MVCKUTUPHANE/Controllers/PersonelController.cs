using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using MVCKUTUPHANE.Models.Entity;

namespace MVCKUTUPHANE.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        MvcDbKutuphaneEntities db = new MvcDbKutuphaneEntities();
        public ActionResult Index()
        {
            var personel = db.TBLPERSONEL.ToList();
            return View(personel);
        }
        [HttpGet]
        public ActionResult YeniPersonel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniPersonel(TBLPERSONEL p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniPersonel");
            }
            db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Tamamlandı!", "Bilgilendirme Penceresi");
            return View();
        }
        public ActionResult Sil(int id)
        {
            var personel = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TBLPERSONEL.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            var prs = db.TBLPERSONEL.Find(p.ID);
            prs.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}