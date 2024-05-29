using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentImplementation.Services.Vehicle.Action;
using TransportManagmentInfrustructure.Model.Vehicle.Action;

namespace TransportManagmentAPI.Controllers.Vehicle.Action
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleReplacementController : ControllerBase
    {

        private readonly IVehicleReplacement _vehicleReplacement;

        public VehicleReplacementController(IVehicleReplacement vehicleReplacement)
        {

            _vehicleReplacement = vehicleReplacement;
        }



        [HttpGet]
        public async Task<IActionResult> GetByVehicleId(Guid vehicleId)
        {
            var pagedList = await _vehicleReplacement.GetByVehicleId(vehicleId);
            return Ok(new { data = pagedList });
        }
        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateReplecementRequest(VehicleReplacementDTO VehicleReplacement)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleReplacement.CreateReplecementRequest(VehicleReplacement));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ApproveRequestAsync(VehicleReplacementDTO VehicleReplacement)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleReplacement.ApproveRequestAsync(VehicleReplacement));
            }
            else
            {
                return BadRequest();
            }
        }



    }
}
