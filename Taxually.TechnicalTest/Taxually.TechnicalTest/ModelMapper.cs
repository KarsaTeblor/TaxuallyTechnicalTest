using AutoMapper;
using Taxually.TechnicalTest.Domain.VatRegistration;
using Taxually.TechnicalTest.Model;

namespace Taxually.TechnicalTest
{
    public class ModelMapper
    {
        public IMapper Instance { get; }

        public ModelMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VatRegistrationRequest, VatRegistrationModel>().ReverseMap();
            });

            config.AssertConfigurationIsValid();

            Instance = config.CreateMapper();
        }
    }
}
