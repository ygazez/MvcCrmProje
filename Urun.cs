using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMPROJEDB.Library
{
    public class Urun
    {
        public int UrunID { get; set; }

        public decimal Fiyat { get; set; }

        public int Adet { get; set; }

        public string  Adi  { get; set; }

        public decimal ToplamFiyat
        {
            get
            {
                return Adet * Fiyat;
            }
        }
       
    }
}
