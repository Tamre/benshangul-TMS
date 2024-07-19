using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;

namespace TransportManagmentAPI.Controllers.Vehicle.Action
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrakeController : ControllerBase
    {


        private readonly IBrake _brakeData;
        private readonly IBrake _service;
        private readonly IConfiguration _configuration;
        private readonly ILogger<BrakeInspectionDTO> _logger;


        public BrakeController(IBrake brakedata,IBrake service, IConfiguration configuration)
        {

            _brakeData = brakedata;
            _service = service;
            _configuration = configuration;
           // _logger = logger;

        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task CreateBrake(IEnumerable<BrakeInspectionDTO> data)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _brakeData.CreateBrake(data));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var data = await _service.GetDataFromJEVOLAsync();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> SaveData()
        {
            try
            {
                var data = await _service.GetDataFromJEVOLAsync();
                await _brakeData.CreateBrake(data);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving vehicle data to SQL");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error saving vehicle data to SQL");
            }

        }

        }
}
