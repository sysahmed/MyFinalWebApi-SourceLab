using MyApp.Demo.Core.Abstract;

namespace MyApp.Demo.Core.DataAccess.Azure
{
    public interface IAzureRepository<T> where T : class, TEntity, new()
    {
        void AddAzureMessage(T entity ,string connectionString,string queueName);
    }
}
