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
    public class VehicleModelService : IVehicleModelService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public VehicleModelService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(VehicleModelPostDto vehicleModelPost)
        {
            try
            {
                var vehicleModel = new VehicleModel
                {
                    Name = vehicleModelPost.Name,
                    EngineCapacity = vehicleModelPost.EngineCapacity,
                    NoOfCylinder = vehicleModelPost.NoOfCylinder,
                    HorsePowerMeasure = Enum.Parse<HorsePowerMeasure>(vehicleModelPost.HorsePowerMeasure),
                    MarkId = vehicleModelPost.MarkId,
                    CreatedById = vehicleModelPost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true 
                };

                await _dbContext.VehicleModels.AddAsync(vehicleModel);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Vehicle Model Added Successfully !!!"
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

        public async Task<List<VehicleModelGetDto>> GetAll()
        {
            var vehicleModels = await _dbContext.VehicleModels.AsNoTracking().ToListAsync();
            var vehicleModelDtos = _mapper.Map<List<VehicleModelGetDto>>(vehicleModels);
            return vehicleModelDtos;
        }

        public async Task<ResponseMessage> Update(VehicleModelGetDto vehicleModelGet)
        {
            try
            {
                var vehicleModel = await _dbContext.VehicleModels.FindAsync(vehicleModelGet.Id);
                if (vehicleModel != null)
                {
                    vehicleModel.Name = vehicleModelGet.Name;
                    vehicleModel.EngineCapacity = vehicleModelGet.EngineCapacity;
                    vehicleModel.NoOfCylinder = vehicleModelGet.NoOfCylinder;
                    vehicleModel.HorsePowerMeasure = Enum.Parse<HorsePowerMeasure>(vehicleModelGet.HorsePowerMeasure);
                    vehicleModel.MarkId = vehicleModelGet.MarkId;
                    vehicleModel.IsActive = vehicleModelGet.IsActive;

                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Vehicle Model Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Vehicle Model Not Found !!!"
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
