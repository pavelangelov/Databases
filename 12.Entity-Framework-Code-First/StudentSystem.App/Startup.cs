using System;
using System.Collections.Generic;
using System.Linq;

using StudentSystem.Data;
using StudentSystem.Models;

namespace StudentSystem.App
{
    public class Startup
    {
        public static void Main()
        {
            var dbContext = new StudentSystemContext();

            // Add single course to DB
            dbContext.Courses.Add(new Course() { Name = "C# Fundamentals", Description = "Learn fundamentals for C#  language." });
            dbContext.SaveChanges();

            // Seed some students and homeworks to DB
            var studentsCount = dbContext.Students.Count();
            var students = GenerateStudents(15, studentsCount);
            foreach (var st in students)
            {
                dbContext.Students.Add(st);
            }

            dbContext.SaveChanges();

            var homeworksCount = dbContext.Homeworks.Count();
            var homeworks = GenerateHomeworks(5, homeworksCount);
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

            var homeworksFromDb = dbContext.Homeworks.Select(h => new
            {
                CourseName = h.Course.Name,
                Content = h.Content,
                TimeSent = h.TimeSent,
                StudentName = h.Student.Name
            });

            foreach (var homework in homeworksFromDb)
            {
                Console.WriteLine($"Homework from Student: {homework.StudentName}");
                Console.WriteLine($"For course: {homework.CourseName}");
                Console.WriteLine($"Sent on: {homework.TimeSent}");
                Console.WriteLine($"Content: {homework.Content}");
                Console.WriteLine("----------------------------------");
            }

        }

        public static ICollection<Student> GenerateStudents(int numberOfStudents, int studentsCount)
        {
            var result = new List<Student>();
            for (int i = 0; i < numberOfStudents; i++)
            {
                var name = $"Student {++studentsCount}";
                var studentNumber = 120 + studentsCount;
                result.Add(new Student() { Name = name, StudentNumber = studentNumber });
            }

            return result;
        }

        public static ICollection<Homework> GenerateHomeworks(int numberOfHomeworks, int homeworksCount)
        {
            var result = new List<Homework>();
            for (int i = 0; i < numberOfHomeworks; i++)
            {
                var content = $"Homework #{++homeworksCount}";
                result.Add(new Homework() { Content = content, StudentId = i + 1, CourseId = 1, TimeSent = DateTime.Now.AddDays(i) });
            }

            return result;
        }
    }
}
