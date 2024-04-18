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
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentImplementation.Services.Common
{
    public class CommonCodeService : ICommonCodeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommonCodeService(ApplicationDbContext dbContext, IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;

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

                return new ResponseMessage
                {
                    Success = true,
                    Message = "CommonCode Added Successfully !!!"
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

        public async Task<List<CommonCodeGetDto>> GetAll()
        {


            var commonCodes = await _dbContext.CommonCodes.Include(x=>x.Zone).AsNoTracking().ToListAsync();

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
