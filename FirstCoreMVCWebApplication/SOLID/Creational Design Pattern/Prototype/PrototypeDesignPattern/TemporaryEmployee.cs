namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Prototype.PrototypeDesignPattern
{
    public class TemporaryEmployee : Employee
    {
        public int FixedAmount { get; set; }
        public override Employee GetClone()
        {
            return (TemporaryEmployee)this.MemberwiseClone();
        }

        public override void ShowDetails()
        {
            Console.WriteLine("Temporary Employee");
            Console.WriteLine($"Name: {this.Name}, Department:{this.Department}" +
                $",Type: {this.Type}, FixedAmount: {this.FixedAmount}");
        }
    }
}

// Employee emp1 = new TemporaryEmployee();
// Employee emp2 = emp1.GetClone();