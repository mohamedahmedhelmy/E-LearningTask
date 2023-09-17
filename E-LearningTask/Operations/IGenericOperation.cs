using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningTask.Operations
{
    public interface IGenericOperation<T> where T : class
    {
        List<T> GetAll();
        void Add(T item);
    }
}
