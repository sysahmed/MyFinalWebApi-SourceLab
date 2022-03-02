using MyApp.Demo.Core.DataAccess;
using MyApp.Demo.Entities.Concrete;
using MyApp.Demo.Entities.DTOs;

namespace MyApp.Demo.DataAccess.Abstract
{
    public interface IOrdersDal : IEntityRepository<Order>
    {
        List<OrdersDetailDto> GetOrderDetails(int clientId);
    }
}
