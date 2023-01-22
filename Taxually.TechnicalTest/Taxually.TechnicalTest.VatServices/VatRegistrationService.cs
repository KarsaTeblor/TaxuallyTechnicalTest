using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Domain.General;
using Taxually.TechnicalTest.Domain.VatRegistration;
using Taxually.TechnicalTest.VatServices.Interface;
using Taxually.TechnicalTest.VatServices.VatRegistrationServices;

namespace Taxually.TechnicalTest.VatServices
{
    public class VatRegistrationService : IVatRegistrationService
    {
        private readonly IDictionary<CountryCode, IVatRegistrationService> _vatRegistrationServices;
        public VatRegistrationService(IDictionary<CountryCode, IVatRegistrationService> vatRegistrationServices)
        {
            _vatRegistrationServices = vatRegistrationServices;
        }
        public async Task RegisterVat(VatRegistrationModel vatRegistrationModel)
        {
            _vatRegistrationServices.TryGetValue(vatRegistrationModel.CountryCode, out IVatRegistrationService? vatRegistrationService);
            if (vatRegistrationService == null)
            {
                throw new ArgumentException($"Unknow CountryCode: {vatRegistrationModel.CountryCode}");
            }

            await vatRegistrationService!.RegisterVat(vatRegistrationModel);
        }
    }
}
