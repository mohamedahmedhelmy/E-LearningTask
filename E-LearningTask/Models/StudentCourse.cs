using System.ComponentModel.DataAnnotations.Schema;

namespace E_LearningTask.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }

        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }
    }
}