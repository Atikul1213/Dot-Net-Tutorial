namespace FirstCoreMVCWebApplication.SOLID.DIP
{
    public class CreditCard : IPaymentMethod
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount}");
        }
    }
}
