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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class crmprojeEntities : DbContext
    {
        public crmprojeEntities()
            : base("name=crmprojeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_Firma> Tbl_Firma { get; set; }
        public virtual DbSet<Tbl_Kullanici> Tbl_Kullanici { get; set; }
        public virtual DbSet<Tbl_Satis> Tbl_Satis { get; set; }
        public virtual DbSet<Tbl_SatisUrunDetay> Tbl_SatisUrunDetay { get; set; }
        public virtual DbSet<Tbl_Urun> Tbl_Urun { get; set; }
        public virtual DbSet<Tbl_UrunKategori> Tbl_UrunKategori { get; set; }

        public System.Data.Entity.DbSet<CRMPROJEDB.Library.Urun> Uruns { get; set; }
    }
}
