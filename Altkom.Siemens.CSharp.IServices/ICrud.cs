using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.IServices
{
    public interface ICrud<T> where T : class
    {
        int Create(T entity);
        T Read(Type type, int id);
        IEnumerable<T> Read();
        bool Update(T entity);
        bool Delete(Type type, int id);
    }
}
