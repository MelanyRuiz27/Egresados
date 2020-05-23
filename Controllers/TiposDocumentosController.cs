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
    public class TiposDocumentosController : Controller
    {
        private InstitucionalEntities db = new InstitucionalEntities();

        // GET: TiposDocumentos
        public ActionResult Index()
        {
            return View(db.TiposDocumentos.ToList());
        }

        // GET: TiposDocumentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposDocumentos tiposDocumentos = db.TiposDocumentos.Find(id);
            if (tiposDocumentos == null)
            {
                return HttpNotFound();
            }
            return View(tiposDocumentos);
        }

        // GET: TiposDocumentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposDocumentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TipoDocumentos")] TiposDocumentos tiposDocumentos)
        {
            if (ModelState.IsValid)
            {
                db.TiposDocumentos.Add(tiposDocumentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposDocumentos);
        }

        // GET: TiposDocumentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposDocumentos tiposDocumentos = db.TiposDocumentos.Find(id);
            if (tiposDocumentos == null)
            {
                return HttpNotFound();
            }
            return View(tiposDocumentos);
        }

        // POST: TiposDocumentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TipoDocumentos")] TiposDocumentos tiposDocumentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposDocumentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposDocumentos);
        }

        // GET: TiposDocumentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposDocumentos tiposDocumentos = db.TiposDocumentos.Find(id);
            if (tiposDocumentos == null)
            {
                return HttpNotFound();
            }
            return View(tiposDocumentos);
        }

        // POST: TiposDocumentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TiposDocumentos tiposDocumentos = db.TiposDocumentos.Find(id);
            db.TiposDocumentos.Remove(tiposDocumentos);
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
