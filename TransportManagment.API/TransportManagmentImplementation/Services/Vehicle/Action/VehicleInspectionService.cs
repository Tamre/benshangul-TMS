using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentInfrustructure.Data;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class VehicleInspectionService: IVehicleInspection
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public VehicleInspectionService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<List<VehicleInspectionDTO>> GetByVehicleId(Guid vehicleId)
        {

            var _serviceChange = await _dbContext.ServiceChanges.Where(x => x.VehilceId == vehicleId).OrderBy(x => x.CreatedDate).ToListAsync();

            var serviceChange = _mapper.Map<List<VehicleInspectionDTO>>(_serviceChange);

            return serviceChange;

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
                        CreatedById = x.CreatedById,
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



        

    }
}
