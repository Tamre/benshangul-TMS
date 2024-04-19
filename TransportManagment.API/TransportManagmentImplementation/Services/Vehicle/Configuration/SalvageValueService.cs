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
    public class SalvageValueService : ISalvageValueService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public SalvageValueService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(SalvageValuePostDto salvageValuePost)
        {
            try
            {
                var salvageValue = new SalvageValue
                {
                    Name = salvageValuePost.Name,
                    LocalName = salvageValuePost.LocalName,
                    Value = salvageValuePost.Value,
                    CreatedById = salvageValuePost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                await _dbContext.SalvageValues.AddAsync(salvageValue);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Salvage Value Added Successfully !!!"
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

        public async Task<List<SalvageValueGetDto>> GetAll()
        {
            var salvageValues = await _dbContext.SalvageValues.AsNoTracking().ToListAsync();
            var salvageValueDtos = _mapper.Map<List<SalvageValueGetDto>>(salvageValues);
            return salvageValueDtos;
        }

        public async Task<ResponseMessage> Update(SalvageValueGetDto salvageValueGet)
        {
            try
            {
                var salvageValue = await _dbContext.SalvageValues.FindAsync(salvageValueGet.Id);
                if (salvageValue != null)
                {
                    salvageValue.Name = salvageValueGet.Name;
                    salvageValue.LocalName = salvageValueGet.LocalName;
                    salvageValue.Value = salvageValueGet.Value;
                    salvageValue.IsActive = salvageValueGet.IsActive; 

                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Salvage Value Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Salvage Value Not Found !!!"
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
