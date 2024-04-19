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
    public class VehicleSerialSettingService : IVehicleSerialSettingService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public VehicleSerialSettingService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(VehicleSerialSettingPostDto vehicleSerialSettingPost)
        {
            try
            {
                var vehicleSerialSetting = new VehicleSerialSetting
                {
                    VehicleSerialType = Enum.Parse<VehicleSerialType>(vehicleSerialSettingPost.VehicleSerialType),
                    Value = vehicleSerialSettingPost.Value,
                    Pad = vehicleSerialSettingPost.Pad,
                    ZoneId = vehicleSerialSettingPost.ZoneId,
                    CreatedById = vehicleSerialSettingPost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true 
                };

                await _dbContext.VehicleSerialSettings.AddAsync(vehicleSerialSetting);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Vehicle Serial Setting Added Successfully !!!"
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

        public async Task<List<VehicleSerialSettingGetDto>> GetAll()
        {
            var vehicleSerialSettings = await _dbContext.VehicleSerialSettings.AsNoTracking().ToListAsync();
            var vehicleSerialSettingDtos = _mapper.Map<List<VehicleSerialSettingGetDto>>(vehicleSerialSettings);
            return vehicleSerialSettingDtos;
        }

        public async Task<ResponseMessage> Update(VehicleSerialSettingGetDto vehicleSerialSettingGet)
        {
            try
            {
                var vehicleSerialSetting = await _dbContext.VehicleSerialSettings.FindAsync(vehicleSerialSettingGet.Id);
                if (vehicleSerialSetting != null)
                {
                    vehicleSerialSetting.VehicleSerialType = Enum.Parse<VehicleSerialType>(vehicleSerialSettingGet.VehicleSerialType);
                    vehicleSerialSetting.Value = vehicleSerialSettingGet.Value;
                    vehicleSerialSetting.Pad = vehicleSerialSettingGet.Pad;
                    vehicleSerialSetting.ZoneId = vehicleSerialSettingGet.ZoneId;
                    vehicleSerialSetting.IsActive = vehicleSerialSettingGet.IsActive;

                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Vehicle Serial Setting Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Vehicle Serial Setting Not Found !!!"
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
