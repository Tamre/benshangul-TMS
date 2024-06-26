﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;
using TransportManagmentImplementation.Services.Vehicle.Configuration;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentAPI.Controllers.Vehicle.Configuration
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VehicleDropDownController : ControllerBase
    {
        private IvehicleDropDownService _vehicleDropDownService; 
        public VehicleDropDownController(IvehicleDropDownService vehicleDropDownService)
        {
            _vehicleDropDownService = vehicleDropDownService;
        }


        [HttpGet]
        public async Task<IActionResult> GetNotAddedDocuments(Guid vehicleId)
        {
            return Ok(await _vehicleDropDownService.GetNotAddedDocuments(vehicleId));
        }
        [HttpGet]
        public async Task<IActionResult> GetDocumentTypeDropdown()
        {
            return Ok(await _vehicleDropDownService.GetDocumentTypeDropdown());
        }

        [HttpGet]
        public async Task<IActionResult> GetOwnerListDropdown(OwnerGroup ownerGroup)
        {
            return Ok(await _vehicleDropDownService.GetOwnerListDropdown(ownerGroup));
        }
    }
}
