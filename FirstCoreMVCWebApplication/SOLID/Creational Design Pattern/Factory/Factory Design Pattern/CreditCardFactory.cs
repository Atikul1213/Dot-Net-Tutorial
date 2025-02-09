namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Factory.Factory_Design_Pattern
{
    public class CreditCardFactory
    {
        public static CreditCard GetCreditCard(string cardType)
        {
            CreditCard creditCard = null;
            if (cardType == "MoneyBack")
                creditCard = new MoneyBack();

            else if (cardType == "Titanium")
                creditCard = new Titanium();

            else if (cardType == "Platinum")
                creditCard = new Platinum();

            return creditCard;
        }
    }
}
