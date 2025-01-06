namespace FirstCoreMVCWebApplication.SOLID.DIP
{
    public interface IPaymentMethod
    {
        void ProcessPayment(decimal amount);
    }
}
