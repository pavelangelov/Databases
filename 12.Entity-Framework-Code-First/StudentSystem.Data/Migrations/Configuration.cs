using System;
using System.Data.Entity.Migrations;
using System.Linq;

using StudentSystem.Models;

namespace StudentSystem.Data.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }
    }
}
