using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentAPI.Controllers.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Configuration
{
    // Interface
    public interface IVehicleBodyTypeService
    {
        Task<ResponseMessage> Add(VehicleBodyTypePostDto vehicleBodyTypePost);
        Task<ResponseMessage> Update(VehicleBodyTypeGetDto vehicleBodyTypeGet);
        Task<List<VehicleBodyTypeGetDto>> GetAll();
    }

}
