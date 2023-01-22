using Taxually.TechnicalTest.Domain;
using Taxually.TechnicalTest.Domain.VatRegistration;
using Taxually.TechnicalTest.VatServices.Interface;

namespace Taxually.TechnicalTest.VatServices.VatRegistrationServices
{
    public class VatRegistrationService_GB : IVatRegistrationService
    {
        private readonly ITaxuallyHttpClient _taxuallyHttpClient;
        public VatRegistrationService_GB(ITaxuallyHttpClient taxuallyHttpClient)
        {
            _taxuallyHttpClient = taxuallyHttpClient;
        }
        public async Task RegisterVat(VatRegistrationModel vatRegistrationModel)
        {
            // UK has an API to register for a VAT number
            await _taxuallyHttpClient.PostAsync("https://api.uktax.gov.uk", vatRegistrationModel);
        }
    }
}