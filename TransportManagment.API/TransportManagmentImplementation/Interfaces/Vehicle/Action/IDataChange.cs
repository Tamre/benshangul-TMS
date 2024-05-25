using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using System.ComponentModel.DataAnnotations;
using TransportManagmentInfrustructure.Data;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IDataChange
    {
       
        //public Task<List<DataChangeDto>> GetDatachangeDetailById(Guid vehicleId);
        Task<IEnumerable<DataChangeDto>> GetAllDataChangeRequests();           
        Task<ResponseMessage> CreateDataChangeRequest(DataChangeDto request);
        //Task<ResponseMessage> CreateDataChangeDetailAsync(DataChangeDto dataChangeDetail);
        //public Task<VehicleDetailDto> GetVehicleDetail(VehicleGetParameterDto vehicleGet);
        Task<ResponseMessage> ApproveRequestAsync(DataChangeDto ApprovedData);
        Task<ResponseMessage> RejectRequestAsync(DataChangeDto rejected);
       

    }
}
