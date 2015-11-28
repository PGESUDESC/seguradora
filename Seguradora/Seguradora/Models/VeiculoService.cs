using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguradora.Models
{
    public class VeiculoService
    {
        private seguradoraEntities qDB = new seguradoraEntities();

        public bool Create(Veiculo poll)
        {
            try
            {
                qDB.Veiculo.Add(poll);
                qDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Veiculo GetByCodigoFIPE(string codigoFipe)
        {
            return qDB.Veiculo.Single(q => q.CodigoFipe == codigoFipe);
        }

        public bool Existe(string codigoFipe)
        {
            try
            {
                return (qDB.Veiculo.Single(q => q.CodigoFipe == codigoFipe).ID > 0);
            }
            catch
            {
                return false;
            }
        }
    }
}