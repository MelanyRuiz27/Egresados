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
    public class PersonasController : Controller
    {
        private InstitucionalEntities db = new InstitucionalEntities();

        // GET: Personas
        public ActionResult Index()
        {
            var personas = db.Personas.Include(p => p.Estados).Include(p => p.TiposDocumentos);
            return View(personas.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personas personas = db.Personas.Find(id);
            if (personas == null)
            {
                return HttpNotFound();
            }
            return View(personas);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.IdEstadoSexo = new SelectList(db.Estados, "Id", "Descripcion");
            ViewBag.IdTipoDocumento = new SelectList(db.TiposDocumentos, "Id", "TipoDocumentos");
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdTipoDocumento,Documento,Nombres,Apellidos,Correo,CorreoAlterno,IdEstadoSexo")] Personas personas)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(personas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstadoSexo = new SelectList(db.Estados, "Id", "Descripcion", personas.IdEstadoSexo);
            ViewBag.IdTipoDocumento = new SelectList(db.TiposDocumentos, "Id", "TipoDocumentos", personas.IdTipoDocumento);
            return View(personas);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personas personas = db.Personas.Find(id);
            if (personas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstadoSexo = new SelectList(db.Estados, "Id", "Descripcion", personas.IdEstadoSexo);
            ViewBag.IdTipoDocumento = new SelectList(db.TiposDocumentos, "Id", "TipoDocumentos", personas.IdTipoDocumento);
            return View(personas);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdTipoDocumento,Documento,Nombres,Apellidos,Correo,CorreoAlterno,IdEstadoSexo")] Personas personas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstadoSexo = new SelectList(db.Estados, "Id", "Descripcion", personas.IdEstadoSexo);
            ViewBag.IdTipoDocumento = new SelectList(db.TiposDocumentos, "Id", "TipoDocumentos", personas.IdTipoDocumento);
            return View(personas);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personas personas = db.Personas.Find(id);
            if (personas == null)
            {
                return HttpNotFound();
            }
            return View(personas);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personas personas = db.Personas.Find(id);
            db.Personas.Remove(personas);
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
