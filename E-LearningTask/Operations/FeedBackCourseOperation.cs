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
        List<FeedBackCourse> feedbacks = new List<FeedBackCourse>()
        {
            new FeedBackCourse(){CourseId=1,StudentId=1,Rate=4.5,Comment="Awesome Course"},
            new FeedBackCourse(){CourseId=1,StudentId=2,Rate=5,Comment="Amazing Course"},
            new FeedBackCourse(){CourseId=1,StudentId=3,Rate=4.2,Comment="Good Course"},
            new FeedBackCourse(){CourseId=1,StudentId=4,Rate=4.3,Comment="Very Good Course"},
        };

        public void Add(FeedBackCourse item)
        {
            feedbacks.Add(item);
        }

        public List<FeedBackCourse> GetAll()
        {
           return feedbacks;
        }
    }
}
