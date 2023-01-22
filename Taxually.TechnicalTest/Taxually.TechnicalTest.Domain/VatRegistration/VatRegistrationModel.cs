using Microsoft.VisualBasic;
using System.Net.NetworkInformation;
using Taxually.TechnicalTest.Domain.General;

namespace Taxually.TechnicalTest.Domain.VatRegistration
{
    public class VatRegistrationModel
    {
        public string CompanyName { get; set; }
        public string CompanyId { get; set; }
        public string Country { get; set; }
        public CountryCode CountryCode
        {
            get
            {
                if(!string.IsNullOrEmpty(Country) && Enum.TryParse<CountryCode>(Country.ToUpper(), out var countryCodeEnum))
            {
                    return countryCodeEnum;
                }

                return CountryCode.Unknown;
            }
        }
    }
}