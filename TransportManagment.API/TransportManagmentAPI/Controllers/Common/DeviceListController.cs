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
    public class DeviceListController : ControllerBase
    {
        private readonly IDeviceListService _DeviceListService;

        public DeviceListController(IDeviceListService DeviceListService)
        {

            _DeviceListService = DeviceListService;

        }

        [HttpGet]
        [ProducesResponseType(typeof(DeviceListGetDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _DeviceListService.GetAll());
        }



        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(DeviceListPostDto DeviceListDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _DeviceListService.Add(DeviceListDto));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(DeviceListGetDto DeviceListDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _DeviceListService.Update(DeviceListDto));
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
