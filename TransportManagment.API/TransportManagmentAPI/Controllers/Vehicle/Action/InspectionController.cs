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
    public class InspectionController : ControllerBase
    {

        private readonly IInpsectionService _inspectionService;

        public InspectionController(IInpsectionService inspectionService)
        {

            _inspectionService = inspectionService;

        }



        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateFieldInspection(FieldInspectionPostDto inspectionPost)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _inspectionService.CreateFieldInspection(inspectionPost));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateFieldInspection(FieldInspectionGetDto inspectionGet)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _inspectionService.UpdateFieldInspection(inspectionGet));
            }
            else
            {
                return BadRequest();
            }
        }



        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateTechnicalInspection(TechnicalInspectionPostDto inspectionPost)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _inspectionService.CreateTechnicalInspection(inspectionPost));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateTechnicalInspection(TechnicalInspectionGetDto inspectionGet)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _inspectionService.UpdateTechnicalInspection(inspectionGet));
            }
            else
            {
                return BadRequest();
            }
        }



        [HttpGet]
        [ProducesResponseType(typeof(InspectionDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetInspectionDetailByVehicleId(Guid vehicleId)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _inspectionService.GetInspectionByVehicleId(vehicleId));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(InspectionDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetInspectionByModelId(int modelId)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _inspectionService.GetInspectionByModelId(modelId));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
