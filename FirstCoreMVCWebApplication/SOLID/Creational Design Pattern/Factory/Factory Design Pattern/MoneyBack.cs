namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Factory.Factory_Design_Pattern
{
    public class MoneyBack : CreditCard
    {
        public int GetAnnualCharge()
        {
            return 500;
        }

        public string GetCardType()
        {
            return "MoneyBack";
        }

        public int GetCreditLimit()
        {
            return 15000;
        }
    }
}
