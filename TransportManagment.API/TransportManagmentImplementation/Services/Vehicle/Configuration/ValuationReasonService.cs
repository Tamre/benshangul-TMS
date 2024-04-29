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
    public class ValuationReasonService : IValuationReasonService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ValuationReasonService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(ValuationReasonPostDto dto)
        {
            try
            {
                var valuationReason = new ValuationReason
                {

                    Name = dto.Name,
                    LocalName = dto.LocalName,
                    IsValuationPayment = dto.IsValuationPayment,
                    IsOwnershipPayment = dto.IsOwnershipPayment,
                    IsActive = true,
                    CreatedById = dto.CreatedById,
                    CreatedDate = DateTime.Now


                };

                await _dbContext.ValuationReasons.AddAsync(valuationReason);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Valuation Reason Added Successfully!"
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

        public async Task<ResponseMessage> Update(ValuationReasonGetDto dto)
        {
            try
            {
                var valuationReason = await _dbContext.ValuationReasons.FindAsync(dto.Id);
                if (valuationReason == null)
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Valuation Reason not found!"
                    };
                }

                valuationReason.Name = dto.Name;
                valuationReason.LocalName = dto.LocalName;
                valuationReason.IsValuationPayment = dto.IsValuationPayment;
                valuationReason.IsOwnershipPayment = dto.IsOwnershipPayment;
                valuationReason.IsActive = dto.IsActive;


                _dbContext.ValuationReasons.Update(valuationReason);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Valuation Reason Updated Successfully!"
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

        public async Task<List<ValuationReasonGetDto>> GetAll()
        {
            var valuationReasons = await _dbContext.ValuationReasons.AsNoTracking().ToListAsync();

            var valuationDtos = _mapper.Map<List<ValuationReasonGetDto>>(valuationReasons);

            return valuationDtos;
        }

    }


}
