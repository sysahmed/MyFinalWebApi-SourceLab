using MyApp.Demo.Core.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Demo.Entities.Concrete
{
    public partial class Client:TEntity
    {
        //public Client()
        //{
        //    Orders = new HashSet<Order>();
        //}
        [Key]
        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public string? ClientAddress { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
    }
}
