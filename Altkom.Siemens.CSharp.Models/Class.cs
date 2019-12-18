using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public Instructor Instructor {get; set;}
        public ICollection<Student> Students { get; set; }
    }
}
