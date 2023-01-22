using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Domain.General;
using Taxually.TechnicalTest.VatServices.Interface;
using Taxually.TechnicalTest.VatServices.VatRegistrationServices;

namespace Taxually.TechnicalTest.VatServices
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterVatServices(this IServiceCollection services)
        {
            services.AddTransient<ITaxuallyHttpClient, TaxuallyHttpClient>();
            services.AddTransient<ITaxuallyQueueClient, TaxuallyQueueClient>();
            services.AddTransient<IVatRegistrationService, VatRegistrationService>();

            services.AddTransient<IDictionary<CountryCode, IVatRegistrationService>>(sp =>
            {
                return new Dictionary<CountryCode, IVatRegistrationService>() {
                    {CountryCode.FR, new VatRegistrationService_FR(sp.GetService<ITaxuallyQueueClient>()) },
                    {CountryCode.GB, new VatRegistrationService_GB(sp.GetService<TaxuallyHttpClient>()) },
                    {CountryCode.DE, new VatRegistrationService_DE(sp.GetService<ITaxuallyQueueClient>()) }
                };
            });

        }
    }
}
