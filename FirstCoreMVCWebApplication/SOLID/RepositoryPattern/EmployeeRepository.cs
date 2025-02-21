using FirstCoreMVCWebApplication.Data;

namespace FirstCoreMVCWebApplication.SOLID.RepositoryPattern
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IEnumerable<Employee> GetEmployeeByDepartment(string dept)
        {
            // return _context.Employees.Where(emp => emp.Email == dept).ToList();
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployeesByGender(string gender)
        {
            //eturn _context.Employees.Where(emp => emp.Gender == gender).ToList();
            throw new NotImplementedException();
        }
    }
}
