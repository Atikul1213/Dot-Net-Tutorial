namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Prototype
{
    public class Car
    {
        public string Model { get; set; }
        public double Speed { get; set; }
        public double Fuel { get; set; }

        public Car Copy()
        {
            return new Car() { Fuel = this.Fuel, Model = this.Model, Speed = this.Speed };
        }
    }
}
