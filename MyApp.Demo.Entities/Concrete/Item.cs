using MyApp.Demo.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Demo.Entities.Concrete
{
    public partial class Item : TEntity
    {
        //public Item()
        //{
        //    OrderLines = new HashSet<OrderLine>();
        //}
        [Key]
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }
        public decimal UnitPrice { get; set; }

    //    public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
