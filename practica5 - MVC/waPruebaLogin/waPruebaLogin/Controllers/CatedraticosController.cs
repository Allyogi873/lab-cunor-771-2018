using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using waPruebaLogin.Models;

namespace waPruebaLogin.Controllers
{
    public class CatedraticosController : Controller
    {
        private ctxPrueba db = new ctxPrueba();

        // GET: Catedraticos
        public ActionResult Index()
        {
            return View(db.catedratico.ToList());
        }

        // GET: Catedraticos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catedratico catedratico = db.catedratico.Find(id);
            if (catedratico == null)
            {
                return HttpNotFound();
            }
            return View(catedratico);
        }

        // GET: Catedraticos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catedraticos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(catedratico catedratico)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    var file = Request.Files[0];
                    string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + file.FileName).ToLower();
                    catedratico.dir_foto = archivo;
                    file.SaveAs(Server.MapPath("~/Uploads/catedraticos/" + archivo));
                }

                db.catedratico.Add(catedratico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catedratico);
        }

        // GET: Catedraticos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catedratico catedratico = db.catedratico.Find(id);
            if (catedratico == null)
            {
                return HttpNotFound();
            }
            return View(catedratico);
        }

        // POST: Catedraticos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(catedratico catedratico)
        {
            catedratico original = db.catedratico.Find(catedratico.cod_catedratico);
            if (ModelState.IsValid)
            {
                
                original.nombre_completo = catedratico.nombre_completo;
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    var file = Request.Files[0];
                    string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + file.FileName).ToLower();
                    original.dir_foto = archivo;
                    file.SaveAs(Server.MapPath("~/Uploads/catedraticos/" + archivo));
                }

                db.Entry(original).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(original);
        }

        // GET: Catedraticos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catedratico catedratico = db.catedratico.Find(id);
            if (catedratico == null)
            {
                return HttpNotFound();
            }
            return View(catedratico);
        }

        // POST: Catedraticos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            catedratico catedratico = db.catedratico.Find(id);
            db.catedratico.Remove(catedratico);
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
