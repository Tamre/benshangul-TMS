using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;

namespace TransportManagmentAPI.Controllers.Vehicle.Configuration
{
    [Route("api/vech-config/[controller]/[action]")]
    [ApiController]
    public class BanBodyController : ControllerBase
    {
        private readonly IBanBodyService _BanBodyService;

        public BanBodyController(IBanBodyService BanBodyService)
        {

            _BanBodyService = BanBodyService;

        }

        [HttpGet]
        [ProducesResponseType(typeof(BanBodyGetDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll( [FromQuery] RequestParameter requestParameter)
        {
            return Ok(await _BanBodyService.GetAll(requestParameter));
        }



        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(BanBodyPostDto BanBodyDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _BanBodyService.Add(BanBodyDto));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(BanBodyGetDto BanBodyDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _BanBodyService.Update(BanBodyDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
