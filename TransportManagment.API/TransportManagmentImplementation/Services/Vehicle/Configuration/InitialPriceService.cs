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
    public class InitialPriceService :IInitialPriceService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public InitialPriceService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(InitialPricePostDto initialPricePost)
        {
            try
            {
                var initialPrice = new InitialPrice
                {
                    Name = initialPricePost.Name,
                    LocalName = initialPricePost.LocalName,
                    Price = initialPricePost.Price,
                    CreatedById = initialPricePost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true 
                };

                await _dbContext.InitialPrices.AddAsync(initialPrice);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Initial Price Added Successfully !!!"
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

        public async Task<List<InitialPriceGetDto>> GetAll()
        {
            var initialPrices = await _dbContext.InitialPrices.AsNoTracking().ToListAsync();
            var initialPriceDtos = _mapper.Map<List<InitialPriceGetDto>>(initialPrices);
            return initialPriceDtos;
        }

        public async Task<ResponseMessage> Update(InitialPriceGetDto initialPriceGet)
        {
            try
            {
                var initialPrice = await _dbContext.InitialPrices.FindAsync(initialPriceGet.Id);
                if (initialPrice != null)
                {
                    initialPrice.Name = initialPriceGet.Name;
                    initialPrice.LocalName = initialPriceGet.LocalName;
                    initialPrice.Price = initialPriceGet.Price;
                    initialPrice.IsActive = initialPriceGet.IsActive; 

                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Initial Price Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Initial Price Not Found !!!"
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
