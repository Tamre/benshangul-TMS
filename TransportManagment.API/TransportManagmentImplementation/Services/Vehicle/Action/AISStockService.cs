using AutoMapper;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Action;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class AISStockService : IAISStockService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AISStockService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<ResponseMessage> Add(AISStockPostDto AISStockPostDto)
        {
            try
            {
                
                for (int aisNo = AISStockPostDto.FromAISNo; aisNo <= AISStockPostDto.ToAISNo; aisNo++)
                {

                    var checkAISExistance = _dbContext.AisStocks.Any(x => x.AISNo == aisNo.ToString());

                    if (!checkAISExistance)
                    {
                        AisStock aisStock = new()
                        {
                            AISNo = aisNo.ToString(),
                            StockTypeId = AISStockPostDto.StockTypeId,
                            RegionId = AISStockPostDto.RegionId,
                            CreatedById = AISStockPostDto.CreatedById,
                            CreatedDate = DateTime.Now,
                            IsActive = true
                        };
                        await _dbContext.AisStocks.AddAsync(aisStock);
                    }

                }
                
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "AIS Stock(s) Added Successfully !!!"
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

        public async Task<PagedList<AISStockGetDto>> GetAll(FilterDetail filterData)
        {
            IQueryable<AisStock> aisStockQuery = _dbContext.AisStocks.AsNoTracking().OrderBy(x => x.AISNo);

            /// Do the Sort And Serch Impleentation here

            if (!string.IsNullOrEmpty(filterData.SearchTerm))
            {
                aisStockQuery = aisStockQuery.Where(p =>
                p.AISNo.Contains(filterData.SearchTerm));
            }

            if (filterData.Criteria != null && filterData.Criteria.Count() > 0)
            {
                foreach (var criteria in filterData.Criteria)
                {
                    aisStockQuery = aisStockQuery.Where(GetFilterProperty(criteria));
                }
            }



            var pagedAisStocks = await PagedList<AisStock>.ToPagedListAsync(aisStockQuery, filterData.PageNumber, filterData.PageSize);

            var aisStockDtos = _mapper.Map<List<AISStockGetDto>>(pagedAisStocks);


            return new PagedList<AISStockGetDto>(aisStockDtos, pagedAisStocks.MetaData);
        }



        private static Expression<Func<AisStock, bool>> GetFilterProperty(FilterCriteria criteria)
        {
            return criteria.ColumnName?.ToLower() switch
            {
                "ais_type" => AisStock => AisStock.StockTypeId == Convert.ToInt32(criteria.FilterValue),
                "zone" => AisStock => AisStock.ToZoneId == Convert.ToInt32(criteria.FilterValue),
                "status" => AisStock => AisStock.IsActive == Convert.ToBoolean(criteria.FilterValue),

            };
        }

        public async Task<ResponseMessage> TransferToZone(TransferAISToZoneDto TransferToZone)
        {
            try
            {
                var result = await _dbContext.AisStocks.Where(ps => TransferToZone.AISStockIds.Contains(ps.Id))
                .ExecuteUpdateAsync(x =>
                x.SetProperty(p => p.ToZoneId, TransferToZone.ToZoneId)
                );
                if (result == 0)
                    return new ResponseMessage
                    {
                        Message = "No AIS Stock Was Transferd",
                        Success = false
                    };
                return new ResponseMessage
                {
                    Message = "AIS Stock Transferred Successfully !!!",
                    Success = true
                };
            }
            catch(Exception ex)
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

