using E_LearningTask.Data;
using E_LearningTask.Enums;
using E_LearningTask.Models;

namespace E_LearningTask.Operations
{
    internal class InstructorOperation : IGenericOperation<Instructor>
    {
        ApplicationDbContext _context;
        public InstructorOperation(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Instructor item)
        {
            _context.Instructors.Add(item);
            _context.SaveChanges();
        }

        public List<Instructor> GetAll()
        {
           return _context.Instructors.ToList();
        }


    }
}
