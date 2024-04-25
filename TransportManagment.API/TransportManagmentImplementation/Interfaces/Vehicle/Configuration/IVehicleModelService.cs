using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Configuration
{
    // Interface
    public interface IVehicleModelService
    {
        Task<ResponseMessage> Add(VehicleModelPostDto vehicleModelPost);
        Task<ResponseMessage> Update(VehicleModelGetDto vehicleModelGet);
        Task<List<VehicleModelGetDto>> GetAll();
    }

}
