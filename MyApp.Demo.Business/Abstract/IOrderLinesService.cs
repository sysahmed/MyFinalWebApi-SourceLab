using MyApp.Demo.Core.Utilities.Results;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.Business.Abstract
{
    public interface IOrderLinesService
    {
        IDataResult<OrderLine> GetById(int orderLineId);
        IDataResult<List<OrderLine>> GetList();
        IResult Add(OrderLine orderLines);
        IResult Delete(int orderLineId);
        IResult Update(OrderLine orderLines);

    }
}
