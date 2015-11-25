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
    public class AditamentoesController : Controller
    {
        private seguradoraEntities db = new seguradoraEntities();

        // GET: Aditamentoes
        public ActionResult Index()
        {
            var aditamento = db.Aditamento.Include(a => a.Marca1).Include(a => a.Modelo1);
            return View(aditamento.ToList());
        }

        // GET: Aditamentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aditamento aditamento = db.Aditamento.Find(id);
            if (aditamento == null)
            {
                return HttpNotFound();
            }
            return View(aditamento);
        }

        // GET: Aditamentoes/Create
        public ActionResult Create()
        {
            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo");
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo");
            return View();
        }

        // POST: Aditamentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nome,Descriao,Categoria,Marca,Modelo,AnoFabricacao")] Aditamento aditamento)
        {
            if (ModelState.IsValid)
            {
                db.Aditamento.Add(aditamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo", aditamento.Marca);
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo", aditamento.Modelo);
            return View(aditamento);
        }

        // GET: Aditamentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aditamento aditamento = db.Aditamento.Find(id);
            if (aditamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo", aditamento.Marca);
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo", aditamento.Modelo);
            return View(aditamento);
        }

        // POST: Aditamentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nome,Descriao,Categoria,Marca,Modelo,AnoFabricacao")] Aditamento aditamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aditamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo", aditamento.Marca);
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo", aditamento.Modelo);
            return View(aditamento);
        }

        // GET: Aditamentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aditamento aditamento = db.Aditamento.Find(id);
            if (aditamento == null)
            {
                return HttpNotFound();
            }
            return View(aditamento);
        }

        // POST: Aditamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aditamento aditamento = db.Aditamento.Find(id);
            db.Aditamento.Remove(aditamento);
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
