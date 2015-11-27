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
    public class SeguradoController : Controller
    {
        private seguradoraEntities db = new seguradoraEntities();

        // GET: Segurado
        public ActionResult Index()
        {
            var segurado = db.Segurado.Include(s => s.ObjetoSegurado1);
            return View(segurado.ToList());
        }

        // GET: Segurado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segurado segurado = db.Segurado.Find(id);
            if (segurado == null)
            {
                return HttpNotFound();
            }
            return View(segurado);
        }

        // GET: Segurado/Create
        public ActionResult Create()
        {
            ViewBag.Codigo = new SelectList(db.ObjetoSegurado, "Codigo", "TipoAutomovel");
            return View();
        }

        // POST: Segurado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nome,Documento,DataNascimento,Sexo,EstadoCivil,FoneResidencial,FoneCelular,Email,Rua,Numero,Bairro,CEP,Cidade,Estado,BonusAtual,SeguradoraAnterior,NumeroCNH,PrimeiraHabilitacao")] Segurado segurado)
        {
            if (ModelState.IsValid)
            {
                db.Segurado.Add(segurado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigo = new SelectList(db.ObjetoSegurado, "Codigo", "TipoAutomovel", segurado.Codigo);
            return View(segurado);
        }

        // GET: Segurado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segurado segurado = db.Segurado.Find(id);
            if (segurado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo = new SelectList(db.ObjetoSegurado, "Codigo", "TipoAutomovel", segurado.Codigo);
            return View(segurado);
        }

        // POST: Segurado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nome,Documento,DataNascimento,Sexo,EstadoCivil,FoneResidencial,FoneCelular,Email,Rua,Numero,Bairro,CEP,Cidade,Estado,BonusAtual,SeguradoraAnterior,NumeroCNH,PrimeiraHabilitacao")] Segurado segurado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(segurado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo = new SelectList(db.ObjetoSegurado, "Codigo", "TipoAutomovel", segurado.Codigo);
            return View(segurado);
        }

        // GET: Segurado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segurado segurado = db.Segurado.Find(id);
            if (segurado == null)
            {
                return HttpNotFound();
            }
            return View(segurado);
        }

        // POST: Segurado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Segurado segurado = db.Segurado.Find(id);
            db.Segurado.Remove(segurado);
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
