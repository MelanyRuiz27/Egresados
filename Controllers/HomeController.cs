using EgresadosU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgresadosU.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Directorios()
        {

            return View();
        }
        public ActionResult RedesSociales()
        {

            return View();
        }

        public ActionResult Mapa()
        {

            return View();
        }
        public ActionResult Convenios()
        {

            return View();
        }
        //Get SubirArhivo
        public ActionResult SubirArchivo()
        {
            return View();
        }

        public FileResult DescargarHV()
        {
            var ruta = Server.MapPath("~/HV/Hoja_De_Vida.docx");
            return File(ruta, "application/doc", "Hoja_De_Vida.doc");
            //return View();
        }

        //Post SubirArchivo
        [HttpPost]
        public ActionResult SubirArchivo(HttpPostedFileBase file)
        {
            SubirArchivoModelo modelo = new SubirArchivoModelo();
            if (file != null)
            {
                String ruta = Server.MapPath("~/Temp/");
                ruta += file.FileName;
                modelo.SubirArchivo(ruta, file);
                ViewBag.Error = modelo.error;
                ViewBag.Correcto = modelo.Confirmacion;
            }
            return View();
        }
    }
}