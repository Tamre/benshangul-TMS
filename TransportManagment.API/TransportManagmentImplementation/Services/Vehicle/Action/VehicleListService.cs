﻿using IntegratedImplementation.Interfaces.Configuration;
using Microsoft.AspNetCore.Components.Web;
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
using TransportManagmentInfrustructure.Migrations;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class VehicleListService : IVehicleListService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly ILoggerManagerService _logger;
        private readonly IGeneralConfigService _generalConfigService;
        

        public VehicleListService(ApplicationDbContext dbContext, ILoggerManagerService logger, IGeneralConfigService generalConfigService)
        {
            _dbContext = dbContext;
            _logger = logger;
            _generalConfigService = generalConfigService;
        }
        public async Task<ResponseMessage> Add(VehicleListPostDto vehicleListPostDto)
        {

            try
            {
<<<<<<< Updated upstream
                var registrationNo = await _generalConfigService.GenerateVehicleNumber(VehicleSerialType.NEWVEHICLE, vehicleListPostDto.ServiceZoneId, vehicleListPostDto.CreatedById);

                var chessisExists = await _dbContext.VehicleLists.AnyAsync(x => x.ChassisNo == vehicleListPostDto.ChassisNo);

                if (chessisExists)
                {
                    return new ResponseMessage { Success = false, Message = "Chessis Number already exists" };
                }
                var engineExists = await _dbContext.VehicleLists.AnyAsync(x => !string.IsNullOrEmpty(x.EngineNumber) && x.EngineNumber == vehicleListPostDto.EngineNumber );

                if (engineExists)
                {
                    return new ResponseMessage { Success = false, Message = "Engine  Number already exists" };
                }

=======
                var registrationNo =await _generalConfigService.GenerateVechilceCode("RN", VehicleSerialType.NEWVEHICLE);

                if (vehicleListPostDto.ChassisNo.Length != 17)
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Chassis No Length Must be equal to 17 !! "
                    };

                }
>>>>>>> Stashed changes
                var vechicle = new VehicleList
                {
                    Id = Guid.NewGuid(),
                    RegistrationNo = registrationNo,
                    RegistrationType = RegistrationType.ENCODED,
                    ModelId = vehicleListPostDto.ModelId,
                    TaxStatus = vehicleListPostDto.TaxStatus,
                    IsVehicleComplete = false,
                    OfficeCode = vehicleListPostDto.OfficeCode,
                    DeclarationNo = vehicleListPostDto.DeclarationNo,
                    DeclarationDate = vehicleListPostDto.DeclarationDate,
                    BillOfLoading = vehicleListPostDto.BillOfLoading,
                    RemovalNumber = vehicleListPostDto.RemovalNumber,
                    InvoiceDate = vehicleListPostDto.InvoiceDate,
                    InvoicePrice = vehicleListPostDto.InvoicePrice,
                    ChassisNo = vehicleListPostDto.ChassisNo,
                    EngineNumber = vehicleListPostDto.EngineNumber,
                    AssembledCountryId = vehicleListPostDto.AssembledCountryId,
                    ChassisMadeId = vehicleListPostDto.ChassisMadeId,
                    ManufacturingYear = vehicleListPostDto.ManufacturingYear,
                    HorsePowerMeasure = vehicleListPostDto.HorsePowerMeasure,
                    HorsePower = vehicleListPostDto.HorsePower,
                    NoCylinder = vehicleListPostDto.NoCylinder,
                    EngineCapacity = vehicleListPostDto.EngineCapacity,
                    ServiceZoneId = vehicleListPostDto.ServiceZoneId,
                    CreatedById = vehicleListPostDto.CreatedById,
                    CreatedDate = DateTime.Now,
<<<<<<< Updated upstream
                    TypeOfVehicle = vehicleListPostDto.TypeOfVehicle,
                    TransferStatus = vehicleListPostDto.TransferStatus,
                    VehicleCurrentStatus = vehicleListPostDto.VehicleCurrentStatus,
=======

>>>>>>> Stashed changes
                };

                await _dbContext.VehicleLists.AddAsync(vechicle);
                await _dbContext.SaveChangesAsync();

              
                    var transferNo = await _generalConfigService.GenerateVehicleNumber(VehicleSerialType.TRANSFERNO, vehicleListPostDto.ServiceZoneId, vehicleListPostDto.CreatedById);

                DateTime? TransferDate = null;
                if (!string.IsNullOrEmpty(vehicleListPostDto.LetterDate))
                {
                    string[] date = vehicleListPostDto.LetterDate.Split('/');
                    TransferDate = Helper.EthiopicDateTime.GetGregorianDate(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]));
                }

                VehicleTransfer transfer = new VehicleTransfer()
                {
                    Id = Guid.NewGuid(),
                    CreatedById = vehicleListPostDto.CreatedById,
                    CreatedDate = DateTime.Now,
                    ChangeOwner = false,
                    ChangePlate = false,
                    ChangeServiceType = false,
                    FromZoneId = (Int32)vehicleListPostDto.FromZoneId,
                    IsActive = true,
                    IsVehicleRejected = false,
                    LetterNo = vehicleListPostDto.LetterNo,
                    PreviousPlate = vehicleListPostDto.PreviousPlate,
                    ToZoneId = vehicleListPostDto.ServiceZoneId,
                    TransferNumber = transferNo,
                    TransferStatus = vehicleListPostDto.TransferStatus,
                    VehicleId = vechicle.Id
                };

                if (TransferDate != null)
                {
                    transfer.TransferedDate = Convert.ToDateTime(TransferDate);
                }

                _logger.LogCreate("VRMS", vehicleListPostDto.CreatedById, $"Vehicle with id {vechicle.Id} Added Successfully on {DateTime.Now}");

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Vehicle Encoded Successfully !!!"
                };

            }

            catch (Exception ex)
            {
                _logger.LogExcption("VRMS", vehicleListPostDto.CreatedById, ex.Message);

                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };


            }



        }
    }
}
