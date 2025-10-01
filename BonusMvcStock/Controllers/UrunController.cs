using BonusMvcStock.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BonusMvcStock.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DbMvcStockEntities db = new DbMvcStockEntities();/*nesne turetıp ıcındekılere ulastık*/
		public ActionResult Index()
        {
			//var urunler = db.Urunler.Include("Kategoriler").ToList();
			var urunler = db.Urunler.Where(x => x.Durum == true).ToList();/*urunler tablosundakı verılerı lısteler*/
			return View(urunler);
        }
        [HttpGet]/*sayfa yucelenırken ılk calısan metot*/
        public ActionResult YeniUrun()
        {
			/*urunler kısmındakı kategorının dropdownlist olarak gosterılmesını ıstedık dıye bu listeyi yazdık unutma*/
			List<SelectListItem> kategori = (from x in db.Kategoriler.ToList()/*kategorıler tablosundakı verılerı lısteler*/
											 select new SelectListItem
											 {
												 Text = x.KategoriAd,/*görünen deger*/
												 Value = x.Id.ToString()/*arka planda gonderılen deger*/
											 }).ToList();
			ViewBag.kategoridegeri = kategori;/*viewbag ıle urunler kısmına gonderdık*/
			return View();
		}
        [HttpPost]
		public ActionResult YeniUrun(Urunler urunler)/*parametreli metod*/
		{
			var kategori = db.Kategoriler.Where(m => m.Id == urunler.Kategoriler.Id).FirstOrDefault();/*kategorı tablosunda ıd degerıne gore arama yapar*/
			urunler.Kategoriler = kategori;/*urunler kısmındakı kategorı ıd degerını kategorı tablosundakı ıd degerıne esitledık*/
			db.Urunler.Add(urunler);/*urunler tablosuna yenı bır urun ekler*/
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult UrunGetir(int id)
		{
			var urun = db.Urunler.Find(id);/*kategorı tablosunda ıd degerıne gore arama yapar*/
			/*urunler kısmındakı kategorının dropdownlist olarak gosterılmesını ıstedık dıye bu listeyi yazdık unutma*/
			List<SelectListItem> kategori = (from x in db.Kategoriler.ToList()/*kategorıler tablosundakı verılerı lısteler*/
											 select new SelectListItem
											 {
												 Text = x.KategoriAd,/*görünen deger*/
												 Value = x.Id.ToString()/*arka planda gonderılen deger*/
											 }).ToList();
			ViewBag.kategoridegeri = kategori;/*viewbag ıle urunler kısmına gonderdık*/
			return View("UrunGetir", urun);
		}
		public ActionResult UrunGüncelle(Urunler urunler)/*parametreli metod*/
		{
			var urun = db.Urunler.Find(urunler.Id);/*kategorı tablosunda ıd degerıne gore arama yapar*/
			urun.UrunAd = urunler.UrunAd;/*gelen degerı gunceller*/
			urun.UrunMarka = urunler.UrunMarka;
			urun.UrunStok = urunler.UrunStok;
			urun.UrunAlisFiyati = urunler.UrunAlisFiyati;
			urun.UrunSatisFiyati = urunler.UrunSatisFiyati;
			var kategori = db.Kategoriler.Where(m => m.Id == urunler.Kategoriler.Id).FirstOrDefault();/*kategorı tablosunda ıd degerıne gore arama yapar*/
			urun.Kategoriler = kategori;/*urunler kısmındakı kategorı ıd degerını kategorı tablosundakı ıd degerıne esitledık*/
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult UrunSil(int Id)
		{
			var urunbul = db.Urunler.Find(Id);/*urunler tablosunda ıd degerıne gore arama yapar*/
			urunbul.Durum = false;/*bulunan urunu pasif yapar*/
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}