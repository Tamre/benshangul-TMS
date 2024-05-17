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
    public class AISController : ControllerBase
    {

        private readonly AISService _aisService; 


        public AISController (AISService aisService)
        {
            
           _aisService = aisService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<AISStockGetDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAISByVehicleId(Guid vehicleId)
        {
            var vehicleAnnualInspections = await _aisService.GetAISByVehicleId(vehicleId);
            return Ok(vehicleAnnualInspections);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateAnnualInspection(AISPostDto aisPost)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _aisService.CreateAnnualInspection(aisPost));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PrintAnnualInspection(Guid aisId)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _aisService.PrintAnnualInspection(aisId));
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
