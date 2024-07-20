using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Organaizations;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Organaizations;

namespace TransportManagmentAPI.Controllers.Organaization
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class OrganizationCompoundController : ControllerBase
    {
     

            private readonly IOrganaizationCompound _organization;


            public OrganizationCompoundController(IOrganaizationCompound organization)
            {

                _organization = organization;
            }
            [HttpPost]
            [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
            public async Task<IActionResult> Add(OrganizationCompoundDto organization)
            {
                if (ModelState.IsValid)
                {
                    return Ok(await _organization.Add(organization));
                }
                else
                {
                    return BadRequest();
                }
            }


            [HttpPut]
            [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
            public async Task<IActionResult> Update(OrganizationCompoundDto organization)
            {
                if (ModelState.IsValid)
                {
                    return Ok(await _organization.Update(organization));
                }
                else
                {
                    return BadRequest();
                }
            }




            [HttpGet]
            [ProducesResponseType(typeof(List<OrganizationCompoundDto>), (int)HttpStatusCode.OK)]
            public async Task<IActionResult> GetAll(Guid Id)
            {
                var pagedList = await _organization.GetAll(Id);
                return Ok(new { data = pagedList });
            }

            [HttpDelete]
            [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
            public async Task<IActionResult> Delete(Guid organization)
            {
                return Ok(await _organization.Delete(organization));
            }


        
    }
}
