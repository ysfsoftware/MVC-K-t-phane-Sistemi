using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using MVCKUTUPHANE.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCKUTUPHANE.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        MvcDbKutuphaneEntities db = new MvcDbKutuphaneEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var uyeler = db.TBLUYE.ToList();
            var uyeler = db.TBLUYE.ToList().ToPagedList(sayfa,3);
            return View(uyeler);
        }
        [HttpGet]
        public ActionResult YeniUye()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniUye(TBLUYE p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniUye");
            }
            db.TBLUYE.Add(p);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Tamamlandı!", "Bilgilendirme Penceresi");
            return View();
        }
        public ActionResult Sil(int id)
        {
            var uye = db.TBLUYE.Find(id);
            db.TBLUYE.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUYE.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TBLUYE p)
        {
            var uye = db.TBLUYE.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.OKUL = p.OKUL;
            uye.TELEFON = p.TELEFON;
            uye.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGecmis(int id)
        {
            var kitapgecmis = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            var uyekit = db.TBLUYE.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.uye1 = uyekit;
            return View(kitapgecmis);
        }
    }
}