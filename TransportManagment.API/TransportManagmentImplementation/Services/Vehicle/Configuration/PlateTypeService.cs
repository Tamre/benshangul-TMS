using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentImplementation.Services.Vehicle.Configuration
{
    public class PlateTypeService : IPlateTypeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PlateTypeService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(PlateTypePostDto plateTypePost)
        {
            try
            {
                var plateType = new PlateType
                {
                    Name = plateTypePost.Name,
                    AmharicName = plateTypePost.AmharicName,
                    Code = plateTypePost.Code,
                    RegionList = plateTypePost.RegionList,
                    CreatedById = plateTypePost.CreatedById,
                    CreatedDate = DateTime.Now
                };

                await _dbContext.PlateTypes.AddAsync(plateType);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "PlateType Added Successfully !!!"
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

        public async Task<List<PlateTypeGetDto>> GetAll()
        {
            var plateTypes = await _dbContext.PlateTypes.AsNoTracking().ToListAsync();
            var plateTypeDtos = _mapper.Map<List<PlateTypeGetDto>>(plateTypes);
            return plateTypeDtos;
        }

        public async Task<ResponseMessage> Update(PlateTypeGetDto plateTypeGet)
        {
            try
            {
                var plateType = await _dbContext.PlateTypes.FindAsync(plateTypeGet.Id);
                if (plateType != null)
                {
                    plateType.Name = plateTypeGet.Name;
                    plateType.AmharicName = plateTypeGet.AmharicName;
                    plateType.Code = plateTypeGet.Code;
                    plateType.RegionList = plateTypeGet.RegionList;

                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "PlateType Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "PlateType Not Found !!!"
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
