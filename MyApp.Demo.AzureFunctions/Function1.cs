using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace MyApp.Demo.AzureFunctions
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("add-myappdemo", Connection = "AzureWebJobsStorage")] Message message, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {message.Key} - {message.Value}");
        }
    }
}
