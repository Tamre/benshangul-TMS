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
    public class InitialPriceController : ControllerBase
    {
        private readonly IInitialPriceService _initialPriceService;

        public InitialPriceController(IInitialPriceService initialPriceService)
        {
            _initialPriceService = initialPriceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _initialPriceService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(InitialPricePostDto initialPriceDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _initialPriceService.Add(initialPriceDto));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(InitialPriceGetDto initialPriceDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _initialPriceService.Update(initialPriceDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
