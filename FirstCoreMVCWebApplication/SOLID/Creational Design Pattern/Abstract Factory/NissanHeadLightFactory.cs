using FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Abstract;

namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Abstract_Factory
{
    public class NissanHeadLightFactory : HeadLightFactory
    {
        public override HeadLIght CreateHeadLight()
        {
            return new NissanHeadLight();
        }
    }
}
