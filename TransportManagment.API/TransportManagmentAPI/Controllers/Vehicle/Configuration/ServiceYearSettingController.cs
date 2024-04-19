using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;

namespace TransportManagmentAPI.Controllers.Vehicle.Configuration
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceYearSettingController : ControllerBase
    {
        private readonly IServiceYearSettingService _serviceYearSettingService;

        public ServiceYearSettingController(IServiceYearSettingService serviceYearSettingService)
        {
            _serviceYearSettingService = serviceYearSettingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _serviceYearSettingService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(ServiceYearSettingPostDto serviceYearSettingDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _serviceYearSettingService.Add(serviceYearSettingDto));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(ServiceYearSettingGetDto serviceYearSettingDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _serviceYearSettingService.Update(serviceYearSettingDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
