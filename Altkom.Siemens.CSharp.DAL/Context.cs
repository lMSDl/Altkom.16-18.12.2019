using Altkom.Siemens.CSharp.DAL.Configurations;
using Altkom.Siemens.CSharp.DAL.Migrations;
using Altkom.Siemens.CSharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.DAL
{
    public class Context : DbContext
    {
        public Context() : base("Data Source=(local);Database=Siemens.CSharp;Integrated Security=True")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>(true));

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new InstructorConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new ClassConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Class> ClassesSet { get; set; }
    }
}
