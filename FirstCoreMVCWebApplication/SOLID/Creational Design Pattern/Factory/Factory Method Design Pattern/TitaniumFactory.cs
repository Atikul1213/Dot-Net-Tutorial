﻿using FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Factory.Factory_Design_Pattern;

namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Factory.Factory_Method_Design_Pattern
{
    public class TitaniumFactory : CreditCardFactory
    {
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new Titanium();

            return product;
        }
    }
}
