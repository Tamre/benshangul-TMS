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
    public class PlateTypeController : ControllerBase
    {
        private readonly IPlateTypeService _plateTypeService;

        public PlateTypeController(IPlateTypeService plateTypeService)
        {
            _plateTypeService = plateTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _plateTypeService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(PlateTypePostDto plateTypeDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _plateTypeService.Add(plateTypeDto));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(PlateTypeGetDto plateTypeDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _plateTypeService.Update(plateTypeDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
