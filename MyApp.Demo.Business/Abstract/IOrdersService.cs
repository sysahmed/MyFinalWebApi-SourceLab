using MyApp.Demo.Core.Utilities.Results;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.Business.Abstract
{
    public interface IOrdersService
    {
        IDataResult<Order> GetById(int ordersId);
        IDataResult<List<Order>> GetList();
        IDataResult<List<Order>> GetByOrderDate(Order order);
        IDataResult<List<Order>> GetListByClient(int clinetId);
        IResult Add(Order orders);
        IResult Delete(int orderId);
        IResult Update(Order orders);

    }
}
