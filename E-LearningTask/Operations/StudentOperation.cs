using E_LearningTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningTask.Operations
{
    public class StudentOperation : IGenericOperation<Student>
    {
        List<Student> students = new List<Student>()
        {
            new Student()
            {
                StudentId=1,
                StudentName="Khaled",
                Courses=new List<StudentCourse>(){ new StudentCourse() { StudentId=1,CourseId=2} },
                IsEnrolled=true
            },
            new Student()
            {
                StudentId=2,
                StudentName="Khaled",
                Courses=new List<StudentCourse>(){ new StudentCourse() { StudentId=2,CourseId=1} },
                IsEnrolled=true
            },
            new Student()
            {
                StudentId=3,
                StudentName="Khaled",
                Courses=new List<StudentCourse>(){ new StudentCourse() { StudentId=3,CourseId=2} },
                IsEnrolled=true
            },

        };
        public void Add(Student item)
        {
            students.Add(item);
        }

        public List<Student> GetAll()
        {
            return students;
        }

    }
}
