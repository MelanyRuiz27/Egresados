using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EgresadosU.Models;

namespace EgresadosU.Controllers
{
    public class OfertasLaboralesController : Controller
    {
        private InstitucionalEntities db = new InstitucionalEntities();

        // GET: OfertasLaborales
        public ActionResult Index()
        {
            return View(db.OfertasLaborales.ToList());
        }

        // GET: OfertasLaborales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfertasLaborales ofertasLaborales = db.OfertasLaborales.Find(id);
            if (ofertasLaborales == null)
            {
                return HttpNotFound();
            }
            return View(ofertasLaborales);
        }

        // GET: OfertasLaborales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfertasLaborales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Mensaje,FechaInicio,FechaFin,Empresa,Cargo,Actividades,Perfil,Salario")] OfertasLaborales ofertasLaborales)
        {
            if (ModelState.IsValid)
            {
                db.OfertasLaborales.Add(ofertasLaborales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ofertasLaborales);
        }

        // GET: OfertasLaborales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfertasLaborales ofertasLaborales = db.OfertasLaborales.Find(id);
            if (ofertasLaborales == null)
            {
                return HttpNotFound();
            }
            return View(ofertasLaborales);
        }

        // POST: OfertasLaborales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Mensaje,FechaInicio,FechaFin,Empresa,Cargo,Actividades,Perfil,Salario")] OfertasLaborales ofertasLaborales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ofertasLaborales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ofertasLaborales);
        }

        // GET: OfertasLaborales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfertasLaborales ofertasLaborales = db.OfertasLaborales.Find(id);
            if (ofertasLaborales == null)
            {
                return HttpNotFound();
            }
            return View(ofertasLaborales);
        }

        // POST: OfertasLaborales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfertasLaborales ofertasLaborales = db.OfertasLaborales.Find(id);
            db.OfertasLaborales.Remove(ofertasLaborales);
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
