using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using waPruebaLogin.Models;

namespace waPruebaLogin.Controllers
{
    public class SeccionesController : Controller
    {
        int codCatedratico = 2;
        ctxPrueba ctx = new ctxPrueba();
        // GET: Secciones
        public ActionResult Index()
        {
            var query = (from m in ctx.seccion
                         where m.cod_catedratico == codCatedratico
                         select m);

            return View(query.ToList());
        }

        public ActionResult ListaActividades(int id) {
            var query = from m in ctx.actividad
                        where m.cod_seccion == id
                        select m;

            ViewBag.seccion = id;
            return View(query.ToList());
        }

        public ActionResult NuevaActividad(int id) {
            ViewBag.seccion = id;
            return View();
        }

        [HttpPost]
        public ActionResult NuevaActividad(actividad registro) {

            try {
                ViewBag.seccion = registro.cod_seccion;
                seccion c = ctx.seccion.Find(registro.cod_seccion);
                registro.cod_curso = c.cod_curso;
                ctx.actividad.Add(registro);
                ctx.SaveChanges();
            }
            catch (Exception ex) {
                return View();
            }
            return RedirectToAction("ListaActividades", new { id = registro.cod_seccion });
        }

        public ActionResult Notas(int id) {
            var estudiantes = (from m in ctx.det_seccion
                              join es in ctx.estudiante on m.cod_estudiante equals es.cod_estudiante
                              where m.cod_seccion == id
                              select new {Codigo = es.cod_estudiante, Carne = es.carne, Nombre = es.nombre_completo}).ToList<Object>();

            ViewBag.estudiantes = estudiantes;

            var actividades = from m in ctx.actividad
                              where m.cod_seccion == id
                              select m;

            ViewBag.actividades = actividades.ToList();
            return View();
        }
    }
}