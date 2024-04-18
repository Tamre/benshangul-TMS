using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;

namespace TransportManagmentAPI.Controllers.Vehicle.Configuration
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepreciationCostController : ControllerBase
    {
        private readonly IDepreciationCostService _depreciationCostService;

        public DepreciationCostController(IDepreciationCostService depreciationCostService)
        {
            _depreciationCostService = depreciationCostService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _depreciationCostService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(DepreciationCostPostDto depreciationCostDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _depreciationCostService.Add(depreciationCostDto));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(DepreciationCostGetDto depreciationCostDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _depreciationCostService.Update(depreciationCostDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
