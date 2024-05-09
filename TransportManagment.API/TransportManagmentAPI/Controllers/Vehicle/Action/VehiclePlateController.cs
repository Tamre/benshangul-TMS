using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentImplementation.Services.Vehicle.Action;

namespace TransportManagmentAPI.Controllers.Vehicle.Action
{
    [Route("api/vech-action/[controller]/[action]")]
    [ApiController]
    public class VehiclePlateController : ControllerBase
    {
        private readonly IVehiclePlateService _vehiclePlateService;

        public VehiclePlateController(IVehiclePlateService vehiclePlateService)
        {
            _vehiclePlateService = vehiclePlateService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<VehiclePlateGetDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByVehicleId(Guid vehicleId)
        {
            var pagedList = await _vehiclePlateService.GetByVehicleId(vehicleId);
            return Ok(new { data = pagedList});
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AssignPlate(VehiclePlatePostDto vehiclePlateDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehiclePlateService.AssignPlate(vehiclePlateDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
