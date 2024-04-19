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

namespace TransportManagmentImplementation.Services.Vehicle.Configuration
{
    // Service
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public VehicleTypeService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(VehicleTypePostDto vehicleTypePost)
        {
            try
            {
                var vehicleType = new VehicleType
                {
                    VehicleCategoryId = vehicleTypePost.VehicleCategoryId,
                    Name = vehicleTypePost.Name,
                    LocalName = vehicleTypePost.LocalName,
                    CreatedById = vehicleTypePost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true 
                };

                await _dbContext.VehicleTypes.AddAsync(vehicleType);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Vehicle Type Added Successfully !!!"
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

        public async Task<List<VehicleTypeGetDto>> GetAll()
        {
            var vehicleTypes = await _dbContext.VehicleTypes.AsNoTracking().ToListAsync();
            var vehicleTypeDtos = _mapper.Map<List<VehicleTypeGetDto>>(vehicleTypes);
            return vehicleTypeDtos;
        }

        public async Task<ResponseMessage> Update(VehicleTypeGetDto vehicleTypeGet)
        {
            try
            {
                var vehicleType = await _dbContext.VehicleTypes.FindAsync(vehicleTypeGet.Id);
                if (vehicleType != null)
                {
                    vehicleType.VehicleCategoryId = vehicleTypeGet.VehicleCategoryId;
                    vehicleType.Name = vehicleTypeGet.Name;
                    vehicleType.LocalName = vehicleTypeGet.LocalName;
                    vehicleType.IsActive = vehicleTypeGet.IsActive;

                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Vehicle Type Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Vehicle Type Not Found !!!"
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
