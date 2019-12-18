using Altkom.Siemens.CSharp.IServices;
using Altkom.Siemens.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.DAL.Services
{
    public class PersonServiceAsync : ICrudAsync<Person>
    {
        public async Task<int> CreateAsync(Person entity)
        {
            using (var context = new Context())
            {
                entity = (Person)context.Set(entity.GetType()).Add(entity);
                await context.SaveChangesAsync();
                return entity.GetId();
            }
        }

        public async Task<bool> DeleteAsync(Type type, int id)
        {
            using (var context = new Context())
            {
                var entity = await context.Set(type).FindAsync(id);
                if (entity == null)
                    return false;
                context.Set(type).Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Person> ReadAsync(Type type, int id)
        {
            using (var context = new Context())
            {
                return (Person)await context.Set(type).FindAsync(id);
            }
        }

        public Task<IEnumerable<Person>> ReadAsync()
        {
            return Task.Run(() =>
            {
                using (var context = new Context())
                {
                    return context.Set<Instructor>().ToList().Cast<Person>().Concat(context.Set<Student>().ToList());
                }
            });
        }

        public async Task<bool> UpdateAsync(Person entity)
        {
            try
            {
                using (var context = new Context())
                {
                    context.Set(entity.GetType()).Attach(entity);
                    context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    await context.SaveChangesAsync();
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
