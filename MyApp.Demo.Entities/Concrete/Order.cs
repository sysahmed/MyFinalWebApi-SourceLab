using MyApp.Demo.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Demo.Entities.Concrete
{
    public partial class Order : TEntity
    {
        //public Order()
        //{
        //    OrderLines = new HashSet<OrderLine>();
        //}
        [Key]
        public int OrdersId { get; set; }
        public int OrdersNumber { get; set; }
        public DateTime OrdersDate { get; set; }
        public int OrdersClient { get; set; }
        public decimal OrdersGrandTotal { get; set; }

        //public virtual Client OrdersClientNavigation { get; set; } = null!;
        //public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
