using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAL;

namespace WebApplication1.Models
{
    public class birlestir
    {
        public List<news> slider { get; set; }
        public news tek1 { get; set; }
        public List<news> tek2 { get; set; }
        public news mob1 { get; set; }
        public List<news> mob2 { get; set; }
        public news don1 { get; set; }
        public List<news> don2 { get; set; }
        public news oy1 { get; set; }
        public List<news> oy2 { get; set; }
        public List<news> foto { get; set; }
    }
}