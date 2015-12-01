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
    public class CotacaoController : Controller
    {
        private seguradoraEntities db = new seguradoraEntities();
        private PopulateController pc = new PopulateController();

        // GET: Cotacao
        public ActionResult Index()
        {
            return View(db.Cotacao.ToList());
        }

        // GET: Cotacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotacao cotacao = db.Cotacao.Find(id);
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            return View(cotacao);
        }

        // GET: Cotacao/Create
        public ActionResult Create()
        {
            ViewBag.Segurados = pc.PopulaSeguradosDropDownList();
            ViewBag.Marcas = pc.PopulaMarcasDropDownList();
            ViewBag.Modelos = pc.PopulaModelosDropDownList();
            ViewBag.AnoModelos = pc.PopulaAnoModelosDropDownList();
            ViewBag.Veiculos = pc.PopulaVeiculosDropDownList();
            return View();
        }

        // POST: Cotacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Tipo,NumeroAditivo,Modalidade,DataInicial,DataFinal,Segurado,Marca,Modelo,Veiculo,AnoModelo")] Cotacao cotacao)
        {
            if (ModelState.IsValid)
            {
                db.Cotacao.Add(cotacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cotacao);
        }

        // GET: Cotacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotacao cotacao = db.Cotacao.Find(id);
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.Segurados = pc.PopulaSeguradosDropDownList(cotacao.Segurado);
            ViewBag.Marcas = pc.PopulaMarcasDropDownList(cotacao.Marca);
            ViewBag.Modelos = pc.PopulaModelosDropDownList(cotacao.Modelo);
            ViewBag.AnoModelos = pc.PopulaAnoModelosDropDownList(cotacao.AnoModelo);
            ViewBag.Veiculos = pc.PopulaVeiculosDropDownList(cotacao.Veiculo);

            return View(cotacao);
        }

        // POST: Cotacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Tipo,NumeroAditivo,Modalidade,DataInicial,DataFinal")] Cotacao cotacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cotacao);
        }

        // GET: Cotacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cotacao cotacao = db.Cotacao.Find(id);
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            return View(cotacao);
        }

        // POST: Cotacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cotacao cotacao = db.Cotacao.Find(id);
            db.Cotacao.Remove(cotacao);
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
