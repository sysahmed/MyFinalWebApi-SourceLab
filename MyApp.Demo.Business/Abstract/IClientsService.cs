using MyApp.Demo.Core.Utilities.Results;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.Business.Abstract
{
    public interface IClientsService
    {
        IDataResult<Client> GetById(int clientId);
        IDataResult<List<Client>> GetList();
        IResult Add(Client clients);
        IResult Delete(int clientId);
        IResult Update(Client clients);

    }
}
