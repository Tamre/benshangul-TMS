using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;

namespace TransportManagmentAPI.Controllers.Vehicle.Configuration
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturingCountryController : ControllerBase
    {
        private readonly IManufacturingCountryService _manufacturingCountryService;

        public ManufacturingCountryController(IManufacturingCountryService manufacturingCountryService)
        {
            _manufacturingCountryService = manufacturingCountryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _manufacturingCountryService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(ManufacturingCountryPostDto manufacturingCountryDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _manufacturingCountryService.Add(manufacturingCountryDto));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(ManufacturingCountryGetDto manufacturingCountryDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _manufacturingCountryService.Update(manufacturingCountryDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
