namespace FirstCoreMVCWebApplication.SOLID.Composition
{
    public class Product
    {
        public double Price { get; set; }
        public double CalculatePriceAfterDiscount(double discount)
        {
            return Price - (Price * discount) / 100;
        }
    }
}
