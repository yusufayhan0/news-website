//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class news
    {
        public int haberID { get; set; }
        [Required(ErrorMessage = "Bos Gešilemez !")]
        public string haberBasligi { get; set; }
        [Required(ErrorMessage = "Bos Gešilemez !")]
        public string sliderBasligi { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Bos Gešilemez !")]
        public string yazi { get; set; }
        public string resim { get; set; }
        public Nullable<System.DateTime> eklenmeTarihi { get; set; }
        public Nullable<int> kategori { get; set; }
        public Nullable<int> yazar { get; set; }
        public Nullable<int> tiklanma { get; set; }
    
        public virtual kategoriler kategoriler { get; set; }
        public virtual yazarlar yazarlar { get; set; }
    }
}
