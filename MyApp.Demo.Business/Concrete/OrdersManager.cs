using MyApp.Demo.Business.Abstract;
using MyApp.Demo.Business.Constants;
using MyApp.Demo.Business.ValidationRules.FluentValidator;
using MyApp.Demo.Core.Aspect.Autofac;
using MyApp.Demo.Core.Aspect.Autofac.Caching;
using MyApp.Demo.Core.Aspect.Autofac.Logging;
using MyApp.Demo.Core.Aspect.Autofac.Performance;
using MyApp.Demo.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using MyApp.Demo.Core.Utilities.Business;
using MyApp.Demo.Core.Utilities.Results;
using MyApp.Demo.DataAccess.Abstract;
using MyApp.Demo.Entities.Concrete;
using MyApp.Demo.Entities.DTOs;

namespace MyApp.Demo.Business.Concrete
{
    public class OrdersManager : IOrdersService
    {
        IOrdersDal _ordersDal;
        public OrdersManager(IOrdersDal ordersDal)
        {
            _ordersDal = ordersDal;
        }
        [ValidationAspect(typeof(OrderValidator), Priority = 1)]
        [CacheRemoveAspect("IOrdersService.Get")]
      
        public IResult Add(Order order)
        {
            
            IResult result = BusinessRules.Run(CheckIfOrdersNameExists(order.OrdersId));
            if (result != null)
            {
                return result;
            }
            _ordersDal.Add(order);
            return new SuccessResult(Messages.OrderAdded);
        }
       
        [LogAspect(typeof(FileLogger))]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Order>> GetByOrderDate(Order order)
        {
            return new SuccessDataResult<List<Order>>(_ordersDal.GetList(d => d.OrdersDate >= order.OrdersDate).ToList());
        } 

        public IResult Delete(int orderId)
        {
            Order orders = _ordersDal.Get(x => x.OrdersId == orderId);
            _ordersDal.Delete(orders);
            return new SuccessResult(Messages.OrderDeleted);
        }
        public IDataResult<List<OrdersDetailDto>> GetByOrderDetailId(int orderId)
        {
            return new SuccessDataResult<List<OrdersDetailDto>>(_ordersDal.GetOrderDetails(orderId).ToList());
        }
        public IDataResult<Order> GetById(int orderId)
        {
            return new SuccessDataResult<Order>(_ordersDal.Get(p => p.OrdersId == orderId));
        }
        [PerformanceAspect(5)]
        public IDataResult<List<Order>> GetList()
        {
            return new SuccessDataResult<List<Order>>(_ordersDal.GetList().ToList());
        }
        public IDataResult<List<Order>> GetListByClient(int clinetId)
        {
            var result = _ordersDal.GetList(p => p.OrdersClient == clinetId);
            return new SuccessDataResult<List<Order>>((List<Order>)result);
        }
        public IResult Update(Order order)
        {
            _ordersDal.Update(order);
            return new SuccessResult(Messages.OrderUpdated);
        }

        #region Checking
        public IResult CheckIfOrdersNameExists(int orderId)
        {
            var result = _ordersDal.GetList();
            if (result == null)
            {
                return new ErrorResult(Messages.OrderAlreadyExists);
            }

            return new SuccessResult();
        }
       
    
        #endregion
    }
}
