using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.CommonEnum;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TransportManagmentImplementation.Services.Vehicle.Configuration
{
    // Service
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServiceTypeService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(ServiceTypePostDto serviceTypePost)
        {
            try
            {
                var serviceType = new ServiceType
                {
                    Name = serviceTypePost.Name,
                    LocalName = serviceTypePost.LocalName,
                    ServiceModule = Enum.Parse<ServiceModule>(serviceTypePost.ServiceModule),
                    ListOfPlates = serviceTypePost.ListOfPlates,
                    ListOfAIS = serviceTypePost.ListOfAIS,
                    CreatedById = serviceTypePost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                await _dbContext.ServiceTypes.AddAsync(serviceType);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Service Type Added Successfully !!!"
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

        public async Task<List<ServiceTypeGetDto>> GetAll()
        {
            var serviceTypes = await _dbContext.ServiceTypes.AsNoTracking().ToListAsync();
            var serviceTypeDtos = _mapper.Map<List<ServiceTypeGetDto>>(serviceTypes);
            return serviceTypeDtos;
        }

        public async Task<ResponseMessage> Update(ServiceTypeGetDto serviceTypeGet)
        {
            try
            {
                var serviceType = await _dbContext.ServiceTypes.FindAsync(serviceTypeGet.Id);
                if (serviceType != null)
                {
                    serviceType.Name = serviceTypeGet.Name;
                    serviceType.LocalName = serviceTypeGet.LocalName;
                    serviceType.ServiceModule = Enum.Parse<ServiceModule>(serviceTypeGet.ServiceModule);
                    serviceType.ListOfPlates = serviceTypeGet.ListOfPlates;
                    serviceType.ListOfAIS = serviceTypeGet.ListOfAIS;
                    serviceType.IsActive = serviceTypeGet.IsActive;

                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Service Type Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Service Type Not Found !!!"
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
