using E_LearningTask.Operations;
using E_LearningTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningTask.Operations
{
    public class CourseOperation : IGenericOperation<Course>
    {
        List<Course> courseList=new List<Course>()
        {
            new Course(){CourseId=1,CourseName="FullStack.net",Duration="9Month",InstructorId=1,Price=9000},
            new Course(){CourseId=2,CourseName="MEANStack",Duration="9Month",InstructorId=1,Price=7000},
            new Course(){CourseId=3,CourseName="FullStack php",Duration="9Month",InstructorId=1,Price=8000},
        };
        public void Add(Course item)
        {
            courseList.Add(item);
        }

        public List<Course> GetAll()
        {
            return courseList;
        }


    }
}
