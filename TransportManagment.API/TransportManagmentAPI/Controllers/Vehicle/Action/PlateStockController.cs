using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentImplementation.Services.Vehicle.Action;

namespace TransportManagmentAPI.Controllers.Vehicle.Action
{
    [Route("api/vech-action/[controller]/[action]")]
    [ApiController]
    public class PlateStockController : ControllerBase
    {
        private readonly IPlateStockService _plateStockService;

        public PlateStockController(IPlateStockService plateStockService)
        {
            _plateStockService = plateStockService;
        }


        [HttpGet]
        [ProducesResponseType(typeof(PagedList<PlateStockGetDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] FilterDetail filterData)
        {
            var pagedList = await _plateStockService.GetAll(filterData);
            return Ok(new { data = pagedList, metaData = pagedList.MetaData });
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(PlateStockPostDto PLateStockPost)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _plateStockService.Add(PLateStockPost));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> TransferToZone(TransferToZoneDto TransferToZone)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _plateStockService.TransferToZone(TransferToZone));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(DeletePlateStockDto plateIds)
        {
            return Ok(await _plateStockService.Delete(plateIds));
        }
    }
}
