using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.IServices
{
    //Interfejs generyczny. where - określa, że T pracuje z każdą klasą, która ma konstruktor bezparametrowy
    public interface ICrud<T> where T : class, new()
    {
        int Create(T entity);
        T Read(int id);
        IEnumerable<T> Read();
        bool Update(T entity);
        bool Delete(int id);
    }
}
