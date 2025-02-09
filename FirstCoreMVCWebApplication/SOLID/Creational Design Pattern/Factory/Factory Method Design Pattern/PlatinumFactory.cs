﻿using FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Factory.Factory_Design_Pattern;

namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Factory.Factory_Method_Design_Pattern
{
    public class PlatinumFactory : CreditCardFactory
    {
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new Platinum();

            return product;
        }
    }
}
