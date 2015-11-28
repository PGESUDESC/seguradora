using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguradora.Models
{
    public class ModeloService
    {
        private seguradoraEntities qDB = new seguradoraEntities();
        

        public bool Create(Modelo poll)
        {
            try
            {
                qDB.Modelo.Add(poll);
                qDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        

        public Modelo GetByCodigo(string codigo)
        {
            return qDB.Modelo.Single(q => q.Codigo == codigo);
        }

        public bool Existe(string codigo)
        {
            try
            {
                return (qDB.Modelo.Single(q => q.Codigo == codigo).ID > 0);
            }
            catch
            {
                return false;
            }
        }
    }
}