using Altkom.Siemens.CSharp.IServices;
using Altkom.Siemens.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.CollectionBasedService
{
    public class GenericContext<T> : ICrud<T> where T : Person
    {
        public GenericContext(IEnumerable<T> seed)
        {
            Entities = seed.ToList();
        }

        private ICollection<T> Entities { get; }

        public int Create(T entity)
        {
            var values = from person in Entities
                         select person.GetId();

            int maxId = values.Max();

            entity.SetId(maxId + 1);
            Entities.Add(entity);
            return entity.GetId();
        }

        public bool Delete(int id)
        {
            var person = Read(id);
            if (person == null)
                return false;
            Entities.Remove(person);
            return true;
        }

        public T Read(int id)
        {
            return Entities.SingleOrDefault(person => person.GetId() == id);
        }

        public IEnumerable<T> Read()
        {
            return Entities.ToList();
        }

        public bool Update(T entity)
        {
            if(Delete(entity.GetId()))
            {
                Entities.Add(entity);
                return true;
            }
            return false;
        }
    }
}
