using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRMPROJEDB.Models;

namespace CRMPROJEDB.Controllers
{
    public class HomeController : Controller
    {

        crmprojeEntities urunliste = new crmprojeEntities();
        public ActionResult Index()
        {

            if (System.Web.HttpContext.Current.Session["Tbl_Kullanıcı"] == null)
            {
                if (Request.Cookies["RememberMe"] != null)
                {
                    crmprojeEntities db = new crmprojeEntities();
                    string okunan = Request.Cookies["RememberMe"].Value;
                    string email = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(okunan));
                    Tbl_Kullanici tbl_kullanici = db.Tbl_Kullanici.Where(n => n.Email == email).FirstOrDefault();
                    if (tbl_kullanici != null)
                    {
                        System.Web.HttpContext.Current.Session["Tbl_Kullanıcı"] = tbl_kullanici;
                    }
                }
            }

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



    }
}