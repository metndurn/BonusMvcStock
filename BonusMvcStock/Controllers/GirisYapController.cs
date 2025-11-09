using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStock.Models.Entity;
using System.Web.Security;

namespace BonusMvcStock.Controllers
{

    public class GirisYapController : Controller
    {
		// GET: GirisYap
		DbMvcStockEntities db = new DbMvcStockEntities();/*nesne turetıp ıcındekılere ulastık*/
		public ActionResult Login()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Login(Admin admin)
		{
			var bilgiler = db.Admin.Where(x => x.Kullanici == admin.Kullanici && x.Sifre == admin.Sifre).FirstOrDefault();
			if (bilgiler != null)
			{
				FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
				return RedirectToAction("Index", "Musteriler");
			}
			else
			{
				return RedirectToAction("Login", "GirisYap");
			}
		}
		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			return RedirectToAction("Login", "GirisYap");
		}
	}
}