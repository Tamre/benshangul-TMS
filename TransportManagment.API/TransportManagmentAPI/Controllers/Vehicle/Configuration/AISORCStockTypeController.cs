using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;

namespace TransportManagmentAPI.Controllers.Vehicle.Configuration
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AISORCStockTypeController : ControllerBase
    {
        private readonly IAISORCStockTypeService _AISORCStockTypeService;

        public AISORCStockTypeController(IAISORCStockTypeService AISORCStockTypeService)
        {

            _AISORCStockTypeService = AISORCStockTypeService;

        }

        [HttpGet]
        [ProducesResponseType(typeof(AISORCStockTypeGetDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _AISORCStockTypeService.GetAll());
        }



        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(AISORCStockTypePostDto AISORCStockTypeDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _AISORCStockTypeService.Add(AISORCStockTypeDto));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(AISORCStockTypeGetDto AISORCStockTypeDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _AISORCStockTypeService.Update(AISORCStockTypeDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
