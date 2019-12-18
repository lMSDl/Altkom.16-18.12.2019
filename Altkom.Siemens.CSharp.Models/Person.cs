using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.Models
{
    public abstract class Person : IPerson
    {
        private string _firstName;

        protected Person() { }

        protected Person(string firstName, string lastName, Genders gender) : this(firstName, lastName, gender, GenerateDate(lastName.GetHashCode()))
        {
        }

        protected Person(string firstName, string lastName, Genders gender, DateTime bithDate)
        {
            LastName = lastName;
            FirstName = firstName;
            Gender = gender;
            BithDate = bithDate;
        }

        private static DateTime GenerateDate(int seed)
        {
            var random = new Random(seed);
            return new DateTime(random.Next(1950, 1990), random.Next(1, 12), random.Next(1, 28));
        }

        public string FirstName {
            get
            {
                //Debug.WriteLine("Wywołanie gettera Person FirstName");
                return _firstName;
            }
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                    _firstName = value;
            }
        }

        public string LastName { get; set; }
        [JsonIgnore]
        public DateTime BithDate { get; set; }
        public Genders Gender { get; set; }

        public bool ShouldSerializeGender()
        {
            return GetAge() < 50;
        }

        public int Age => GetAge();

        public int GetAge()
        {
            return new DateTime((DateTime.Now.Subtract(BithDate).Ticks)).Year;
        }
        public abstract int GetId();
        public abstract void SetId(int id);

        public override string ToString()
        {
            return string.Format("{0, -3} {1, -15} {2, -15} {3, -10} {4, -15}", GetId(), FirstName, LastName, GetAge(), Gender);
        }
    }
}
