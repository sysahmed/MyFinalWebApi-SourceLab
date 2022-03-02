using MyApp.Demo.Core.DataAccess.Azure;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.DataAccess.Abstract
{
    public interface IAzureDal:IAzureRepository<Order>
    {
    }
}
