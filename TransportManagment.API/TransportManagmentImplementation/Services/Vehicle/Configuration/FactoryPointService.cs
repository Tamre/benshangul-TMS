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
    public class FactoryPointService :IFactoryPointService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public FactoryPointService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(FactoryPointPostDto factoryPointPost)
        {
            try
            {
                var factoryPoint = new FactoryPoint
                {
                    MarkId = factoryPointPost.MarkId,
                    Value = factoryPointPost.Value,                    
                    CreatedById = factoryPointPost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                await _dbContext.FactoryPoints.AddAsync(factoryPoint);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Factory Point Added Successfully !!!"
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

        public async Task<List<FactoryPointGetDto>> GetAll()
        {
            var factoryPoints = await _dbContext.FactoryPoints.Include(x=>x.Mark).AsNoTracking().ToListAsync();
            var factoryPointDtos = _mapper.Map<List<FactoryPointGetDto>>(factoryPoints);
            return factoryPointDtos;
        }

        public async Task<ResponseMessage> Update(FactoryPointGetDto factoryPointGet)
        {
            try
            {
                var factoryPoint = await _dbContext.FactoryPoints.FindAsync(factoryPointGet.Id);
                if (factoryPoint != null)
                {
                    factoryPoint.MarkId = factoryPointGet.MarkId;
                    factoryPoint.Value = factoryPointGet.Value;
                    factoryPoint.IsActive = factoryPointGet.IsActive;
                  

                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Factory Point Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Factory Point Not Found !!!"
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
