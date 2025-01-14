namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Abstract_Factory
{
    public class NissanFactory : CarFactory
    {
        public NissanFactory()
        {
            engineFactory = new NissanEngineFactory();
            headLightFactory = new NissanHeadLightFactory();
        }
    }
}
