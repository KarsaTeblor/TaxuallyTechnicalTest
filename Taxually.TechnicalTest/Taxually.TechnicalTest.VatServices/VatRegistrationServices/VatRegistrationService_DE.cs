using System.IO;
using System.Xml.Serialization;
using Taxually.TechnicalTest.Domain;
using Taxually.TechnicalTest.Domain.VatRegistration;
using Taxually.TechnicalTest.VatServices.Interface;

namespace Taxually.TechnicalTest.VatServices.VatRegistrationServices
{
    internal class VatRegistrationService_DE : IVatRegistrationService
    {
        private readonly ITaxuallyQueueClient _taxuallyQueueClient;
        public VatRegistrationService_DE(ITaxuallyQueueClient taxuallyQueueClient)
        {
            _taxuallyQueueClient = taxuallyQueueClient;
        }
        public async Task RegisterVat(VatRegistrationModel vatRegistrationModel)
        {
            // Germany requires an XML document to be uploaded to register for a VAT number
            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(VatRegistrationModel));
                serializer.Serialize(stringwriter, vatRegistrationModel);
                var xml = stringwriter.ToString();
                // Queue xml doc to be processed
                await _taxuallyQueueClient.EnqueueAsync("vat-registration-xml", xml);
            }
        }
    }
}
