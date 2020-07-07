using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class zaman
    {
        public static String GecenZamaniHesapla(DateTime dt)
        {
            TimeSpan ts = DateTime.Now.Subtract(dt);
            if (ts.Days >= 365) return ts.Days / 365 + " yıl önce";
            if (ts.Days >= 30) return ts.Days / 30 + " ay önce";
            if (ts.Days >= 7) return ts.Days / 7 + " hafta önce";
            if (ts.Days > 0) return ts.Days + " gün önce";
            if (ts.Hours >= 1) return ts.Hours + " saat önce";
            if (ts.Minutes >= 1) return ts.Minutes + " dakika önce";
            else return "biraz önce";
        }
    }
}