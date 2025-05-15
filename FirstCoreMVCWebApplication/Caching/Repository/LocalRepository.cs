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
        private readonly int _CacheAbsoluteDurationMinutes;
        private readonly int _CacheSlidingDurationMinutes;
        private readonly IConfiguration _configuration;
        public LocalRepository(ApplicationDbContext context,
            IMemoryCache cache,
            IConfiguration configuration)
        {
            _context = context;
            _cache = cache;
            _configuration = configuration;
            _CacheAbsoluteDurationMinutes = _configuration.GetValue<int?>("CacheSettings:CacheAbsoluteDurationMinutes") ?? 30;
            _CacheSlidingDurationMinutes = _configuration.GetValue<int?>("CacheSettings:CacheSlidingDurationMinutes") ?? 30;
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
