using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Seguradora;

namespace Seguradora.Controllers
{
    public class AnoModeloController : Controller
    {
        private seguradoraEntities db = new seguradoraEntities();

        // GET: AnoModelo
        public ActionResult Index()
        {
            var anoModelo = db.AnoModelo.Include(a => a.Marca1).Include(a => a.Modelo1);
            return View(anoModelo.ToList());
        }

        // GET: AnoModelo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnoModelo anoModelo = db.AnoModelo.Find(id);
            if (anoModelo == null)
            {
                return HttpNotFound();
            }
            return View(anoModelo);
        }

        // GET: AnoModelo/Create
        public ActionResult Create()
        {
            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo");
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo");
            return View();
        }

        // POST: AnoModelo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Codigo,Descricao,Marca,Modelo,TipoVeiculo")] AnoModelo anoModelo)
        {
            if (ModelState.IsValid)
            {
                db.AnoModelo.Add(anoModelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo", anoModelo.Marca);
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo", anoModelo.Modelo);
            return View(anoModelo);
        }

        // GET: AnoModelo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnoModelo anoModelo = db.AnoModelo.Find(id);
            if (anoModelo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo", anoModelo.Marca);
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo", anoModelo.Modelo);
            return View(anoModelo);
        }

        // POST: AnoModelo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Codigo,Descricao,Marca,Modelo,TipoVeiculo")] AnoModelo anoModelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anoModelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo", anoModelo.Marca);
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo", anoModelo.Modelo);
            return View(anoModelo);
        }

        // GET: AnoModelo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnoModelo anoModelo = db.AnoModelo.Find(id);
            if (anoModelo == null)
            {
                return HttpNotFound();
            }
            return View(anoModelo);
        }

        // POST: AnoModelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnoModelo anoModelo = db.AnoModelo.Find(id);
            db.AnoModelo.Remove(anoModelo);
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
