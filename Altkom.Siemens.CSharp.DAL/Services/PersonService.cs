using Altkom.Siemens.CSharp.IServices;
using Altkom.Siemens.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.DAL.Services
{
    public class PersonService : ICrud<Person>
    {
        public int Create(Person entity)
        {
            using (var context = new Context())
            {
                entity = (Person)context.Set(entity.GetType()).Add(entity);
                context.SaveChanges();
                return entity.GetId();
            }
        }

        public bool Delete(Type type, int id)
        {
            using (var context = new Context())
            {
                var entity = context.Set(type).Find(id);
                if (entity == null)
                    return false;
                context.Set(type).Remove(entity);
                context.SaveChanges();
                return true;
            }
        }

        public Person Read(Type type, int id)
        {
            using (var context = new Context())
            {
                return (Person)context.Set(type).Find(id);
            }
        }

        public IEnumerable<Person> Read()
        {
            using (var context = new Context())
            {
                return context.Set<Instructor>().ToList().Cast<Person>().Concat(context.Set<Student>().ToList());
            }
        }

        public bool Update(Person entity)
        {
            try
            {
                using (var context = new Context())
                {
                    context.Set(entity.GetType()).Attach(entity);
                    context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
