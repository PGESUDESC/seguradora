using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguradora.Models
{
    public class MarcaService
    {
        private seguradoraEntities qDB = new seguradoraEntities();

        public bool Create(Marca poll)
        {
            try
            {
                qDB.Marca.Add(poll);
                qDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        
        public Marca GetByCodigo(string codigo)
        {
            return qDB.Marca.Single(q => q.Codigo == codigo);
        }

        public bool Existe(string codigo)
        {
            try
            {
                return (qDB.Marca.Single(q => q.Codigo == codigo).ID > 0);
            }
            catch
            {
                return false;
            }
        }
    }
}