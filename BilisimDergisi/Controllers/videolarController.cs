using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;

namespace WebApplication1.Controllers
{
    public class videolarController : Controller
    {
        private bilisimDergisiEntities1 db = new bilisimDergisiEntities1();

        // GET: videolar
        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["yetki"]) == false)
            {
                return RedirectToAction("hata3", "Hata");
            }
            return View(db.videolar.ToList());
        }

        // GET: videolar/Details/5
        

        // GET: videolar/Create
        public ActionResult Create()
        {
            if (Convert.ToBoolean(Session["yetki"]) == false)
            {
                return RedirectToAction("hata3", "Hata");
            }
            return View();
        }

        // POST: videolar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(videolar videolar)
        {
            if (ModelState.IsValid)
            {
                videolar.adres = videolar.adres;
                videolar.tarih = DateTime.Now;
                db.videolar.Add(videolar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videolar);
        }

        // GET: videolar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToBoolean(Session["yetki"]) == false)
            {
                return RedirectToAction("hata3", "Hata");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            videolar videolar = db.videolar.Find(id);
            if (videolar == null)
            {
                return HttpNotFound();
            }
            return View(videolar);
        }

        // POST: videolar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(videolar videolar)
        {
            if (ModelState.IsValid)
            {
                videolar guncelle = db.videolar.Find(videolar.vID);
                guncelle.adres = videolar.adres;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videolar);
        }

        // GET: videolar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToBoolean(Session["yetki"]) == false)
            {
                return RedirectToAction("hata3", "Hata");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            videolar videolar = db.videolar.Find(id);
            if (videolar == null)
            {
                return HttpNotFound();
            }
            return View(videolar);
        }

        // POST: videolar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            videolar videolar = db.videolar.Find(id);
            db.videolar.Remove(videolar);
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
