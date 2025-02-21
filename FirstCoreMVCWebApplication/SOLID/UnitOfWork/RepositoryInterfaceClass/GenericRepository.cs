using FirstCoreMVCWebApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstCoreMVCWebApplication.SOLID.UnitOfWork.RepositoryInterfaceClass
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private DbSet<T> _entities;
        private string _errorMsg = string.Empty;
        private bool _isDisposed;
        public ApplicationDbContext _context { get; set; }
        public GenericRepository(ApplicationDbContext context)
        {
            _isDisposed = false;
            _context = context;
        }

        protected virtual DbSet<T> Entities
        {
            get { return _entities ?? (_entities = _context.Set<T>()); }
        }


        public void Dispose()
        {
            if (_context is not null)
                _context.Dispose();
            _isDisposed = true;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }

        public T GetById(object id)
        {
            return _entities.Find(id);
        }

        public void Insert(T obj)
        {
            try
            {
                if (obj is null)
                    throw new ArgumentNullException("Entity");

                if (_context == null || _isDisposed)
                {
                    //  _context =  ApplicationDbContext context;
                }
                _entities.Add(obj);
            }
            catch (Exception ex)
            {
                _errorMsg = ex.Message;
            }
        }

        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var obj = _entities.Find(id);
            _context.Remove(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
