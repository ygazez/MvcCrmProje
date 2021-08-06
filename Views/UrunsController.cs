using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMPROJEDB.Library;
using CRMPROJEDB.Models;

namespace CRMPROJEDB.Views
{
    [ActionFilters.Authorize]
    public class UrunsController : Controller
    {
        private crmprojeEntities db = new crmprojeEntities();


        // GET: Uruns
        public ActionResult Index()
        {
            var z = CRMPROJEDB.Library.Helper.SepetGetir();
            return View(z);
        }

        [HttpPost]
        public string MiktarDegis(int id, int adet)
        {
            var z = CRMPROJEDB.Library.Helper.SepetGetir();
            var urun = z.Urunler.Where(n => n.UrunID == id).FirstOrDefault();
            if (urun != null)
            {
                urun.Adet = adet;
            }
            else
                return "Ürün sepette bulunamadı";

            System.Web.HttpContext.Current.Session["Sepet"] = z;
            return "OK";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRMPROJEDB.Library.Helper.SepetCikar((int)id);
            return RedirectToAction("Index");
        }

        public ActionResult Siparisver()
        {
            var z = CRMPROJEDB.Library.Helper.SepetGetir();

            Tbl_Satis satis = new Tbl_Satis();

            satis.Firma = z.FirmaID;
            satis.Tarih = DateTime.Now;
            satis.Kdv = 18;
            

            decimal toplamKdvsiz = 0;
            decimal toplamKdvli = 0;
            foreach (var u in z.Urunler)
            {

                Tbl_Urun tbl_Urun = db.Tbl_Urun.Find(u.UrunID);

                Tbl_SatisUrunDetay urun = new Tbl_SatisUrunDetay();
                urun.UrunID = u.UrunID;
                urun.Adet = u.Adet;
                urun.BirimFiyati = u.Fiyat;
                urun.KdvDahilFiyat = u.ToplamFiyat;
                urun.Kdv = 18;
                urun.KdvsizFiyat = u.ToplamFiyat / (decimal)1.18;


                toplamKdvli += urun.KdvDahilFiyat;
                toplamKdvsiz += urun.KdvsizFiyat;

                satis.Tbl_SatisUrunDetay.Add(urun);
            }

            satis.KdvDahilFiyat = toplamKdvli;
            satis.KdvsizFiyat = toplamKdvsiz;

            var t =  (Tbl_Kullanici)HttpContext.Session["Tbl_Kullanıcı"];
            satis.SatisYapanKisi = t.KullaniciID;

            db.Tbl_Satis.Add(satis);
            db.SaveChanges();
            CRMPROJEDB.Library.Helper.SepetBosalt();
            return RedirectToAction("Index");

        }








    }
}
