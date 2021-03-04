using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using MVCKUTUPHANE.Models.Entity;


namespace MVCKUTUPHANE.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbKutuphaneEntities db = new MvcDbKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORI.Where(x=>x.DURUM==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();      
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORI p)
        {
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Tamamlandı!", "Bilgilendirme Penceresi");
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir",ktg);
        }
        public ActionResult KategoriGuncelle(TBLKATEGORI p)
        {
            var ktg = db.TBLKATEGORI.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}