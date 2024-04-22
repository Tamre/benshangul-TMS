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
    public class VehicleSerialSettingController : ControllerBase
    {
        private readonly IVehicleSerialSettingService _vehicleSerialSettingService;

        public VehicleSerialSettingController(IVehicleSerialSettingService vehicleSerialSettingService)
        {
            _vehicleSerialSettingService = vehicleSerialSettingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _vehicleSerialSettingService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(VehicleSerialSettingPostDto vehicleSerialSettingDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleSerialSettingService.Add(vehicleSerialSettingDto));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(VehicleSerialSettingGetDto vehicleSerialSettingDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleSerialSettingService.Update(vehicleSerialSettingDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }

}
