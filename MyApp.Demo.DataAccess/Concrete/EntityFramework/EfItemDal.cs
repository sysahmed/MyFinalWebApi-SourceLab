using MyApp.Demo.Core.DataAccess.EntityFramework;
using MyApp.Demo.DataAccess.Abstract;
using MyApp.Demo.DataAccess.Concrete.EntityFramework.Context;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.DataAccess.Concrete.EntityFramework
{
    public class EfItemsDal : EfEntityRepositoryBase<Item, MyAppDbContext>, IItemsDal
    {
    }
}
