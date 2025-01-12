namespace FirstCoreMVCWebApplication.SOLID.Composition
{
    public class Electronics
    {
        public string Name { get; set; }
        private Product Product { get; set; }

        public double Price
        {
            get
            {
                return Product.Price;
            }
            set
            {
                Product.Price = value;
            }
        }

        public double GetPriceAAfterDiscount(double discount)
        {
            return Product.CalculatePriceAfterDiscount(discount);
        }
    }
}
