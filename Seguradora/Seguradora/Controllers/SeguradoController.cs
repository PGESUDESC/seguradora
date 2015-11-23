using Seguradora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Seguradora.Controllers
{
    public class SeguradoController : Controller
    {
        private SeguradoService qService = new SeguradoService();
        //
        // GET: /Segurado/

        public ActionResult Index(int? page)
        {
            IQueryable<Segurado> itens = qService.GetAll().OrderBy(p => p.Nome).AsQueryable();

            var paginated = itens.ToPagedList(page ?? 1, 10);

            return View(paginated);
        }

        [HttpPost]
        public ActionResult Index(int? page, FormCollection collection)
        {
            string filtro = collection["filtro"];
            IQueryable<Segurado> itens = qService.GetAll().OrderBy(p => p.Nome).AsQueryable();
            if (!String.IsNullOrEmpty(filtro))
                itens = itens.Where(p => (p.Nome != null && p.Nome.ToLower().Contains(filtro.ToLower()))
                                    || p.Documento != null && p.Documento.ToLower().Contains(filtro.ToLower()));
            var paginated = itens.ToPagedList(page ?? 1, 10);

            return View(paginated);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Segurado newSegurado)
        {

            if (ModelState.IsValid)
            {
                qService.Create(newSegurado);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newSegurado);
            }
        }


        public ActionResult Edit(int id)
        {
            Segurado item;
            try
            {
                item = qService.Get(id);
            }
            catch
            {
                item = new Segurado();
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Segurado newSegurado)
        {

            if (ModelState.IsValid)
            {
                qService.Save(newSegurado);
                return RedirectToAction("Index");
            }
            else
            {
                return View(newSegurado);
            }
        }
    }
}
