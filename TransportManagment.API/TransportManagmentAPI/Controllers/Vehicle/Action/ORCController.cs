using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Services.Vehicle.Action;

namespace TransportManagmentAPI.Controllers.Vehicle.Action
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ORCController : ControllerBase
    {

        private readonly ORCService _ORCService;


        public ORCController(ORCService ORCService)
        {

            _ORCService = ORCService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ORCStockGetDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetORCByVehicleId(Guid vehicleId)
        {
            var vehicleAnnualInspections = await _ORCService.GetORCByVehicleId(vehicleId);
            return Ok(vehicleAnnualInspections);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateAnnualInspection(ORCPostDto ORCPost)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _ORCService.CreateOwnerRegistration(ORCPost));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PrintAnnualInspection(Guid ORCId)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _ORCService.PrintOwnerRegistration(ORCId));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
