using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IVehiclePlateService
    {
        public Task<ResponseMessage> AssignPlate(VehiclePlatePostDto vehiclePlateDto);
        public Task<List<VehiclePlateGetDto>> GetByVehicleId(Guid vehicleId); 

             
    }
}
