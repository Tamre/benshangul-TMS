using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentImplementation.Services.Vehicle;
using TransportManagmentInfrustructure.Model.Vehicle.Action;

namespace TransportManagmentAPI.Controllers.Vehicle.Action
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleTransferController : ControllerBase
    {
        private readonly IVehicleTransfer _vehicleTransferService;

        public VehicleTransferController(IVehicleTransfer vehicleTransferService)
        {
            _vehicleTransferService = vehicleTransferService;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<VehicleTransferDTO>>> GetVehicleTransferByIdAsync( Guid Id)
        {
            var pagedList = await _vehicleTransferService.GetVehicleTransferByIdAsync(Id);
            return Ok(new { data = pagedList });
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleTransferDTO>> GetAllTransfersFromZone(int id )
        {
            var vehicleTransfer = await _vehicleTransferService.GetAllTransfersFromZone(id);
            if (vehicleTransfer == null)
                return NotFound();

            return Ok(vehicleTransfer);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
       


        public async Task<IActionResult> CreateVehicleTransferAsync(VehicleTransferDTO VehicleReplacement)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleTransferService.CreateVehicleTransferAsync(VehicleReplacement));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
