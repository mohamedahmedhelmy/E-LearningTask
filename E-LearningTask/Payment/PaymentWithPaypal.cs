namespace E_LearningTask.Payment
{
    public class PaymentWithPaypal : IPayment
    {
        public bool PaymentManageWay()
        {
            Console.WriteLine("Your Payment Handled With Paypal Successfully ");
            return true;

        }
    }
}
