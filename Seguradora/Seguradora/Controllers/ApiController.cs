using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguradora.Controllers
{
    public class ApiController : Controller
    {
        private seguradoraEntities db = new seguradoraEntities();
        
        // GET: Api
        [HttpPost]
        public ActionResult Modelos(string codigoMarca)
        {
            var modelos = db.Modelo.ToList().Where(p => p.Marca == Convert.ToInt32(codigoMarca)).Select(c => new { c.ID, c.Descricao });
            return Json(new SelectList(modelos.AsEnumerable(), "ID", "Descricao"));
        }
        [HttpPost]
        public ActionResult AnoModelos(string codigoMarca, string codigoModelo)
        {
            var anoModelos = db.AnoModelo.ToList().Where(p => p.Marca == Convert.ToInt32(codigoMarca) && p.Modelo == Convert.ToInt32(codigoModelo)).Select(c => new { c.ID, c.Descricao });
            return Json(new SelectList(anoModelos.AsEnumerable(), "ID", "Descricao"));
        }


        [HttpPost]
        public ActionResult Veiculos(string codigoMarca, string codigoModelo)
        {
            var cidade = db.Veiculo.ToList().Where(p => p.Marca == Convert.ToInt32(codigoMarca) && p.Modelo == Convert.ToInt32(codigoModelo)).Select(c => new { c.ID, c.Combustivel });
            return Json(new SelectList(cidade.AsEnumerable(), "ID", "Combustivel"));
        }
    }
}