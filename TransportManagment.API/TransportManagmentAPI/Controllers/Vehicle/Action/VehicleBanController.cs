using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentImplementation.Services.Vehicle.Action;

namespace TransportManagmentAPI.Controllers.Vehicle.Action
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleBanController : ControllerBase
    {

        private readonly IVehicleBanService _vehicleBanService;

        public VehicleBanController(IVehicleBanService vehicleBanService)
        {

            _vehicleBanService = vehicleBanService;

        }


        [HttpGet]
        [ProducesResponseType(typeof(List<VehicleBanGetDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBanHistories(Guid vehicleId)
        {
            var vehicleAnnualInspections = await _vehicleBanService.GetBanHistories(vehicleId);
            return Ok(vehicleAnnualInspections);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> BanVehicle(VehicleBanPostDto vehicleBanPost)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleBanService.BanVehicle(vehicleBanPost));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> LiftBanVehicle(VehicleLiftBanDto liftBanDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleBanService.LiftBanVehicle(liftBanDto));
            }
            else
            {
                return BadRequest();
            }
        }



    }
}
