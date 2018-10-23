using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using waPrueba5.Models;

namespace waPrueba5.Controllers
{
    public class BlogController : Controller
    {
        ctxPruebas ctx = new ctxPruebas();
        // GET: Blog
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            var entradas = (from m in ctx.entrada
                           orderby m.fec_creacion descending
                           select m).ToList();

            var unaPagina = entradas.ToPagedList(pageNumber, 5);
            ViewBag.pagina = unaPagina;
            return View();
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
