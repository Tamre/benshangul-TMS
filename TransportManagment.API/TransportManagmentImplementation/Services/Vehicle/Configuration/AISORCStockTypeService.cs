using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.Services.Vehicle.Configuration
{
    public class AISORCStockTypeService : IAISORCStockTypeService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AISORCStockTypeService(ApplicationDbContext dbContext, IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;

        }

        public async Task<ResponseMessage> Add(AISORCStockTypePostDto AISORCStockTypePost)
        {
            try
            {



                var StockType = new AISORCStockType
                {
                    Name = AISORCStockTypePost.Name,
                    LocalName = AISORCStockTypePost.LocalName,
                    Code = AISORCStockTypePost.Code,
                    Category = Enum.Parse<AISORCStockCategory>( AISORCStockTypePost.Category),
                    CreatedById = AISORCStockTypePost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true

                };
                await _dbContext.AISORCStockTypes.AddAsync(StockType);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "AISORC Stock Type Added Successfully !!!"
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

        public async Task<List<AISORCStockTypeGetDto>> GetAll()
        {

            var stockTypes = await _dbContext.AISORCStockTypes.AsNoTracking().ToListAsync();

            var stockTypeDtos = _mapper.Map<List<AISORCStockTypeGetDto>>(stockTypes);

            return stockTypeDtos;
        }

        public async Task<ResponseMessage> Update(AISORCStockTypeGetDto AISORCStockTypeGet)
        {
            try
            {
                
                var stockType = await _dbContext.AISORCStockTypes.FindAsync(AISORCStockTypeGet.Id);

                if (stockType != null)
                {
                    // Update the properties of the AISORCStockType
                    stockType.Name = AISORCStockTypeGet.Name;
                    stockType.LocalName = AISORCStockTypeGet.LocalName;
                    stockType.Code = AISORCStockTypeGet.Code;
                    stockType.Category = Enum.Parse<AISORCStockCategory>(AISORCStockTypeGet.Category);

                    stockType.IsActive = AISORCStockTypeGet.IsActive;

                    // Save the changes to the database
                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "AISORC Stock Type Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "AISORC Stock Type Not Found !!!"
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
