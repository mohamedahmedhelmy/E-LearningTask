using E_LearningTask.Enums;

namespace E_LearningTask.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; } = null!;
        public EmployeeType employeeType { get; set; }
    }
}
