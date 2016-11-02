using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

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

        [MaxLength(60)]
        public string Name { get; set; }

        [MaxLength(60)]
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
