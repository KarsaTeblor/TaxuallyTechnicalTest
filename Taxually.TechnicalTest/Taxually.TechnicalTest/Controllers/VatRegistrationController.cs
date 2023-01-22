using System.Net;
using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Taxually.TechnicalTest.BL.Interface;
using Taxually.TechnicalTest.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        private readonly IVatRegistrationServiceManager _vatRegistrationServiceManager;
        private readonly ILogger<VatRegistrationController> _logger;
        public VatRegistrationController(IVatRegistrationServiceManager vatRegistrationServiceManager, ILogger<VatRegistrationController> logger)
        {
            _vatRegistrationServiceManager = vatRegistrationServiceManager;
            _logger = logger;
        }
        /// <summary>
        /// Registers a company for a VAT number.
        /// </summary>
        /// <param name="vatRegistrationRequest">VAT registration details.</param>
        /// <returns>HttpStatusCode</returns>
        [HttpPost]
        [Route("register")]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = null)]
        public async Task<ActionResult> Register([FromBody] VatRegistrationRequest vatRegistrationRequest)
        {
            var serviceResponse = await _vatRegistrationServiceManager.RegisterVat(vatRegistrationRequest);
            if (serviceResponse.HasError)
            {
                return StatusCode(500);
            }
            return Ok();
        }
    }
}
