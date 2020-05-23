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
    public class EgresadosController : Controller
    {
        private InstitucionalEntities db = new InstitucionalEntities();

        // GET: Egresados
        public ActionResult Index()
        {
            var egresados = db.Egresados.Include(e => e.Programas).Include(e => e.Personas);
            return View(egresados.ToList());
        }

        // GET: Egresados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Egresados egresados = db.Egresados.Find(id);
            if (egresados == null)
            {
                return HttpNotFound();
            }
            return View(egresados);
        }

        // GET: Egresados/Create
        public ActionResult Create()
        {
            ViewBag.IdPrograma = new SelectList(db.Programas, "Id", "Codigo");
            ViewBag.IdPersona = new SelectList(db.Personas, "Id", "Documento");
            return View();
        }

        // POST: Egresados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdPersona,IdPrograma,FechaEgreso,TarjetaProfesional")] Egresados egresados)
        {
            if (ModelState.IsValid)
            {
                db.Egresados.Add(egresados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPrograma = new SelectList(db.Programas, "Id", "Codigo", egresados.IdPrograma);
            ViewBag.IdPersona = new SelectList(db.Personas, "Id", "Documento", egresados.IdPersona);
            return View(egresados);
        }

        // GET: Egresados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Egresados egresados = db.Egresados.Find(id);
            if (egresados == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPrograma = new SelectList(db.Programas, "Id", "Codigo", egresados.IdPrograma);
            ViewBag.IdPersona = new SelectList(db.Personas, "Id", "Documento", egresados.IdPersona);
            return View(egresados);
        }

        // POST: Egresados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdPersona,IdPrograma,FechaEgreso,TarjetaProfesional")] Egresados egresados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(egresados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPrograma = new SelectList(db.Programas, "Id", "Codigo", egresados.IdPrograma);
            ViewBag.IdPersona = new SelectList(db.Personas, "Id", "Documento", egresados.IdPersona);
            return View(egresados);
        }

        // GET: Egresados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Egresados egresados = db.Egresados.Find(id);
            if (egresados == null)
            {
                return HttpNotFound();
            }
            return View(egresados);
        }

        // POST: Egresados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Egresados egresados = db.Egresados.Find(id);
            db.Egresados.Remove(egresados);
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
