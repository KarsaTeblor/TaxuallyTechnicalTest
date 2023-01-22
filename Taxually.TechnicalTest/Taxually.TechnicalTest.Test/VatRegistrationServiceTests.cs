using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using Taxually.TechnicalTest.Domain.General;
using Taxually.TechnicalTest.Domain.VatRegistration;
using Taxually.TechnicalTest.VatServices;
using Taxually.TechnicalTest.VatServices.Interface;
using Taxually.TechnicalTest.VatServices.VatRegistrationServices;

namespace Taxually.TechnicalTest.Test
{
    public class Tests
    {

        [Test]
        public async Task VatRegistrationService_CalledWithDifferentCountryCodes_ShouldCallRightServices()
        {
            Mock<IVatRegistrationService> vatRegistrationService_DE = new();
            Mock<IVatRegistrationService> vatRegistrationService_FR = new();
            Mock<IVatRegistrationService> vatRegistrationService_GB = new();

            var vatRegistrationService = new VatRegistrationService(new Dictionary<CountryCode, IVatRegistrationService> {
                { CountryCode.DE, vatRegistrationService_DE.Object },
                { CountryCode.FR, vatRegistrationService_FR.Object },
                { CountryCode.GB, vatRegistrationService_GB.Object }
            });

            await vatRegistrationService.RegisterVat(new VatRegistrationModel
            {
                Country = "DE"
            });

            vatRegistrationService_DE.Verify(v => v.RegisterVat(It.IsAny<VatRegistrationModel>()), Times.Once);
            vatRegistrationService_FR.Verify(v => v.RegisterVat(It.IsAny<VatRegistrationModel>()), Times.Never);
            vatRegistrationService_GB.Verify(v => v.RegisterVat(It.IsAny<VatRegistrationModel>()), Times.Never);

            vatRegistrationService_DE.Invocations.Clear();

            await vatRegistrationService.RegisterVat(new VatRegistrationModel
            {
                Country = "FR"
            });

            vatRegistrationService_DE.Verify(v => v.RegisterVat(It.IsAny<VatRegistrationModel>()), Times.Never);
            vatRegistrationService_FR.Verify(v => v.RegisterVat(It.IsAny<VatRegistrationModel>()), Times.Once);
            vatRegistrationService_GB.Verify(v => v.RegisterVat(It.IsAny<VatRegistrationModel>()), Times.Never);

            vatRegistrationService_FR.Invocations.Clear();

            await vatRegistrationService.RegisterVat(new VatRegistrationModel
            {
                Country = "GB"
            });

            vatRegistrationService_DE.Verify(v => v.RegisterVat(It.IsAny<VatRegistrationModel>()), Times.Never);
            vatRegistrationService_FR.Verify(v => v.RegisterVat(It.IsAny<VatRegistrationModel>()), Times.Never);
            vatRegistrationService_GB.Verify(v => v.RegisterVat(It.IsAny<VatRegistrationModel>()), Times.Once);

            vatRegistrationService_GB.Invocations.Clear();
        }
    }
}