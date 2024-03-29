﻿using Altkom.Siemens.CSharp.IServices;
using Altkom.Siemens.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.CollectionBasedService
{
    public class Context : ICrud<Person>
    {
        public Context()
        {
            //People = new List<Person>() {
            //    new Person() { PersonId = 1, FirstName = "Adam", LastName = "Adamski", BithDate = new DateTime(1950, 2, 12)},
            //    new Person() { PersonId = 2, FirstName = "Piotr", LastName = "Piotrowski", BithDate = new DateTime(1990, 6, 25)},
            //    new Person() { PersonId = 3, FirstName = "Michał", LastName = "Michalski", BithDate = new DateTime(1978, 7, 1)},
            //};
        }

        private ICollection<Person> People { get; }

        public int Create(Person entity)
        {
            var values = from person in People
                         select person.GetId();

            int maxId = values.Max();

            //* Równoważne zapytanie LINQ w postaci łańcucha metod
            //maxId = People.Select(person => person.GetId()).Max();


            //int maxId = 0;
            //foreach (var person in People)
            //{
            //    if (person.GetId() > maxId)
            //        maxId = person.PersonId;
            //}
            entity.SetId(maxId + 1);
            People.Add(entity);
            return entity.GetId();
        }

        public bool Delete(int id)
        {
            var person = Read(id);
            if (person == null)
                return false;
            People.Remove(person);
            return true;
        }

        public Person Read(int id)
        {
            //return (from person in People
            //              where person.GetId() == id
            //              select person).SingleOrDefault();
            return People.SingleOrDefault(person => person.GetId() == id);


            //foreach (var item in People)
            //{
            //    if (item.GetId() == id)
            //        return item;
            //}
            //return null;
        }

        public IEnumerable<Person> Read()
        {
            //return from person in People select person;
            return People.ToList();
            
            //var list = new List<Person>();
            //list.AddRange(People);
            //return list;
        }

        public bool Update(Person entity)
        {
            if(Delete(entity.GetId()))
            {
                People.Add(entity);
                return true;
            }
            return false;
        }
    }
}
