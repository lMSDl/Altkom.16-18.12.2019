using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.IServices
{
    public interface ICrudAsync<T> where T : class
    {
        Task<int> CreateAsync(T entity);
        Task<T> ReadAsync(Type type, int id);
        Task<IEnumerable<T>> ReadAsync();
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Type type, int id);
    }
}
