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
            PopulaSeguradosDropDownList();
            PopulaMarcasDropDownList();
            PopulaModelosDropDownList();
            PopulaAnoModelosDropDownList();
            PopulaVeiculosDropDownList();
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
                return RedirectToAction("Aditamento", new { @id = cotacao.Codigo });
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
            PopulaSeguradosDropDownList(cotacao.Segurado);
            PopulaMarcasDropDownList(cotacao.Marca);
            PopulaModelosDropDownList(cotacao.Modelo);
            PopulaAnoModelosDropDownList(cotacao.AnoModelo);
            PopulaVeiculosDropDownList(cotacao.Veiculo);
            return View(cotacao);
        }

        // POST: Cotacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Tipo,NumeroAditivo,Modalidade,DataInicial,DataFinal,Segurado,Marca,Modelo,Veiculo,AnoModelo")] Cotacao cotacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Aditamento", new { @id = cotacao.Codigo });
            }
            return View(cotacao);
        }

        public ActionResult Aditamento(int id)
        {
            Cotacao cotacao = db.Cotacao.Find(id);
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            return View(cotacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Aditamento([Bind(Include = "Codigo")] Cotacao cotacao)
        {
            //So passa adiante ate ter os aditamentos
            if (ModelState.IsValid)
            {
                Cotacao cotacaoAtual = db.Cotacao.Find(cotacao.Codigo);
                db.Entry(cotacaoAtual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("InformacoesAdicionais", new { @id = cotacao.Codigo });
            }
            return View(cotacao);
        }

        public ActionResult InformacoesAdicionais(int id)
        {
            Cotacao cotacao = db.Cotacao.Find(id);
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            return View(cotacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InformacoesAdicionais([Bind(Include = "Codigo,SeguradoCondutor,PercentualCoeficiente,PercentualDesconto,TipoUso,PernoiteDoVeiculo,Observacoes,InformacoesGerais")] Cotacao cotacao)
        {
            //So passa adiante ate ter os aditamentos
            if (ModelState.IsValid)
            {
                Cotacao cotacaoAtual = db.Cotacao.Find(cotacao.Codigo);
                cotacaoAtual.SeguradoCondutor = cotacao.SeguradoCondutor;
                cotacaoAtual.PercentualCoeficiente = cotacao.PercentualCoeficiente;
                cotacaoAtual.PercentualDesconto = cotacao.PercentualDesconto;
                cotacaoAtual.TipoUso = cotacao.TipoUso;
                cotacaoAtual.PernoiteDoVeiculo = cotacao.PernoiteDoVeiculo;
                cotacaoAtual.Observacoes = cotacao.Observacoes;
                cotacaoAtual.InformacoesGerais = cotacao.InformacoesGerais;
                db.Entry(cotacaoAtual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Resumo", new { @id = cotacao.Codigo });
            }
            return View(cotacao);
        }

        public ActionResult Resumo(int id)
        {
            //Aqui deve calcular o valor da cotacao e mostrar na tela do resumo
            
            Cotacao cotacao = db.Cotacao.Find(id);
            if (cotacao == null)
            {
                return HttpNotFound();
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

        private void PopulaSeguradosDropDownList(object selectedItem = null)
        {
            var query = db.Segurado.ToList().Select(c => new { c.Codigo, c.Nome });
            ViewBag.Segurados = new SelectList(query.AsEnumerable(), "Codigo", "Nome", selectedItem);
        }

        private void PopulaMarcasDropDownList(object selectedItem = null)
        {
            var query = db.Marca.ToList().Select(c => new { c.ID, c.Descricao });
            ViewBag.Marcas = new SelectList(query.AsEnumerable(), "ID", "Descricao", selectedItem);
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


        private void PopulaAnoModelosDropDownList(object selectedItem = null)
        {
            if (selectedItem != null)
            {
                var query = db.AnoModelo.ToList().Select(c => new { c.ID, c.Descricao });
                ViewBag.Veiculos = new SelectList(query.AsEnumerable(), "ID", "Descricao", selectedItem);
            }
            else
            {
                var query = db.AnoModelo.ToList().Where(p => p.ID == 1).Select(c => new { c.ID, c.Descricao });
                ViewBag.AnoModelos = new SelectList(query.AsEnumerable(), "ID", "Descricao", selectedItem);
            }
        }
        private void PopulaVeiculosDropDownList(object selectedItem = null)
        {
            if (selectedItem != null)
            {
                var query = db.Veiculo.ToList().Select(c => new { c.ID, c.Combustivel });
                ViewBag.Veiculos = new SelectList(query.AsEnumerable(), "ID", "Combustivel", selectedItem);
            }
            else
            {
                var query = db.Veiculo.ToList().Where(p => p.ID == 1).Select(c => new { c.ID, c.Combustivel });
                ViewBag.Veiculos = new SelectList(query.AsEnumerable(), "ID", "Combustivel", selectedItem);
            }
        }


    }
}
