namespace E_LearningTask.Payment
{
    public class PaymentWithFawry : IPayment
    {
        public bool PaymentManageWay()
        {
            Console.WriteLine("Your Payment Handled With Fawry");
            return true;
        }
    }
}
