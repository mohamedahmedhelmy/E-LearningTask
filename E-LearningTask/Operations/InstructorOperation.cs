using E_LearningTask.Enums;
using E_LearningTask.Models;

namespace E_LearningTask.Operations
{
    internal class InstructorOperation : IGenericOperation<Instructor>
    {
        List<Instructor> instructors =new List<Instructor>()
        {
            new Instructor(){InstructorId=1,InstructorName="Mohamed", employeeType=EmployeeType.PerCourse},
            new Instructor(){InstructorId=2,InstructorName="Ahmed", employeeType=EmployeeType.FullTime},
            new Instructor(){InstructorId=3,InstructorName="Helmy", employeeType=EmployeeType.PerCourse}
        };
        public void Add(Instructor item)
        {
           instructors.Add(item);
        }

        public List<Instructor> GetAll()
        {
           return instructors;
        }


    }
}
