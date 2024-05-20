using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;
using TransportManagmentImplementation.Services.Vehicle.Action;

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

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddVehicleDocument(AddVehicleDocumetDto addVehicleDocument)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleListService.AddVehicleDocument(addVehicleDocument));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(VehicleDetailDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetVehicleDetail(VehicleGetParameterDto vehicleGet)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleListService.GetVehicleDetail(vehicleGet));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(PagedList<PlateStockGetDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFilterdVehicles([FromQuery] FilterDetail filterData)
        {
            var pagedList = await _vehicleListService.GetAll(filterData);
            return Ok(new { data = pagedList, metaData = pagedList.MetaData });
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(UpdateVehicleDto updteVehicle)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleListService.Update(updteVehicle));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ChangeVechicleActionStatus(VehicleStatusActionDto updteVehicle)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _vehicleListService.VehicleActionStatus(updteVehicle));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
