using AutoMapper;
using FluentEmail.Core;
using IntegratedImplementation.Interfaces.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentImplementation.Services.Common
{
    public class CompanyProfileService : ICompanyProfileService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IGeneralConfigService _generalConfig;
        private readonly ILoggerManagerService _logger;
        public CompanyProfileService(
            ApplicationDbContext dbContext, 
            IMapper mapper,
            IGeneralConfigService generalConfig,
            ILoggerManagerService logger)
        {

            _generalConfig = generalConfig;
            _mapper = mapper;
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<CompanyProfileGetDto> Get()
        {

            var companyProfile = await _dbContext.CompanyProfiles.FirstOrDefaultAsync();

            var companyProfileDtos = _mapper.Map<CompanyProfileGetDto>(companyProfile);

            return companyProfileDtos;

        }

        public async Task<ResponseMessage> Update(CompanyProfileGetDto companyProfileGet)
        {
            try
            {
                var currentCompanyProfile = await _dbContext.CompanyProfiles.FirstOrDefaultAsync();

                var ImagePath = "";

                if (companyProfileGet.LogoFile != null)
                    ImagePath =await  _generalConfig.UploadFiles(companyProfileGet.LogoFile, $"{companyProfileGet.Name}", "Company Profile");

                if (currentCompanyProfile == null)
                {

                    var companyProfile = new CompanyProfile
                    {
                        Name = companyProfileGet.Name,
                        LocalName = companyProfileGet.LocalName,
                        Logo = ImagePath,
                        Address = ImagePath,   
                        Email = companyProfileGet.Email,
                        Description = companyProfileGet.Description,
                        CreatedById = companyProfileGet.CreatedById,                  
                        CreatedDate = DateTime.Now,
                        IsActive = true

                    };
                    await _dbContext.CompanyProfiles.AddAsync(companyProfile);
                    await _dbContext.SaveChangesAsync();

                    _logger.LogCreate("COMMON", companyProfileGet.CreatedById, $"Company Profile Updated Successfully on {DateTime.Now}");



                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Company Profile Added Successfully !!!"
                    };
                }
                else
                {                 
                    currentCompanyProfile.Name = companyProfileGet.Name;
                    currentCompanyProfile.LocalName = companyProfileGet.LocalName;
                    if (companyProfileGet.LogoFile != null)
                    {
                        currentCompanyProfile.Logo = ImagePath ;
                    }
                        
                    currentCompanyProfile.Description = companyProfileGet.Description;
                    currentCompanyProfile.Email = companyProfileGet.Email;
                    currentCompanyProfile.Address = companyProfileGet.Address;
                    await _dbContext.SaveChangesAsync();


                    _logger.LogUpdate("COMMON", companyProfileGet.CreatedById, $"Company Profile Updated Successfully on {DateTime.Now}");



                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Company Profile Updated Successfully !!!"
                    };
                }
            

            }
            catch (Exception ex)
            {

                _logger.LogExcption("COMMMON", companyProfileGet.CreatedById, ex.Message);


                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };

            }
        }
    }
}
