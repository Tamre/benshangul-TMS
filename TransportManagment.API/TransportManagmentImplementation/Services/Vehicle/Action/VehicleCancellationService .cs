using AutoMapper;
using IntegratedImplementation.Interfaces.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class VehicleCancellationService : IVehicleCancellationService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        private readonly ILoggerManagerService _logger;
        private readonly IGeneralConfigService _generalConfigService;

        public VehicleCancellationService(ApplicationDbContext dbContext, ILoggerManagerService logger, IGeneralConfigService generalConfigService, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _generalConfigService = generalConfigService;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> CreateVehicleCancellation(VehicleCancellationDTO vhicleCancellation)
        {


            try
            {



                var vehicleCancilataion = new VehicleCancelation
                {
                    Id = Guid.NewGuid(),
                    VehicleId = vhicleCancellation.VehicleId,
                    ClearanceLetterNo = vhicleCancellation.ClearanceLetterNo,
                    CleranceDate = vhicleCancellation.CleranceDate,
                    CreatedById = vhicleCancellation.CreatedById,
                    IsReverted = false,
                    RevertedById = vhicleCancellation.RevertedById,
                    Reason = vhicleCancellation.Reason,
                    CreatedDate = DateTime.Now,


                };

                await _dbContext.VehicleCancelations.AddAsync(vehicleCancilataion);

                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = $"Replacement Request Created succussfuly"
                };


            }
            catch (Exception ex)
            {
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message,
                };
            }



        }


        public async Task<List<VehicleCancellationDTO>> GetVehicleCancellationById(Guid Id)
        {

            var _vehicleTransfer = await _dbContext.VehicleCancelations.Where(x => x.VehicleId == Id).OrderBy(x => x.CreatedDate).ToListAsync();

            var VehicleCancilation = _mapper.Map<List<VehicleCancellationDTO>>(_vehicleTransfer);

            return VehicleCancilation;
        }

        public async Task<ResponseMessage> UpdateVehicleCancellation(VehicleCancellationDTO updateVehicle)
        {

            try
            {

                var currentVehicle = await _dbContext.VehicleCancelations.FindAsync(updateVehicle.Id);


                if (currentVehicle == null)
                {

                    return new ResponseMessage
                    {
                        Success = false,
                        Message = $"Owner Not Found !!!"
                    };
                }

                currentVehicle.CleranceDate = updateVehicle.CleranceDate;
                currentVehicle.ClearanceLetterNo = updateVehicle.ClearanceLetterNo;
                currentVehicle.IsReverted = true;
                currentVehicle.Reason = updateVehicle.Reason;
                currentVehicle.VehicleId = updateVehicle.VehicleId;

                await _dbContext.SaveChangesAsync();



                return new ResponseMessage
                {
                    Success = true,
                    Message = " updated Successfully With Owner Numeber ",

                };
            }
            catch (Exception ex)
            {

                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message,
                };
            }

        }


    
    }
}
