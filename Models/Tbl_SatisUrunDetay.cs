//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRMPROJEDB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_SatisUrunDetay
    {
        public int SatisUrunDetayID { get; set; }
        public int UrunID { get; set; }
        public int SatisID { get; set; }
        public int Adet { get; set; }
        public decimal Kdv { get; set; }
        public decimal KdvsizFiyat { get; set; }
        public decimal KdvDahilFiyat { get; set; }
        public decimal BirimFiyati { get; set; }
    
        public virtual Tbl_Satis Tbl_Satis { get; set; }
        public virtual Tbl_Urun Tbl_Urun { get; set; }
    }
}