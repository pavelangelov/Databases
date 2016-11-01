using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using StudentSystem.Data;
using StudentSystem.Models;

namespace StudentSystem.App
{
    public class Startup
    {
        public static void Main()
        {
            var dbContext = new StudentSystemContext();

            using (dbContext)
            {
                Database.SetInitializer<StudentSystemContext>(new CreateDatabaseIfNotExists<StudentSystemContext>());

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

                // Add single course to DB
                dbContext.Courses.Add(new Course() { Name = "C# Fundamentals", Description = "Learn fundamentals for C#  language." });
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
            }
        }

        public static IEnumerable<Student> GenerateStudents(int numberOfStudents, int nextId)
        {
            
            var result = new List<Student>();
            for (int i = 1; i <= numberOfStudents; i++)
            {
                var name = $"Student {i}";
                var studentNumber = 120 + i;
                result.Add(new Student() { Id = nextId++, Name = name, StudentNumber = studentNumber });
            }

            return result;
        }

        public static IEnumerable<Homework> GenerateHomeworks(int numberOfHomeworks, int nextId)
        {
            var result = new List<Homework>();
            for (int i = 1; i <= numberOfHomeworks; i++)
            {
                var content = $"Homework #{i}";
                result.Add(new Homework() { Id = nextId++, Content = content, StudentId = i, CourseId = 5, TimeSent = DateTime.Now.AddDays(i) });
            }

            return result;
        }
    }
}
