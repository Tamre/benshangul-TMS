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
using Superpower;


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
        public async Task<ResponseMessage> CreateDataChangeRequest(DataChangeDto _datachangePostDto)
        {

            try
            {
                // Create a new DataChange entity
                var dataChange = new DataChange
            {
                Id = Guid.NewGuid(),
                TableName = _datachangePostDto.TableName,
                VehicleId = _datachangePostDto.VehicleId,
                Reason = _datachangePostDto.Reason,
                CreatedById = _datachangePostDto.CreatedById,
                CreatedDate = _datachangePostDto.CreatedDate,
                Status = DataChangeStatus.Submitted
            };

            // Add the DataChange entity to the database
            _dbContext.DataChanges.Add(dataChange);

                // Create DataChangeDetail entities for each change detail
                foreach (var detail in _datachangePostDto.DataChangeDetails)
                {
                    var dataChangeDetail = new DataChangeDetail
                    {
                        Id = Guid.NewGuid(),
                        DataChangeId = dataChange.Id,
                        ColumnName = detail.ColumnName,
                        OldValue = detail.OldValue,
                        NewValue = detail.NewValue,
                    };

                    // Add the DataChangeDetail entity to the database
                    _dbContext.DataChangeDetails.Add(dataChangeDetail);
                }

                _dbContext.SaveChanges();

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
      
        public async Task<IEnumerable<DataChangeDto>> GetAllDataChangeRequests()
        {
           var dataChangeDTOs = new List<DataChangeDto>();

            var dataChanges = await _dbContext.DataChanges
                .Where(dc => dc.Status == DataChangeStatus.Submitted)
                .OrderBy(x => x.CreatedDate)
                .Include(dc => dc.DataChangeDetails)
                .Select(x => new DataChangeDto
                {
                    Id = x.Id,
                    TableName = x.TableName,
                    VehicleId = x.VehicleId,
                    Reason = x.Reason,
                    CreatedById = x.CreatedBy.FullName,
                    CreatedDate = x.CreatedDate,
                    DataChangeDetails = x.DataChangeDetails.Select(dcd => new DataChangeDetailDto
                    {
                        DataChangeId = dcd.DataChangeId,
                        Id = dcd.Id,
                        OldValue = dcd.OldValue,
                        NewValue = dcd.NewValue
                    }).ToList()
                })
                .ToListAsync();
            return dataChangeDTOs;
        }     
       
        public async Task<ResponseMessage> ApproveRequestAsync(DataChangeDto dataChangePostDto)
        {
            // Retrieve the DataChange entity from the database
            var dataChange = await _dbContext.DataChanges
                .Include(dc => dc.DataChangeDetails)
                .FirstOrDefaultAsync(dc => dc.Id == dataChangePostDto. Id);


            try
            {

                if (dataChange == null)
            {
           
                    return new ResponseMessage { Success = false, Message = "Not Found" };
                }

            // Check if the data change request is in the 'Submitted' status
            if (dataChange.Status != DataChangeStatus.Submitted)
            {
                 return new ResponseMessage { Success = false, Message = "is not in the Submitted status and cannot be approved" };
                }
           
            // Save the changes to the database

            if (dataChange != null)
            {
                dataChange.Status = DataChangeStatus.Approved;
                dataChange.ApprovedById = dataChangePostDto.ApprovedById;
                dataChange.ApprovedDate = DateTime.UtcNow;
                dataChange.Comments = dataChangePostDto.Comments;
                await _dbContext.SaveChangesAsync();
                await Update(dataChangePostDto);
            }          

               //return new ResponseMessage { Success = true, Message = "Updated Vehicle Succesfully!!" };

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Vehicle Encoded Successfully !!!"
                };

            }

            catch (Exception ex)
            {
               // _logger.LogExcption("VRMS", dataChangePostDto.CreatedById, ex.Message);

                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };


            }

        }
        public async Task<ResponseMessage> Update(DataChangeDto vehicleUpdateDto)
        {
            
            try
            {
                // Retrieve the vehicle from the database
                var vehicle = await _dbContext.VehicleLists.FirstOrDefaultAsync(v => v.Id == vehicleUpdateDto.VehicleId);

                if (vehicle == null)
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = $"Vehicle with ID {vehicleUpdateDto.VehicleId} not found."
                    };
                }

                // Update the vehicle's properties
                foreach (var detail in vehicleUpdateDto.DataChangeDetails)
                {
                    switch (detail.ColumnName)
                    {
                        case TableColumnName.ChassisNo:
                            vehicle.ChassisNo = detail.NewValue;
                            break;
                        case TableColumnName.EngineNumber:
                            vehicle.EngineNumber = detail.NewValue;
                            break;
                        case TableColumnName.ManufacturingYear:
                            vehicle.ManufacturingYear = int.Parse(detail.NewValue);
                            break;
                       
                    }
                }

                // Save the changes to the database
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = $"Vehicle with ID {vehicleUpdateDto.VehicleId} updated successfully."
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
        public async Task<ResponseMessage> RejectRequestAsync(DataChangeDto dataChangePostDto)
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
