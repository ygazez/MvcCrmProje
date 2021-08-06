using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMPROJEDB.Models;
using System.Security.Cryptography;
using System.Text;

namespace CRMPROJEDB.Views
{
    [ActionFilters.Authorize]
    public class Tbl_KullaniciController : Controller
    {
        private crmprojeEntities db = new crmprojeEntities();

        // GET: Tbl_Kullanici
        public ActionResult Index()
        {
            return View(db.Tbl_Kullanici.ToList());
        }
        public ActionResult Firma_Kullanici()
        {
            return View(db.Tbl_Kullanici.ToList());
        }

        // GET: Tbl_Kullanici/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Kullanici tbl_Kullanici = db.Tbl_Kullanici.Find(id);
            if (tbl_Kullanici == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Kullanici);
        }

        // GET: Tbl_Kullanici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Kullanici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KullaniciID,Adi,Soyadi,Email,Sifre,SifreTekrar")] Tbl_Kullanici tbl_Kullanici)
        {

            if (ModelState.IsValid)
            {
                SHA1 sha = new SHA1CryptoServiceProvider();
                //db.Tbl_Kullanici.Add(tbl_Kullanici);

                // tbl_Kullanici.Sifre = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(tbl_Kullanici.Sifre)));

                if (tbl_Kullanici.Sifre == tbl_Kullanici.SifreTekrar)
                {
                    tbl_Kullanici.Sifre = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(tbl_Kullanici.Sifre)));
                    db.Tbl_Kullanici.Add(tbl_Kullanici);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mesaj = "Girilen şifreler uyuşmamaktadır!";
                }
            }

            return View(tbl_Kullanici);
        }

        // GET: Tbl_Kullanici/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Kullanici tbl_Kullanici = db.Tbl_Kullanici.Find(id);
            if (tbl_Kullanici == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Kullanici);
        }

        // POST: Tbl_Kullanici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KullaniciID,Adi,Soyadi,Email,Sifre")] Tbl_Kullanici tbl_Kullanici)
        {
            if (ModelState.IsValid)
            {
                SHA1 sha = new SHA1CryptoServiceProvider();
                if (string.IsNullOrEmpty(tbl_Kullanici.Sifre))
                {
                    string sifre = db.Tbl_Kullanici.Where(n => n.KullaniciID == tbl_Kullanici.KullaniciID).Select(n => n.Sifre).FirstOrDefault();
                    tbl_Kullanici.Sifre = sifre;

                }
                else
                    tbl_Kullanici.Sifre = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(tbl_Kullanici.Sifre)));
                db.Entry(tbl_Kullanici).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Kullanici);
        }

        // GET: Tbl_Kullanici/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Kullanici tbl_Kullanici = db.Tbl_Kullanici.Find(id);
            if (tbl_Kullanici == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Kullanici);
        }

        // POST: Tbl_Kullanici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Kullanici tbl_Kullanici = db.Tbl_Kullanici.Find(id);
            db.Tbl_Kullanici.Remove(tbl_Kullanici);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
