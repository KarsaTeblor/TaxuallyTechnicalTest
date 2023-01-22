using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Domain;
using Taxually.TechnicalTest.Domain.VatRegistration;

namespace Taxually.TechnicalTest.VatServices.Interface
{
    public interface IVatRegistrationService
    {
        Task RegisterVat(VatRegistrationModel vatRegistrationModel);
    }
}
