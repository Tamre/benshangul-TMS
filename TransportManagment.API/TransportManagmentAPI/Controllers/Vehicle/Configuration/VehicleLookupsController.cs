using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;

namespace TransportManagmentAPI.Controllers.Vehicle.Configuration
{
    [Route("api/vech-config/[controller]")]
    [ApiController]
    public class VehicleLookupsController : ControllerBase
    {
        private readonly IVehicleLookupsService _vehicleLookupsService;

        public VehicleLookupsController(IVehicleLookupsService vehicleLookupsService)
        {
            _vehicleLookupsService = vehicleLookupsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _vehicleLookupsService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(VehicleLookupsPostDto vehicleLookupsDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleLookupsService.Add(vehicleLookupsDto));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(VehicleLookupsGetDto vehicleLookupsDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleLookupsService.Update(vehicleLookupsDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
