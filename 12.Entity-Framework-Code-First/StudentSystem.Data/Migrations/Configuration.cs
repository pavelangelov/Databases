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

        protected override void Seed(StudentSystemContext context)
        {
            if (context.Courses.Count() == 0)
            {
                context.Courses.AddOrUpdate(
                    new Course() { Name = "Databases", Description = "Learn Relative and NoSQL databases." },
                    new Course() { Name = "Design Patterns", Description = "Who cares about the name of all patterns." },
                    new Course() { Name = "HTML Basics", Description = "Learn the fundametals of HTML." });
                context.SaveChanges();
            }

            if (context.Students.Count() == 0)
            {
                context.Students.AddOrUpdate(
                    new Student() { Name = "Pavel Angelov", StudentNumber = 111 },
                    new Student() { Name = "Pesho Peshev", StudentNumber = 112 },
                    new Student() { Name = "Yana Yankova", StudentNumber = 113 }
                    );
                context.SaveChanges();
            }

            if (context.Homeworks.Count() == 0)
            {
                context.Homeworks.AddOrUpdate(
                    new Homework() { Content = "No time for this homework.", StudentId = 1, CourseId = 1, TimeSent = DateTime.Now },
                    new Homework() { Content = "See my repo in git pls.", StudentId = 2, CourseId = 1, TimeSent = new DateTime(2016, 10, 29) }
                );
                context.SaveChanges();
            }

            base.Seed(context);
        }
    }
}
