using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguradora.Models
{
    public class AnoModeloService : IService<AnoModelo>
    {
        private ModeloDadosDataContext qDB;

        public AnoModeloService()
        {
            qDB = new ModeloDadosDataContext();
        }
        public bool Validate(AnoModelo poll)
        {
            throw new NotImplementedException();
        }

        public bool Create(AnoModelo poll)
        {
            try
            {
                qDB.AnoModelos.InsertOnSubmit(poll);
                qDB.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<AnoModelo> GetAll()
        {
            throw new NotImplementedException();
        }

        public AnoModelo Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(AnoModelo poll)
        {
            throw new NotImplementedException();
        }

        public AnoModelo GetByCodigo(string codigo)
        {
            return qDB.AnoModelos.Single(q => q.Codigo == codigo);
        }

        public bool Existe(string codigo)
        {
            try
            {
                return (qDB.AnoModelos.Single(q => q.Codigo == codigo).ID > 0);
            }
            catch
            {
                return false;
            }
        }
    }
}