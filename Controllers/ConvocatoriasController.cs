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
    public class ConvocatoriasController : Controller
    {
        private InstitucionalEntities db = new InstitucionalEntities();

        // GET: Convocatorias
        public ActionResult Index()
        {
            return View(db.Convocatorias.ToList());
        }

        // GET: Convocatorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convocatorias convocatorias = db.Convocatorias.Find(id);
            if (convocatorias == null)
            {
                return HttpNotFound();
            }
            return View(convocatorias);
        }

        // GET: Convocatorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Convocatorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Mensaje,DirigidoA,Fecha")] Convocatorias convocatorias)
        {
            if (ModelState.IsValid)
            {
                db.Convocatorias.Add(convocatorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(convocatorias);
        }

        // GET: Convocatorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convocatorias convocatorias = db.Convocatorias.Find(id);
            if (convocatorias == null)
            {
                return HttpNotFound();
            }
            return View(convocatorias);
        }

        // POST: Convocatorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Mensaje,DirigidoA,Fecha")] Convocatorias convocatorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(convocatorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(convocatorias);
        }

        // GET: Convocatorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Convocatorias convocatorias = db.Convocatorias.Find(id);
            if (convocatorias == null)
            {
                return HttpNotFound();
            }
            return View(convocatorias);
        }

        // POST: Convocatorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Convocatorias convocatorias = db.Convocatorias.Find(id);
            db.Convocatorias.Remove(convocatorias);
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
