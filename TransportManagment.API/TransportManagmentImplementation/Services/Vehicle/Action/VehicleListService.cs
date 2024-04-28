using IntegratedImplementation.Interfaces.Configuration;
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
                var vechicle = new VehicleList
                {
                    Id = Guid.NewGuid(),
                    RegistrationNo = "",
                    RegistrationType = RegistrationType.ENCODED,
                    ModelId = vehicleListPostDto.ModelId,
                    TaxStatus = Enum.Parse<TaxStatus>(vehicleListPostDto.TaxStatus),
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
                    HorsePowerMeasure = Enum.Parse<HorsePowerMeasure>(vehicleListPostDto.HorsePowerMeasure),
                    HorsePower = vehicleListPostDto.HorsePower,
                    NoCylinder = vehicleListPostDto.NoCylinder,
                    EngineCapacity = vehicleListPostDto.EngineCapacity,
                    ServiceZoneId = vehicleListPostDto.ServiceZoneId,






                    CreatedById = vehicleListPostDto.CreatedById,
                    CreatedDate = DateTime.Now,




                };

                if (vehicleListPostDto.TypeOfVehicle != null)
                {
                    vechicle.TypeOfVehicle = Enum.Parse<TypeOfVehicle>(vehicleListPostDto.TypeOfVehicle);
                }
                if (vehicleListPostDto.TransferStatus != null)
                {
                    vechicle.TransferStatus = Enum.Parse<TransferStatus>(vehicleListPostDto.TransferStatus);
                }
                if (vehicleListPostDto.VehicleCurrentStatus != null)
                {
                    vechicle.VehicleCurrentStatus = Enum.Parse<VehicleCurrentStatus>(vehicleListPostDto.VehicleCurrentStatus);
                }



                await _dbContext.VehicleLists.AddAsync(vechicle);
                await _dbContext.SaveChangesAsync();



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
