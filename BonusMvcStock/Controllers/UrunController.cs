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
			//var urunler = db.urunler.Include("Kategoriler").ToList();
			var urunler = db.Urunler.ToList();/*urunler tablosundakı verılerı lısteler*/
			return View(urunler);
        }
        [HttpGet]/*sayfa yucelenırken ılk calısan metot*/
        public ActionResult YeniUrun()
        {
            return View();
		}
        [HttpPost]
		public ActionResult YeniUrun(Urunler urunler)/*parametreli metod*/
		{
			db.Urunler.Add(urunler);/*urunler tablosuna yenı bır urun ekler*/
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}