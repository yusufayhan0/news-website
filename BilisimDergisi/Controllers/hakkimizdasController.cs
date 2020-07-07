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
    public class hakkimizdasController : Controller
    {
        private bilisimDergisiEntities1 db = new bilisimDergisiEntities1();

        
        // GET: hakkimizdas/Details/5
        public ActionResult Details()
        {
            if (Convert.ToBoolean(Session["yetki"]) == true)
            {
                hakkimizda hakkimizda = db.hakkimizda.SingleOrDefault();
                return View(hakkimizda);
            }
            else
            {
                return RedirectToAction("hata3", "Hata");
            }
        }

        // GET: hakkimizdas/Create
        

        // GET: hakkimizdas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Convert.ToBoolean(Session["yetki"]) == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                hakkimizda hakkimizda = db.hakkimizda.Find(id);
                if (hakkimizda == null)
                {
                    return HttpNotFound();
                }
                return View(hakkimizda);
            }
            else
            {
                return RedirectToAction("hata3", "Hata");
            }            
        }
        [HttpPost]
        public ActionResult Edit(hakkimizda hakkimizda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hakkimizda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details","hakkimizdas");
            }
            return View(hakkimizda);
        }
    }
}
