using MyApp.Demo.Core;

namespace MyApp.Demo.Entities.DTOs
{
    public class OrdersDetailDto:IDto
    {
        public int OrdersNumber { get; set; }
        public string? ItemName { get; set; }
        public string? ClientName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal OrdersGrandTotal { get; set; } 
        public DateTime OrdersDate { get; set; }
      
    }
}
