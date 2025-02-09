namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Factory.Factory_Design_Pattern
{
    public class Titanium : CreditCard
    {
        public int GetAnnualCharge()
        {
            return 1500;
        }

        public string GetCardType()
        {
            return "Titanium Edge";
        }

        public int GetCreditLimit()
        {
            return 25000;
        }
    }
}
