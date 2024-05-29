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
using TransportManagmentInfrustructure.Data;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class VehicleReplacementService: IVehicleReplacement
    {

        private readonly ApplicationDbContext _dbContext;

        private readonly ILoggerManagerService _logger;
        private readonly IGeneralConfigService _generalConfigService;

        private readonly IMapper _mapper;
        public VehicleReplacementService(ApplicationDbContext dbContext, ILoggerManagerService logger, IGeneralConfigService generalConfigService, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _generalConfigService = generalConfigService;
            _mapper = mapper;
        }

        public async Task<List<VehicleReplacementDTO>> GetByVehicleId(Guid vehicleId)
        {

            var _serviceChange = await _dbContext.ServiceChanges.Where(x => x.VehilceId == vehicleId).OrderBy(x => x.CreatedDate).ToListAsync();

            var serviceChange = _mapper.Map<List<VehicleReplacementDTO>>(_serviceChange);

            return serviceChange;


        }

        public async Task<ResponseMessage> CreateReplecementRequest(VehicleReplacementDTO vehicleReplacementDTO)
        {
            try
            {



                var vehicleReplacement = new VehicleReplacement
                {
                    Id = Guid.NewGuid(),
                    VehicleId = vehicleReplacementDTO.VehicleId,
                    PoliceStation = vehicleReplacementDTO.PoliceStation,
                    LetterNo = vehicleReplacementDTO.LetterNo,
                    LetterDate = vehicleReplacementDTO.LetterDate,
                    ReplacementType = vehicleReplacementDTO.ReplacementType ,
                    ReplacementReason = vehicleReplacementDTO.ReplacementReason,                  
                   
                    CreatedById = vehicleReplacementDTO.CretedById,
                    CreatedDate = DateTime.Now,
                    Status = DataChangeStatus.Submitted,
                    Remark = vehicleReplacementDTO.Remark,
                    ApprovedById = vehicleReplacementDTO.ApprovedById ,
                    ApprovedDate = DateTime.Now



                };

                await _dbContext.VehicleReplacements.AddAsync(vehicleReplacement);

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

        public async Task<ResponseMessage> ApproveRequestAsync(VehicleReplacementDTO vehicleReplacementDTO)
        {
            // Retrieve the replacement entity from the database
            var vehicleReplacement = await _dbContext.VehicleReplacements
                .FirstOrDefaultAsync(dc => dc.Id == vehicleReplacementDTO.VehicleId);
            try
            {

                if (vehicleReplacement == null)
                {

                    return new ResponseMessage { Success = false, Message = "Not Found" };
                }

                // Check if the replecement  request is in the 'Approved' status
                if (vehicleReplacement.Status != DataChangeStatus.Submitted)
                {
                    return new ResponseMessage { Success = false, Message = "is not in the Submitted status and cannot be approved" };
                }

                // Save the sreplecementto the database

                if (vehicleReplacement != null)
                {

                    vehicleReplacement.Status = DataChangeStatus.Approved;
                    vehicleReplacement.ApprovedById = vehicleReplacementDTO.ApprovedById;
                    vehicleReplacement.ApprovedDate = DateTime.Now;
                    vehicleReplacement.Remark = vehicleReplacementDTO.Remark;
                    await _dbContext.SaveChangesAsync();

                }



                return new ResponseMessage
                {
                    Success = true,
                    Message = "Request Approved  Successfully !!!"
                };

            }

            catch (Exception ex)
            {
                _logger.LogExcption("VRMS", vehicleReplacementDTO.ApprovedById, ex.Message);

                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };


            }

        }

        public async Task<ResponseMessage> RejectRequestAsync(VehicleReplacementDTO vehicleReplacementDTO)
        {
            var request = await _dbContext.DataChanges.FindAsync(vehicleReplacementDTO.VehicleId);

            if (request == null)
            {
                return new ResponseMessage { Success = false, Message = "Data could not be found" };
            }
            if (request != null)
            {
                request.Status = DataChangeStatus.Rejected;
                request.ApprovedById = vehicleReplacementDTO.CretedById;
                request.Comments = vehicleReplacementDTO.Remark;
                await _dbContext.SaveChangesAsync();
            }
            return new ResponseMessage { Success = true, Message = "Rejected Succesfully!!" };


        }


    }
}
