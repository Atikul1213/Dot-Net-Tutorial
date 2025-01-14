using FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Abstract;

namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Abstract_Factory
{
    public abstract class CarFactory
    {
        public EngineFactory engineFactory { get; protected set; }
        public HeadLightFactory headLightFactory { get; protected set; }
    }
}
