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
    public class yazarlarController : Controller
    {
        private bilisimDergisiEntities1 db = new bilisimDergisiEntities1();

        // GET: yazarlar
        public ActionResult Index()
        {
            if (Convert.ToBoolean(Session["yetki"]) == false)
            {
                return RedirectToAction("hata3", "Hata");
            }
            return View(db.yazarlar.ToList());
        }
        public ActionResult Create()
        {
            if (Convert.ToBoolean(Session["yetki"]) == false)
            {
                return RedirectToAction("hata3", "Hata");
            }
            return View();
        }

        // POST: yazarlar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "yazarID,adi,soyadi,mail,kullaniciAdi,sifre,P_resim,yetki")] yazarlar yazarlar)
        {
            if (ModelState.IsValid)
            {
                db.yazarlar.Add(yazarlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yazarlar);
        }

        // GET: yazarlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToBoolean(Session["yetki"]) == true)
            {
                yazarlar yazarlar = db.yazarlar.Find(id);
                return View(yazarlar);
            }
            else
            {
                if (id == null)
                {
                    int deger = Convert.ToInt16(Session["ID"]);
                    yazarlar yazarlar = db.yazarlar.Find(deger);
                    return View(yazarlar);
                }
                else
                {
                    return RedirectToAction("hata3", "Hata");
                }
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }           
        }

        // POST: yazarlar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(yazarlar yazarlar)
        {
            if (ModelState.IsValid)
            {                
                if (Convert.ToBoolean(Session["yetki"]) == true)
                {
                    if (yazarlar.yazarID==Convert.ToInt16(Session["ID"]))
                    {
                        Session["kadi"] = yazarlar.kullaniciAdi;
                        Session["adi"] = yazarlar.adi;
                        Session["soyadi"] = yazarlar.soyadi;
                        Session["sifre"] = yazarlar.sifre;
                        Session["yetki"] = yazarlar.yetki;
                        Session["mail"] = yazarlar.mail;
                        Session["resim"] = yazarlar.P_resim;
                        Session["ID"] = yazarlar.yazarID;
                    }
                    db.Entry(yazarlar).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Session["kadi"] = yazarlar.kullaniciAdi;
                    Session["adi"] = yazarlar.adi;
                    Session["soyadi"] = yazarlar.soyadi;
                    Session["sifre"] = yazarlar.sifre;
                    Session["yetki"] = yazarlar.yetki;
                    Session["mail"] = yazarlar.mail;
                    Session["resim"] = yazarlar.P_resim;
                    Session["ID"] = yazarlar.yazarID;
                    yazarlar.yetki = false;
                    db.Entry(yazarlar).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index","news");
                }
            }
            return View(yazarlar);
        }

        // GET: yazarlar/Delete/5
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
            yazarlar yazarlar = db.yazarlar.Find(id);
            if (yazarlar == null)
            {
                return HttpNotFound();
            }
            return View(yazarlar);
        }

        // POST: yazarlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            yazarlar yazarlar = db.yazarlar.Find(id);
            db.yazarlar.Remove(yazarlar);
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
