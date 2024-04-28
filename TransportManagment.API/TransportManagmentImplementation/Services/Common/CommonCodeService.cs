using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentImplementation.Services.Common
{
    public class CommonCodeService : ICommonCodeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILoggerManagerService _logger;

        public CommonCodeService(ApplicationDbContext dbContext, IMapper mapper,ILoggerManagerService logger)
        {

            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;

        }
     
        public async Task<ResponseMessage> Add(CommonCodePostDto CommonCodePost)
        {
            try
            {
                var commonCode = new CommonCodes
                {
                    Name = CommonCodePost.Name,
                    ZoneId = CommonCodePost.ZoneId,
                    CommonCodeType = Enum.Parse<CommonCodeType>(CommonCodePost.CommonCodeType),
                    Pad = CommonCodePost.Pad,
                    CurrentNumber = CommonCodePost.CurrentNumber,
                    CreatedById = CommonCodePost.CreatedById,                    
                    CreatedDate = DateTime.Now,
                    IsActive = true

                };
                await _dbContext.CommonCodes.AddAsync(commonCode);
                await _dbContext.SaveChangesAsync();


             
   _logger.LogCreate("COMMON", CommonCodePost.CreatedById, $"CommonCode Added Successfully on {DateTime.Now}");


                return new ResponseMessage
                {
                    Success = true,
                    Message = "CommonCode Added Successfully !!!"
                };


            }
            catch (Exception ex)
            {
                _logger.LogExcption("COMMON", CommonCodePost.CreatedById, ex.Message);

                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };
            }


        }

        public async Task<List<CommonCodeGetDto>> GetAll(RequestParameter requestParameter)
        {


            var commonCodes = await _dbContext.CommonCodes.Include(x=>x.Zone).AsNoTracking()

                 .OrderBy(e => e.Id)
 .Skip((requestParameter.PageNumber - 1) * requestParameter.PageSize)
 .Take(requestParameter.PageSize)
 .ToListAsync();
                
                

            var commonCodesDtos = _mapper.Map<List<CommonCodeGetDto>>(commonCodes);

            return commonCodesDtos;




        }

        public async Task<ResponseMessage> Update(CommonCodeGetDto CommonCodeGet)
        {
            try
            {
              
                var CommonCode = await _dbContext.CommonCodes.FindAsync(CommonCodeGet.Id);

                if (CommonCode != null)
                {
                    // Update the properties of the CommonCode entity
                    CommonCode.Name = CommonCodeGet.Name;
                    CommonCode.ZoneId = CommonCodeGet.ZoneId;
                    CommonCode.CommonCodeType = Enum.Parse<CommonCodeType>(CommonCodeGet.CommonCodeType);
                    CommonCode.Pad = CommonCodeGet.Pad;
                    CommonCode.CurrentNumber = CommonCodeGet.CurrentNumber;
                    CommonCode.IsActive = CommonCodeGet.IsActive;

                    // Save the changes to the database
                    await _dbContext.SaveChangesAsync();

                    _logger.LogCreate("COMMON", CommonCodeGet.CreatedById, $"CommonCode Updated Successfully on {DateTime.Now}");

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "CommonCode Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "CommonCode Not Found !!!"
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
