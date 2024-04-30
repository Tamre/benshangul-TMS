using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;

namespace TransportManagmentAPI.Controllers.Vehicle.Configuration
{
    [Route("api/vech-config/[controller]/[action]")]
    [ApiController]
    public class ValuationReasonController : ControllerBase
    {
        private readonly IValuationReasonService _ValuationReasonService;

        public ValuationReasonController(IValuationReasonService ValuationReasonService)
        {

            _ValuationReasonService = ValuationReasonService;

        }

        [HttpGet]
        [ProducesResponseType(typeof(ValuationReasonGetDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ValuationReasonService.GetAll());
        }



        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(ValuationReasonPostDto ValuationReasonDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _ValuationReasonService.Add(ValuationReasonDto));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(ValuationReasonGetDto ValuationReasonDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _ValuationReasonService.Update(ValuationReasonDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
