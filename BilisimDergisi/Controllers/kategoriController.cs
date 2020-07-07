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
    public class kategoriController : Controller
    {        
        private bilisimDergisiEntities1 db = new bilisimDergisiEntities1();

        // GET: kategori
        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["yetki"]) == true)
            {
                return View(db.kategoriler.ToList());
            }
            else
            {
                return RedirectToAction("hata3", "Hata");
            }
        }

        // GET: kategori/Details/5
       
        // GET: kategori/Create
        public ActionResult Create()
        {
            if (Convert.ToBoolean(Session["yetki"]) == false)
            {
                return RedirectToAction("hata3", "Hata");
            }
            else
            {
                return View();
            }            
        }

        // POST: kategori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kateID,kategori")] kategoriler kategoriler)
        {
            if (ModelState.IsValid)
            {
                db.kategoriler.Add(kategoriler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategoriler);
        }

        // GET: kategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kategoriler kategoriler = db.kategoriler.Find(id);
            if (Convert.ToBoolean(Session["yetki"]) == false)
            {
                return RedirectToAction("hata3", "Hata");
            }
            if (kategoriler == null)
            {
                return HttpNotFound();
            }
            return View(kategoriler);
        }

        // POST: kategori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kateID,kategori")] kategoriler kategoriler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoriler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategoriler);
        }

        // GET: kategori/Delete/5
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
            kategoriler kategoriler = db.kategoriler.Find(id);
            if (kategoriler == null)
            {
                return HttpNotFound();
            }
            return View(kategoriler);
        }

        // POST: kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kategoriler kategoriler = db.kategoriler.Find(id);
            db.kategoriler.Remove(kategoriler);
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
