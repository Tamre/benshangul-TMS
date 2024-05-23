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
        Task<PagedList<DataChangeGetDto>> GetAll(FilterDetail filterData);           
        Task<ResponseMessage> CreateDataChangeRequest(DataChangePostDto request);
        public Task<VehicleDetailDto> GetVehicleDetail(VehicleGetParameterDto vehicleGet);
        Task<ResponseMessage> ApproveRequestAsync(DataChangePostDto ApprovedData);
        Task<ResponseMessage> RejectRequestAsync(DataChangePostDto rejected);
    }
}
