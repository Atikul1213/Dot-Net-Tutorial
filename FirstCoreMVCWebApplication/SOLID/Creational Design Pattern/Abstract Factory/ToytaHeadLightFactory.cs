using FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Abstract;

namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Abstract_Factory
{
    public class ToytaHeadLightFactory : HeadLightFactory
    {
        public override HeadLIght CreateHeadLight()
        {
            return new ToytaHeadLight();
        }
    }
}
