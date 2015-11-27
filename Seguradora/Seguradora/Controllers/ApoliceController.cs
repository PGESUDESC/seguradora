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
    public class ApoliceController : Controller
    {
        private seguradoraEntities db = new seguradoraEntities();

        // GET: Apolice
        public ActionResult Index()
        {
            var apolice = db.Apolice.Include(a => a.Cotacao1).Include(a => a.ObjetoSegurado1).Include(a => a.Segurado1);
            return View(apolice.ToList());
        }

        // GET: Apolice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apolice apolice = db.Apolice.Find(id);
            if (apolice == null)
            {
                return HttpNotFound();
            }
            return View(apolice);
        }

        // GET: Apolice/Create
        public ActionResult Create()
        {
            ViewBag.Cotacao = new SelectList(db.Cotacao, "Codigo", "Codigo");
            ViewBag.ObjetoSegurado = new SelectList(db.ObjetoSegurado, "Codigo", "TipoAutomovel");
            ViewBag.Segurado = new SelectList(db.Segurado, "Codigo", "Nome");
            return View();
        }

        // POST: Apolice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Cotacao,NroAditivo,Segurado,ObjetoSegurado,DataVigencia,DataPrimeiraParcela")] Apolice apolice)
        {
            if (ModelState.IsValid)
            {
                db.Apolice.Add(apolice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cotacao = new SelectList(db.Cotacao, "Codigo", "Codigo", apolice.Cotacao);
            ViewBag.ObjetoSegurado = new SelectList(db.ObjetoSegurado, "Codigo", "TipoAutomovel", apolice.ObjetoSegurado);
            ViewBag.Segurado = new SelectList(db.Segurado, "Codigo", "Nome", apolice.Segurado);
            return View(apolice);
        }

        // GET: Apolice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apolice apolice = db.Apolice.Find(id);
            if (apolice == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cotacao = new SelectList(db.Cotacao, "Codigo", "Codigo", apolice.Cotacao);
            ViewBag.ObjetoSegurado = new SelectList(db.ObjetoSegurado, "Codigo", "TipoAutomovel", apolice.ObjetoSegurado);
            ViewBag.Segurado = new SelectList(db.Segurado, "Codigo", "Nome", apolice.Segurado);
            return View(apolice);
        }

        // POST: Apolice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Cotacao,NroAditivo,Segurado,ObjetoSegurado,DataVigencia,DataPrimeiraParcela")] Apolice apolice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apolice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cotacao = new SelectList(db.Cotacao, "Codigo", "Codigo", apolice.Cotacao);
            ViewBag.ObjetoSegurado = new SelectList(db.ObjetoSegurado, "Codigo", "TipoAutomovel", apolice.ObjetoSegurado);
            ViewBag.Segurado = new SelectList(db.Segurado, "Codigo", "Nome", apolice.Segurado);
            return View(apolice);
        }

        // GET: Apolice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apolice apolice = db.Apolice.Find(id);
            if (apolice == null)
            {
                return HttpNotFound();
            }
            return View(apolice);
        }

        // POST: Apolice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apolice apolice = db.Apolice.Find(id);
            db.Apolice.Remove(apolice);
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
