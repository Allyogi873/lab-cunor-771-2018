using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using waPruebaLogin.Helpers;
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

        public ActionResult ListaActividades(int id)
        {
            var query = from m in ctx.actividad
                        where m.cod_seccion == id
                        select m;

            ViewBag.seccion = id;
            return View(query.ToList());
        }

        public ActionResult NuevaActividad(int id)
        {
            ViewBag.seccion = id;
            return View();
        }

        [HttpPost]
        public ActionResult NuevaActividad(actividad registro)
        {

            try
            {
                ViewBag.seccion = registro.cod_seccion;
                seccion c = ctx.seccion.Find(registro.cod_seccion);
                registro.cod_curso = c.cod_curso;
                ctx.actividad.Add(registro);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return View();
            }
            return RedirectToAction("ListaActividades", new { id = registro.cod_seccion });
        }

        public ActionResult Notas(int id)
        {
            var estudiantes = (from m in ctx.det_seccion
                               join es in ctx.estudiante on m.cod_estudiante equals es.cod_estudiante
                               where m.cod_seccion == id
                               select es);

            ViewBag.estudiantes = estudiantes;

            var actividades = from m in ctx.actividad
                              where m.cod_seccion == id
                              select m;

            ViewBag.actividades = actividades.ToList();

            seccion sec = ctx.seccion.Find(id);
            ViewBag.cod_seccion = sec.cod_seccion;
            ViewBag.cod_curso = sec.cod_curso;
            
            ViewBag.seccion = sec;

            var notas = from n in ctx.nota
                        where n.cod_seccion == id && n.cod_curso == sec.cod_curso
                        select n;

            ViewBag.notas = notas.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Notas(List<nota> notas)
        {
            foreach (var itm in notas) {
                nota regAnterior = (from m in ctx.nota
                                    where m.cod_curso == itm.cod_curso &&
                                    m.cod_seccion == itm.cod_seccion &&
                                    m.cod_estudiante == itm.cod_estudiante &&
                                    m.cod_actividad == itm.cod_actividad
                                    select m).FirstOrDefault();

                if (regAnterior != null)
                {
                    regAnterior.nota1 = itm.nota1;
                    ctx.Entry(regAnterior).State = System.Data.Entity.EntityState.Modified;
                }
                else {
                    ctx.nota.Add(itm);
                }
            }
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public void Generar(int id) {
            byte[] bPDF = null;
            Convertidor convertidor = new Convertidor();
            MemoryStream ms = new MemoryStream();
            Document doc = new Document(PageSize.LEGAL, 15, 15, 15, 15);
            doc.SetPageSize(iTextSharp.text.PageSize.LEGAL.Rotate());
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Abrimos el archivo
            doc.Open();
            Paragraph titulo = new Paragraph("CUADRO DE NOTAS\n\n\n", _standardFont);
            doc.Add(titulo);
            int nCol = 4;

            //Las actividades de la sección.
            var actividades = from m in ctx.actividad
                              where m.cod_seccion == id
                              select m;

            nCol = nCol + actividades.Count();

            PdfPTable tblNotas = new PdfPTable(nCol);
            tblNotas.WidthPercentage = 100;

            int[] intWidth = new int[nCol];

            intWidth[0] = 4;
            intWidth[1] = 10;

            for (int n = 2; n < (nCol - 2); n++) {
                intWidth[n] = 3;
            }
            intWidth[nCol - 2] = 3;
            intWidth[nCol - 1] = 10;


            tblNotas.SetWidths(intWidth);
            tblNotas.AddCell(new PdfPCell(new Phrase("CARNÉ", _standardFont)));
            tblNotas.AddCell(new PdfPCell(new Phrase("NOMBRES", _standardFont)));

            foreach (var itm in actividades) {
                tblNotas.AddCell(new PdfPCell(new Phrase("" + itm.nombre, _standardFont)));
            }

            tblNotas.AddCell(new PdfPCell(new Phrase("TOTAL", _standardFont)));
            tblNotas.AddCell(new PdfPCell(new Phrase("EN LETRAS", _standardFont)));

            var estudiantes = (from m in ctx.det_seccion
                               join es in ctx.estudiante on m.cod_estudiante equals es.cod_estudiante
                               where m.cod_seccion == id
                               select es);

            foreach (var itm in estudiantes) {
                tblNotas.AddCell(new PdfPCell(new Phrase("" + itm.carne, _standardFont)));
                tblNotas.AddCell(new PdfPCell(new Phrase("" + itm.nombre_completo, _standardFont)));

                var query = from m in ctx.nota
                            where m.cod_estudiante == itm.cod_estudiante &&
                            m.cod_seccion == id
                            orderby m.cod_actividad ascending
                            select m;

                int? total = 0;
                foreach (var nota in query) {
                    tblNotas.AddCell(new PdfPCell(new Phrase("" + nota.nota1, _standardFont)));
                    total += nota.nota1;
                }

                tblNotas.AddCell(new PdfPCell(new Phrase(""+ total, _standardFont)));
                tblNotas.AddCell(new PdfPCell(new Phrase(convertidor.Convertir(""+total,true), _standardFont)));
            }


            doc.Add(tblNotas);


            

            doc.Close();
            bPDF = ms.ToArray();

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + "cuadro.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bPDF);
            Response.End();
        }
    }
}