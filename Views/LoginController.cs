using CRMPROJEDB.ActionFilters;
using CRMPROJEDB.Library;
using CRMPROJEDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CRMPROJEDB.Views
{
    [ActionFilters.Authorize]
    public class LoginController : Controller
    {
        private crmprojeEntities db = new crmprojeEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CRMPROJEDB.Library.Login model)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            model.Sifre = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(model.Sifre)));
            Tbl_Kullanici tbl_kullanici = db.Tbl_Kullanici.Where(n => n.Email == model.Email && n.Sifre == model.Sifre).FirstOrDefault();
            if (tbl_kullanici != null)
            {
                System.Web.HttpContext.Current.Session["Tbl_Kullanıcı"] = tbl_kullanici;

                if (model.RememberMe)
                {
                    var cookie = new HttpCookie("RememberMe", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(tbl_kullanici.Email)));
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }

                //FormsAuthentication.SetAuthCookie(tbl_kullanici.Email, tbl_kullanici.RememberMe);
                return Redirect("/");
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı bilgilerinizi lütfen kontrol ediniz!";
            }

            return View();
        }
        public ActionResult LogOut()
        {
            HttpContext.Session.Remove("Tbl_Kullanıcı");
            return Redirect("/Login");
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
