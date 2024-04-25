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
    public class ServiceYearSettingService : IServiceYearSettingService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServiceYearSettingService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(ServiceYearSettingPostDto serviceYearSettingPost)
        {
            try
            {
                var serviceYearSetting = new ServiceYearSetting
                {
                    FromYear = serviceYearSettingPost.FromYear,
                    ToYear = serviceYearSettingPost.ToYear,
                    YearValue = serviceYearSettingPost.YearValue,
                    CreatedById = serviceYearSettingPost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                await _dbContext.ServiceYearSettings.AddAsync(serviceYearSetting);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Service Year Setting Added Successfully !!!"
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

        public async Task<List<ServiceYearSettingGetDto>> GetAll()
        {
            var serviceYearSettings = await _dbContext.ServiceYearSettings.AsNoTracking().ToListAsync();
            var serviceYearSettingDtos = _mapper.Map<List<ServiceYearSettingGetDto>>(serviceYearSettings);
            return serviceYearSettingDtos;
        }

        public async Task<ResponseMessage> Update(ServiceYearSettingGetDto serviceYearSettingGet)
        {
            try
            {
                var serviceYearSetting = await _dbContext.ServiceYearSettings.FindAsync(serviceYearSettingGet.Id);
                if (serviceYearSetting != null)
                {
                    serviceYearSetting.FromYear = serviceYearSettingGet.FromYear;
                    serviceYearSetting.ToYear = serviceYearSettingGet.ToYear;
                    serviceYearSetting.YearValue = serviceYearSettingGet.YearValue;
                    serviceYearSetting.IsActive = serviceYearSettingGet.IsActive;

                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Service Year Setting Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Service Year Setting Not Found !!!"
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
