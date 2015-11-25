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
    public class ObjetoSeguradoesController : Controller
    {
        private seguradoraEntities db = new seguradoraEntities();

        // GET: ObjetoSeguradoes
        public ActionResult Index()
        {
            var objetoSegurado = db.ObjetoSegurado.Include(o => o.Marca1).Include(o => o.Modelo1).Include(o => o.Segurado1).Include(o => o.Segurado2);
            return View(objetoSegurado.ToList());
        }

        // GET: ObjetoSeguradoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjetoSegurado objetoSegurado = db.ObjetoSegurado.Find(id);
            if (objetoSegurado == null)
            {
                return HttpNotFound();
            }
            return View(objetoSegurado);
        }

        // GET: ObjetoSeguradoes/Create
        public ActionResult Create()
        {
            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo");
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo");
            ViewBag.Segurado = new SelectList(db.Segurado, "Codigo", "Nome");
            ViewBag.Codigo = new SelectList(db.Segurado, "Codigo", "Nome");
            return View();
        }

        // POST: ObjetoSeguradoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Segurado,TipoAutomovel,CodigoFipe,Categoria,Marca,Modelo,Potencia,AnoDeFabricacao,AnoModelo,Chassi,Placa,QtdPortas,NroPassageiros,CepPernoite,Renavam,ValorFipe,ValorCotado")] ObjetoSegurado objetoSegurado)
        {
            if (ModelState.IsValid)
            {
                db.ObjetoSegurado.Add(objetoSegurado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo", objetoSegurado.Marca);
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo", objetoSegurado.Modelo);
            ViewBag.Segurado = new SelectList(db.Segurado, "Codigo", "Nome", objetoSegurado.Segurado);
            ViewBag.Codigo = new SelectList(db.Segurado, "Codigo", "Nome", objetoSegurado.Codigo);
            return View(objetoSegurado);
        }

        // GET: ObjetoSeguradoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjetoSegurado objetoSegurado = db.ObjetoSegurado.Find(id);
            if (objetoSegurado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo", objetoSegurado.Marca);
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo", objetoSegurado.Modelo);
            ViewBag.Segurado = new SelectList(db.Segurado, "Codigo", "Nome", objetoSegurado.Segurado);
            ViewBag.Codigo = new SelectList(db.Segurado, "Codigo", "Nome", objetoSegurado.Codigo);
            return View(objetoSegurado);
        }

        // POST: ObjetoSeguradoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Segurado,TipoAutomovel,CodigoFipe,Categoria,Marca,Modelo,Potencia,AnoDeFabricacao,AnoModelo,Chassi,Placa,QtdPortas,NroPassageiros,CepPernoite,Renavam,ValorFipe,ValorCotado")] ObjetoSegurado objetoSegurado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objetoSegurado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo", objetoSegurado.Marca);
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo", objetoSegurado.Modelo);
            ViewBag.Segurado = new SelectList(db.Segurado, "Codigo", "Nome", objetoSegurado.Segurado);
            ViewBag.Codigo = new SelectList(db.Segurado, "Codigo", "Nome", objetoSegurado.Codigo);
            return View(objetoSegurado);
        }

        // GET: ObjetoSeguradoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjetoSegurado objetoSegurado = db.ObjetoSegurado.Find(id);
            if (objetoSegurado == null)
            {
                return HttpNotFound();
            }
            return View(objetoSegurado);
        }

        // POST: ObjetoSeguradoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObjetoSegurado objetoSegurado = db.ObjetoSegurado.Find(id);
            db.ObjetoSegurado.Remove(objetoSegurado);
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
