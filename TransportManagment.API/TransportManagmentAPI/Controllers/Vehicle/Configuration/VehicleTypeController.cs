using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;

namespace TransportManagmentAPI.Controllers.Vehicle.Configuration
{
    // Controller
    [Route("api/vech-config/[controller]/[action]")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        private readonly IVehicleTypeService _vehicleTypeService;

        public VehicleTypeController(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _vehicleTypeService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(VehicleTypePostDto vehicleTypeDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleTypeService.Add(vehicleTypeDto));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(VehicleTypeGetDto vehicleTypeDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleTypeService.Update(vehicleTypeDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }

}
