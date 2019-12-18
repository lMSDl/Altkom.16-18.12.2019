using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Siemens.CSharp.DAL.Migrations
{
    class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            ContextKey = typeof(Context).FullName;
            AutomaticMigrationsEnabled = false;
        }
    }
}
