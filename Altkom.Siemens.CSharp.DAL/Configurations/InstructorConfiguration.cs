using Altkom.Siemens.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.DAL.Configurations
{
    class InstructorConfiguration : EntityTypeConfiguration<Instructor>
    {
        public InstructorConfiguration()
        {
            Property(x => x.FirstName).HasMaxLength(64).IsRequired();
            Property(x => x.LastName).HasMaxLength(64).IsRequired();

            Property(x => x.Specialization).HasMaxLength(32);


        }
    }
}
