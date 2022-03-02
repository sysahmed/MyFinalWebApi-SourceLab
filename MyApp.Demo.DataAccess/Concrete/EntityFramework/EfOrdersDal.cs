using Microsoft.EntityFrameworkCore;
using MyApp.Demo.Core.DataAccess.EntityFramework;
using MyApp.Demo.DataAccess.Abstract;
using MyApp.Demo.DataAccess.Concrete.EntityFramework.Context;
using MyApp.Demo.Entities.Concrete;
using MyApp.Demo.Entities.DTOs;

namespace MyApp.Demo.DataAccess.Concrete.EntityFramework
{
    public class EfOrdersDal : EfEntityRepositoryBase<Order, MyAppDbContext>, IOrdersDal
    {
        public List<OrdersDetailDto> GetOrderDetails(int clientId)
        {
            using (var db = new MyAppDbContext())
            {

                var data = (from o in db.Orders
                            join c in db.Clients on o.OrdersClient equals c.ClientId
                            join l in db.OrderLines on o.OrdersNumber equals l.OrderLinesNumber
                            join i in db.Items on l.ItemId equals i.ItemId
                            where c.ClientId == clientId
                            select new OrdersDetailDto
                            {
                                OrdersDate = o.OrdersDate,
                                OrdersNumber = l.OrderLinesNumber,
                                ItemName = i.ItemName,
                                UnitPrice = i.UnitPrice,
                                Quantity = l.Quantity,
                                OrdersGrandTotal = i.UnitPrice * l.Quantity

                            }).Distinct().ToList();
                return data;
            }
        }
    }
}
