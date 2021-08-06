using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMPROJEDB.Library
{
    public class Helper
    {
        public static bool SepetVarmi()
        {
            if (System.Web.HttpContext.Current.Session["Sepet"] != null)
                return true;
            else
                return false;
        }
        public static Sepet SepetGetir()
        {
            if (SepetVarmi())
            {
                return (Sepet)System.Web.HttpContext.Current.Session["Sepet"];
            }
            else
            {
                return new Sepet();
            }
        }

        public static int SepetUrunSayisi()
        {
            return SepetGetir().Urunler.Count;
        }

        public static void SepeteUrunEkle(int UrunId,string Adi, int Adet, decimal Fiyat)
        {
            var sepet = SepetGetir();

            Urun urun = new Urun();
            urun.Adi = Adi;
            urun.Adet = Adet;
            urun.Fiyat = Fiyat;
            urun.UrunID = UrunId;

            var a = sepet.Urunler.Where(n => n.UrunID == UrunId).FirstOrDefault();
            if (a!=null)
            {
                a.Adet += 1;
                
            }
            else
            {
                sepet.Urunler.Add(urun);
            }
           
              //  sepet.Urunler.Add(urun);
            
            System.Web.HttpContext.Current.Session["Sepet"] = sepet;
        }
        public static void SepetCikar(int UrunId)
        {
            var sepet = SepetGetir();

            var urun = sepet.Urunler.Where(n => n.UrunID == UrunId).FirstOrDefault();

            if (urun != null)
            {
                sepet.Urunler.Remove(urun);
                System.Web.HttpContext.Current.Session["Sepet"] = sepet;
            }
        }

        public static void SepetBosalt()
        {
            System.Web.HttpContext.Current.Session["Sepet"] = null;
        }

        
    }
}
