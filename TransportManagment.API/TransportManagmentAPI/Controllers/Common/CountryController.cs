using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentImplementation.Services.Common;

namespace TransportManagmentAPI.Controllers.Common
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
   
    public class CountryController : ControllerBase
    {

        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {

            _countryService = countryService;

        }

        [HttpGet]
        [ProducesResponseType(typeof(CountryGetDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _countryService.GetAll());
        }



        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(CountryPostDto CountryDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _countryService.Add(CountryDto));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(CountryGetDto CountryDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _countryService.Update(CountryDto));
            }
            else
            {
                return BadRequest();
            }
        }



    }
}
