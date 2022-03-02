using Azure.Storage.Queues;
using System.Text.Json;

namespace MyApp.Demo.Core.DataAccess.Azure
{
    public class AzureRepository<TEntity> : IAzureRepository<TEntity>
      where TEntity : class, Abstract.TEntity, new()
    {
        public void AddAzureMessage(TEntity entity,string connectionString,string queueName)
        {
            var queueClients = new QueueClient(connectionString, queueName);
            var message = JsonSerializer.Serialize(entity);
            queueClients.SendMessageAsync(message);
        }
    }
}
