namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Abstract_Factory.AbstractFactoryEx
{
    public interface IVehicleFactory
    {
        IBike CreateBike();
        ICar CreateCar();
    }
}
