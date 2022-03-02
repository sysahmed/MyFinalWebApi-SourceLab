using MyApp.Demo.Core.Abstract;
using System.Linq.Expressions;

namespace MyApp.Demo.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, TEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
