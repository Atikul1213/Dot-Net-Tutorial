namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Abstract_Factory.AbstractFactoryEx
{
    public class RegularVehicleFactory : IVehicleFactory
    {
        public IBike CreateBike()
        {
            return new RegularBike();
        }

        public ICar CreateCar()
        {
            return new RegularCar();
        }
    }
}
