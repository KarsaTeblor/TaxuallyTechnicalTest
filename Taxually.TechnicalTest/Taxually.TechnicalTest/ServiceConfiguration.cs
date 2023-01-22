using Taxually.TechnicalTest.BL;
using Taxually.TechnicalTest.BL.Interface;
using Taxually.TechnicalTest.VatServices;

namespace Taxually.TechnicalTest
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton(s => new ModelMapper().Instance);
            services.AddTransient<IVatRegistrationServiceManager, VatRegistrationServiceManager>();

            services.RegisterVatServices();
        }
    }
}
