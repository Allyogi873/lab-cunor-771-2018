using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcEjemploProgra2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult HolaMundo() {
            List<Persona> lstPersonas = new List<Persona>();
            lstPersonas.Add(new Persona("1", "Jonathan Ramirez"));
            lstPersonas.Add(new Persona("2", "Angel Ruiz"));
            lstPersonas.Add(new Persona("3", "David Montoya"));

            ViewBag.items = lstPersonas.ToArray();

            return View();
        }

        public class Persona {
            public Persona(string no_persona, string nombre) {
                this.nombre = nombre;
                this.no_persona = no_persona;
            }

            public string no_persona { get; set; }
            public string nombre { get; set; }
        }
    }
}