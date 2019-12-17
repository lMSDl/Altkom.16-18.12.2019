using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.Models
{
    public class Student : Person, IStudent
    {
        public Student(string firstName, string lastName, Genders gender, int yearOfStudy) : base(firstName, lastName, gender)
        {
            YearOfStudy = yearOfStudy;
        }

        public int StudentId { get; set; }
        public int YearOfStudy { get; set; }

        public override int GetId()
        {
            return StudentId;
        }

        public override void SetId(int id)
        {
            StudentId = id;
        }
    }
}
