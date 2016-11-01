using System.Collections.Generic;

using StudentSystem.Models.Contracts;

namespace StudentSystem.Models
{
    public class Course : INameble
    {
        private ICollection<Student> students;
        private ICollection<string> materials;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.materials = new HashSet<string>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
        }

        public virtual ICollection<string> Materials
        {
            get
            {
                return this.materials;
            }

            set
            {
                this.materials = value;
            }
        }
    }
}
