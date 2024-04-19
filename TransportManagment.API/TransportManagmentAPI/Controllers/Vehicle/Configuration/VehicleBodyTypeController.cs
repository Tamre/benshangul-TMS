using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;

namespace TransportManagmentAPI.Controllers.Vehicle.Configuration
{
    // Controller
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleBodyTypeController : ControllerBase
    {
        private readonly IVehicleBodyTypeService _vehicleBodyTypeService;

        public VehicleBodyTypeController(IVehicleBodyTypeService vehicleBodyTypeService)
        {
            _vehicleBodyTypeService = vehicleBodyTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _vehicleBodyTypeService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(VehicleBodyTypePostDto vehicleBodyTypeDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleBodyTypeService.Add(vehicleBodyTypeDto));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(VehicleBodyTypeGetDto vehicleBodyTypeDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleBodyTypeService.Update(vehicleBodyTypeDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }

}
