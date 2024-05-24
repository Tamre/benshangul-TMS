using AutoMapper;
using IntegratedImplementation.Interfaces.Configuration;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentImplementation.Services.Configuration;
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

        private readonly IMapper _mapper;


        public VehicleListService(ApplicationDbContext dbContext, ILoggerManagerService logger, IGeneralConfigService generalConfigService, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _generalConfigService = generalConfigService;
            _mapper = mapper;
        }
        public async Task<ResponseMessage> Add(VehicleListPostDto vehicleListPostDto)
        {

            try
            {

                var registrationNo = await _generalConfigService.GenerateVehicleNumber(VehicleSerialType.NEWVEHICLE, vehicleListPostDto.ServiceZoneId, vehicleListPostDto.CreatedById);

                var chessisExists = await _dbContext.VehicleLists.AnyAsync(x => x.ChassisNo == vehicleListPostDto.ChassisNo);

                if (chessisExists)
                {
                    return new ResponseMessage { Success = false, Message = "Chessis Number already exists" };
                }
                var engineExists = await _dbContext.VehicleLists.AnyAsync(x => !string.IsNullOrEmpty(x.EngineNumber) && x.EngineNumber == vehicleListPostDto.EngineNumber);

                if (engineExists)
                {
                    return new ResponseMessage { Success = false, Message = "Engine  Number already exists" };
                }


                var vechicle = new VehicleList
                {
                    Id = Guid.NewGuid(),
                    RegistrationNo = registrationNo,
                    RegistrationType = RegistrationType.ENCODED,
                    ModelId = vehicleListPostDto.ModelId,
                    TaxStatus = Enum.Parse<TaxStatus>( vehicleListPostDto.TaxStatus),
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

                    TypeOfVehicle = Enum.Parse<TypeOfVehicle>(vehicleListPostDto.TypeOfVehicle),
                    TransferStatus = Enum.Parse<TransferStatus>(vehicleListPostDto.TransferStatus),
                    VehicleCurrentStatus = Enum.Parse<TransportManagmentInfrustructure.Enums.VehicleEnum.VehicleCurrentStatus>(vehicleListPostDto.VehicleCurrentStatus),



                };

                await _dbContext.VehicleLists.AddAsync(vechicle);
                await _dbContext.SaveChangesAsync();

                if (vehicleListPostDto.TransferStatus != TransferStatus.New.ToString()) {

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
                        TransferStatus = Enum.Parse<TransferStatus>(vehicleListPostDto.TransferStatus),
                        VehicleId = vechicle.Id
                    };

                    if (TransferDate != null)
                    {
                        transfer.TransferedDate = Convert.ToDateTime(TransferDate);
                    }

                }
                _logger.LogCreate("VRMS", vehicleListPostDto.CreatedById, $"Vehicle with id {vechicle.Id} Added Successfully on {DateTime.Now}");

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Vehicle Encoded Successfully !!!",
                    Data = new
                    {
                        vehicleId= vechicle.Id,
                        vehicleRegNo= vechicle.RegistrationNo,
                        vehicleChasis = vechicle.ChassisNo}

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



        public async Task<ResponseMessage> AddVehicleDocument(AddVehicleDocumetDto addVehicleDocument)
        {

            var currentVehicle = await _dbContext.VehicleLists.FirstOrDefaultAsync(x => x.Id == addVehicleDocument.VehicleId);
            if (currentVehicle == null)
            {
                return new ResponseMessage { Success = false, Message = "Vehicle Could not be found" };
            }

            var currentDocument = await _dbContext.DocumentTypes.FirstOrDefaultAsync(x => x.Id == addVehicleDocument.DocumentTypeId);
            if (currentDocument == null)
            {
                return new ResponseMessage { Success = false, Message = "Document could not be found" };
            }

            var documentExists = await _dbContext.VehicleDocuments.AnyAsync(x => x.VehicleId == addVehicleDocument.VehicleId && x.DocumentTypeId == addVehicleDocument.DocumentTypeId);

            if (documentExists)
            {
                return new ResponseMessage { Success = false, Message = "Document Already exists" };
            }

            string nameOfFolder = $"Vehicle\\{currentDocument.FileName}";

            string path = await _generalConfigService.UploadFiles(addVehicleDocument.Document, currentVehicle.Id.ToString(), nameOfFolder);

            if (string.IsNullOrEmpty(path))
            {
                return new ResponseMessage { Success = false, Message = "Please Upload The file again" };
            }

            VehicleDocument document = new VehicleDocument()
            {
                Id = Guid.NewGuid(),
                CreatedById = addVehicleDocument.CreatedById,
                CreatedDate = DateTime.Now,
                DocumentPath = path,
                DocumentTypeId = addVehicleDocument.DocumentTypeId,
              
                IsActive = true,
                VehicleId = addVehicleDocument.VehicleId
            };

            await _dbContext.VehicleDocuments.AddAsync(document);
            await _dbContext.SaveChangesAsync();

            return new ResponseMessage { Success = true, Message = "Succesfully Uploaded The file " };

        }

        public async Task<PagedList<VehicleDetailDto>> GetAll(FilterDetail filterData)
        {
            IQueryable<VehicleList> vehicleQuery = _dbContext.VehicleLists.AsNoTracking().OrderBy(x => x.CreatedDate);

            /// Do the Sort And Serch Impleentation here

            if (!string.IsNullOrEmpty(filterData.SearchTerm))
            {

            }

            if (filterData.Criteria != null && filterData.Criteria.Count() > 0)
            {
                foreach (var criteria in filterData.Criteria)
                {
                    vehicleQuery = vehicleQuery.Where(GetFilterProperty(criteria));
                }
            }



            var pagedVechileList = await PagedList<VehicleList>.ToPagedListAsync(vehicleQuery, filterData.PageNumber, filterData.PageSize);

            var pagedVechileListDtos = _mapper.Map<List<VehicleDetailDto>>(pagedVechileList);


            return new PagedList<VehicleDetailDto>(pagedVechileListDtos, pagedVechileList.MetaData);
        }

        private static Expression<Func<VehicleList, bool>> GetFilterProperty(FilterCriteria criteria)
        {
            return criteria.ColumnName?.ToLower() switch
            {
                "ApprovalStatus" => vechile => vechile.ApprovalStatus.ToString() == criteria.FilterValue


            };
        }

        public async Task<VehicleDetailDto> GetVehicleDetail(VehicleGetParameterDto vehicleGet)
        {
            VehicleDetailDto vehicleDetail = new VehicleDetailDto();

            if (vehicleGet.VehicleFileteParameter == VehicleFileteParameter.PlateNo)
            {
                var currVeh = await _dbContext.VehiclePlates.Include(x => x.PlateStock).Include(x => x.Vehicle.Model)
                                        .Include(x => x.Vehicle.AssembledCountry).Include(x => x.Vehicle.ChassisMade)
                                       .Where(x => x.PlateStock.PlateNo == vehicleGet.Value)
                                      .Select(x => new VehicleDetailDto
                                      {
                                          Id = x.VehicleId,
                                          RegistrationNumber = x.Vehicle.RegistrationNo,
                                          RegistrationType = x.Vehicle.RegistrationType.ToString(),
                                          AssembledCountry = x.Vehicle.AssembledCountry.Name,
                                          BillOfLoading = x.Vehicle.BillOfLoading,
                                          ChassisMadeCountry = x.Vehicle.ChassisMade.Name,
                                          ChassisNo = x.Vehicle.ChassisNo,
                                          DeclarationDate = x.Vehicle.DeclarationDate,
                                          DeclarationNo = x.Vehicle.DeclarationNo,
                                          EngineCapacity = x.Vehicle.EngineCapacity,
                                          EngineNumber = x.Vehicle.EngineNumber,
                                          HorsePower = x.Vehicle.HorsePower,
                                          HorsePowerMeasure = x.Vehicle.HorsePowerMeasure.ToString(),
                                          InvoiceDate = x.Vehicle.InvoiceDate,
                                          InvoicePrice = x.Vehicle.InvoicePrice,
                                          ManufacturingYear = x.Vehicle.ManufacturingYear,
                                          Model = x.Vehicle.Model.Name,
                                          NoCylinder = x.Vehicle.NoCylinder,
                                          OfficeCode = x.Vehicle.OfficeCode,
                                          ApprovalStatus = x.Vehicle.ApprovalStatus.ToString(),
                                          RemovalNumber = x.Vehicle.RemovalNumber,
                                          TaxStatus = x.Vehicle.TaxStatus.ToString(),
                                          TransferStatus = x.Vehicle.TransferStatus.ToString(),
                                          TypeOfVehicle = x.Vehicle.TypeOfVehicle.ToString(),
                                          VehicleCurrentStatus = x.Vehicle.VehicleCurrentStatus.ToString(),
                                          ServiceZone = x.Vehicle.ServiceZone.Name,
                                      })
                                  .FirstOrDefaultAsync();

                if (currVeh != null)
                {
                    vehicleDetail = currVeh;
                }
            }
            else if (vehicleGet.VehicleFileteParameter == VehicleFileteParameter.EngineNo)
            {
                var currVeh = await _dbContext.VehicleLists.Include(x => x.Model)
                                        .Include(x => x.AssembledCountry).Include(x => x.ChassisMade)
                                       .Where(x => x.EngineNumber == vehicleGet.Value)
                                      .Select(x => new VehicleDetailDto
                                      {
                                          Id = x.Id,
                                          RegistrationNumber = x.RegistrationNo,
                                          AssembledCountry = x.AssembledCountry.Name,
                                          RegistrationType = x.RegistrationType.ToString(),
                                          BillOfLoading = x.BillOfLoading,
                                          ChassisMadeCountry = x.ChassisMade.Name,
                                          ChassisNo = x.ChassisNo,
                                          DeclarationDate = x.DeclarationDate,
                                          DeclarationNo = x.DeclarationNo,
                                          EngineCapacity = x.EngineCapacity,
                                          EngineNumber = x.EngineNumber,
                                          HorsePower = x.HorsePower,
                                          HorsePowerMeasure = x.HorsePowerMeasure.ToString(),
                                          InvoiceDate = x.InvoiceDate,
                                          InvoicePrice = x.InvoicePrice,
                                          ManufacturingYear = x.ManufacturingYear,
                                          Model = x.Model.Name,
                                          NoCylinder = x.NoCylinder,
                                          OfficeCode = x.OfficeCode,
                                          ApprovalStatus = x.ApprovalStatus.ToString(),
                                          RemovalNumber = x.RemovalNumber,
                                          TaxStatus = x.TaxStatus.ToString(),
                                          TransferStatus = x.TransferStatus.ToString(),
                                          TypeOfVehicle = x.TypeOfVehicle.ToString(),
                                          VehicleCurrentStatus = x.VehicleCurrentStatus.ToString(),
                                          ServiceZone = x.ServiceZone.Name,
                                      })
                                  .FirstOrDefaultAsync();

                if (currVeh != null)
                {
                    vehicleDetail = currVeh;
                }
            }
            else if (vehicleGet.VehicleFileteParameter == VehicleFileteParameter.ChessisNo)
            {
                var currVeh = await _dbContext.VehicleLists.Include(x => x.Model)
                                        .Include(x => x.AssembledCountry).Include(x => x.ChassisMade)
                                       .Where(x => x.ChassisNo == vehicleGet.Value)
                                      .Select(x => new VehicleDetailDto
                                      {
                                          Id = x.Id,
                                          RegistrationNumber = x.RegistrationNo,
                                          AssembledCountry = x.AssembledCountry.Name,
                                          RegistrationType = x.RegistrationType.ToString(),
                                          BillOfLoading = x.BillOfLoading,
                                          ChassisMadeCountry = x.ChassisMade.Name,
                                          ChassisNo = x.ChassisNo,
                                          DeclarationDate = x.DeclarationDate,
                                          DeclarationNo = x.DeclarationNo,
                                          EngineCapacity = x.EngineCapacity,
                                          EngineNumber = x.EngineNumber,
                                          HorsePower = x.HorsePower,
                                          HorsePowerMeasure = x.HorsePowerMeasure.ToString(),
                                          InvoiceDate = x.InvoiceDate,
                                          InvoicePrice = x.InvoicePrice,
                                          ManufacturingYear = x.ManufacturingYear,
                                          Model = x.Model.Name,
                                          NoCylinder = x.NoCylinder,
                                          OfficeCode = x.OfficeCode,
                                          ApprovalStatus = x.ApprovalStatus.ToString(),
                                          RemovalNumber = x.RemovalNumber,
                                          TaxStatus = x.TaxStatus.ToString(),
                                          TransferStatus = x.TransferStatus.ToString(),
                                          TypeOfVehicle = x.TypeOfVehicle.ToString(),
                                          VehicleCurrentStatus = x.VehicleCurrentStatus.ToString(),
                                          ServiceZone = x.ServiceZone.Name,
                                      })
                                  .FirstOrDefaultAsync();

                if (currVeh != null)
                {
                    vehicleDetail = currVeh;
                }
            }
            else if (vehicleGet.VehicleFileteParameter == VehicleFileteParameter.RegistrationNo)
            {
                var currVeh = await _dbContext.VehicleLists.Include(x => x.Model)
                                        .Include(x => x.AssembledCountry).Include(x => x.ChassisMade)
                                       .Where(x => x.RegistrationNo == vehicleGet.Value && x.RegistrationType == vehicleGet.RegistrationType)
                                      .Select(x => new VehicleDetailDto
                                      {
                                          Id = x.Id,                                          
                                          RegistrationNumber = x.RegistrationNo,
                                          RegistrationType = x.RegistrationType.ToString(),
                                          AssembledCountry = x.AssembledCountry.Name,
                                          BillOfLoading = x.BillOfLoading,
                                          ChassisMadeCountry = x.ChassisMade.Name,
                                          ChassisNo = x.ChassisNo,
                                          DeclarationDate = x.DeclarationDate,
                                          DeclarationNo = x.DeclarationNo,
                                          EngineCapacity = x.EngineCapacity,
                                          EngineNumber = x.EngineNumber,
                                          HorsePower = x.HorsePower,
                                          HorsePowerMeasure = x.HorsePowerMeasure.ToString(),
                                          InvoiceDate = x.InvoiceDate,
                                          InvoicePrice = x.InvoicePrice,
                                          ManufacturingYear = x.ManufacturingYear,
                                          Model = x.Model.Name,
                                          NoCylinder = x.NoCylinder,
                                          OfficeCode = x.OfficeCode,
                                          ApprovalStatus = x.ApprovalStatus.ToString(),
                                          RemovalNumber = x.RemovalNumber,
                                          TaxStatus = x.TaxStatus.ToString(),
                                          TransferStatus = x.TransferStatus.ToString(),
                                          TypeOfVehicle = x.TypeOfVehicle.ToString(),
                                          VehicleCurrentStatus = x.VehicleCurrentStatus.ToString(),
                                          ServiceZone = x.ServiceZone.Name,
                                      })
                                  .FirstOrDefaultAsync();

                if (currVeh != null)
                {
                    vehicleDetail = currVeh;
                }
            }


            return vehicleDetail;
        }

        public async Task<ResponseMessage> Update(UpdateVehicleDto updateVehicle)
        {
            var currentVehicle = await _dbContext.VehicleLists.FirstOrDefaultAsync(x => x.Id == updateVehicle.Id);

            if (currentVehicle == null)
            {
                return new ResponseMessage { Success = false, Message = "Vehicle could not be found" };
            }

            if (currentVehicle.RegistrationType == RegistrationType.PERMANENT)
            {
                return new ResponseMessage { Success = false, Message = "Vehicle can not be edited " };


            }
            if (updateVehicle.ISApproved)
            {
                if (currentVehicle.ChassisNo.Length < 17)
                {
                    return new ResponseMessage { Success = false, Message = "Chessis no should be 17" };
                }

                var documents = await _dbContext.DocumentTypes.Where(x => x.IsActive).ToListAsync();
                foreach (var item in documents)
                {
                    var esists = await _dbContext.VehicleDocuments.AnyAsync(x => x.DocumentTypeId == item.Id);
                    if (!esists && ((updateVehicle.RegistrationType == RegistrationType.TEMPORARY && item.IsTemporaryRequired) || (updateVehicle.RegistrationType == RegistrationType.PERMANENT && item.IsPermanentRequired)))
                    {
                        return new ResponseMessage { Success = false, Message = "Please upload the required files first" };
                    }
                }

                currentVehicle.ApprovalStatus = VehicleApprovalStatus.APPROVED;
                currentVehicle.ApprovedById = updateVehicle.CreatedById;
            }

            currentVehicle.VehicleCurrentStatus= Enum.Parse<VehicleCurrentStatus> (updateVehicle.VehicleCurrentStatus);
            currentVehicle.RemovalNumber = updateVehicle.RemovalNumber;
            currentVehicle.EngineNumber = updateVehicle.EngineNumber;
            currentVehicle.AssembledCountryId = updateVehicle.AssembledCountryId;
            currentVehicle.ChassisMadeId = updateVehicle.ChassisMadeId;
            currentVehicle.BillOfLoading = updateVehicle.BillOfLoading;
            currentVehicle.ChassisNo = updateVehicle.ChassisNo;
            currentVehicle.BillOfLoading = updateVehicle.BillOfLoading;
            currentVehicle.ChassisNo = updateVehicle.ChassisNo;
            currentVehicle.DeclarationDate = updateVehicle.DeclarationDate;
            currentVehicle.DeclarationNo = updateVehicle.DeclarationNo;
            currentVehicle.EngineCapacity = updateVehicle.EngineCapacity;
            currentVehicle.HorsePower = updateVehicle.HorsePower;
            currentVehicle.HorsePowerMeasure =Enum.Parse<HorsePowerMeasure>( updateVehicle.HorsePowerMeasure);
            currentVehicle.InvoiceDate = updateVehicle.InvoiceDate;
            currentVehicle.InvoicePrice = updateVehicle.InvoicePrice;
            currentVehicle.ManufacturingYear = updateVehicle.ManufacturingYear;
            currentVehicle.ModelId = updateVehicle.ModelId;
            currentVehicle.NoCylinder = updateVehicle.NoCylinder;
            currentVehicle.OfficeCode = updateVehicle.OfficeCode;
            currentVehicle.RemovalNumber = updateVehicle.RemovalNumber;

            currentVehicle.TypeOfVehicle = Enum.Parse<TypeOfVehicle>( updateVehicle.TypeOfVehicle);


            if (currentVehicle.RegistrationType == RegistrationType.ENCODED && updateVehicle.RegistrationType != RegistrationType.ENCODED)
            {
                VehicleSerialType newVehicleSerial = updateVehicle.RegistrationType == RegistrationType.TEMPORARY ? VehicleSerialType.TEMPORARY : VehicleSerialType.PERMANENT;

                var registrationNo = await _generalConfigService.GenerateVehicleNumber(newVehicleSerial, currentVehicle.ServiceZoneId, updateVehicle.CreatedById);
                currentVehicle.RegistrationType = updateVehicle.RegistrationType;
                currentVehicle.RegistrationNo = registrationNo;
            }


            return new ResponseMessage { Success = true, Message = "Updated Vehicle Succesfully!!" };
        }


        public async Task<ResponseMessage> VehicleActionStatus(VehicleStatusActionDto vehicleStatusActionDto)
        {
            try
            {
                var vechicle = await _dbContext.VehicleLists.FindAsync(vehicleStatusActionDto.VechileId);


                if (vechicle != null)
                {
                    var oldSTatus = vechicle.ApprovalStatus.ToString();

                    vechicle.ApprovalStatus = Enum.Parse<VehicleApprovalStatus>(vehicleStatusActionDto.VehicleAction);

                    await _dbContext.SaveChangesAsync();

                    var loggerMessage = $"Vechicle with {vechicle.Id} has been change to status from ={oldSTatus} to ={vechicle.ApprovalStatus.ToString()} by {vehicleStatusActionDto.CreatedById} on {DateTime.Now.ToString()}";

                    _logger.LogExcption("VRMS", vehicleStatusActionDto.CreatedById, loggerMessage);


                    return new ResponseMessage { Success = true, Message = loggerMessage };
                }
                else
                {
                    return new ResponseMessage { Success = false, Message = "Vechicle Not Found !!!" };
                }


            }
            catch (Exception ex)
            {
                _logger.LogExcption("VRMS", vehicleStatusActionDto.CreatedById, ex.Message);
                return new ResponseMessage { Success = false, Message = ex.Message };
            }
        }

        public async Task<List<VehicleDocumetGetDto>> GetVehicleDocuments(Guid vehicleId)
        {

            var docs = await _dbContext.VehicleDocuments.Include(x => x.DocumentType).
                
                Where(x => x.VehicleId== vehicleId).ToListAsync();

            var docDtos = _mapper.Map<List<VehicleDocumetGetDto>>(docs);

            return docDtos; 


        }
    }
}
