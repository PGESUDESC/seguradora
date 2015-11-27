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
    public class SinistroController : Controller
    {
        private seguradoraEntities db = new seguradoraEntities();

        // GET: Sinistro
        public ActionResult Index()
        {
            var sinistro = db.Sinistro.Include(s => s.Apolice);
            return View(sinistro.ToList());
        }

        // GET: Sinistro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinistro sinistro = db.Sinistro.Find(id);
            if (sinistro == null)
            {
                return HttpNotFound();
            }
            return View(sinistro);
        }

        // GET: Sinistro/Create
        public ActionResult Create()
        {
            ViewBag.NroContrato = new SelectList(db.Apolice, "ID", "ID");
            return View();
        }

        // POST: Sinistro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,NroContrato,NroBO,Avarias,DescricaoOcorrido")] Sinistro sinistro)
        {
            if (ModelState.IsValid)
            {
                db.Sinistro.Add(sinistro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NroContrato = new SelectList(db.Apolice, "ID", "ID", sinistro.NroContrato);
            return View(sinistro);
        }

        // GET: Sinistro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinistro sinistro = db.Sinistro.Find(id);
            if (sinistro == null)
            {
                return HttpNotFound();
            }
            ViewBag.NroContrato = new SelectList(db.Apolice, "ID", "ID", sinistro.NroContrato);
            return View(sinistro);
        }

        // POST: Sinistro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,NroContrato,NroBO,Avarias,DescricaoOcorrido")] Sinistro sinistro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinistro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NroContrato = new SelectList(db.Apolice, "ID", "ID", sinistro.NroContrato);
            return View(sinistro);
        }

        // GET: Sinistro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sinistro sinistro = db.Sinistro.Find(id);
            if (sinistro == null)
            {
                return HttpNotFound();
            }
            return View(sinistro);
        }

        // POST: Sinistro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sinistro sinistro = db.Sinistro.Find(id);
            db.Sinistro.Remove(sinistro);
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
