using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using PagedList;
using PagedList.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        bilisimDergisiEntities1 data = new bilisimDergisiEntities1();
        birlestir modelBirlestir = new birlestir();
        // GET: Home
        public ActionResult Index()
        {

            modelBirlestir.slider = data.news.OrderByDescending(x => x.eklenmeTarihi).Take(10).ToList();
            //---------
            modelBirlestir.tek1 = data.news.OrderByDescending(x => x.eklenmeTarihi).Where(x => x.kategori == 1).Take(1).SingleOrDefault();
            modelBirlestir.tek2 = data.news.OrderByDescending(x => x.eklenmeTarihi).Where(x => x.haberID != modelBirlestir.tek1.haberID && x.kategori == 1).Take(4).ToList();

            //---------
            modelBirlestir.mob1 = data.news.OrderByDescending(x => x.eklenmeTarihi).Where(x => x.kategori == 2).Take(1).SingleOrDefault();
            modelBirlestir.mob2 = data.news.OrderByDescending(x => x.eklenmeTarihi).Where(x => x.haberID != modelBirlestir.mob1.haberID && x.kategori == 2).Take(4).ToList();
            //---------
            modelBirlestir.don1 = data.news.OrderByDescending(x => x.eklenmeTarihi).Where(x => x.kategori == 3).Take(1).SingleOrDefault();
            modelBirlestir.don2 = data.news.OrderByDescending(x => x.eklenmeTarihi).Where(x => x.haberID != modelBirlestir.don1.haberID && x.kategori == 3).Take(4).ToList();
            //---------
            modelBirlestir.oy1 = data.news.OrderByDescending(x => x.eklenmeTarihi).Where(x => x.kategori == 5).Take(1).SingleOrDefault();
            modelBirlestir.oy2 = data.news.OrderByDescending(x => x.eklenmeTarihi).Where(x => x.haberID != modelBirlestir.oy1.haberID && x.kategori == 5).Take(4).ToList();
            //---------
            modelBirlestir.foto = data.news.OrderByDescending(x => Guid.NewGuid()).Take(6).ToList();

            return View(modelBirlestir);
        }


        [HttpGet]
        [Route("arama/{deger?}")]
        public ActionResult aramaYap(string aramaDegeri)
        {
            List<news> arananHaber = data.news.Where(x => x.haberBasligi.Contains(aramaDegeri)).ToList();
            if (aramaDegeri == " " || aramaDegeri == "")
            {
                ViewBag.deger = "Aradığınız Değer Bulunamadı !";
                return View();
            }
            if (arananHaber.Count == 0)
            {
                ViewBag.deger = "Aradığınız Değer Bulunamadı !";
                return View();
            }
            else
            {
                ViewBag.deger = aramaDegeri;
                return View(arananHaber);
            }
        }
        [Route("Hakkimizda")]
        public ActionResult hakkimizda()
        {
            return View(data.hakkimizda.SingleOrDefault());
        }
        [Route("Iletisim")]
        public ActionResult iletisim()
        {
            return View(data.iletisim.SingleOrDefault());
        }
        [Route("admin")]
        public ActionResult giris()
        {
            if (Session["ID"] != null)
            {
                if (Convert.ToBoolean(Session["yetki"]) == true)
                {
                    return RedirectToAction("Index", "kategori");
                }
                else
                {
                    return RedirectToAction("Index", "news");
                }
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ActionName("giris")]
        [Route("admin")]
        public ActionResult giris(yazarlar bilgi)
        {
            yazarlar varmi = data.yazarlar.Where(x => x.kullaniciAdi == bilgi.kullaniciAdi && x.sifre == bilgi.sifre).SingleOrDefault();

            if (varmi == null)
            {
                ViewBag.hataMesaji = "Kullanıcı Adı veya Şifre Hatalı !";
                return View();
            }
            else
            {
                Session["kadi"] = varmi.kullaniciAdi;
                Session["adi"] = varmi.adi;
                Session["soyadi"] = varmi.soyadi;
                Session["sifre"] = varmi.sifre;
                Session["yetki"] = varmi.yetki;
                Session["mail"] = varmi.mail;
                Session["resim"] = varmi.P_resim;
                Session["ID"] = varmi.yazarID;
                if (varmi.yetki == true)
                {
                    return RedirectToAction("Index", "kategori");
                }
                else
                {
                    return RedirectToAction("Index", "news");
                }
            }
        }
        public ActionResult cikis()
        {
            Session.Abandon();
            return RedirectToAction("giris", "Home");
        }
        [Route("Kategoriler/{title}/{Id}")]
        public ActionResult kategori_detay(int id, int? sayfaNo)
        {
            int _sayfaNo = sayfaNo ?? 1;
            var kategori = data.kategoriler.Where(x => x.kateID == id).SingleOrDefault();
            var haber = data.news.Where(x => x.kategori == id).OrderByDescending(x => x.eklenmeTarihi).ToPagedList(_sayfaNo, 10);

            return View(Tuple.Create(kategori, haber));
        }
        [Route("Haberler/{title}/{Id}")]
        public ActionResult haber_detay(int? id)
        {
            if (id != null)
            {
                news haberDetay = data.news.Where(x => x.haberID == id).SingleOrDefault();
                var sira = data.news.OrderByDescending(x => x.eklenmeTarihi).ToList();
                int sayac = 0;
                int[] dizi = new int[sira.Count];
                ViewBag.sonraki = null;
                ViewBag.onceki = null;
                foreach (var item in sira)
                {
                    if (haberDetay.haberID==item.haberID)
                    {
                        if (sayac!=0)
                        {
                            ViewBag.onceki = sira[sayac - 1].haberID;
                            ViewBag.onceki_baslik = sira[sayac - 1].haberBasligi.Replace(" ", "-");
                        }
                        if (sayac+1!=sira.Count)
                        {
                            ViewBag.sonraki = sira[sayac + 1].haberID;
                            ViewBag.sonraki_baslik = sira[sayac + 1].haberBasligi.Replace(" ", "-");
                        }                        
                        break;
                    }                    
                    sayac++;
                }
                //ViewBag.once=sirali.
                if (haberDetay != null)
                {
                    ViewBag.eklenme_tarih = zaman.GecenZamaniHesapla(Convert.ToDateTime(haberDetay.eklenmeTarihi)).ToString();
                    news tiklama = data.news.Find(id);
                    Response.Cookies["ID_cook"]["ID_deger"] = Convert.ToString(tiklama.haberID);
                    Response.Cookies["ID_cook"].Expires = DateTime.Now.AddDays(1);
                    if (Request.Cookies["ID_cook"] == null)
                    {
                        tiklama.tiklanma = tiklama.tiklanma + 1;
                        data.SaveChanges();
                    }
                    else
                    {
                        if (Request.Cookies["ID_cook"]["ID_deger"] != Convert.ToString(tiklama.haberID))
                        {
                            tiklama.tiklanma = tiklama.tiklanma + 1;
                            data.SaveChanges();
                        }
                    }
                    return View(haberDetay);
                }
                else
                {
                    return RedirectToAction("hata1", "Hata");
                }
            }
            else
            {
                return RedirectToAction("hata2", "Hata");
            }
        }
        //------------------------------------------------------------
        //var model = new Tuple<List<news>, List<kategoriler>>(haber(), kategori());
        //public List<kategoriler> kategori()
        //{
        //    List<kategoriler> kategori = data.kategoriler.ToList();
        //    return kategori;
        //}

        //public List<news> haber()
        //{
        //    List<news> haber = data.news.ToList();
        //    return haber;
        //}

        //------------------------------------------------------------
    }
}