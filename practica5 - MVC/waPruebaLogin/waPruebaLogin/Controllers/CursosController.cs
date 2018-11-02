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
    public class CursosController : Controller
    {
        private ctxPrueba db = new ctxPrueba();

        // GET: Cursos
        public ActionResult Index()
        {
            var cursos = db.cursos.Include(c => c.carrera).Include(c => c.ciclo).Include(c => c.pensum);
            return View(cursos.ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cursos cursos = db.cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            ViewBag.cod_carrera = new SelectList(db.carrera, "cod_carrera", "nombre");
            ViewBag.cod_ciclo = new SelectList(db.ciclo, "cod_ciclo", "nombre");
            ViewBag.cod_pensum = new SelectList(db.pensum, "cod_pensum", "nombre");
            return View();
        }

        // POST: Cursos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_curso,cod_carrera,cod_ciclo,cod_pensum,nombre,creditos,prerequisitos")] cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.cursos.Add(cursos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_carrera = new SelectList(db.carrera, "cod_carrera", "nombre", cursos.cod_carrera);
            ViewBag.cod_ciclo = new SelectList(db.ciclo, "cod_ciclo", "nombre", cursos.cod_ciclo);
            ViewBag.cod_pensum = new SelectList(db.pensum, "cod_pensum", "nombre", cursos.cod_pensum);
            return View(cursos);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cursos cursos = db.cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_carrera = new SelectList(db.carrera, "cod_carrera", "nombre", cursos.cod_carrera);
            ViewBag.cod_ciclo = new SelectList(db.ciclo, "cod_ciclo", "nombre", cursos.cod_ciclo);
            ViewBag.cod_pensum = new SelectList(db.pensum, "cod_pensum", "nombre", cursos.cod_pensum);
            return View(cursos);
        }

        // POST: Cursos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_curso,cod_carrera,cod_ciclo,cod_pensum,nombre,creditos,prerequisitos")] cursos cursos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_carrera = new SelectList(db.carrera, "cod_carrera", "nombre", cursos.cod_carrera);
            ViewBag.cod_ciclo = new SelectList(db.ciclo, "cod_ciclo", "nombre", cursos.cod_ciclo);
            ViewBag.cod_pensum = new SelectList(db.pensum, "cod_pensum", "nombre", cursos.cod_pensum);
            return View(cursos);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cursos cursos = db.cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cursos cursos = db.cursos.Find(id);
            db.cursos.Remove(cursos);
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
