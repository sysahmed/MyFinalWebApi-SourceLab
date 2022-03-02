using MyApp.Demo.Core.DataAccess.Azure;
using MyApp.Demo.DataAccess.Abstract;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.DataAccess.Concrete.EntityFramework
{
    public class AzureDal: AzureRepository<Order>,IAzureDal
    {
    }
}
