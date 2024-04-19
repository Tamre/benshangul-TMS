using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;

namespace TransportManagmentAPI.Controllers.Vehicle.Configuration
{
    // Controller
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleSettingsController : ControllerBase
    {
        private readonly IVehicleSettingsService _vehicleSettingsService;

        public VehicleSettingsController(IVehicleSettingsService vehicleSettingsService)
        {
            _vehicleSettingsService = vehicleSettingsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _vehicleSettingsService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(VehicleSettingsPostDto vehicleSettingsDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleSettingsService.Add(vehicleSettingsDto));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(VehicleSettingsGetDto vehicleSettingsDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleSettingsService.Update(vehicleSettingsDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }

}
