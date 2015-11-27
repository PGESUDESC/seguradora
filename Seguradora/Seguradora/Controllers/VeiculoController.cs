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
    public class VeiculoController : Controller
    {
        private seguradoraEntities db = new seguradoraEntities();

        // GET: Veiculo
        public ActionResult Index()
        {
            var veiculo = db.Veiculo.Include(v => v.AnoModelo1).Include(v => v.Marca1).Include(v => v.Modelo1);
            return View(veiculo.ToList());
        }

        // GET: Veiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: Veiculo/Create
        public ActionResult Create()
        {
            ViewBag.AnoModelo = new SelectList(db.AnoModelo, "ID", "Codigo");
            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo");
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo");
            return View();
        }

        // POST: Veiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Valor,Marca,Modelo,AnoModelo,Combustivel,CodigoFipe,MesReferencia,TipoVeiculo,SiglaCombustivel")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Veiculo.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnoModelo = new SelectList(db.AnoModelo, "ID", "Codigo", veiculo.AnoModelo);
            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo", veiculo.Marca);
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo", veiculo.Modelo);
            return View(veiculo);
        }

        // GET: Veiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnoModelo = new SelectList(db.AnoModelo, "ID", "Codigo", veiculo.AnoModelo);
            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo", veiculo.Marca);
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo", veiculo.Modelo);
            return View(veiculo);
        }

        // POST: Veiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Valor,Marca,Modelo,AnoModelo,Combustivel,CodigoFipe,MesReferencia,TipoVeiculo,SiglaCombustivel")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnoModelo = new SelectList(db.AnoModelo, "ID", "Codigo", veiculo.AnoModelo);
            ViewBag.Marca = new SelectList(db.Marca, "ID", "Codigo", veiculo.Marca);
            ViewBag.Modelo = new SelectList(db.Modelo, "ID", "Codigo", veiculo.Modelo);
            return View(veiculo);
        }

        // GET: Veiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veiculo veiculo = db.Veiculo.Find(id);
            db.Veiculo.Remove(veiculo);
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
