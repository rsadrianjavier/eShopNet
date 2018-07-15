using System.Linq;

namespace eShop.CORE.Contracts
{
    public interface IGenericManager<T> where T : class
    {
        IApplicationDbContext Context { get; }

        T Add(T entity);
        IQueryable<T> GetAll();
        T GetById(int id);
        T GetById(object[] key);
        T Remove(T entity);
    }
}