using BonusMvcStock.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BonusMvcStock.Controllers
{
    public class KategoriController : Controller
    {
		// GET: Kategori
		DbMvcStockEntities db = new DbMvcStockEntities();/*nesne turetıp ıcındekılere ulastık*/
		public ActionResult Index()
        {
            var kategoriler = db.Kategoriler.ToList();/*kategorıler tablosundakı verılerı lısteler*/
			return View(kategoriler);
        }
		[HttpGet]/*sayfa yucelenırken ılk calısan metot*/
		public ActionResult YeniKategori()
		{
			return View();
		}
		[HttpPost]/*sayfa yucelendıktın sonra calısan metot*/
		public ActionResult YeniKategori(Kategoriler kategoriler)
		{
			db.Kategoriler.Add(kategoriler);/*kategorıler tablosuna yenı bır kategori ekler*/
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult KategoriSil(int id)
		{
			var kategori = db.Kategoriler.Find(id);/*kategorı tablosunda ıd degerıne gore arama yapar*/
			db.Kategoriler.Remove(kategori);/*bulunan kategorıyı sıler*/
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult KategoriGüncelle(int id)
		{
			var kategori = db.Kategoriler.Find(id);/*kategorı tablosunda ıd degerıne gore arama yapar*/
			return RedirectToAction("Index");
		}
	}
}