using AutoMapper;
using IntegratedImplementation.Interfaces.Configuration;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
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
 
    public class DataChangeService : IDataChange
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public DataChangeService(ApplicationDbContext dbContext, IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;

        }
        public async Task<ResponseMessage> CreateDataChangeRequest(DataChangePostDto _datachangePostDto)
        {
            //var currentVehicle = await _dbContext.VehicleLists.FirstOrDefaultAsync(x => x.Id == _datachangePostDto.Id);

            try
            {
                var dataChange = new DataChange
                {
                    Id = Guid.NewGuid(),                   
                    TableName = _datachangePostDto.TableName,
                    ColumnName = _datachangePostDto.ColumnName,
                    VehicleId = _datachangePostDto.VehicleId,
                    OldValue = _datachangePostDto.OldValue,
                    NewValue = _datachangePostDto.NewValue,
                    Reason = _datachangePostDto.Reason,
                    AdditionalChanges = _datachangePostDto.AdditionalChanges?.ToString()?? string.Empty, // Convert dictionary to JSON string
                    CreatedDate = DateTime.Now,
                    CreatedById = _datachangePostDto.CreatedById,
                   // Requestor = _datachangePostDto.Requestor,
                    RequestedDate = _datachangePostDto.RequestedDate,
                    ApprovedById = _datachangePostDto.ApprovedById,
                    //ApprovedBy = _datachangePostDto.ApprovedBy,
                    Comments = _datachangePostDto.Comments,
                    Status = DataChangeStatus.Submitted

                };
              
                await _dbContext.DataChanges.AddAsync(dataChange);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = $"Data change Request Created For DataChange DataChangeId {dataChange.Id}"
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

        public async Task<PagedList<DataChangeGetDto>> GetAll(FilterDetail filterData)
        {
            IQueryable<DataChange> dataChangeQuery = _dbContext.DataChanges.AsNoTracking().Where((y =>y.Status== DataChangeStatus.Submitted)).OrderBy(x => x.CreatedDate);

            /// Do the Sort And Serch Impleentation here

            if (!string.IsNullOrEmpty(filterData.SearchTerm))
            {

            }

            if (filterData.Criteria != null && filterData.Criteria.Count() > 0)
            {
                foreach (var criteria in filterData.Criteria)
                {
                    dataChangeQuery = dataChangeQuery.Where(GetFilterProperty(criteria));
                }
            }



            var pagedDatachange = await PagedList<DataChange>.ToPagedListAsync(dataChangeQuery, filterData.PageNumber, filterData.PageSize);

            var pagedDatachangDtos = _mapper.Map<List<DataChangeGetDto>>(pagedDatachange);


            return new PagedList<DataChangeGetDto>(pagedDatachangDtos, pagedDatachange.MetaData);
        }

        private static Expression<Func<DataChange, bool>> GetFilterProperty(FilterCriteria criteria)
        {
            return criteria.ColumnName?.ToLower() switch
            {
                "ApprovalStatus" => DataChange => DataChange.ApprovalStatus.ToString() == criteria.FilterValue


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
                                          VehicleCurrentStatus = x.Vehicle.VehicleCurrentStatus.ToString()
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
                                          VehicleCurrentStatus = x.VehicleCurrentStatus.ToString()
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
                                          VehicleCurrentStatus = x.VehicleCurrentStatus.ToString()
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
                                          VehicleCurrentStatus = x.VehicleCurrentStatus.ToString()
                                      })
                                  .FirstOrDefaultAsync();

                if (currVeh != null)
                {
                    vehicleDetail = currVeh;
                }
            }


            return vehicleDetail;
        }

        public async Task<ResponseMessage> ApproveRequestAsync(DataChangePostDto dataChangePostDto)
        {
           

                var request = await _dbContext.DataChanges.FindAsync(DataChangeStatus.Submitted);
                if (request == null)
                {
                    return new ResponseMessage { Success = false, Message = "Data could not be found" };
                }

                if (request != null)
                {
                    request.Status = DataChangeStatus.Approved;
                    request.ApprovedById = dataChangePostDto.ApprovedById;
                    request.ApprovedDate = DateTime.UtcNow;
                    request.Comments = dataChangePostDto.Comments;
                    await _dbContext.SaveChangesAsync();
                await Update(dataChangePostDto);
                }

                  return new ResponseMessage { Success = true, Message = "Updated Vehicle Succesfully!!" };

        }
        public async Task<ResponseMessage> Update(DataChangePostDto updateVehicle)
        {
            var currentVehicle = await _dbContext.VehicleLists.FirstOrDefaultAsync(x => x.Id == updateVehicle.VehicleId);

            if (currentVehicle == null)
            {
                return new ResponseMessage { Success = false, Message = "Vehicle could not be found" };
            }

            //if (currentVehicle.RegistrationType == RegistrationType.PERMANENT)
            //{
            //    return new ResponseMessage { Success = false, Message = "Vehicle can not be edited " };


            //}
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
                currentVehicle.ApprovedById = updateVehicle.ApprovedById;
            }
          

            currentVehicle.EngineNumber = TableColumnName.EngineNumber.ToString();
            currentVehicle.ChassisNo = TableColumnName.ManufacturingYear.ToString();
            currentVehicle.ManufacturingYear = Convert.ToInt32(TableColumnName.ChassisNo);


            return new ResponseMessage { Success = true, Message = "Updated Vehicle Succesfully!!" };
        }
        public async Task<ResponseMessage> RejectRequestAsync(DataChangePostDto dataChangePostDto)
        {
            var request = await _dbContext.DataChanges.FindAsync(dataChangePostDto.VehicleId);

            if (request == null)
            {
                return new ResponseMessage { Success = false, Message = "Data could not be found" };
            }
            if (request != null)
            {
                request.Status = DataChangeStatus.Rejected;
                request.ApprovedById = dataChangePostDto.ApprovedById;
                request.ApprovedDate = DateTime.UtcNow;
                request.Comments = dataChangePostDto.Comments;
                await _dbContext.SaveChangesAsync();
            }
            return new ResponseMessage { Success = true, Message = "Rejected Vehicle Succesfully!!" };
        }


    }
}
