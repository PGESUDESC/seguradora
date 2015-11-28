using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguradora.Models
{
    public class AnoModeloService
    {
        private seguradoraEntities qDB = new seguradoraEntities();

        public bool Create(AnoModelo poll)
        {
            try
            {
                qDB.AnoModelo.Add(poll);
                qDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public AnoModelo GetByCodigo(string codigo)
        {
            return qDB.AnoModelo.Single(q => q.Codigo == codigo);
        }

        public bool Existe(string codigo)
        {
            try
            {
                return (qDB.AnoModelo.Single(q => q.Codigo == codigo).ID > 0);
            }
            catch
            {
                return false;
            }
        }
    }
}