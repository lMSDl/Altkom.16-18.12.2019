using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        private string _firstName;
        public string FirstName {
            get
            {
                Debug.WriteLine("Wywołanie gettera Person FirstName");
                return _firstName;
            }
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                    _firstName = value;
            }
        }

        public string LastName { get; set; }
        public DateTime BithDate { get; set; }
    }
}
