using MyApp.Demo.Business.Abstract;
using MyApp.Demo.Business.Constants;
using MyApp.Demo.Core.Utilities.Results;
using MyApp.Demo.DataAccess.Abstract;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.Business.Concrete
{
    public class ItemsManager : IItemsService
    {
        IItemsDal _itemsDal;
        public ItemsManager(IItemsDal itemsDal)
        {
            _itemsDal = itemsDal;
        }
        public IResult Add(Item items)
        {
            _itemsDal.Add(items);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(int itemId)
        {
           Item item = _itemsDal.Get(x => x.ItemId == itemId);
            _itemsDal.Delete(item);
            return new SuccessResult(Messages.ItemDeleted);
        }
        public IDataResult<Item> GetById(int itemId)
        {
            return new SuccessDataResult<Item>(_itemsDal.Get(p => p.ItemId == itemId));
        }
        public IDataResult<List<Item>> GetList()
        {
            return new SuccessDataResult<List<Item>>(_itemsDal.GetList().ToList());
        }
        public IResult Update(Item items)
        {
           _itemsDal.Update(items);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
