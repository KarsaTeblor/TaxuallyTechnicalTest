using Taxually.TechnicalTest.VatServices;
using Taxually.TechnicalTest.VatServices.Interface;

namespace Taxually.TechnicalTest.VatServices
{
    internal class TaxuallyQueueClient: ITaxuallyQueueClient
    {
        public Task EnqueueAsync<TPayload>(string queueName, TPayload payload)
        {
            // Code to send to message queue removed for brevity
            return Task.CompletedTask;
        }
    }
}
