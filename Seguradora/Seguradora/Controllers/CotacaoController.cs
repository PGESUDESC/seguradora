using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Seguradora;
using Seguradora.Comum;

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
        public ActionResult Create([Bind(Include = "Codigo,Tipo,Modalidade,DataInicial,DataFinal,Segurado,Marca,Modelo,Veiculo,AnoModelo")] Cotacao cotacao)
        {
            if (ModelState.IsValid)
            {
                cotacao.NumeroAditivo = (string.Format("{0}{1}{2}{3}{4}{5}", DateTime.Now.Year,
                                                                  DateTime.Now.Month < 10 ? DateTime.Now.Month.ToString().PadLeft(2, '0') : DateTime.Now.Month.ToString(),
                                                                  DateTime.Now.Day < 10 ? DateTime.Now.Day.ToString().PadLeft(2, '0') : DateTime.Now.Day.ToString(),
                                                                  DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
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
        public ActionResult Edit([Bind(Include = "Codigo,NumeroAditivo,Modalidade,DataInicial,DataFinal,Segurado,Marca,Modelo,Veiculo,AnoModelo")] Cotacao cotacao)
        {
            if (ModelState.IsValid)
            {
                Cotacao cotacaoAtual = db.Cotacao.Find(cotacao.Codigo);
                cotacaoAtual.NumeroAditivo = cotacaoAtual.NumeroAditivo;
                cotacaoAtual.Modalidade = cotacao.Modalidade;
                cotacaoAtual.DataInicial = cotacao.DataInicial;
                cotacaoAtual.DataFinal = cotacao.DataFinal;
                cotacaoAtual.Segurado = cotacao.Segurado;
                cotacaoAtual.Marca = cotacao.Marca;
                cotacaoAtual.Modelo = cotacao.Modelo;
                cotacaoAtual.Veiculo = cotacao.Veiculo;
                cotacaoAtual.AnoModelo = cotacao.AnoModelo;
                db.Entry(cotacaoAtual).State = EntityState.Modified;
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
            ViewBag.CodigoCotacao = cotacao.Codigo;
            List<Aditamento> aditamentos = db.Aditamento.ToList().Where(p => p.Marca == cotacao.Marca && p.Modelo == cotacao.Modelo).ToList();

            return View(aditamentos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Aditamento(FormCollection collection)
        {
            Cotacao cotacao = db.Cotacao.Find(Convert.ToInt32(collection["CodigoCotacao"]));
            try
            {
                if (!String.IsNullOrEmpty(collection["checksDisp"]) && !String.IsNullOrEmpty(collection["idsDisp"]))
                {
                    string[] ids = collection["idsDisp"].ToString().Split(',');
                    string[] checks = collection["checksDisp"].ToString().Split(',');
                    int idIterator = 0;
                    int checkIterator = 0;
                    foreach (var idItem in ids)
                    {
                        int idInt = Convert.ToInt32(ids[idIterator]);
                        string marcado = checks[checkIterator].ToString();
                        idIterator++;
                        checkIterator++;
                        if (marcado == "true")
                        {
                            checkIterator++;
                            try
                            {
                                CotacaoAditamento itemCotacao = new CotacaoAditamento();
                                itemCotacao.Cotacao = cotacao.Codigo;
                                itemCotacao.Aditamento = idInt;

                                db.CotacaoAditamento.Add(itemCotacao);
                                db.SaveChanges();
                            }
                            catch (Exception error)
                            {
                            } 
                        }
                    }
                }
                return RedirectToAction("InformacoesAdicionais", new { @id = cotacao.Codigo });
            }
            catch
            {
                return RedirectToAction("InformacoesAdicionais", new { @id = cotacao.Codigo });
            }
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
            Cotacao cotacao = db.Cotacao.Find(id);
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            decimal valorTotal = 0;
            List<CotacaoAditamento> aditamentos = db.CotacaoAditamento.ToList().Where(p => p.Cotacao == cotacao.Codigo).ToList();
            decimal percentualTotal = aditamentos.Sum(p => p.Aditamento1.Percentual);
            decimal franquia = (cotacao.Veiculo1.Valor * 3 / 100);
            valorTotal = franquia * percentualTotal / 100;
            cotacao.ValorTotal = valorTotal;
            if (cotacao.status != (int)StatusCotacaoEnum.Aguardando || cotacao.status != (int)StatusCotacaoEnum.Cadastrada)
                cotacao.status = (int)StatusCotacaoEnum.Aguardando;
            db.Entry(cotacao).State = EntityState.Modified;
            db.SaveChanges();
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

        public ActionResult Aprovar(int id)
        {
            Cotacao cotacaoAtual = db.Cotacao.Find(id);
            cotacaoAtual.status = (int)StatusCotacaoEnum.Aprovada;
            db.Entry(cotacaoAtual).State = EntityState.Modified;
            db.SaveChanges();
            return View(cotacaoAtual);
            //return RedirectToAction("Resumo", new { @id = id });
        }

        public ActionResult Reprovar(int id)
        {
            Cotacao cotacaoAtual = db.Cotacao.Find(id);
            cotacaoAtual.status = (int)StatusCotacaoEnum.Reprovada;
            db.Entry(cotacaoAtual).State = EntityState.Modified;
            db.SaveChanges();
            return View(cotacaoAtual);
            //return RedirectToAction("Resumo", new { @id = id });
        }

        public ActionResult CotacaoCompleta(int id)
        {
            Cotacao cotacao = db.Cotacao.Find(id);
            return View(cotacao);
        }


    }
}
