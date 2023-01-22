using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Domain;
using Taxually.TechnicalTest.Domain.VatRegistration;
using Taxually.TechnicalTest.VatServices.Interface;

namespace Taxually.TechnicalTest.VatServices.VatRegistrationServices
{
    internal class VatRegistrationService_FR : IVatRegistrationService
    {
        private readonly ITaxuallyQueueClient _taxuallyQueueClient;
        public VatRegistrationService_FR(ITaxuallyQueueClient taxuallyQueueClient)
        {
            _taxuallyQueueClient = taxuallyQueueClient;
        }
        public async Task RegisterVat(VatRegistrationModel vatRegistrationModel)
        {
            // France requires an excel spreadsheet to be uploaded to register for a VAT number
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{vatRegistrationModel.CompanyName}{vatRegistrationModel.CompanyId}");
            var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            // Queue file to be processed
            await _taxuallyQueueClient.EnqueueAsync("vat-registration-csv", csv);
        }
    }
}
