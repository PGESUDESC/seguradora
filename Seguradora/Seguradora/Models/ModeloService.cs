using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguradora.Models
{
    public class ModeloService : IService<Modelo>
    {
        private ModeloDadosDataContext qDB;

        public ModeloService()
        {
            qDB = new ModeloDadosDataContext();
        }
        public bool Validate(Modelo poll)
        {
            throw new NotImplementedException();
        }

        public bool Create(Modelo poll)
        {
            try
            {
                qDB.Modelos.InsertOnSubmit(poll);
                qDB.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Modelo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Modelo Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Modelo poll)
        {
            throw new NotImplementedException();
        }

        public Modelo GetByCodigo(string codigo)
        {
            return qDB.Modelos.Single(q => q.Codigo == codigo);
        }

        public bool Existe(string codigo)
        {
            try
            {
                return (qDB.Modelos.Single(q => q.Codigo == codigo).ID > 0);
            }
            catch
            {
                return false;
            }
        }
    }
}