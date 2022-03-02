using MyApp.Demo.Core.Utilities.Results;
using MyApp.Demo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Demo.Business.Abstract
{
    public interface IItemsService
    {
        IDataResult<Item> GetById(int itemId);
        IDataResult<List<Item>> GetList();
        IResult Add(Item items);
        IResult Delete(int itemId);
        IResult Update(Item items);

    }
}
