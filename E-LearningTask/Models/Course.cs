using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningTask.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public decimal Price { get; set; }
        public int InstructorId { get; set; }
        public List<FeedBackCourse>? FeedBackCourse { get; set; }
    }
}
