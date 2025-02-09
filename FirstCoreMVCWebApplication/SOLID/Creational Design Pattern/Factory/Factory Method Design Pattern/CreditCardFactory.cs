using FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Factory.Factory_Design_Pattern;

namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Factory.Factory_Method_Design_Pattern
{
    public abstract class CreditCardFactory
    {
        protected abstract CreditCard MakeProduct();

        public CreditCard CreateProduct()
        {
            return this.MakeProduct();
        }
    }
}
