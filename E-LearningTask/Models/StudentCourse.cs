using System.ComponentModel.DataAnnotations.Schema;

namespace E_LearningTask.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }
    }
}