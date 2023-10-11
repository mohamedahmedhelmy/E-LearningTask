using E_LearningTask.Data;
using E_LearningTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningTask.Operations
{
    public class FeedBackCourseOperation : IGenericOperation<FeedBackCourse>
    {
        ApplicationDbContext _context;
        public FeedBackCourseOperation(ApplicationDbContext context)
        {
            _context = context;

        }

        public void Add(FeedBackCourse item)
        {
            _context.FeedBacks.AddRange(item);
            _context.SaveChanges();
        }

        public List<FeedBackCourse> GetAll()
        {
           return _context.FeedBacks.ToList();
        }
    }
}
