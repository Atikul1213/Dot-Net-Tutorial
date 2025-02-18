namespace FirstCoreMVCWebApplication.SOLID.Behaviroal_Design_Pattern.Mediator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IFacebookGroupMediator facebookMediator = new ConcreteFacebookGroupMediator();

            User Ram = new ConcreteUser("Ram");
            User Dave = new ConcreteUser("Dave");
            User Smith = new ConcreteUser("Smith");
            User Sam = new ConcreteUser("Sam");

            facebookMediator.RegisterUser(Ram);
            facebookMediator.RegisterUser(Dave);
            facebookMediator.RegisterUser(Smith);
            facebookMediator.RegisterUser(Sam);

            Dave.Send("What is Desing patterns? Please explain");
        }
    }
}
