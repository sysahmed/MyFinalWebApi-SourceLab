using MyApp.Demo.Core.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Demo.Entities.Concrete
{
    public partial class OrderLine : TEntity
    {
        [Key]
        public int OrderLinesId { get; set; }
        public int OrderLinesNumber { get; set; }
        public int ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        //public virtual Item Item { get; set; } = null!;
        //public virtual Order OrderLinesNumberNavigation { get; set; } = null!;
    }
}
