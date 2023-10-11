using E_LearningTask.Operations;
using E_LearningTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_LearningTask.Data;
using Microsoft.EntityFrameworkCore;

namespace E_LearningTask.Operations
{
    public class CourseOperation : IGenericOperation<Course>
    {
        ApplicationDbContext _context;
        public CourseOperation(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Course item)
        {
           _context.Courses.Add(item);
            _context.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return _context.Courses.Include(c=>c.FeedBackCourse).ToList();
        }


    }
}
