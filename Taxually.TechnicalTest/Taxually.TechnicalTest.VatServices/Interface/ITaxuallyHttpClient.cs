namespace Taxually.TechnicalTest.VatServices.Interface
{
    public interface ITaxuallyHttpClient
    {
        Task PostAsync<TRequest>(string url, TRequest request);
    }
}