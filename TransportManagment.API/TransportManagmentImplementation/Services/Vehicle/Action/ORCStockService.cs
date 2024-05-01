using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class ORCStockService : IORCStockService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ORCStockService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<ResponseMessage> Add(ORCStockPostDto ORCStockPost)
        {
            try
            {
                
                for (int orcNo = ORCStockPost.FromORCNo; orcNo <= ORCStockPost.ToORCNo; orcNo++)
                {
                    var checkORCExistance = _dbContext.ORCStocks.Any(x => x.ORCNo == orcNo.ToString()&& x.StockTypeId == ORCStockPost.StockTypeId);

                    if (!checkORCExistance)
                    {
                        ORCStock aisStock = new()
                        {
                            ORCNo = orcNo.ToString(),
                            StockTypeId = ORCStockPost.StockTypeId,
                            RegionId = ORCStockPost.RegionId,
                            CreatedById = ORCStockPost.CreatedById,
                            CreatedDate = DateTime.Now,
                            IsActive = true
                        };
                        await _dbContext.ORCStocks.AddAsync(aisStock);

                    }
                    
                }

                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "ORC Stock(s) Added Successfully !!!"
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

        public async Task<PagedList<ORCStockGetDto>> GetAll(FilterDetail filterData)
        {
            IQueryable<ORCStock> orcStockQuery = _dbContext.ORCStocks.AsNoTracking().OrderBy(x => x.ORCNo);

            /// Do the Sort And Serch Impleentation here
            if (!string.IsNullOrEmpty(filterData.SearchTerm))
            {
                orcStockQuery = orcStockQuery.Where(p =>
                p.ORCNo.Contains(filterData.SearchTerm));
            }

            if (filterData.Criteria != null && filterData.Criteria.Count() > 0)
            {
                foreach(var criteria in filterData.Criteria)
                {
                    orcStockQuery = orcStockQuery.Where(GetFilterProperty(criteria));
                }
            }



            var pagedOrcStocks = await PagedList<ORCStock>.ToPagedListAsync(orcStockQuery, filterData.PageNumber, filterData.PageSize);
           
            var orcStockDtos = _mapper.Map<List<ORCStockGetDto>>(pagedOrcStocks);

            
            return new PagedList<ORCStockGetDto>(orcStockDtos, pagedOrcStocks.MetaData);
        }

        private static Expression<Func<ORCStock, bool>> GetFilterProperty(FilterCriteria criteria)
        {
            return criteria.ColumnName?.ToLower() switch
            {
                "orc_type" => ORCStock => ORCStock.StockTypeId == Convert.ToInt32(criteria.FilterValue),
                "zone" => ORCStock => ORCStock.ToZoneId == Convert.ToInt32(criteria.FilterValue),
                "status" => ORCStock => ORCStock.IsActive == Convert.ToBoolean(criteria.FilterValue),

            };
        }


        public async Task<ResponseMessage> TransferToZone(TransferORCToZoneDto TransferToZone)
        {
            try
            {
                var result = await _dbContext.ORCStocks.Where(ps => TransferToZone.ORCStockIds.Contains(ps.Id))
                .ExecuteUpdateAsync(x =>
                x.SetProperty(p => p.ToZoneId, TransferToZone.ToZoneId)
                );
                if (result == 0)
                    return new ResponseMessage
                    {
                        Message = "No ORC Stock Was Transferd",
                        Success = false
                    };
                return new ResponseMessage
                {
                    Message = "ORC Stock Transferred Successfully !!!",
                    Success = true
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

    }
}
