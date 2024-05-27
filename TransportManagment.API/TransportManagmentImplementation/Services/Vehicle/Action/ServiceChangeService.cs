using AutoMapper;
using IntegratedImplementation.Interfaces.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.Interfaces.Vehicle;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentImplementation.Services.Configuration;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Migrations;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using Superpower;
using TransportManagmentInfrustructure.Model.Authentication;
namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class ServiceChangeService : IServiceChange
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly ILoggerManagerService _logger;
        private readonly IGeneralConfigService _generalConfigService;

        private readonly IMapper _mapper;

        public ServiceChangeService(ApplicationDbContext dbContext, ILoggerManagerService logger, IGeneralConfigService generalConfigService, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _generalConfigService = generalConfigService;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> CreateServiceChangeRequest(ServiceChangeDTO ServiceChangeRequestDto)
        {
                try
            {                           

               
              
                var serviceChange = new ServiceChange
                {
                    Id = Guid.NewGuid(),
                    VehilceId = ServiceChangeRequestDto.VehilceId,
                    OrganizationId = ServiceChangeRequestDto.OrganizationId,                 
                    GivingZoneId = ServiceChangeRequestDto.GivingZoneId,                 
                    ServiceChangeType= ServiceChangeRequestDto.ServiceChangeType,
                    LetterNo = ServiceChangeRequestDto.LetterNo,
                    ISAISChanges = ServiceChangeRequestDto.ISAISChanges,
                    IsORCChanges = ServiceChangeRequestDto.IsORCChanges,
                    IsPlateChanges= ServiceChangeRequestDto.IsPlateChanges,
                    PreviousEngineNo= ServiceChangeRequestDto.PreviousEngineNo,
                    EngineNo= ServiceChangeRequestDto.EngineNo,
                    Reason = ServiceChangeRequestDto.Reason,
                    CreatedById = ServiceChangeRequestDto.CreatedById,
                    CreatedDate = DateTime.Now,
                    Status = DataChangeStatus.Submitted,
                    Remark = ServiceChangeRequestDto.Remark,
                    ApprovedById = ServiceChangeRequestDto.CreatedById,
                    ApprovedDate = DateTime.Now
                   


                };

                await _dbContext.ServiceChanges.AddAsync(serviceChange);               

                await _dbContext.SaveChangesAsync();

                return new ResponseMessage 
                {
                    Success = true,
                    Message = $"Service change Request Created For Service"
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
        public async Task<IEnumerable<ServiceChangeDTO>> GetAllServiceChanges()
        {
           
                var dataChanges = await _dbContext.ServiceChanges
                .Where(dc => dc.Status == DataChangeStatus.Submitted)
                .OrderBy(x => x.CreatedDate)
               
                .Select(x => new ServiceChangeDTO
                {
                    Id = x.Id,
                    VehilceId = x.VehilceId,                 
                    Reason = x.Reason,
                    CreatedById = x.CreatedById,
                    CreatedDate = x.CreatedDate,
              
                })
                .ToListAsync();
            return   dataChanges;
        }

        public async Task<ResponseMessage> ApproveRequestAsync(ServiceChangeDTO ServiceChangeRequestDto)
        {
            // Retrieve the ServiceChange entity from the database
            var serviceChange = await _dbContext.ServiceChanges             
                .FirstOrDefaultAsync(dc => dc.Id == ServiceChangeRequestDto.Id);
            try
            {

                if (serviceChange == null)
                {

                    return new ResponseMessage { Success = false, Message = "Not Found" };
                }

                // Check if the service change request is in the 'Approved' status
                if (serviceChange.Status != DataChangeStatus.Submitted)
                {
                    return new ResponseMessage { Success = false, Message = "is not in the Submitted status and cannot be approved" };
                }

                // Save the service changes to the database

                if (serviceChange != null)
                {

                    serviceChange.Status = DataChangeStatus.Approved;
                    serviceChange.ApprovedById = ServiceChangeRequestDto.ApprovedById;
                    serviceChange.ApprovedDate = DateTime.Now;
                    serviceChange.Remark = ServiceChangeRequestDto.Remark;             
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
                _logger.LogExcption("VRMS", ServiceChangeRequestDto.ApprovedById, ex.Message);

                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };


            }

        }
        public async Task<ResponseMessage> Update(ServiceChangeDTO vehicleUpdateDto)
        {

            try
            {
                // Retrieve the vehicle from the database
                var vehicle = await _dbContext.VehicleLists.FirstOrDefaultAsync(v => v.Id == vehicleUpdateDto.VehilceId);

                if (vehicle == null)
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = $"Vehicle with ID {vehicleUpdateDto.VehilceId} not found."
                    };
                }

                
                    if (vehicleUpdateDto.ServiceChangeType== ServiceChangeType.EngineChange)
                    {
                       vehicle.EngineNumber = vehicleUpdateDto.EngineNo;                        

                    }
                

                // Save the changes to the database
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = $"Vehicle with ID {vehicleUpdateDto.EngineNo} updated successfully."
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
        public async Task<ResponseMessage> RejectRequestAsync(ServiceChangeDTO ServiceChangePDto)
        {
            var request = await _dbContext.DataChanges.FindAsync(ServiceChangePDto.VehilceId);

            if (request == null)
            {
                return new ResponseMessage { Success = false, Message = "Data could not be found" };
            }
            if (request != null)
            {
                request.Status = DataChangeStatus.Rejected;
                request.ApprovedById = ServiceChangePDto.CreatedById;
                request.Comments = ServiceChangePDto.Remark;
                await _dbContext.SaveChangesAsync();
            }
            return new ResponseMessage { Success = true, Message = "Rejected service Change Succesfully!!" };


        }
        public async Task<List<ServiceChangeDTO>> GetByVehicleId(Guid vehicleId)
        {

            var _serviceChange = await _dbContext.ServiceChanges.Where(x => x.VehilceId == vehicleId).OrderBy(x => x.CreatedDate).ToListAsync();

            var serviceChange = _mapper.Map<List<ServiceChangeDTO>>(_serviceChange);

            return serviceChange;


        }


    }
}
