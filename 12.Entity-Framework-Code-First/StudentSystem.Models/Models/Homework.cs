using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Models
{
    public class Homework
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Content { get; set; }

        public DateTime TimeSent { get; set; }
        
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
