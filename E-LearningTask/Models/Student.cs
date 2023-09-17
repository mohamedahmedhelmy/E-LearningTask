using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningTask.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public bool IsEnrolled { get; set; }
        public ICollection<StudentCourse> Courses { get; set; }
    }
}
