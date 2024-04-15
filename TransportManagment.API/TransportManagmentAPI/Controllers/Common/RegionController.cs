using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;

namespace TransportManagmentAPI.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _RegionService;

        public RegionController(IRegionService RegionService)
        {

            _RegionService = RegionService;

        }

        [HttpGet]
        [ProducesResponseType(typeof(RegionGetDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _RegionService.GetAll());
        }



        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(RegionPostDto RegionDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _RegionService.Add(RegionDto));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(RegionGetDto RegionDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _RegionService.Update(RegionDto));
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
