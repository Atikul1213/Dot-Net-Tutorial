namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Prototype.PrototypeDesignPattern
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Type { get; set; }
        public abstract Employee GetClone();
        public abstract void ShowDetails();
    }
}
