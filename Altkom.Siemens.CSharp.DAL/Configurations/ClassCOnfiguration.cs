using Altkom.Siemens.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.DAL.Configurations
{
    class ClassConfiguration : EntityTypeConfiguration<Class>
    {
        public ClassConfiguration()
        {
            HasRequired(x => x.Instructor);

            HasMany(x => x.Students).WithMany();

        }
    }
}
