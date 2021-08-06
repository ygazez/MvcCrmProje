using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMPROJEDB.Models;

namespace CRMPROJEDB.Views
{
    [ActionFilters.Authorize]
    public class Tbl_FirmaController : Controller
    {
        private crmprojeEntities db = new crmprojeEntities();

        // GET: Tbl_Firma
        public ActionResult Index()
        {
            var tbl_Firma = db.Tbl_Firma.Include(t => t.Tbl_Kullanici);
            return View(tbl_Firma.ToList());
        }

        // GET: Tbl_Firma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Firma tbl_Firma = db.Tbl_Firma.Find(id);
            if (tbl_Firma == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Firma);
        }

        // GET: Tbl_Firma/Create
        public ActionResult Create()
        {
            ViewBag.MusteriTemsilcisi = new SelectList(db.Tbl_Kullanici, "KullaniciID", "Adi");
            return View();
        }

        // POST: Tbl_Firma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirmaID,Adi,Telefon,Adres,VergiDairesi,VergiNumarasi,MusteriTemsilcisi")] Tbl_Firma tbl_Firma)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Firma.Add(tbl_Firma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusteriTemsilcisi = new SelectList(db.Tbl_Kullanici, "KullaniciID", "Adi", tbl_Firma.MusteriTemsilcisi);
            return View(tbl_Firma);
        }

        // GET: Tbl_Firma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Firma tbl_Firma = db.Tbl_Firma.Find(id);
            if (tbl_Firma == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusteriTemsilcisi = new SelectList(db.Tbl_Kullanici, "KullaniciID", "Adi", tbl_Firma.MusteriTemsilcisi);
            return View(tbl_Firma);
        }



        // POST: Tbl_Firma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirmaID,Adi,Telefon,Adres,VergiDairesi,VergiNumarasi,MusteriTemsilcisi")] Tbl_Firma tbl_Firma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Firma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusteriTemsilcisi = new SelectList(db.Tbl_Kullanici, "KullaniciID", "Adi", tbl_Firma.MusteriTemsilcisi);
            return View(tbl_Firma);
        }

        // GET: Tbl_Firma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Firma tbl_Firma = db.Tbl_Firma.Find(id);
            if (tbl_Firma == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Firma);
        }

        // POST: Tbl_Firma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Firma tbl_Firma = db.Tbl_Firma.Find(id);
            db.Tbl_Firma.Remove(tbl_Firma);
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
