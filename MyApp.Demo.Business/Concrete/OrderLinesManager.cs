using MyApp.Demo.Business.Abstract;
using MyApp.Demo.Business.Constants;
using MyApp.Demo.Core.Utilities.Results;
using MyApp.Demo.DataAccess.Abstract;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.Business.Concrete
{
    public class OrderLinesManager : IOrderLinesService
    {
        IOrderLinesDal _orderLinesDal;
        public OrderLinesManager(IOrderLinesDal orderLinesDal)
        {
            _orderLinesDal=orderLinesDal;
        }
        public IResult Add(OrderLine orderLines)
        {
           _orderLinesDal.Add(orderLines);
            return new SuccessResult(Messages.OrderAdded);
        }

        public IResult Delete(int orderLineId)
        {
            OrderLine orderLine = _orderLinesDal.Get(x => x.OrderLinesId == orderLineId);
            _orderLinesDal.Delete(orderLine);
            return new SuccessResult(Messages.OrderDeleted);
        }

        public IDataResult<OrderLine> GetById(int orderLineId)
        {
            return new SuccessDataResult<OrderLine>(_orderLinesDal.Get(p => p.OrderLinesId == orderLineId));
        }

        public IDataResult<List<OrderLine>> GetList()
        {
            return new SuccessDataResult<List<OrderLine>>(_orderLinesDal.GetList().ToList());
        }

        public IResult Update(OrderLine orderLines)
        {
            _orderLinesDal.Update(orderLines);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
