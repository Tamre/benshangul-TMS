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
    public class DepreciationCostService :IDepreciationCostService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DepreciationCostService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(DepreciationCostPostDto depreciationCostPost)
        {
            try
            {
                var depreciationCost = new DepreciationCost
                {
                    Name = depreciationCostPost.Name,
                    LocalName = depreciationCostPost.LocalName,
                    Value = depreciationCostPost.Value,
                    CreatedById = depreciationCostPost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                await _dbContext.DepreciationCosts.AddAsync(depreciationCost);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Depreciation Cost Added Successfully !!!"
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

        public async Task<List<DepreciationCostGetDto>> GetAll()
        {
            var depreciationCosts = await _dbContext.DepreciationCosts.AsNoTracking().ToListAsync();
            var depreciationCostDtos = _mapper.Map<List<DepreciationCostGetDto>>(depreciationCosts);
            return depreciationCostDtos;
        }

        public async Task<ResponseMessage> Update(DepreciationCostGetDto depreciationCostGet)
        {
            try
            {
                var depreciationCost = await _dbContext.DepreciationCosts.FindAsync(depreciationCostGet.Id);
                if (depreciationCost != null)
                {
                    depreciationCost.Name = depreciationCostGet.Name;
                    depreciationCost.LocalName = depreciationCostGet.LocalName;
                    depreciationCost.Value = depreciationCostGet.Value;
                    depreciationCost.IsActive = depreciationCostGet.IsActive;

                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Depreciation Cost Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Depreciation Cost Not Found !!!"
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
