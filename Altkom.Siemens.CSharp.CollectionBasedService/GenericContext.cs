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

            //* Równoważne zapytanie LINQ w postaci łańcucha metod
            //maxId = People.Select(person => person.PersonId).Max();

            
            //int maxId = 0;
            //foreach (var person in People)
            //{
            //    if (person.PersonId > maxId)
            //        maxId = person.PersonId;
            //}
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
            //return (from person in People
            //              where person.PersonId == id
            //              select person).SingleOrDefault();
            return Entities.SingleOrDefault(person => person.GetId() == id);


            //foreach (var item in People)
            //{
            //    if (item.PersonId == id)
            //        return item;
            //}
            //return null;
        }

        public IEnumerable<T> Read()
        {
            //return from person in People select person;
            return Entities.ToList();
            
            //var list = new List<Person>();
            //list.AddRange(People);
            //return list;
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
