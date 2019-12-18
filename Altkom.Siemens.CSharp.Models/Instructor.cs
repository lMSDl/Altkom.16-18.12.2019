using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.Models
{
    public class Instructor : Person, IInstructor
    {
        public Instructor()
        {

        }

        public Instructor(string firstName, string lastName, Genders gender, int yearsOfWork, string specialization) : base(firstName, lastName, gender)
        {
            YearsOfWork = yearsOfWork;
            Specialization = specialization;
        }

        public int InstructorId { get; set; }

        public int YearsOfWork { get; set; }
        public string Specialization { get; set; }
        
        public override int GetId()
        {
            return InstructorId;
        }

        public override void SetId(int id)
        {
            InstructorId = id;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("{0, -5} {1, 15}", YearsOfWork, Specialization);
        }
    }
}
