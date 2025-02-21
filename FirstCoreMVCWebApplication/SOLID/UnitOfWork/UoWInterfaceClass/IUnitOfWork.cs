using Microsoft.EntityFrameworkCore;

namespace FirstCoreMVCWebApplication.SOLID.UnitOfWork.UoWInterfaceClass
{
    public interface IUnitOfWork<out TContext> where TContext : DbContext, new()
    {
        TContext Context { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}
