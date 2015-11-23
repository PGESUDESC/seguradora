using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguradora.Models
{
    public class MarcaService : IService<Marca>
    {
        private ModeloDadosDataContext qDB;

        public MarcaService()
        {
            qDB = new ModeloDadosDataContext();
        }
        public bool Validate(Marca poll)
        {
            throw new NotImplementedException();
        }

        public bool Create(Marca poll)
        {
            try
            {
                qDB.Marcas.InsertOnSubmit(poll);
                qDB.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Marca> GetAll()
        {
            throw new NotImplementedException();
        }

        public Marca Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Marca poll)
        {
            throw new NotImplementedException();
        }

        public Marca GetByCodigo(string codigo)
        {
            return qDB.Marcas.Single(q => q.Codigo == codigo);
        }

        public bool Existe(string codigo)
        {
            try
            {
                return (qDB.Marcas.Single(q => q.Codigo == codigo).ID > 0);
            }catch{
                return false;
            }
        }
    }
}