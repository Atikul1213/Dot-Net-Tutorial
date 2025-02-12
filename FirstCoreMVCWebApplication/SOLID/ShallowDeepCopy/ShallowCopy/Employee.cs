namespace FirstCoreMVCWebApplication.SOLID.ShallowDeepCopy.ShallowCopy
{
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public Address EmpAddress { get; set; }

        public Employee GetClone()
        {
            return (Employee)this.MemberwiseClone();
        }
    }

    public class Address
    {
        public string address { get; set; }
    }
}
