using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentImplementation.Services.Common;

namespace TransportManagmentAPI.Controllers.Common
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CompanyProfileController : ControllerBase
    {
        private readonly ICompanyProfileService _companyProfileService;
        public CompanyProfileController(ICompanyProfileService companyProfileService) {
            _companyProfileService = companyProfileService;
        }



        [HttpGet]
        [ProducesResponseType(typeof(CompanyProfileGetDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _companyProfileService.Get());
        }



        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(CompanyProfileGetDto companyProfileGet)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _companyProfileService.Update(companyProfileGet));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
