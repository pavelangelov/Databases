using System;
using System.Collections.Generic;
using System.Linq;

using StudentSystem.Data;
using StudentSystem.Models;
using System.Data.Entity.Migrations;

namespace StudentSystem.App
{
    public class Startup
    {
        public static void Main()
        {
            var dbContext = new StudentSystemContext();
            SeedData(dbContext);

            // Add single course to DB
            dbContext.Courses.Add(new Course() { Name = "C# Fundamentals", Description = "Learn fundamentals for C#  language." });
            dbContext.SaveChanges();

            // Seed some students and homeworks to DB
            var nextStudentId = dbContext.Students.Count();
            var students = GenerateStudents(15, nextStudentId);
            foreach (var st in students)
            {
                dbContext.Students.Add(st);
            }

            var nextHomeworkId = dbContext.Homeworks.Count();
            var homeworks = GenerateHomeworks(5, nextHomeworkId);
            foreach (var homework in homeworks)
            {
                dbContext.Homeworks.Add(homework);
            }

            dbContext.SaveChanges();

            // Add first student to first course
            var course = dbContext.Courses.FirstOrDefault();
            var student = dbContext.Students.FirstOrDefault();
            student.Courses.Add(course);
            dbContext.SaveChanges();

            // Print all courses with their students
            var courses = dbContext.Courses;
            foreach (var c in courses)
            {
                Console.WriteLine($"Course: {c.Name}");
                var studentsStr = string.Join(", ", c.Students.Select(x => x.Name));
                Console.WriteLine($"Students int this course: \r\n{studentsStr}");
            }

            var homeworksFromDb = dbContext.Homeworks;
            foreach (var homework in homeworksFromDb)
            {
                Console.WriteLine($"Homework from Student: {homework.Student.Name}");
                Console.WriteLine($"For course: {homework.Course.Name}");
                Console.WriteLine($"Sent on: {homework.TimeSent}");
                Console.WriteLine($"Content: {homework.Content}");
                Console.WriteLine("----------------------------------");
            }

        }

        public static IEnumerable<Student> GenerateStudents(int numberOfStudents, int nextId)
        {

            var result = new List<Student>();
            for (int i = 1; i <= numberOfStudents; i++)
            {
                var name = $"Student {i}";
                var studentNumber = 120 + i;
                result.Add(new Student() { Id = ++nextId,  Name = name, StudentNumber = studentNumber });
            }

            return result;
        }

        public static IEnumerable<Homework> GenerateHomeworks(int numberOfHomeworks, int nextId)
        {
            var result = new List<Homework>();
            for (int i = 1; i <= numberOfHomeworks; i++)
            {
                var content = $"Homework #{i}";
                result.Add(new Homework() {Id = ++nextId, Content = content, StudentId = i, CourseId = 1, TimeSent = DateTime.Now.AddDays(i) });
            }

            return result;
        }

        private static void SeedData(StudentSystemContext context)
        {

            if (context.Courses.Count() == 0)
            {
                context.Courses.AddOrUpdate(
                    new Course() { Id = 1, Name = "Databases", Description = "Learn Relative and NoSQL databases." },
                    new Course() { Id = 2, Name = "Design Patterns", Description = "Who cares about the name of all patterns." },
                    new Course() { Id = 3, Name = "HTML Basics", Description = "Learn the fundametals of HTML." });
                context.SaveChanges();
            }

            if (context.Students.Count() == 0)
            {
                context.Students.AddOrUpdate(
                    new Student() { Id = 1, Name = "Pavel Angelov", StudentNumber = 111 },
                    new Student() { Id = 2, Name = "Pesho Peshev", StudentNumber = 112 },
                    new Student() { Id = 3, Name = "Yana Yankova", StudentNumber = 113 }
                    );
                context.SaveChanges();
            }

            if (context.Homeworks.Count() == 0)
            {
                context.Homeworks.AddOrUpdate(
                    new Homework() { Id = 1, Content = "No time for this homework.", StudentId = 1, CourseId = 1, TimeSent = DateTime.Now },
                    new Homework() { Id = 2, Content = "See my repo in git pls.", StudentId = 2, CourseId = 1, TimeSent = new DateTime(2016, 10, 29) }
                );
                context.SaveChanges();
            }

        }
    }
}
