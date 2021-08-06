using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMPROJEDB.Models;
using System.IO;

namespace CRMPROJEDB.Views
{
    [ActionFilters.Authorize]
    public class Tbl_UrunController : Controller
    {
        private crmprojeEntities db = new crmprojeEntities();

        // GET: Tbl_Urun
        public ActionResult Index()
        {
            if (Request.QueryString["FirmaID"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["FirmaID"]);
                var sepet = CRMPROJEDB.Library.Helper.SepetGetir();

                Tbl_Firma firma = db.Tbl_Firma.Find(id);
                sepet.FirmaAdi = firma.Adi;
                sepet.FirmaID = firma.FirmaID;
                System.Web.HttpContext.Current.Session["Sepet"] = sepet;
            }
            var tbl_Urun = db.Tbl_Urun.Include(t => t.Tbl_UrunKategori);
            return View(tbl_Urun.ToList());
            //return View(tbl_Urun.Where(m => m.UrunKategoriID == 1).ToList());
        }

        // GET: Tbl_Urun/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Urun tbl_Urun = db.Tbl_Urun.Find(id);
            if (tbl_Urun == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Urun);
        }

        // GET: Tbl_Urun/Create
        public ActionResult Create()
        {
            ViewBag.UrunKategoriID = new SelectList(db.Tbl_UrunKategori, "UrunKategoriID", "KategoriAdi");
            return View();
        }

        // POST: Tbl_Urun/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrunID,UrunKategoriID,Adi,Fiyat,Aciklama,Fotograf,Urunmiktari")] Tbl_Urun tbl_Urun)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Urun.Add(tbl_Urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UrunKategoriID = new SelectList(db.Tbl_UrunKategori, "UrunKategoriID", "KategoriAdi", tbl_Urun.UrunKategoriID);
            return View(tbl_Urun);
        }

        // GET: Tbl_Urun/Edit/5
        public ActionResult Edit(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Urun tbl_Urun = db.Tbl_Urun.Find(id);
            if (tbl_Urun == null)
            {
                return HttpNotFound();
            }

            ViewBag.UrunKategoriID = new SelectList(db.Tbl_UrunKategori, "UrunKategoriID", "KategoriAdi", tbl_Urun.UrunKategoriID);
            return View(tbl_Urun);
        }

        // POST: Tbl_Urun/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrunID,UrunKategoriID,Adi,Fiyat,Aciklama,Fotograf,Urunmiktari")] Tbl_Urun tbl_Urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Urun).State = EntityState.Modified;
                if (Request.Files.Count > 0)
                {

                    DateTime dt = DateTime.Now;
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string yeniad = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString() + "-" + dt.Hour.ToString() + "-" + dt.Minute.ToString() + "-" + dt.Second.ToString() + "-" + dosyaadi;
                    //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Content/img/" + yeniad;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    tbl_Urun.Fotograf = yeniad;

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UrunKategoriID = new SelectList(db.Tbl_UrunKategori, "UrunKategoriID", "KategoriAdi", tbl_Urun.UrunKategoriID);
            return View(tbl_Urun);
        }


        // GET: Tbl_Urun/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Urun tbl_Urun = db.Tbl_Urun.Find(id);
            if (tbl_Urun == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Urun);
        }

        // POST: Tbl_Urun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Urun tbl_Urun = db.Tbl_Urun.Find(id);
            db.Tbl_Urun.Remove(tbl_Urun);
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


        public ActionResult Sepete_Ekle(int id)
        {
            Tbl_Urun tbl_Urun = db.Tbl_Urun.Find(id);
            CRMPROJEDB.Library.Helper.SepeteUrunEkle(id, tbl_Urun.Adi, 1, tbl_Urun.Fiyat);

            return RedirectToAction("Index");
        }

    }
}
