using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentImplementation.Services.Vehicle.Action;

namespace TransportManagmentAPI.Controllers.Vehicle.Action
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataChangeController : ControllerBase
    {

        private readonly DataChangeService _dataChangeService;


        public DataChangeController(DataChangeService dataChangeService)
        {

            _dataChangeService = dataChangeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDataChangeRequests()
        {
            var pagedList = await _dataChangeService.GetAllDataChangeRequests();
            return Ok(new { data = pagedList });
        }
        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateDataChangeRequest(DataChangeDto dataChangePost)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _dataChangeService .CreateDataChangeRequest(dataChangePost));
            }
            else
            {
                return BadRequest();
            }
        }
        
        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ApproveRequestAsync(DataChangeDto dataChangePostDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _dataChangeService.ApproveRequestAsync(dataChangePostDto));
            }
            else
            {
                return BadRequest();
            }
        }



    }
}
