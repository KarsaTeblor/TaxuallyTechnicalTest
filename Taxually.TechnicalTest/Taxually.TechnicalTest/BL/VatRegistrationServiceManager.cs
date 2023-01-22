using AutoMapper;
using Taxually.TechnicalTest.BL.Interface;
using Taxually.TechnicalTest.Domain.VatRegistration;
using Taxually.TechnicalTest.Model;
using Taxually.TechnicalTest.VatServices;
using Taxually.TechnicalTest.VatServices.Interface;

namespace Taxually.TechnicalTest.BL
{
    public class VatRegistrationServiceManager : IVatRegistrationServiceManager
    {
        private readonly IMapper _mapper;
        private readonly ILogger<VatRegistrationServiceManager> _logger;
        private readonly IVatRegistrationService _vatRegistrationService;
        public VatRegistrationServiceManager(IMapper mapper, ILogger<VatRegistrationServiceManager> logger, IVatRegistrationService vatRegistrationService)
        {
            _mapper = mapper;
            _logger = logger;
            _vatRegistrationService = vatRegistrationService;
        }
        public async Task<ServiceResult<VatRegistrationResponse>> RegisterVat(VatRegistrationRequest vatRegistrationRequest)
        {
            try
            {
                var vatRegistrationModel = _mapper.Map<VatRegistrationModel>(vatRegistrationRequest);
                await _vatRegistrationService.RegisterVat(vatRegistrationModel);
                return new ServiceResult<VatRegistrationResponse>
                {
                    Error = ErrorStatusCode.None,
                    Result = new VatRegistrationResponse()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[VatRegistrationServiceManager.RegisterVat] Couldn't register VAT!");
                return new ServiceResult<VatRegistrationResponse>
                {
                    Error = ErrorStatusCode.UnknownError,
                    Result = null
                };
            }

        }
    }
}
