namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Factory
{
    public class CarFactory
    {
        public Car CreateCar(string type, string modell, string color, double speed)
        {
            if (type == "Toyta")
            {
                return new Toyta { Color = color, Model = modell, Speed = speed };
            }
            else if (type == "Nisan")
            {
                return new Nisan { Color = color, Model = modell, Speed = speed };
            }

            return null;
        }
    }
}
