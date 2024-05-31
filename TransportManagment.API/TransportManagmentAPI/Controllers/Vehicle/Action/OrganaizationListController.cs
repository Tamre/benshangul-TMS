using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransportManagmentImplementation.DTOS.Organaizations;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Organaizations;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentImplementation.Services.Vehicle.Action;

namespace TransportManagmentAPI.Controllers.Vehicle.Action
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrganaizationListController : ControllerBase
    {

        private readonly IOrganaizationList _organizationList;


        public OrganaizationListController(IOrganaizationList organizationList)
        {

            _organizationList = organizationList;
        }
        [HttpPost]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateOrganization(OrganizationDTO organization)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _organizationList.CreateOrganization(organization));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateOrganization(OrganizationDTO organization)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _organizationList.UpdateOrganization(organization));
            }
            else
            {
                return BadRequest();
            }
        }

       



        [HttpGet]
        [ProducesResponseType(typeof(OwnerListGetDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllOrganizations([FromQuery] FilterDetail filterDetail)
        {
            if (ModelState.IsValid)
            {
                var pagedList = await _organizationList.GetAllOrganizations(filterDetail);
                return Ok(new { data = pagedList, metaData = pagedList.MetaData });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ResponseMessage), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(Guid organization)
        {
            return Ok(await _organizationList.DeleteOrganization(organization));
        }


    }
}
