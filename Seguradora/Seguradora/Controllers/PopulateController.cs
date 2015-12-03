using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguradora.Controllers
{
    public class PopulateController 

    {
        private seguradoraEntities db = new seguradoraEntities();

        public SelectList PopulaSeguradosDropDownList(object selectedItem = null)
        {
            var query = db.Segurado.ToList().Select(c => new { c.Codigo, c.Nome });
            return new SelectList(query.AsEnumerable(), "Codigo", "Nome", selectedItem);
        }

        public SelectList PopulaMarcasDropDownList(object selectedItem = null)
        {
            var query = db.Marca.ToList().Select(c => new { c.ID, c.Descricao });
            return new SelectList(query.AsEnumerable(), "ID", "Descricao", selectedItem);
        }

        public SelectList PopulaModelosDropDownList(object selectedItem = null)
        {
            if (selectedItem != null)
            {
                var query = db.Modelo.ToList().Select(c => new { c.ID, c.Descricao });
                return new SelectList(query.AsEnumerable(), "ID", "Descricao", selectedItem);
            }
            else
            {
                var query = db.Modelo.ToList().Where(p => p.ID == 1).Select(c => new { c.ID, c.Descricao });
                return new SelectList(query.AsEnumerable(), "ID", "Descricao", selectedItem);
            }
        }

        public SelectList PopulaAnoModelosDropDownList(object selectedItem = null)
        {
            if (selectedItem == null)
            {
                var query = db.AnoModelo.ToList().Select(c => new { c.ID, c.Descricao });
                return new SelectList(query.AsEnumerable(), "ID", "Descricao", selectedItem);
            }
            else
            { 

                var query = db.AnoModelo.ToList().Where(p => p.ID == ((AnoModelo)selectedItem).ID).Select(c => new { c.ID, c.Descricao });
                return new SelectList(query.AsEnumerable(), "ID", "Descricao", selectedItem);
            }
        }

        public SelectList PopulaVeiculosDropDownList(object selectedItem = null)
        {
            if (selectedItem != null)
            {
                var query = db.Veiculo.ToList().Select(c => new { c.ID, c.Combustivel });
                return new SelectList(query.AsEnumerable(), "ID", "Combustivel", selectedItem);
            }
            else
            {
                var query = db.Veiculo.ToList().Where(p => p.ID == 1).Select(c => new { c.ID, c.Combustivel });
                return new SelectList(query.AsEnumerable(), "ID", "Combustivel", selectedItem);
            }
        }
    }
}