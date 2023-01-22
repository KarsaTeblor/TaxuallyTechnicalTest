namespace Taxually.TechnicalTest.VatServices.Interface
{
    public interface ITaxuallyQueueClient
    {
        Task EnqueueAsync<TPayload>(string queueName, TPayload payload);
    }
}