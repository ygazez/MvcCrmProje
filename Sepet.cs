using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMPROJEDB.Library
{
    public class Sepet
    {

        public List<Urun> Urunler
        {
            get;
            set;
        } = new List<Urun>();

        public string FirmaAdi { get; set; }
        public int FirmaID { get; set; }

        public decimal SepetToplami
        {
            get
            {
                decimal toplam = 0;
                foreach (var item in Urunler)
                {
                    toplam += item.ToplamFiyat;
                }
                return toplam;
            }
        }



    }
}



