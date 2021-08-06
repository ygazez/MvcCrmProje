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
    public class Tbl_UrunKategoriController : Controller
    {
        private crmprojeEntities db = new crmprojeEntities();

        // GET: Tbl_UrunKategori
        public ActionResult Index()
        {
            return View(db.Tbl_UrunKategori.ToList());
        }
        public ActionResult KategoriUrun()
        {
            return View(db.Tbl_UrunKategori.ToList());
        }

        // GET: Tbl_UrunKategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_UrunKategori tbl_UrunKategori = db.Tbl_UrunKategori.Find(id);
            if (tbl_UrunKategori == null)
            {
                return HttpNotFound();
            }
            return View(tbl_UrunKategori);
        }

        // GET: Tbl_UrunKategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_UrunKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrunKategoriID,KategoriAdi")] Tbl_UrunKategori tbl_UrunKategori)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_UrunKategori.Add(tbl_UrunKategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_UrunKategori);
        }

        // GET: Tbl_UrunKategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_UrunKategori tbl_UrunKategori = db.Tbl_UrunKategori.Find(id);
            if (tbl_UrunKategori == null)
            {
                return HttpNotFound();
            }
            return View(tbl_UrunKategori);
        }

        // POST: Tbl_UrunKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrunKategoriID,KategoriAdi")] Tbl_UrunKategori tbl_UrunKategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_UrunKategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_UrunKategori);
        }

        // GET: Tbl_UrunKategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_UrunKategori tbl_UrunKategori = db.Tbl_UrunKategori.Find(id);
            if (tbl_UrunKategori == null)
            {
                return HttpNotFound();
            }
            return View(tbl_UrunKategori);
        }

        // POST: Tbl_UrunKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_UrunKategori tbl_UrunKategori = db.Tbl_UrunKategori.Find(id);
            db.Tbl_UrunKategori.Remove(tbl_UrunKategori);
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
