using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguradora.Models
{
    public class VeiculoService : IService<Veiculo>
    {
        private ModeloDadosDataContext qDB;

        public VeiculoService()
        {
            qDB = new ModeloDadosDataContext();
        }

        public bool Validate(Veiculo poll)
        {
            throw new NotImplementedException();
        }

        public bool Create(Veiculo poll)
        {
            try
            {
                qDB.Veiculos.InsertOnSubmit(poll);
                qDB.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Veiculo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Veiculo Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Veiculo poll)
        {
            throw new NotImplementedException();
        }

        public Veiculo GetByCodigoFIPE(string codigoFipe)
        {
            return qDB.Veiculos.Single(q => q.CodigoFipe == codigoFipe);
        }

        public bool Existe(string codigoFipe)
        {
            try
            {
                return (qDB.Veiculos.Single(q => q.CodigoFipe == codigoFipe).ID > 0);
            }
            catch
            {
                return false;
            }
        }
    }
}