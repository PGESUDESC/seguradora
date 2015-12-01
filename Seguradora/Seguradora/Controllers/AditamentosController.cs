﻿using System;
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
    public class AditamentosController : Controller
    {
        private seguradoraEntities db = new seguradoraEntities();

        // GET: Aditamentos
        public ActionResult Index()
        {
            var aditamento = db.Aditamento.Include(a => a.Marca1).Include(a => a.Modelo1);
            return View(aditamento.ToList());
        }

        // GET: Aditamentos/Details/5
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

        // GET: Aditamentos/Create
        public ActionResult Create()
        {
            PopulaMarcasDropDownList();
            PopulaModelosDropDownList();
            return View();
        }

        private void PopulaModelosDropDownList(object selectedItem = null)
        {
            if (selectedItem != null)
            {
                var query = db.Modelo.ToList().Select(c => new { c.ID, c.Descricao });
                ViewBag.Modelos = new SelectList(query.AsEnumerable(), "ID", "Descricao", selectedItem);
            }
            else
            {
                var query = db.Modelo.ToList().Where(p => p.ID == 1).Select(c => new { c.ID, c.Descricao });
                ViewBag.Modelos = new SelectList(query.AsEnumerable(), "ID", "Descricao", selectedItem);
            }
        }
        private void PopulaMarcasDropDownList(object selectedItem = null)
        {
            var query = db.Marca.ToList().Select(c => new { c.ID, c.Descricao });
            ViewBag.Marcas = new SelectList(query.AsEnumerable(), "ID", "Descricao", selectedItem);
        }

        // POST: Aditamentos/Create
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

        // GET: Aditamentos/Edit/5
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

        // POST: Aditamentos/Edit/5
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

        // GET: Aditamentos/Delete/5
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

        // POST: Aditamentos/Delete/5
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
