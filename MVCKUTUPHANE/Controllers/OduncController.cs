using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using MVCKUTUPHANE.Models.Entity;

namespace MVCKUTUPHANE.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        MvcDbKutuphaneEntities db = new MvcDbKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> Deger1 =(from x in db.TBLUYE.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.AD +" "+ x.SOYAD,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.dgr1 = Deger1;

            List<SelectListItem> Deger2 = (from y in db.TBLKITAP.Where(x=>x.DURUM==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.AD,
                                               Value = y.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = Deger2;

            List<SelectListItem> Deger3 = (from z in db.TBLPERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.PERSONEL,
                                               Value = z.ID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = Deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            var d1 = db.TBLUYE.Where(x => x.ID == p.TBLUYE.ID).FirstOrDefault();
            var d2 = db.TBLKITAP.Where(y => y.ID == p.TBLKITAP.ID).FirstOrDefault();
            var d3 = db.TBLPERSONEL.Where(z => z.ID == p.TBLPERSONEL.ID).FirstOrDefault();
            p.TBLUYE = d1;
            p.TBLKITAP = d2;
            p.TBLPERSONEL = d3;
            db.TBLHAREKET.Add(p);
            MessageBox.Show("Ödünç Verme İşlemi Tamamlandı!", "Bilgilendirme Penceresi");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OduncIade(TBLHAREKET p)
        {
            var odn = db.TBLHAREKET.Find(p.ID);
            DateTime d1 = DateTime.Parse(odn.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("OduncIade", odn);
        }
        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var hrk = db.TBLHAREKET.Find(p.ID);
            hrk.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hrk.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}