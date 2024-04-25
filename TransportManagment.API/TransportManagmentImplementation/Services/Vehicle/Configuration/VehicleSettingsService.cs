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
    public class VehicleSettingsService : IVehicleSettingsService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public VehicleSettingsService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(VehicleSettingsPostDto vehicleSettingsPost)
        {
            try
            {
                var vehicleSettings = new VehicleSettings
                {
                    VehicleSettingType = Enum.Parse< VehicleSettingType >( vehicleSettingsPost.VehicleSettingType),
                    Value = vehicleSettingsPost.Value,
                    CreatedById = vehicleSettingsPost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true 
                };

                await _dbContext.VehicleSettings.AddAsync(vehicleSettings);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Vehicle Setting Added Successfully !!!"
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

        public async Task<List<VehicleSettingsGetDto>> GetAll()
        {
            var vehicleSettings = await _dbContext.VehicleSettings.AsNoTracking().ToListAsync();
            var vehicleSettingsDtos = _mapper.Map<List<VehicleSettingsGetDto>>(vehicleSettings);
            return vehicleSettingsDtos;
        }

        public async Task<ResponseMessage> Update(VehicleSettingsGetDto vehicleSettingsGet)
        {
            try
            {
                var vehicleSettings = await _dbContext.VehicleSettings.FindAsync(vehicleSettingsGet.Id);
                if (vehicleSettings != null)
                {
                    vehicleSettings.VehicleSettingType = Enum.Parse<VehicleSettingType>(vehicleSettingsGet.VehicleSettingType);
                    vehicleSettings.Value = vehicleSettingsGet.Value;
                    vehicleSettings.IsActive = vehicleSettingsGet.IsActive;


                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Vehicle Setting Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Vehicle Setting Not Found !!!"
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
