using MyApp.Demo.Core.DataAccess;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.DataAccess.Abstract
{
    public interface IItemsDal : IEntityRepository<Item>
    {
    }
}
