using Taxually.TechnicalTest.VatServices;
using Taxually.TechnicalTest.VatServices.Interface;

namespace Taxually.TechnicalTest.VatServices
{
    internal class TaxuallyHttpClient: ITaxuallyHttpClient
    {
        public Task PostAsync<TRequest>(string url, TRequest request)
        {
            // Actual HTTP call removed for purposes of this exercise
            return Task.CompletedTask;
        }
    }
}
