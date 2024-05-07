using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;
using TransportManagmentImplementation.Services.Vehicle.Configuration;

namespace TransportManagmentAPI.Controllers.Vehicle.Configuration
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleDropDownController : ControllerBase
    {
        private IvehicleDropDownService _vehicleDropDownService; 
        public VehicleDropDownController(IvehicleDropDownService vehicleDropDownService)
        {
            _vehicleDropDownService = vehicleDropDownService;
        }


        [HttpGet]
        public async Task<IActionResult> GetNotAddedDocuments(Guid vehicleId)
        {
            return Ok(await _vehicleDropDownService.GetNotAddedDocuments(vehicleId));
        }
    }
}
