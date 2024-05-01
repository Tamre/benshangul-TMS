using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class PlateStockService : IPlateStockService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PlateStockService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<ResponseMessage> Add(PlateStockPostDto PlateStockPost)
        {
            try
            {
                var platDigitInt = (int)Enum.Parse<PlateDigit>(PlateStockPost.PlateDigit);

                var regionName = _dbContext.Regions.Where(x => x.Id == PlateStockPost.RegionId).Select(x => x.Code).SingleOrDefault();
                var plateTypeName = _dbContext.PlateTypes.Where(x => x.Id == PlateStockPost.PlateTypeId).Select(x => x.Code).SingleOrDefault();



                for (int plateNo = PlateStockPost.FromPlateNo; plateNo <= PlateStockPost.ToPlateNo; plateNo++)
                {
                    var length = plateNo.ToString().Count();
                    string plateNoString = plateNo.ToString().PadLeft(platDigitInt, '0');

                    if (!String.IsNullOrEmpty(PlateStockPost.AToZ))
                    {
                       plateNoString = $"{PlateStockPost.AToZ}{plateNoString}";
                    }

                   
                    var plateNoWithPrefix = $"{regionName}-{plateTypeName}-{plateNoString}";

                    var checkPlateExistance = _dbContext.PlateStocks.Any(x => x.PlateNo == plateNoWithPrefix && x.IssuanceType == Enum.Parse<IssuanceType>(PlateStockPost.IssuanceType));


                    if (!checkPlateExistance)
                    {
                        PlateStock plateStock = new()
                        {
                            PlateTypeId = PlateStockPost.PlateTypeId,
                            RegionId = PlateStockPost.RegionId,
                            PlateNo = plateNoWithPrefix,
                            PlateDigit = Enum.Parse<PlateDigit>(PlateStockPost.PlateDigit),
                            FrontPlateSizeId = PlateStockPost.FrontPlateSizeId,
                            GivenStatus = GivenStatus.NotGiven,
                            IssuanceType = Enum.Parse<IssuanceType>(PlateStockPost.IssuanceType),
                            IsBackLog = false,
                            CreatedById = PlateStockPost.CreatedById,
                            CreatedDate = DateTime.Now,
                            IsActive = true
                        };

                        if (PlateStockPost.BackPlateSizeId > 0)
                        {
                            plateStock.BackPlateSizeId = PlateStockPost.BackPlateSizeId;
                        }

                        await _dbContext.PlateStocks.AddAsync(plateStock);
                    }

                    
                }
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Plate Stock(s) Added Successfully !!!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseMessage
                {
                    Message = ex.Message,
                    Success = false
                };

            }
        }

        public async Task<PagedList<PlateStockGetDto>> GetAll(FilterDetail filterData)
        {
            IQueryable<PlateStock> plateStockQuery = _dbContext.PlateStocks.Include(ps => ps.PlateType).AsNoTracking().OrderBy(x => x.PlateNo);

            /// Do the Sort And Serch Impleentation here

            if (!string.IsNullOrEmpty(filterData.SearchTerm))
            {
                plateStockQuery = plateStockQuery.Where(p =>
                p.PlateNo.Contains(filterData.SearchTerm));
            }

            if (filterData.Criteria != null && filterData.Criteria.Count() > 0)
            {
                foreach (var criteria in filterData.Criteria)
                {
                    plateStockQuery = plateStockQuery.Where(GetFilterProperty(criteria));
                }
            }



            var pagedPlateStocks = await PagedList<PlateStock>.ToPagedListAsync(plateStockQuery, filterData.PageNumber, filterData.PageSize);

            var plateStockDtos = _mapper.Map<List<PlateStockGetDto>>(pagedPlateStocks);


            return new PagedList<PlateStockGetDto>(plateStockDtos, pagedPlateStocks.MetaData);
        }


        
        private static Expression<Func<PlateStock, bool>> GetFilterProperty(FilterCriteria criteria)
        {
            return criteria.ColumnName?.ToLower() switch
            {
                "plate_code" => PlateStock => PlateStock.PlateTypeId == Convert.ToInt32(criteria.FilterValue),
                "region" => PlateStock => PlateStock.RegionId == Convert.ToInt32(criteria.FilterValue),
                "front_plate_size" => PlateStock => PlateStock.FrontPlateSizeId == Convert.ToInt32(criteria.FilterValue),
                "back_plate_size" => PlateStock => PlateStock.BackPlateSizeId == Convert.ToInt32(criteria.FilterValue),
                "zone" => PlateStock => PlateStock.ToZoneId == Convert.ToInt32(criteria.FilterValue),
                "status" => PlateStock => PlateStock.IsActive == Convert.ToBoolean(criteria.FilterValue),

            };
        }

        public async Task<ResponseMessage> Delete(DeletePlateStockDto plateIds)
        {
            try
            {
                var plateStocks = await _dbContext.PlateStocks.Where(e => plateIds.PlateStockIds.Contains(e.Id)).ToListAsync();

                var plateStocksToDelete = plateStocks.Where(e => e.GivenStatus == GivenStatus.NotGiven || e.GivenStatus == GivenStatus.Transfer).ToList();

                _dbContext.PlateStocks.RemoveRange(plateStocksToDelete);

                var remainingPlateStocksReturned = string.Join(", ",plateStocks.Where(e => e.GivenStatus == GivenStatus.Returned).Select(x => x.PlateNo).ToList());
                var remainingPlateStocksGiven = string.Join(", ", plateStocks.Where(e => e.GivenStatus == GivenStatus.Given).Select(x => x.PlateNo).ToList());

                await _dbContext.SaveChangesAsync();

                var message = $"Delete Plate Stock Successful except for Returned: {remainingPlateStocksReturned}, Given: {remainingPlateStocksGiven}";

                return new ResponseMessage
                {
                    Success = true,
                    Message = message,
                    
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
        

        public async Task<ResponseMessage> TransferToZone(TransferToZoneDto TransferToZone)
        {
            try
            {
                var result = await _dbContext.PlateStocks.Where(ps => TransferToZone.PlateStockIds.Contains(ps.Id))
                .ExecuteUpdateAsync(x =>
                x.SetProperty(p => p.ToZoneId, TransferToZone.ToZoneId)
                );
                if (result == 0)
                    return new ResponseMessage
                    {
                        Message = "No Plate Stock Was Transferd",
                        Success = false
                    };
                return new ResponseMessage
                {
                    Message = "Plate Stock Transferred Successfully !!!",
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
