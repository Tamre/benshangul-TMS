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
    public interface IVehicleSerialSettingService
    {
        Task<ResponseMessage> Add(VehicleSerialSettingPostDto vehicleSerialSettingPost);
        Task<ResponseMessage> Update(VehicleSerialSettingGetDto vehicleSerialSettingGet);
        Task<List<VehicleSerialSettingGetDto>> GetAll();
    }

}
