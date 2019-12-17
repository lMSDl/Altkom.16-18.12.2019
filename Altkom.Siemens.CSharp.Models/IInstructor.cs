using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.Models
{
    public interface IInstructor
    {
        int YearsOfWork { get; set; }

        string Specialization { get; set; }
    }
}
