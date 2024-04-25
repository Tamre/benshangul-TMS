using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentAPI.Controllers.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentImplementation.Services.Vehicle.Configuration
{
    // Service
    public class VehicleBodyTypeService : IVehicleBodyTypeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public VehicleBodyTypeService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(VehicleBodyTypePostDto vehicleBodyTypePost)
        {
            try
            {
                var vehicleBodyType = new VehicleBodyType
                {
                    Name = vehicleBodyTypePost.Name,
                    LocalName = vehicleBodyTypePost.LocalName,
                    VehicleTypeId = vehicleBodyTypePost.VehicleTypeId,
                    Value = vehicleBodyTypePost.Value,
                    CreatedById = vehicleBodyTypePost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                await _dbContext.VehicleBodyTypes.AddAsync(vehicleBodyType);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Vehicle Body Type Added Successfully !!!"
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

        public async Task<List<VehicleBodyTypeGetDto>> GetAll()
        {
            var vehicleBodyTypes = await _dbContext.VehicleBodyTypes.AsNoTracking().ToListAsync();
            var vehicleBodyTypeDtos = _mapper.Map<List<VehicleBodyTypeGetDto>>(vehicleBodyTypes);
            return vehicleBodyTypeDtos;
        }

        public async Task<ResponseMessage> Update(VehicleBodyTypeGetDto vehicleBodyTypeGet)
        {
            try
            {
                var vehicleBodyType = await _dbContext.VehicleBodyTypes.FindAsync(vehicleBodyTypeGet.Id);
                if (vehicleBodyType != null)
                {
                    vehicleBodyType.Name = vehicleBodyTypeGet.Name;
                    vehicleBodyType.LocalName = vehicleBodyTypeGet.LocalName;
                    vehicleBodyType.VehicleTypeId = vehicleBodyTypeGet.VehicleTypeId;
                    vehicleBodyType.Value = vehicleBodyTypeGet.Value;
                    vehicleBodyType.IsActive = vehicleBodyTypeGet.IsActive;

                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Vehicle Body Type Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Vehicle Body Type Not Found !!!"
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
