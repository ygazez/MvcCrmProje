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
    public class Tbl_SatisController : Controller
    {
        private crmprojeEntities db = new crmprojeEntities();

        // GET: Tbl_Satis
        public ActionResult Index()
        {
            var tbl_Satis = db.Tbl_Satis.Include(t => t.Tbl_Firma).Include(t => t.Tbl_Kullanici);
            return View(tbl_Satis.ToList());
        }

        // GET: Tbl_Satis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Satis tbl_Satis = db.Tbl_Satis.Find(id);
            if (tbl_Satis == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Satis);
        }

        // GET: Tbl_Satis/Create
        public ActionResult Create()
        {
            ViewBag.Firma = new SelectList(db.Tbl_Firma, "FirmaID", "Adi");
            ViewBag.SatisYapanKisi = new SelectList(db.Tbl_Kullanici, "KullaniciID", "Adi");
            return View();
        }

        // POST: Tbl_Satis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SatisID,SatisYapanKisi,Firma,Kdv,Tarih,KdvDahilFiyat,KdvsizFiyat")] Tbl_Satis tbl_Satis)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Satis.Add(tbl_Satis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Firma = new SelectList(db.Tbl_Firma, "FirmaID", "Adi", tbl_Satis.Firma);
            ViewBag.SatisYapanKisi = new SelectList(db.Tbl_Kullanici, "KullaniciID", "Adi", tbl_Satis.SatisYapanKisi);
            return View(tbl_Satis);
        }

        // GET: Tbl_Satis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Satis tbl_Satis = db.Tbl_Satis.Find(id);
            if (tbl_Satis == null)
            {
                return HttpNotFound();
            }
            ViewBag.Firma = new SelectList(db.Tbl_Firma, "FirmaID", "Adi", tbl_Satis.Firma);
            ViewBag.SatisYapanKisi = new SelectList(db.Tbl_Kullanici, "KullaniciID", "Adi", tbl_Satis.SatisYapanKisi);
            return View(tbl_Satis);
        }

        // POST: Tbl_Satis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SatisID,SatisYapanKisi,Firma,Kdv,Tarih,KdvDahilFiyat,KdvsizFiyat")] Tbl_Satis tbl_Satis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Satis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Firma = new SelectList(db.Tbl_Firma, "FirmaID", "Adi", tbl_Satis.Firma);
            ViewBag.SatisYapanKisi = new SelectList(db.Tbl_Kullanici, "KullaniciID", "Adi", tbl_Satis.SatisYapanKisi);
            return View(tbl_Satis);
        }

        // GET: Tbl_Satis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Satis tbl_Satis = db.Tbl_Satis.Find(id);
            if (tbl_Satis == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Satis);
        }

        // POST: Tbl_Satis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Satis tbl_Satis = db.Tbl_Satis.Find(id);
            db.Tbl_Satis.Remove(tbl_Satis);
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
