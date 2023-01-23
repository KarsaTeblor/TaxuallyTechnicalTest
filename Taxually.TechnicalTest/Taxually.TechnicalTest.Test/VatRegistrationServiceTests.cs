using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Taxually.TechnicalTest.Domain.General;
using Taxually.TechnicalTest.Domain.VatRegistration;
using Taxually.TechnicalTest.VatServices;
using Taxually.TechnicalTest.VatServices.Interface;

namespace Taxually.TechnicalTest.Test
{
    public class Tests
    {
        ServiceCollection services;
        ServiceProvider serviceProvider;

        [SetUp]
        public void Setup()
        {
            IConfigurationRoot configuration;
            var builder = new ConfigurationBuilder();
            configuration = builder.Build();

            services = new ServiceCollection();

            ServiceConfiguration.RegisterServices(services, configuration);

            serviceProvider = services.BuildServiceProvider();
        }

        [Test]
        public async Task VatRegistrationServiceCount_ShouldCheckVatregistrationServiceCount()
        {
            var vatRegistrationServices = serviceProvider.GetService<IDictionary<CountryCode, IVatRegistrationService>>();
            Assert.IsTrue(vatRegistrationServices.Count() == 3);

            Assert.IsTrue(vatRegistrationServices.ContainsKey(CountryCode.FR));
            Assert.IsTrue(vatRegistrationServices.ContainsKey(CountryCode.DE));
            Assert.IsTrue(vatRegistrationServices.ContainsKey(CountryCode.GB));
        }

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