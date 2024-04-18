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
    public class FactoryPointController : ControllerBase
    {
        private readonly IFactoryPointService _factoryPointService;

        public FactoryPointController(IFactoryPointService factoryPointService)
        {
            _factoryPointService = factoryPointService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _factoryPointService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(FactoryPointPostDto factoryPointDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _factoryPointService.Add(factoryPointDto));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(FactoryPointGetDto factoryPointDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _factoryPointService.Update(factoryPointDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
