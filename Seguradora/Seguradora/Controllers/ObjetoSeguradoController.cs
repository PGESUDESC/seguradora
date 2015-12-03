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
    public class ObjetoSeguradoController : Controller
    {
        private seguradoraEntities db = new seguradoraEntities();
        private PopulateController pc = new PopulateController();

        // GET: ObjetoSegurado
        public ActionResult Index()
        {
            var objetoSegurado = db.ObjetoSegurado.Include(o => o.Marca1).Include(o => o.Modelo1).Include(o => o.Segurado1).Include(o => o.Segurado2);
            return View(objetoSegurado.ToList());
        }

        // GET: ObjetoSegurado/Details/5
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

        // GET: ObjetoSegurado/Create
        public ActionResult Create()
        {
            ViewBag.Segurados = pc.PopulaSeguradosDropDownList();
            ViewBag.Marcas = pc.PopulaMarcasDropDownList();
            ViewBag.Modelos = pc.PopulaModelosDropDownList();
            ViewBag.AnoModelos = pc.PopulaAnoModelosDropDownList();
            ViewBag.Veiculos = pc.PopulaVeiculosDropDownList();
            ViewBag.Codigo = new SelectList(db.Segurado, "Codigo", "Nome");
            return View();
        }

        // POST: ObjetoSegurado/Create
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

            ViewBag.Segurados = pc.PopulaSeguradosDropDownList(objetoSegurado.Segurado);
            ViewBag.Marcas = pc.PopulaMarcasDropDownList(objetoSegurado.Marca);
            ViewBag.Modelos = pc.PopulaModelosDropDownList(objetoSegurado.Modelo);
            ViewBag.AnoModelos = pc.PopulaAnoModelosDropDownList();
            ViewBag.Veiculos = pc.PopulaVeiculosDropDownList();
            ViewBag.Codigo = new SelectList(db.Segurado, "Codigo", "Nome", objetoSegurado.Codigo);
            return View(objetoSegurado);
        }

        // GET: ObjetoSegurado/Edit/5
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
            ViewBag.Segurados = pc.PopulaSeguradosDropDownList();
            ViewBag.Marcas = pc.PopulaMarcasDropDownList();
            ViewBag.Modelos = pc.PopulaModelosDropDownList();
            ViewBag.Codigo = new SelectList(db.Segurado, "Codigo", "Nome", objetoSegurado.Codigo);
            return View(objetoSegurado);
        }

        // POST: ObjetoSegurado/Edit/5
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

            ViewBag.Segurados = pc.PopulaSeguradosDropDownList(objetoSegurado.Segurado);
            ViewBag.Marcas = pc.PopulaMarcasDropDownList(objetoSegurado.Marca);
            ViewBag.Modelos = pc.PopulaModelosDropDownList(objetoSegurado.Modelo);
            ViewBag.Codigo = new SelectList(db.Segurado, "Codigo", "Nome", objetoSegurado.Codigo);
            return View(objetoSegurado);
        }

        // GET: ObjetoSegurado/Delete/5
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

        // POST: ObjetoSegurado/Delete/5
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
