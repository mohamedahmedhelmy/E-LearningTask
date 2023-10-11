using E_LearningTask.Data;
using E_LearningTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningTask.Operations
{
    public class StudentOperation : IGenericOperation<Student>
    {
        ApplicationDbContext _context;
        public StudentOperation(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Student item)
        {
            _context.Students.Add(item);
            _context.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return _context.Students.Include(c=>c.Courses).ToList();
        }

    }
}
