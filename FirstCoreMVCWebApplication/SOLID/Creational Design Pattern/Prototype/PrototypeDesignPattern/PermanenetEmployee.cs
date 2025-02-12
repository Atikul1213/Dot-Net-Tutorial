namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Prototype.PrototypeDesignPattern
{
    public class PermanenetEmployee : Employee
    {
        public int Salary { get; set; }
        public override Employee GetClone()
        {
            return (PermanenetEmployee)this.MemberwiseClone();
        }

        public override void ShowDetails()
        {
            Console.WriteLine("Permanent Employee");
            Console.WriteLine($"Name: {this.Name}, Department: {this.Department}" +
                $"type: {this.Type}, Salary: {this.Salary}\n");
        }
    }
}
