namespace FirstCoreMVCWebApplication.SOLID.RepositoryPattern
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeesByGender(string gender);
        IEnumerable<Employee> GetEmployeeByDepartment(string dept);
    }
}
