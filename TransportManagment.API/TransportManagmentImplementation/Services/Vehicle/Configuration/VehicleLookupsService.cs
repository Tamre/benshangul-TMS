using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.Services.Vehicle.Configuration
{
    // Service
    public class VehicleLookupsService : IVehicleLookupsService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public VehicleLookupsService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(VehicleLookupsPostDto vehicleLookupsPost)
        {
            try
            {
                var vehicleLookups = new VehicleLookups
                {
                    VehicleLookupType = Enum.Parse<VehicleLookupType>(vehicleLookupsPost.VehicleLookupType),
                    Name = vehicleLookupsPost.Name,
                    LocalName = vehicleLookupsPost.LocalName,
                    CreatedById = vehicleLookupsPost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                await _dbContext.VehicleLookups.AddAsync(vehicleLookups);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Vehicle Lookups Added Successfully !!!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<List<VehicleLookupsGetDto>> GetAllByLookUpType(string LookUpType)
        {
            var lookUpType = Enum.Parse<VehicleLookupType>(LookUpType);
            var vehicleLookups = await _dbContext.VehicleLookups.Where(x=>x.VehicleLookupType==lookUpType).AsNoTracking().ToListAsync();
            var vehicleLookupsDtos = _mapper.Map<List<VehicleLookupsGetDto>>(vehicleLookups);
            return vehicleLookupsDtos;
        }

        public async Task<ResponseMessage> Update(VehicleLookupsGetDto vehicleLookupsGet)
        {
            try
            {
                var vehicleLookups = await _dbContext.VehicleLookups.FindAsync(vehicleLookupsGet.Id);
                if (vehicleLookups != null)
                {
                    vehicleLookups.VehicleLookupType = Enum.Parse<VehicleLookupType>(vehicleLookupsGet.VehicleLookupType);
                    vehicleLookups.Name = vehicleLookupsGet.Name;
                    vehicleLookups.LocalName = vehicleLookupsGet.LocalName;
                    vehicleLookups.IsActive = vehicleLookupsGet.IsActive;

                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Vehicle Lookups Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Vehicle Lookups Not Found !!!"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }

}
