using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguradora.Models
{
    public class SeguradoService : IService<Segurado>
    {
        private ModeloDadosDataContext qDB;

        public SeguradoService()
        {
            qDB = new ModeloDadosDataContext();
        }
        public bool Validate(Segurado poll)
        {
            throw new NotImplementedException();
        }

        public bool Create(Segurado poll)
        {
            try
            {
                qDB.Segurados.InsertOnSubmit(poll);
                qDB.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Segurado> GetAll()
        {
            return qDB.Segurados.ToList();
        }

        public Segurado Get(int id)
        {
            return qDB.Segurados.Single(q => q.Codigo == id);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Segurado poll)
        {
            throw new NotImplementedException();
        }
    }
}