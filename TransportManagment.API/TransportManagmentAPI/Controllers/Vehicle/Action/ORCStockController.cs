using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;

namespace TransportManagmentAPI.Controllers.Vehicle.Action
{
    [Route("api/vech-action/[controller]/[action]")]
    [ApiController]
    public class ORCStockController : ControllerBase
    {
        private readonly IORCStockService _oRCStockService;

        public ORCStockController(IORCStockService oRCStockService)
        {
            _oRCStockService = oRCStockService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedList<ORCStockGetDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] FilterDetail filterData)
        {
            var pagedList = await _oRCStockService.GetAll(filterData);
            return Ok(new { data = pagedList, metaData = pagedList.MetaData });
        }



        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(ORCStockPostDto ORCStockPost)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _oRCStockService.Add(ORCStockPost));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> TransferToZone(TransferORCToZoneDto TransferToZone)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _oRCStockService.TransferToZone(TransferToZone));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
