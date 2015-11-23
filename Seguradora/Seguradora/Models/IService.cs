using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguradora.Models
{
    public interface IService<T>
    {
        bool Validate(T poll);
        bool Create(T poll);
        List<T> GetAll();
        T Get(int id);
        bool Delete(int id);
        bool Save(T poll);
    }
}
