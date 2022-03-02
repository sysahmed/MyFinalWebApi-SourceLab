using MyApp.Demo.Core.DataAccess;
using MyApp.Demo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Demo.DataAccess.Abstract
{
    public interface IOrderLinesDal:IEntityRepository<OrderLine>
    {
    }
}
