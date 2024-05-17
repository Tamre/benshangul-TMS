using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IVehicleListService
    {

        public Task<ResponseMessage> Add(VehicleListPostDto vehicleListPostDto);
        public Task<ResponseMessage> AddVehicleDocument(AddVehicleDocumetDto addVehicleDocument);
        public Task<VehicleDetailDto> GetVehicleDetail(VehicleGetParameterDto vehicleGet);
        Task<PagedList<VehicleDetailDto>> GetAll(FilterDetail filterData);
        public Task<ResponseMessage> Update(UpdateVehicleDto updteVehicle);
        public Task<ResponseMessage> VehicleActionStatus(VehicleStatusActionDto vehicleStatusActionDto);

    }
}
