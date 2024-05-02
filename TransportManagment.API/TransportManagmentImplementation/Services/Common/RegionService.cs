using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Common;

namespace TransportManagmentImplementation.Services.Common
{
    public class RegionService : IRegionService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILoggerManagerService _logger;

        public RegionService(ApplicationDbContext dbContext, IMapper mapper, ILoggerManagerService logger)
        {

            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseMessage> Add(RegionPostDto RegionPost)
        {
            try
            {
                var Region = new Region
                {
                    Name = RegionPost.Name,
                    LocalName = RegionPost.LocalName,
                    Code= RegionPost.Code,
                    LocalCode = RegionPost.LocalCode,
                    CountryId  = RegionPost.CountryId,
                    CreatedById = RegionPost.CreatedById,                   
                    CreatedDate = DateTime.Now,
                    IsActive = true

                };
                await _dbContext.Regions.AddAsync(Region);
                await _dbContext.SaveChangesAsync();


                _logger.LogCreate("COMMON", RegionPost.CreatedById, $"Region Added Successfully on {DateTime.Now}");


                return new ResponseMessage
                {
                    Success = true,
                    Message = "Region Added Successfully !!!"
                };


            }
            catch (Exception ex)
            {

                _logger.LogExcption("COOMON", RegionPost.CreatedById, ex.Message);

                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };
            }


        }

        public async Task<List<RegionGetDto>> GetAll(RequestParameter requestParameter)
        {


            var regions = await _dbContext.Regions.Include(x=>x.Country).AsNoTracking().OrderBy(e => e.Id)
 .Skip((requestParameter.PageNumber - 1) * requestParameter.PageSize)
 .Take(requestParameter.PageSize)
 .ToListAsync(); ;

            var RegionDtos = _mapper.Map<List<RegionGetDto>>(regions);

            return RegionDtos;




        }

        public async Task<ResponseMessage> Update(RegionGetDto RegionGet)
        {
            try
            {

                var Region = await _dbContext.Regions.FindAsync(RegionGet.Id);

                if (Region != null)
                {
                    // Update the properties of the Region entity
                    Region.Name = RegionGet.Name;
                    Region.LocalName = RegionGet.LocalName;
                    Region.Code = RegionGet.Code;
                    Region.LocalCode = RegionGet.LocalCode;
                    Region.CountryId = RegionGet.CountryId;

                    Region.IsActive = RegionGet.IsActive;

                    // Save the changes to the database
                    await _dbContext.SaveChangesAsync();
                    _logger.LogUpdate("COMMON", RegionGet.CreatedById, $"Region Updated Successfully on {DateTime.Now}");



                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Region Updated Successfully !!!"
                    };
                }
                else
                {
                   
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Region Not Found !!!"
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.LogExcption("COMMON", RegionGet.CreatedById, ex.Message);
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };

            }
        }
    }
}
