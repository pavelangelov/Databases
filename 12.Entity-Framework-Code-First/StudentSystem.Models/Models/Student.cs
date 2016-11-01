using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using StudentSystem.Models.Contracts;

namespace StudentSystem.Models
{
    public class Student : INameble
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }
        

        public int Id { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }

        public int StudentNumber { get; set; }


        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }

            set
            {
                this.courses = value;
            }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }

            set
            {
                this.homeworks = value;
            }
        }
    }
}
