using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;

namespace TransportManagmentAPI.Controllers.Common
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneService _ZoneService;

        public ZoneController(IZoneService ZoneService)
        {

            _ZoneService = ZoneService;

        }

        [HttpGet]
        [ProducesResponseType(typeof(ZoneGetDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] RequestParameter requestParameter)
        {
            return Ok(await _ZoneService.GetAll(requestParameter));
        }



        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(ZonePostDto ZoneDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _ZoneService.Add(ZoneDto));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(ZoneGetDto ZoneDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _ZoneService.Update(ZoneDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
