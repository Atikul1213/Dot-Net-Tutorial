using FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Abstract;

namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Abstract_Factory
{
    public class ToytaEngineFactory : EngineFactory
    {
        public override Engine CreateEngine()
        {
            return new ToytaEngine();
        }
    }
}
