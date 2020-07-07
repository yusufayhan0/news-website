using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace WebApplication1.Models
{
    
    public class htmlTemizle
    {
        public static string kodTemizle(string text, int uzunluk)
        {
            if (text.Length > uzunluk)
            {
                return Regex.Replace(text, @"<(.|\n)*?>", string.Empty).Substring(0, uzunluk);
            }
            return Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
        }

        public static string detayKodTemizle(string text)
        {           
            return Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
        }
    }
}