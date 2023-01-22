using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest.BL.Interface
{
    public interface IVatRegistrationServiceManager
    {
        Task<ServiceResult<VatRegistrationResponse>> RegisterVat(VatRegistrationRequest vatRegistrationRequest);
    }
}