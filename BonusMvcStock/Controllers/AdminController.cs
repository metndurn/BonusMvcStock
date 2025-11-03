using BonusMvcStock.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BonusMvcStock.Controllers
{
	public class AdminController : Controller
	{
		// GET: Admin
		DbMvcStockEntities db = new DbMvcStockEntities();/*nesne turetıp ıcındekılere ulastık*/
		public ActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public ActionResult YeniAdmin()
		{
			return View();
		}
		[HttpPost]
		public ActionResult YeniAdmin(Admin admin)
		{
			db.Admin.Add(admin);/*admin tablosuna yenı bır admin ekler*/
			db.SaveChanges();
			return RedirectToAction("Index");

			//var admn = db.Admin.FirstOrDefault(x => x.Kullanici == admin.Kullanici && x.Sifre == admin.Sifre);
			//if (admn != null)
			//{
			//	Session["Kullanici"] = admn.Kullanici.ToString();
			//	return RedirectToAction("Index", "Urun");
			//}
			//else
			//{
			//	return RedirectToAction("YeniAdmin", "Admin");
			//}
		}
	}
}