namespace FirstCoreMVCWebApplication.SOLID.DIP
{
    public class PaymentProcessor
    {
        private readonly IPaymentMethod _paymentMethod;
        public PaymentProcessor(IPaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }
        public void ExecutePayment(decimal amount)
        {
            _paymentMethod.ProcessPayment(amount);
        }
    }
}
