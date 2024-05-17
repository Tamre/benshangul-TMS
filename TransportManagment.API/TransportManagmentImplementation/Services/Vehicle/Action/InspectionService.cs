using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    public class InspectionService : IInpsectionService
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly ILoggerManagerService _logger;

        private readonly IMapper _mapper;

        public InspectionService(ApplicationDbContext dbContext, ILoggerManagerService logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;   
        }

        public async Task<ResponseMessage> CreateFieldInspection(FieldInspectionPostDto inspection)
        {

            try
            {
                var FieldInspection = new FieldInspection();




                FieldInspection.Id = Guid.NewGuid();
                FieldInspection.CreatedById = FieldInspection.CreatedById;
                FieldInspection.CreatedDate = DateTime.Now;
                FieldInspection.VehicleId = inspection.VehicleId;
                FieldInspection.GivenZoneId = inspection.GivenZoneId;
                FieldInspection.ServiceChangeId = inspection.ServiceChangeId;
                FieldInspection.Width = inspection.Width;
                FieldInspection.Height = inspection.Height;
                FieldInspection.Length = inspection.Length;
                FieldInspection.FrontTyreSize = inspection.FrontTyreSize;
                FieldInspection.RearTyreSize = inspection.RearTyreSize;
                FieldInspection.NoOfRearAxel = inspection.NoOfRearAxel;
                FieldInspection.NoOfFrontAxel = inspection.NoOfFrontAxel;
                FieldInspection.AxelDriveType = inspection.AxelDriveType;
                FieldInspection.NumberOfTyre = inspection.NumberOfTyre;
                FieldInspection.FrontAxelMAxLoad = inspection.FrontAxelMAxLoad;
                FieldInspection.RearAxelMaxLoad = inspection.RearAxelMaxLoad;
                FieldInspection.GrossWeight = inspection.GrossWeight;
                FieldInspection.TareWeight = inspection.TareWeight;
                FieldInspection.FrontPlateSizeId = inspection.FrontPlateSizeId;
                FieldInspection.BackPlateSizeId = inspection.BackPlateSizeId;


                await _dbContext.FieldInspections.AddAsync(FieldInspection);
                await _dbContext.SaveChangesAsync();

                string loggerMessage = $"Field Inspection with Id {FieldInspection.Id} for Vechicle {inspection.VehicleId} created By {inspection.CreatedById} on {DateTime.Now}";

                _logger.LogCreate("VRMS", inspection.CreatedById, loggerMessage);


                var vehicle = await _dbContext.VehicleLists.FindAsync(FieldInspection.VehicleId);
                if (vehicle != null)
                {
                    vehicle.LastActionTaken = TransportManagmentInfrustructure.Enums.VehicleEnum.LastActionTaken.FieldInspection;

                }
                await _dbContext.SaveChangesAsync();


                return new ResponseMessage
                {

                    Success = true,
                    Message = loggerMessage,
                    Data = FieldInspection.Id

                };


            }
            catch (Exception ex)
            {

                var message = $"Message={ex.Message}, Detail ={ex.StackTrace}";

                _logger.LogExcption("VRMS", inspection.CreatedById, message);

                return new ResponseMessage
                {
                    Success = true,
                    Message = ex.Message,
                };


            }

        }

        public async Task<ResponseMessage> CreateTechnicalInspection(TechnicalInspectionPostDto inspection)
        {
            try
            {
                var TechnicalInspection = new TechnicalInspection();

                TechnicalInspection.Id = Guid.NewGuid();
                TechnicalInspection.CreatedById = TechnicalInspection.CreatedById;
                TechnicalInspection.CreatedDate = DateTime.Now;
                TechnicalInspection.FieldInspectionId = inspection.FieldInspectionId;
                TechnicalInspection.VehicleBodyTypeId = inspection.VehicleBodyTypeId;
                TechnicalInspection.ServiceTypeId = inspection.ServiceTypeId;
                TechnicalInspection.LoadMesurementId = inspection.LoadMesurementId;
                TechnicalInspection.NoOfPeople = inspection.NoOfPeople;
                TechnicalInspection.LoadValue = inspection.LoadValue;
                TechnicalInspection.ColorId = inspection.ColorId;
                TechnicalInspection.HydroCarbon = inspection.HydroCarbon;
                TechnicalInspection.CarbonMonoOxide = inspection.CarbonMonoOxide;
                TechnicalInspection.IsEngineReadable = inspection.IsEngineReadable;
                TechnicalInspection.PermissionLetterNo = inspection.PermissionLetterNo;
                TechnicalInspection.PermissionDate = inspection.PermissionDate;
                TechnicalInspection.Remark = inspection.Remark;


                await _dbContext.TechnicalInspections.AddAsync(TechnicalInspection);
                await _dbContext.SaveChangesAsync();

                var fieldInspection = await _dbContext.FieldInspections.FindAsync(TechnicalInspection.FieldInspectionId);

                string loggerMessage = $"Technical Inspection with Id {TechnicalInspection.Id} for Field Inspection {inspection.FieldInspectionId} created By {inspection.CreatedById} on {DateTime.Now}";

                _logger.LogCreate("VRMS", inspection.CreatedById, loggerMessage);


                var vehicle = await _dbContext.VehicleLists.FindAsync(fieldInspection.VehicleId);
                if (vehicle != null)
                {
                    vehicle.LastActionTaken = TransportManagmentInfrustructure.Enums.VehicleEnum.LastActionTaken.TechnicalInspection;

                }
                await _dbContext.SaveChangesAsync();




                var serviceType = await _dbContext.ServiceTypes.FindAsync(TechnicalInspection.ServiceTypeId);
                var vehiclePlate = await _dbContext.VehiclePlates.Where(x => x.VehicleId == fieldInspection.VehicleId && x.IsActive).FirstOrDefaultAsync();

                if (serviceType != null && vehiclePlate != null)
                {
                    vehiclePlate.ServiceModule = serviceType.ServiceModule;


                    await _dbContext.SaveChangesAsync();
                }








                return new ResponseMessage
                {

                    Success = true,
                    Message = loggerMessage,
                    Data = TechnicalInspection.Id

                };


            }
            catch (Exception ex)
            {

                var message = $"Message={ex.Message}, Detail ={ex.StackTrace}";

                _logger.LogExcption("VRMS", inspection.CreatedById, message);

                return new ResponseMessage
                {
                    Success = true,
                    Message = ex.Message,
                };


            }

        }

        public async Task<InspectionDto> GetInspectionByVehicleId(Guid vehicleId)
        {

            var InspectionDetails = new InspectionDto();
            var FieldInspection = await _dbContext.FieldInspections.Where(u => u.VehicleId == vehicleId && u.IsActive).FirstOrDefaultAsync();

            if (FieldInspection != null)
            {

                var tecnicalInspection = await _dbContext.TechnicalInspections.Where(u => u.FieldInspectionId == FieldInspection.Id && u.IsActive).FirstOrDefaultAsync();

                var FieldInspectionDetailResponseDto = _mapper.Map<FieldInspectionGetDto>(FieldInspection);
                var tecnicalInspectionDetailResponseDto = _mapper.Map<TechnicalInspectionGetDto>(tecnicalInspection);


                InspectionDetails.FieldInspection = FieldInspectionDetailResponseDto;

                InspectionDetails.TechnicalInspection = tecnicalInspectionDetailResponseDto;


            }

            return InspectionDetails;
        }

        public async Task<ResponseMessage> UpdateFieldInspection(FieldInspectionGetDto inspection)
        {

            try
            {
                var FieldInspection = await _dbContext.FieldInspections.FindAsync(inspection.Id);


                if (FieldInspection != null) { 

                
                FieldInspection.VehicleId = inspection.VehicleId;
                FieldInspection.GivenZoneId = inspection.GivenZoneId;
                FieldInspection.ServiceChangeId = inspection.ServiceChangeId;
                FieldInspection.Width = inspection.Width;
                FieldInspection.Height = inspection.Height;
                FieldInspection.Length = inspection.Length;
                FieldInspection.FrontTyreSize = inspection.FrontTyreSize;
                FieldInspection.RearTyreSize = inspection.RearTyreSize;
                FieldInspection.NoOfRearAxel = inspection.NoOfRearAxel;
                FieldInspection.NoOfFrontAxel = inspection.NoOfFrontAxel;
                FieldInspection.AxelDriveType = inspection.AxelDriveType;
                FieldInspection.NumberOfTyre = inspection.NumberOfTyre;
                FieldInspection.FrontAxelMAxLoad = inspection.FrontAxelMAxLoad;
                FieldInspection.RearAxelMaxLoad = inspection.RearAxelMaxLoad;
                FieldInspection.GrossWeight = inspection.GrossWeight;
                FieldInspection.TareWeight = inspection.TareWeight;
                FieldInspection.FrontPlateSizeId = inspection.FrontPlateSizeId;
                FieldInspection.BackPlateSizeId = inspection.BackPlateSizeId;


                await _dbContext.SaveChangesAsync();

                string loggerMessage = $"Field Inspection with Id {FieldInspection.Id} for Vechicle {inspection.VehicleId} updated By {inspection.CreatedById} on {DateTime.Now}";

                _logger.LogCreate("VRMS", inspection.CreatedById, loggerMessage);


                var vehicle = await _dbContext.VehicleLists.FindAsync(FieldInspection.VehicleId);
                if (vehicle != null)
                {
                    vehicle.LastActionTaken = TransportManagmentInfrustructure.Enums.VehicleEnum.LastActionTaken.FieldInspection;

                }
                await _dbContext.SaveChangesAsync();


                return new ResponseMessage
                {

                    Success = true,
                    Message = loggerMessage,
                    Data = FieldInspection.Id

                };
            }
            else
            {
                    return new ResponseMessage
                    {

                        Success = false,
                        Message = "Field Inspection Not Found !!! ",
                        

                    };

                }


            }
            catch (Exception ex)
            {

                var message = $"Message={ex.Message}, Detail ={ex.StackTrace}";

                _logger.LogExcption("VRMS", inspection.CreatedById, message);

                return new ResponseMessage
                {
                    Success = true,
                    Message = ex.Message,
                };


            }

        }

        public async Task<ResponseMessage> UpdateTechnicalInspection(TechnicalInspectionGetDto inspection)
        {
            try
            {
                var TechnicalInspection = await _dbContext.TechnicalInspections.FindAsync(inspection.Id);

                if (TechnicalInspection != null)
                {

                   
                    TechnicalInspection.FieldInspectionId = inspection.FieldInspectionId;
                    TechnicalInspection.VehicleBodyTypeId = inspection.VehicleBodyTypeId;
                    TechnicalInspection.ServiceTypeId = inspection.ServiceTypeId;
                    TechnicalInspection.LoadMesurementId = inspection.LoadMesurementId;
                    TechnicalInspection.NoOfPeople = inspection.NoOfPeople;
                    TechnicalInspection.LoadValue = inspection.LoadValue;
                    TechnicalInspection.ColorId = inspection.ColorId;
                    TechnicalInspection.HydroCarbon = inspection.HydroCarbon;
                    TechnicalInspection.CarbonMonoOxide = inspection.CarbonMonoOxide;
                    TechnicalInspection.IsEngineReadable = inspection.IsEngineReadable;
                    TechnicalInspection.PermissionLetterNo = inspection.PermissionLetterNo;
                    TechnicalInspection.PermissionDate = inspection.PermissionDate;
                    TechnicalInspection.Remark = inspection.Remark;


                    await _dbContext.SaveChangesAsync();

                    var fieldInspection = await _dbContext.FieldInspections.FindAsync(TechnicalInspection.FieldInspectionId);

                    string loggerMessage = $"Technical Inspection with Id {TechnicalInspection.Id} for Field Inspection {inspection.FieldInspectionId} updated By {inspection.CreatedById} on {DateTime.Now}";

                    _logger.LogCreate("VRMS", inspection.CreatedById, loggerMessage);


                    var vehicle = await _dbContext.VehicleLists.FindAsync(fieldInspection.VehicleId);
                    if (vehicle != null)
                    {
                        vehicle.LastActionTaken = TransportManagmentInfrustructure.Enums.VehicleEnum.LastActionTaken.TechnicalInspection;

                    }
                    await _dbContext.SaveChangesAsync();




                    var serviceType = await _dbContext.ServiceTypes.FindAsync(TechnicalInspection.ServiceTypeId);
                    var vehiclePlate = await _dbContext.VehiclePlates.Where(x => x.VehicleId == fieldInspection.VehicleId && x.IsActive).FirstOrDefaultAsync();

                    if (serviceType != null && vehiclePlate != null)
                    {
                        vehiclePlate.ServiceModule = serviceType.ServiceModule;


                        await _dbContext.SaveChangesAsync();
                    }








                    return new ResponseMessage
                    {

                        Success = true,
                        Message = loggerMessage,
                        Data = TechnicalInspection.Id

                    };
                }
                return new ResponseMessage
                {

                    Success = false,
                    Message = "Technical Inspection Not Found!!!",
                    Data = TechnicalInspection.Id

                };


            }
            catch (Exception ex)
            {

                var message = $"Message={ex.Message}, Detail ={ex.StackTrace}";

                _logger.LogExcption("VRMS", inspection.CreatedById, message);

                return new ResponseMessage
                {
                    Success = true,
                    Message = ex.Message,
                };


            }

        }
    }
}
