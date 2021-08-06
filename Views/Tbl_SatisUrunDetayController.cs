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
    public class Tbl_SatisUrunDetayController : Controller
    {
        private crmprojeEntities db = new crmprojeEntities();

        // GET: Tbl_SatisUrunDetay
        public ActionResult Index()
        {
            if (Request.QueryString["SatisID"] == null)
            {
                var tbl_SatisUrunDetay = db.Tbl_SatisUrunDetay.Include(t => t.Tbl_Satis).Include(t => t.Tbl_Urun);
                return View(tbl_SatisUrunDetay.ToList());
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["SatisID"]);
                var tbl_SatisUrunDetay = db.Tbl_SatisUrunDetay.Where(n => n.SatisID == id).Include(t => t.Tbl_Satis).Include(t => t.Tbl_Urun);
                return View(tbl_SatisUrunDetay.ToList());
            }
        }

        // GET: Tbl_SatisUrunDetay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_SatisUrunDetay tbl_SatisUrunDetay = db.Tbl_SatisUrunDetay.Find(id);
            if (tbl_SatisUrunDetay == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SatisUrunDetay);
        }

        // GET: Tbl_SatisUrunDetay/Create
        public ActionResult Create()
        {
            ViewBag.SatisID = new SelectList(db.Tbl_Satis, "SatisID", "SatisID");
            ViewBag.UrunID = new SelectList(db.Tbl_Urun, "UrunID", "Adi");
            return View();
        }

        // POST: Tbl_SatisUrunDetay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SatisUrunDetayID,UrunID,SatisID,Adet,Kdv,KdvsizFiyat,KdvDahilFiyat,BirimFiyati")] Tbl_SatisUrunDetay tbl_SatisUrunDetay)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_SatisUrunDetay.Add(tbl_SatisUrunDetay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SatisID = new SelectList(db.Tbl_Satis, "SatisID", "SatisID", tbl_SatisUrunDetay.SatisID);
            ViewBag.UrunID = new SelectList(db.Tbl_Urun, "UrunID", "Adi", tbl_SatisUrunDetay.UrunID);
            return View(tbl_SatisUrunDetay);
        }

        // GET: Tbl_SatisUrunDetay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_SatisUrunDetay tbl_SatisUrunDetay = db.Tbl_SatisUrunDetay.Find(id);
            if (tbl_SatisUrunDetay == null)
            {
                return HttpNotFound();
            }
            ViewBag.SatisID = new SelectList(db.Tbl_Satis, "SatisID", "SatisID", tbl_SatisUrunDetay.SatisID);
            ViewBag.UrunID = new SelectList(db.Tbl_Urun, "UrunID", "Adi", tbl_SatisUrunDetay.UrunID);
            return View(tbl_SatisUrunDetay);
        }

        // POST: Tbl_SatisUrunDetay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SatisUrunDetayID,UrunID,SatisID,Adet,Kdv,KdvsizFiyat,KdvDahilFiyat,BirimFiyati")] Tbl_SatisUrunDetay tbl_SatisUrunDetay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_SatisUrunDetay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SatisID = new SelectList(db.Tbl_Satis, "SatisID", "SatisID", tbl_SatisUrunDetay.SatisID);
            ViewBag.UrunID = new SelectList(db.Tbl_Urun, "UrunID", "Adi", tbl_SatisUrunDetay.UrunID);
            return View(tbl_SatisUrunDetay);
        }

        // GET: Tbl_SatisUrunDetay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_SatisUrunDetay tbl_SatisUrunDetay = db.Tbl_SatisUrunDetay.Find(id);
            if (tbl_SatisUrunDetay == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SatisUrunDetay);
        }

        // POST: Tbl_SatisUrunDetay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_SatisUrunDetay tbl_SatisUrunDetay = db.Tbl_SatisUrunDetay.Find(id);
            db.Tbl_SatisUrunDetay.Remove(tbl_SatisUrunDetay);
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
