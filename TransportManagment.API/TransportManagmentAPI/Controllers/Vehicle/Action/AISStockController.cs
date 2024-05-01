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
    public class AISStockController : ControllerBase
    {
        private readonly IAISStockService _aISStockService;

        public AISStockController(IAISStockService aISStockService)
        {
            _aISStockService = aISStockService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedList<AISStockGetDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] FilterDetail filterData)
        {
            var pagedList = await _aISStockService.GetAll(filterData);
            return Ok(new { data = pagedList, metaData = pagedList.MetaData });
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
       public async Task<IActionResult> Add(AISStockPostDto AISStockPost)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _aISStockService.Add(AISStockPost));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> TransferToZone(TransferAISToZoneDto TransferToZone)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _aISStockService.TransferToZone(TransferToZone));
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
