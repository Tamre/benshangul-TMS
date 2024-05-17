using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using static TransportManagmentInfrustructure.Enums.CommonEnum;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class VehiclePlateService : IVehiclePlateService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly ILoggerManagerService _logger;
        private readonly IMapper _mapper;
        public VehiclePlateService(ApplicationDbContext dbContext, ILoggerManagerService logger, IMapper mapper
            )
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<ResponseMessage> AssignPlate(VehiclePlatePostDto vehiclePlateDto)
        {

            try
            {
                var technicalInspection = await _dbContext.TechnicalInspections.Include(x => x.ServiceType).Include(x => x.FieldInspection).Where(x => x.FieldInspection.VehicleId == vehiclePlateDto.VehicleId && x.IsActive).FirstOrDefaultAsync();

                if (technicalInspection != null)
                {


                    var plateStock = await _dbContext.PlateStocks.FindAsync(vehiclePlateDto.PlateStockId);

                    if (plateStock != null)
                    {



                        var plateList = technicalInspection.ServiceType.ListOfPlates.Split(",");

                        if (plateList.Contains(plateStock.PlateNo))
                        {



                            var assignPlate = new VehiclePlate
                            {
                                VehicleId = vehiclePlateDto.VehicleId,
                                GivenZoneId = vehiclePlateDto.GivenZoneId,
                                PlateStockId = vehiclePlateDto.PlateStockId,
                                ServiceModule = technicalInspection.ServiceType.ServiceModule,
                                IssueReason = Enum.Parse<IssueReason>(vehiclePlateDto.IssueReason),
                                CreatedById = vehiclePlateDto.CreatedBy,
                                CreatedDate = DateTime.Now,
                                Id = Guid.NewGuid(),

                            };


                            await _dbContext.VehiclePlates.AddAsync(assignPlate);
                            await _dbContext.SaveChangesAsync();

                            var loggermessage = $"Plate assigned for VehicleId = {assignPlate.VehicleId} with plate stock ={assignPlate.PlateStockId} is {assignPlate.Id} by {assignPlate.CreatedById}on {assignPlate.CreatedDate}";
                    _logger.LogCreate("VRMS", vehiclePlateDto.CreatedBy, loggermessage);

                            return new ResponseMessage
                            {
                                Success = true,
                                Message = "Acitve Technical Inspection not found !!!"
                            };
                        }
                        else
                        {
                            return new ResponseMessage
                            {
                                Success = false,
                                Message = "Plate Stock not found in Plate Stock List !!!"
                            };
                        }

                    }

                    else
                    {
                        return new ResponseMessage
                        {
                            Success = false,
                            Message = "Plate Stock not found !!!"
                        };
                    }

                }

                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Acitve Technical Inspection not found !!!"
                    };
                }


            }
            catch (Exception ex)
            {

                _logger.LogExcption("VRMS", vehiclePlateDto.CreatedBy, $"{ex.Message} - detail {ex.StackTrace}");
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };
            }

        }


        public async Task<List<VehiclePlateGetDto>> GetByVehicleId(Guid vehicleId)
        {

            var VechiclePlates = await _dbContext.VehiclePlates.Where(x=>x.VehicleId==vehicleId).OrderBy(x=>x.CreatedDate).ToListAsync();

            var VechiclePlatesMapper = _mapper.Map<List<VehiclePlateGetDto>>(VechiclePlates);

            return VechiclePlatesMapper;


        }
    }
}
