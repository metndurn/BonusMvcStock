using BonusMvcStock.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BonusMvcStock.Controllers
{
    public class SatislarController : Controller
    {
		// GET: Satislar
		DbMvcStockEntities db = new DbMvcStockEntities();/*nesne turetıp ıcındekılere ulastık*/
		public ActionResult Index(int satsayfa = 1)
        {
			//var satislar = db.Satislar.ToList();
			var satislar = db.Satislar.ToList().ToPagedList(satsayfa, 10);//sayfalama burada var
			return View(satislar);
        }
		[HttpGet]
		public ActionResult YeniSatis()
		{
			/*urunler kısmındakı kategorının dropdownlist olarak gosterılmesını ıstedık dıye bu listeyi yazdık unutma*/
			List<SelectListItem> urun = (from x in db.Urunler.ToList()/*kategorıler tablosundakı verılerı lısteler*/
											 select new SelectListItem
											 {
												 Text = x.UrunAd,/*görünen deger*/
												 Value = x.Id.ToString()/*arka planda gonderılen deger*/
											 }).ToList();
			ViewBag.urundegeri = urun;/*viewbag ıle urunler kısmına gonderdık*/

			/*personel kısmı*/
			List<SelectListItem> personel = (from x in db.Personeller.ToList()
										 select new SelectListItem
										 {
											 Text = x.PersonalAd + " " + x.PersonalSoyad,
											 Value = x.Id.ToString()
										 }).ToList();
			ViewBag.personeldegeri = personel;

			/*musteri kısmı*/
			List<SelectListItem> musteri = (from x in db.Musteriler.ToList()
										 select new SelectListItem
										 {
											 Text = x.MusteriAd + " " + x.MusteriSoyad,
											 Value = x.Id.ToString()
										 }).ToList();
			ViewBag.musteridegeri = musteri;

			return View();
		}
		[HttpPost]
		public ActionResult YeniSatis(Satislar satislar)
		{
			var urun = db.Urunler.Where(m => m.Id == satislar.Urunler.Id).FirstOrDefault();
			var musteri = db.Musteriler.Where(m => m.Id == satislar.Musteriler.Id).FirstOrDefault();
			var personel = db.Personeller.Where(m => m.Id == satislar.Personeller.Id).FirstOrDefault();
			satislar.Urunler = urun;
			satislar.Musteriler = musteri;
			satislar.Personeller = personel;
			satislar.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
			db.Satislar.Add(satislar);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}