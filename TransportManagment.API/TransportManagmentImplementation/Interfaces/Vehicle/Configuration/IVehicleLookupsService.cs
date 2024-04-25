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
    public interface IVehicleLookupsService
    {
        Task<ResponseMessage> Add(VehicleLookupsPostDto vehicleLookupsPost);
        Task<ResponseMessage> Update(VehicleLookupsGetDto vehicleLookupsGet);
        Task<List<VehicleLookupsGetDto>> GetAllByLookUpType(string LookUpType);
    }

}
