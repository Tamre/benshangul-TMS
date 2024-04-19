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
    public interface IVehicleTypeService
    {
        Task<ResponseMessage> Add(VehicleTypePostDto vehicleTypePost);
        Task<ResponseMessage> Update(VehicleTypeGetDto vehicleTypeGet);
        Task<List<VehicleTypeGetDto>> GetAll();
    }

}
