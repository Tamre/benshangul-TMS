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
    public class CommonCodeController : ControllerBase
    {
        private readonly ICommonCodeService _CommonCodeService;

        public CommonCodeController(ICommonCodeService CommonCodeService)
        {

            _CommonCodeService = CommonCodeService;

        }

        [HttpGet]
        [ProducesResponseType(typeof(CommonCodeGetDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] RequestParameter requestParameter)
        {
            return Ok(await _CommonCodeService.GetAll(requestParameter));
        }



        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(CommonCodePostDto CommonCodeDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _CommonCodeService.Add(CommonCodeDto));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(CommonCodeGetDto CommonCodeDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _CommonCodeService.Update(CommonCodeDto));
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
