using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningTask.Models
{
    public class FeedBackCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Double Rate { get; set; }
        public string Comment { get; set; } =null!;
    }
}
