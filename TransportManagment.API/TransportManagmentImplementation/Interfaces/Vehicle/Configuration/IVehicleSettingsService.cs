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
    public interface IVehicleSettingsService
    {
        Task<ResponseMessage> Add(VehicleSettingsPostDto vehicleSettingsPost);
        Task<ResponseMessage> Update(VehicleSettingsGetDto vehicleSettingsGet);
        Task<List<VehicleSettingsGetDto>> GetAll();
    }

}
