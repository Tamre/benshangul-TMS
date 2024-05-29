using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentImplementation.Services.Vehicle.Action;

namespace TransportManagmentAPI.Controllers.Vehicle.Action
{
  
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class VehicleCancellationController : ControllerBase
        {
            private readonly IVehicleCancellationService _VehicleCancellationService;


        public VehicleCancellationController(IVehicleCancellationService vehicleCancellation)
        {
            _VehicleCancellationService = vehicleCancellation;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<VehicleCancellationDTO>>> getGetVehicleCancellationById(Guid Id)
        {
            var pagedList = await _VehicleCancellationService.GetVehicleCancellationById(Id);
            return Ok(new { data = pagedList });
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]



        public async Task<IActionResult> CreateVehicleCancellation(VehicleCancellationDTO vehicleCancilation)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _VehicleCancellationService.CreateVehicleCancellation(vehicleCancilation));
            }
            else
            {
                return BadRequest();
            }
        }
        
        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> upUpdateVehicleCancellation(VehicleCancellationDTO vehicleCancilation)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _VehicleCancellationService.UpdateVehicleCancellation(vehicleCancilation));
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
