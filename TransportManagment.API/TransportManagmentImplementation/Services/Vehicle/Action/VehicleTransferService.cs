using AutoMapper;
using IntegratedImplementation.Interfaces.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Action;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class VehicleTransferService : IVehicleTransfer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        private readonly ILoggerManagerService _logger;
        private readonly IGeneralConfigService _generalConfigService;

        public VehicleTransferService(ApplicationDbContext dbContext, ILoggerManagerService logger, IGeneralConfigService generalConfigService, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _generalConfigService = generalConfigService;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> CreateVehicleTransferAsync(VehicleTransferDTO vehicleTransferDTO)
        {
            
            try
            {



                var vehicleTransfer = new VehicleTransfer
                {
                    Id = Guid.NewGuid(),
                    VehicleId = vehicleTransferDTO.VehicleId,
                    ChangeOwner = vehicleTransferDTO.ChangeOwner,
                    LetterNo = vehicleTransferDTO.LetterNo,
                    TransferNumber = vehicleTransferDTO.TransferNumber,
                    TransferedDate = vehicleTransferDTO.TransferedDate,
                    TransferStatus = vehicleTransferDTO.TransferStatus,
                    CreatedById = vehicleTransferDTO.CretedById,
                    CreatedDate = DateTime.Now,
                    PreviousPlate = vehicleTransferDTO.PreviousPlate,
                    Description = vehicleTransferDTO.Description,
                    ChangeServiceType = vehicleTransferDTO.ChangeServiceType,
                    ChangePlate = vehicleTransferDTO.ChangePlate,
                    IsVehicleRejected = vehicleTransferDTO.IsVehicleRejected,
                    FromZoneId = vehicleTransferDTO.FromZoneId,
                    ToZoneId = vehicleTransferDTO.ToZoneId





                };

                await _dbContext.VehicleTransfers.AddAsync(vehicleTransfer);

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


        public async Task<List<VehicleTransferDTO>> GetVehicleTransferByIdAsync(Guid id)
        {


            var _vehicleTransfer = await _dbContext.VehicleTransfers.Where(x => x.VehicleId == id).OrderBy(x => x.CreatedDate).ToListAsync();

            var Transfer = _mapper.Map<List<VehicleTransferDTO>>(_vehicleTransfer);

            return Transfer;

        }

        public async Task<List<VehicleTransferDTO>> GetAllTransfersFromZone(int zoneId)
        {

            var TransferVehicles = _dbContext.VehicleTransfers.Where(x => x.FromZoneId == zoneId);
            var TransferItemResponseDtos = _mapper.Map<List<VehicleTransferDTO>>(TransferVehicles);
            return TransferItemResponseDtos;
        }



    }
}
