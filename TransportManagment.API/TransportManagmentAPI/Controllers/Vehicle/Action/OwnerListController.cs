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
    public class OwnerListController : ControllerBase
    {

        private readonly OwnerManagmentService _ownerService;


        public OwnerListController(OwnerManagmentService ownerService)
        {

            _ownerService = ownerService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<OwnerListGetDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOwnerByVechicleId(Guid vehicleId)
        {
            var vehicleAnnualInspections = await _ownerService.GetOwnerByVechicleId(vehicleId);
            return Ok(vehicleAnnualInspections);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddOwner(OwnerListPostDto ownerPost)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _ownerService.CreateOwner(ownerPost));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateOwner(OwnerListGetDto ownerListGetDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _ownerService.UpdateOwner(ownerListGetDto));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AssignOwner(VehicleOwnerDto vehicleOwnerDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _ownerService.AssignOwner(vehicleOwnerDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
