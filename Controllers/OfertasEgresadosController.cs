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
    public class OfertasEgresadosController : Controller
    {
        private InstitucionalEntities db = new InstitucionalEntities();

        // GET: OfertasEgresados
        public ActionResult Index()
        {
            var ofertasEgresados = db.OfertasEgresados.Include(o => o.Egresados).Include(o => o.OfertasLaborales);
            return View(ofertasEgresados.ToList());
        }

        // GET: OfertasEgresados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfertasEgresados ofertasEgresados = db.OfertasEgresados.Find(id);
            if (ofertasEgresados == null)
            {
                return HttpNotFound();
            }
            return View(ofertasEgresados);
        }

        // GET: OfertasEgresados/Create
        public ActionResult Create()
        {
            ViewBag.IdEgresado = new SelectList(db.Egresados, "Id", "TarjetaProfesional");
            ViewBag.IdOfertaLaboral = new SelectList(db.OfertasLaborales, "Id", "Titulo");
            return View();
        }

        // POST: OfertasEgresados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdOfertaLaboral,IdEgresado")] OfertasEgresados ofertasEgresados)
        {
            if (ModelState.IsValid)
            {
                db.OfertasEgresados.Add(ofertasEgresados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEgresado = new SelectList(db.Egresados, "Id", "TarjetaProfesional", ofertasEgresados.IdEgresado);
            ViewBag.IdOfertaLaboral = new SelectList(db.OfertasLaborales, "Id", "Titulo", ofertasEgresados.IdOfertaLaboral);
            return View(ofertasEgresados);
        }

        // GET: OfertasEgresados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfertasEgresados ofertasEgresados = db.OfertasEgresados.Find(id);
            if (ofertasEgresados == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEgresado = new SelectList(db.Egresados, "Id", "TarjetaProfesional", ofertasEgresados.IdEgresado);
            ViewBag.IdOfertaLaboral = new SelectList(db.OfertasLaborales, "Id", "Titulo", ofertasEgresados.IdOfertaLaboral);
            return View(ofertasEgresados);
        }

        // POST: OfertasEgresados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdOfertaLaboral,IdEgresado")] OfertasEgresados ofertasEgresados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ofertasEgresados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEgresado = new SelectList(db.Egresados, "Id", "TarjetaProfesional", ofertasEgresados.IdEgresado);
            ViewBag.IdOfertaLaboral = new SelectList(db.OfertasLaborales, "Id", "Titulo", ofertasEgresados.IdOfertaLaboral);
            return View(ofertasEgresados);
        }

        // GET: OfertasEgresados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfertasEgresados ofertasEgresados = db.OfertasEgresados.Find(id);
            if (ofertasEgresados == null)
            {
                return HttpNotFound();
            }
            return View(ofertasEgresados);
        }

        // POST: OfertasEgresados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfertasEgresados ofertasEgresados = db.OfertasEgresados.Find(id);
            db.OfertasEgresados.Remove(ofertasEgresados);
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
