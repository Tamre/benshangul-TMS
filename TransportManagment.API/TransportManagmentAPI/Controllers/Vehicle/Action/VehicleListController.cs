using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;

namespace TransportManagmentAPI.Controllers.Vehicle.Action
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleListController : ControllerBase
    {
        private readonly IVehicleListService _vehicleListService;

        public VehicleListController(IVehicleListService vehicleListService)
        {

            _vehicleListService = vehicleListService;

        }



        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(VehicleListPostDto vehicleListPost)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleListService.Add(vehicleListPost));
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
