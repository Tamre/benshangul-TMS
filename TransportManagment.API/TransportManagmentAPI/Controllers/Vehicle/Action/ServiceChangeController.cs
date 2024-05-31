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
    public class ServiceChangeController: ControllerBase
    {

        private readonly IServiceChange _serviceChangeService;

        public ServiceChangeController(IServiceChange serviceChangeService)
        {

            _serviceChangeService = serviceChangeService;
        }


        [HttpGet]
        public async Task<IActionResult> GetByVehicleId(Guid vehicleId)
        {
            var pagedList = await _serviceChangeService.GetByVehicleId(vehicleId);
            return Ok(new { data = pagedList });
        }
        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateDataChangeRequest(ServiceChangeDTO serviceChangePost)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _serviceChangeService.CreateServiceChangeRequest(serviceChangePost));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ApproveRequestAsync(ServiceChangeDTO serviceChangePost)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _serviceChangeService.ApproveRequestAsync(serviceChangePost));
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
