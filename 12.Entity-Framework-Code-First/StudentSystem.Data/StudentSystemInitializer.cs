using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

using StudentSystem.Models;

namespace StudentSystem.Data
{
    public class StudentSystemInitializer : CreateDatabaseIfNotExists<StudentSystemContext>
    {
        protected override void Seed(StudentSystemContext context)
        {
            using (context)
            {
                if (!context.Courses.Any())
                {
                    context.Courses.AddOrUpdate(
                        new Course() { Id = 1, Name = "Databases", Description = "Introducing to Relative and NoSQL databases." },
                        new Course() { Id = 2, Name = "Design Patterns", Description = "Who cares about the name of all patterns." },
                        new Course() { Id = 3, Name = "HTML Basics", Description = "Learn the fundametals of HTML." });
                }

                if (!context.Students.Any())
                {
                    context.Students.AddOrUpdate(
                        new Student() { Id = 1, Name = "Pavel Angelov", StudentNumber = 111 },
                        new Student() { Id = 2, Name = "Pesho Peshev", StudentNumber = 112 },
                        new Student() { Id = 3, Name = "Yana Yankova", StudentNumber = 113 });
                }

                if (!context.Homeworks.Any())
                {
                    context.Homeworks.AddOrUpdate(
                        new Homework() { Id = 1, Content = "No time for this homework.", StudentId = 1, CourseId = 1, TimeSent = DateTime.Now },
                        new Homework() { Id = 2, Content = "See my repo in git pls.", StudentId = 2, CourseId = 3, TimeSent = new DateTime(2016, 10, 29) }
                    );
                }
            }
            base.Seed(context);
        }
    }
}
