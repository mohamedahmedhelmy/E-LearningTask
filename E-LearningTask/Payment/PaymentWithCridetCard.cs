using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_LearningTask.Payment
{
    public class PaymentWithCridetCard : IPayment
    {
        public bool PaymentManageWay()
        {
            Console.WriteLine("Your Payment Handled With Cridet Card Successfully ");
            return true;
        }
    }
}
