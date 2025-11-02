using BonusMvcStock.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BonusMvcStock.Controllers
{
    public class MusterilerController : Controller
    {
		// GET: Musteriler
		DbMvcStockEntities db = new DbMvcStockEntities();/*nesne turetıp ıcındekılere ulastık*/
		public ActionResult Index(int mussayfa = 1)
        {
			/*sayfalama islemi yapıldı*/
            //var musteriler = db.Musteriler.ToList();
            var musteriler = db.Musteriler.ToList().ToPagedList(mussayfa, 10);//sayfalama burada var
			return View(musteriler);
        }
        [HttpGet]
		public ActionResult YeniMusteri()
		{
			return View();
		}
		[HttpPost]
		public ActionResult YeniMusteri(Musteriler musteriler)
		{
			db.Musteriler.Add(musteriler);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult MusteriSil(int id)
		{
			var musteriler = db.Musteriler.Find(id);/*musteri tablosunda ıd degerıne gore arama yapar*/
			db.Musteriler.Remove(musteriler);/*bulunan musterileri sıler*/
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult MusteriGetir(int id)
		{
			var musteri = db.Musteriler.Find(id);/*kategorı tablosunda ıd degerıne gore arama yapar*/
			return View("MusteriGetir", musteri);
		}
		public ActionResult MusteriGuncelle(Musteriler musteriler)/*parametreli metod*/
		{
			var musteri = db.Musteriler.Find(musteriler.Id);/*kategorı tablosunda ıd degerıne gore arama yapar*/
			musteri.MusteriAd = musteriler.MusteriAd;/*gelen degerı gunceller*/
			musteri.MusteriSoyad = musteriler.MusteriSoyad;
			musteri.MusteriSehir = musteriler.MusteriSehir;
			musteri.MusteriBakiye = musteriler.MusteriBakiye;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}