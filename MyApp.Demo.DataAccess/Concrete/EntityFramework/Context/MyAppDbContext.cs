using Microsoft.EntityFrameworkCore;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.DataAccess.Concrete.EntityFramework.Context
{
    public class MyAppDbContext:DbContext
    {
        public virtual DbSet<Client> Clients { get; set; } 
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; } 
        public virtual DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(@"Server=DEVOPS\SQLEXPRESS;Database=MyAppDataBase;Trusted_Connection=true");
                    //("Server=10.168.0.5;Database=DataSource;User Id=sa;Password=wrjkd34mk22");
            }
        }
    }
}
