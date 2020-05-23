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
    public class DivisionesPoliticasController : Controller
    {
        private InstitucionalEntities db = new InstitucionalEntities();

        // GET: DivisionesPoliticas
        public ActionResult Index()
        {
            var divisionesPoliticas = db.DivisionesPoliticas.Include(d => d.Niveles);
            return View(divisionesPoliticas.ToList());
        }

        // GET: DivisionesPoliticas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DivisionesPoliticas divisionesPoliticas = db.DivisionesPoliticas.Find(id);
            if (divisionesPoliticas == null)
            {
                return HttpNotFound();
            }
            return View(divisionesPoliticas);
        }

        // GET: DivisionesPoliticas/Create
        public ActionResult Create()
        {
            ViewBag.IdNivel = new SelectList(db.Niveles, "Id", "Descripcion");
            return View();
        }

        // POST: DivisionesPoliticas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdNivel,Codigo,Nombre,IdPadre,CodigoAlterno")] DivisionesPoliticas divisionesPoliticas)
        {
            if (ModelState.IsValid)
            {
                db.DivisionesPoliticas.Add(divisionesPoliticas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdNivel = new SelectList(db.Niveles, "Id", "Descripcion", divisionesPoliticas.IdNivel);
            return View(divisionesPoliticas);
        }

        // GET: DivisionesPoliticas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DivisionesPoliticas divisionesPoliticas = db.DivisionesPoliticas.Find(id);
            if (divisionesPoliticas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdNivel = new SelectList(db.Niveles, "Id", "Descripcion", divisionesPoliticas.IdNivel);
            return View(divisionesPoliticas);
        }

        // POST: DivisionesPoliticas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdNivel,Codigo,Nombre,IdPadre,CodigoAlterno")] DivisionesPoliticas divisionesPoliticas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(divisionesPoliticas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdNivel = new SelectList(db.Niveles, "Id", "Descripcion", divisionesPoliticas.IdNivel);
            return View(divisionesPoliticas);
        }

        // GET: DivisionesPoliticas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DivisionesPoliticas divisionesPoliticas = db.DivisionesPoliticas.Find(id);
            if (divisionesPoliticas == null)
            {
                return HttpNotFound();
            }
            return View(divisionesPoliticas);
        }

        // POST: DivisionesPoliticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DivisionesPoliticas divisionesPoliticas = db.DivisionesPoliticas.Find(id);
            db.DivisionesPoliticas.Remove(divisionesPoliticas);
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
