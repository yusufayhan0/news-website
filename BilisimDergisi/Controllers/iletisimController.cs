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
    public class iletisimController : Controller
    {
        private bilisimDergisiEntities1 db = new bilisimDergisiEntities1();
        public ActionResult Details()
        {
            if (Convert.ToBoolean(Session["yetki"]) == true)
            {
                return View(db.iletisim.SingleOrDefault());
            }
            else
            {
                return RedirectToAction("hata3", "Hata");
            }
        }

        
        public ActionResult Edit(int? id)
        {
            if (Convert.ToBoolean(Session["yetki"]) == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                iletisim iletisim = db.iletisim.Find(id);
                if (iletisim == null)
                {
                    return HttpNotFound();
                }
                return View(iletisim);
            }
            else
            {
                return RedirectToAction("hata3", "Hata");
            }
            
        }
        [HttpPost]
        public ActionResult Edit(iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iletisim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details","iletisim");
            }
            return View(iletisim);
        }
    }
}
