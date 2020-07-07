using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using PagedList;
using PagedList.Mvc;

namespace WebApplication1.Controllers
{
    public class newsController : Controller
    {
        private bilisimDergisiEntities1 db = new bilisimDergisiEntities1();

        // GET: news
        public ActionResult Index(int? sayfaNo)
        {
            int _sayfaNo = sayfaNo ?? 1;
            if (Convert.ToBoolean(Session["yetki"]) == true)
            {
                var news = db.news.Include(n => n.kategoriler).OrderByDescending(x=>x.eklenmeTarihi).ToPagedList(_sayfaNo, 10);
                return View(news);
            }
            else
            {
                int deger = Convert.ToInt32(Session["ID"]);
                var news = db.news.Include(n => n.kategoriler).Where(x => x.yazar == deger).OrderByDescending(x => x.eklenmeTarihi).ToPagedList(_sayfaNo, 10);
                return View(news);
            }
        }

        // GET: news/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = db.news.Find(id);
            if (Convert.ToBoolean(Session["yetki"]) == false)
            {
                if (news.yazar != Convert.ToInt32(Session["ID"]))
                {
                    return RedirectToAction("hata3", "Hata");
                }
            }
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: news/Create
        public ActionResult Create()
        {
            ViewBag.kategori = new SelectList(db.kategoriler, "kateID", "kategori");
            return View();
        }

        // POST: news/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(news news)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img/"), fileName);
                    file.SaveAs(path);
                    news.eklenmeTarihi = DateTime.Now;
                    news.tiklanma = 0;
                    news.resim = "/Content/img/" + fileName;
                    news.yazar = Convert.ToInt16(Session["ID"]);
                    db.news.Add(news);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.bosmesaj = "Boş Geçilemez !";
                }
            }
            ViewBag.kategori = new SelectList(db.kategoriler, "kateID", "kategori", news.kategori);
            return View(news);
        }

        // GET: news/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = db.news.Find(id);
            if (Convert.ToBoolean(Session["yetki"]) == false)
            {
                if (news.yazar != Convert.ToInt32(Session["ID"]))
                {
                    return RedirectToAction("hata3", "Hata");
                }
            }
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.kategori = new SelectList(db.kategoriler, "kateID", "kategori", news.kategori);
            return View(news);
        }

        // POST: news/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(news news)
        {
            int durum = 0;
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    news guncelle = db.news.Find(news.haberID);
                    System.IO.File.Delete(Server.MapPath(guncelle.resim));
                    durum = 1;
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img/"), fileName);
                    file.SaveAs(path);
                    
                    guncelle.haberBasligi = news.haberBasligi;
                    guncelle.sliderBasligi = news.sliderBasligi;
                    guncelle.yazi = news.yazi;
                    guncelle.resim = "/Content/img/" + fileName;
                    guncelle.kategori = news.kategori;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            if(durum==0)
            {
                news guncelle = db.news.Find(news.haberID);
                guncelle.haberBasligi = news.haberBasligi;
                guncelle.sliderBasligi = news.sliderBasligi;
                guncelle.yazi = news.yazi;
                guncelle.kategori = news.kategori;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.kategori = new SelectList(db.kategoriler, "kateID", "kategori", news.kategori);
            return View(news);
        }

        // GET: news/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = db.news.Find(id);
            if (Convert.ToBoolean(Session["yetki"]) == false)
            {
                if (news.yazar != Convert.ToInt32(Session["ID"]))
                {
                    return RedirectToAction("hata3", "Hata");
                }
            }
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: news/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            news news = db.news.Find(id);
            db.news.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
