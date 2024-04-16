using Microsoft.AspNetCore.Authorization;
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
  
    public class WoredaController : ControllerBase
    {
        private readonly IWoredaService _WoredaService;

        public WoredaController(IWoredaService WoredaService)
        {

            _WoredaService = WoredaService;

        }

        [HttpGet]
        [ProducesResponseType(typeof(WoredaGetDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _WoredaService.GetAll());
        }



        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(WoredaPostDto WoredaDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _WoredaService.Add(WoredaDto));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(WoredaGetDto WoredaDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _WoredaService.Update(WoredaDto));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
