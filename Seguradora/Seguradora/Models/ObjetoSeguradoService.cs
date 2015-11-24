using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seguradora.Models
{
    public class ObjetoSeguradoService : IService<ObjetoSegurado>
    {
        private ModeloDadosDataContext qDB;

        public ObjetoSeguradoService(){
            qDB = new ModeloDadosDataContext();
        }
    

        public bool Validate(ObjetoSegurado poll)
        {
            throw new NotImplementedException();
        }

        public bool Create(ObjetoSegurado poll)
        {
            throw new NotImplementedException();
        }

        public List<ObjetoSegurado> GetAll()
        {
            throw new NotImplementedException();
        }

        public ObjetoSegurado Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(ObjetoSegurado poll)
        {
            throw new NotImplementedException();
        }
    }
}