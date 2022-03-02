using MyApp.Demo.Business.Abstract;
using MyApp.Demo.Business.Constants;
using MyApp.Demo.Core.Utilities.Results;
using MyApp.Demo.DataAccess.Abstract;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.Business.Concrete
{
    public class ClientsManager : IClientsService
    {
        IClientsDal _clientsDal;
        public ClientsManager(IClientsDal clientsDal)
        {
            _clientsDal = clientsDal;
        }
        public IResult Add(Client clients)
        {
            _clientsDal.Add(clients);
            return new SuccessResult(Messages.ClientAdded);
        }

        public IResult Delete(int clientId)
        {
            Client clients = _clientsDal.Get(x => x.ClientId == clientId);
            _clientsDal.Delete(clients);
            return new SuccessResult(Messages.ClientDeleted);
        }

        public IDataResult<Client> GetById(int clientId)
        {
            return new SuccessDataResult<Client>(_clientsDal.Get(p => p.ClientId == clientId));
        }

        public IDataResult<List<Client>> GetList()
        {
            return new SuccessDataResult<List<Client>>(_clientsDal.GetList().ToList());
        }

        public IResult Update(Client clients)
        {
            _clientsDal.Update(clients);
            return new SuccessResult(Messages.ClientUpdated);
        }
    }
}
