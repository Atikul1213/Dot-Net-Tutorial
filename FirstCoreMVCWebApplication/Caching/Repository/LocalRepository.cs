using FirstCoreMVCWebApplication.Data;
using FirstCoreMVCWebApplication.Models.BrainStationEmployeeModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace FirstCoreMVCWebApplication.Caching.Repository
{
    public class LocalRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        public LocalRepository(ApplicationDbContext context,
            IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            var cacheKey = "BrainStationDepartments.Department";

            if (!_cache.TryGetValue(cacheKey, out List<Department>? departments))
            {
                departments = await _context.Departments.ToListAsync();
                _cache.Set(cacheKey, departments, _cacheExpiration);
            }

            return departments ?? new List<Department>();
        }

        public async Task<List<Department>> GetAddDepartmentById(int departmentId)
        {
            var cacheKey = $"BrainStationDepartments.Department.{departmentId}";

            if (!_cache.TryGetValue(cacheKey, out List<Department>? department))
            {
                department = await _context.Departments.ToListAsync();

                _cache.Set(cacheKey, department, _cacheExpiration);
            }

            return department ?? new List<Department>();
        }

        public void RemoveDepartmentFromCache()
        {
            var cacheKey = "BrainStationDepartments.Department";
            _cache.Remove(cacheKey);
        }


    }
}
