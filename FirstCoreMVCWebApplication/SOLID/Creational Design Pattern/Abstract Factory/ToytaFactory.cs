namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Abstract_Factory
{
    public class ToytaFactory : CarFactory
    {
        public ToytaFactory()
        {
            engineFactory = new ToytaEngineFactory();
            headLightFactory = new ToytaHeadLightFactory();
        }
    }
}
