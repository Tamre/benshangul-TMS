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
    public class SalvageValueController : ControllerBase
    {
        private readonly ISalvageValueService _salvageValueService;

        public SalvageValueController(ISalvageValueService salvageValueService)
        {
            _salvageValueService = salvageValueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _salvageValueService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(SalvageValuePostDto salvageValueDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _salvageValueService.Add(salvageValueDto));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(SalvageValueGetDto salvageValueDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _salvageValueService.Update(salvageValueDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
