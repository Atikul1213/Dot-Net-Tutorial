using FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Abstract;

namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Abstract_Factory
{
    public class NissanEngineFactory : EngineFactory
    {
        public override Engine CreateEngine()
        {
            return new NissanEngine();
        }
    }
}
