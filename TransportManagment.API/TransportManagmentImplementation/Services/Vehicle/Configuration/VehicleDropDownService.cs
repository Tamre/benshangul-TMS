﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;
using TransportManagmentInfrustructure.Data;

namespace TransportManagmentImplementation.Services.Vehicle.Configuration
{
    public class VehicleDropDownService : IvehicleDropDownService
    {

        private readonly ApplicationDbContext _dbContext;

        public VehicleDropDownService(ApplicationDbContext dbContext) 
        {   
            _dbContext = dbContext;
        } 
        public async Task<List<SettingDropDownsDto>> GetNotAddedDocuments(Guid VehicleId)
        {
            var documents = await _dbContext.DocumentTypes.Where(x => !_dbContext.VehicleDocuments.Where(x => x.VehicleId == VehicleId).Select(y => y.DocumentTypeId).Contains(x.Id))
                            .Select(z => new SettingDropDownsDto
                            {
                                Id = z.Id,
                                Name = z.FileName,
                            }).ToListAsync();

            return documents;
        }
    }
}
