using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using waPrueba5.Models;
using PagedList.Mvc;
using PagedList;

namespace waPrueba5.Controllers
{
    public class FacturasController : Controller
    {
        ctxPruebas ctx = new ctxPruebas();
        // GET: Facturas
        public ActionResult Index(int? page, string busqueda)
        {
            var pageNumber = page ?? 1;

            var query = ctx.factura.ToList();

            if (busqueda != "" && busqueda!= null) {
                query = query.Where(a => a.descripcion.Contains(busqueda)).ToList();
            }

            var unaPagina = query.ToPagedList(pageNumber, 5);
            ViewBag.pagina = unaPagina;
            return View();
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int id)
        {
            factura query = ctx.factura.Find(id);
            return View(query);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            var clientes = (from m in ctx.cliente
                           select new SelectListItem { Value = "" + m.cod_cliente, Text = m.nombres + " " + m.apellidos }).ToList();

            ViewBag.clientes = clientes;

            var productos = (from m in ctx.producto
                             select m);

            ViewBag.productos = productos;
            return View();
        }

        // POST: Facturas/Create
        [HttpPost]
        public ActionResult Create(factura factura)
        {
            try
            {
                ctx.factura.Add(factura);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult getClientes(String busqueda) {
            var query = from m in ctx.cliente
                        where m.nit.Contains(busqueda) || m.nombres.Contains(busqueda)
                        select new { m.cod_cliente, m.nit, m.nombres, m.apellidos, m.direccion };

            return Json(query.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Facturas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Facturas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
