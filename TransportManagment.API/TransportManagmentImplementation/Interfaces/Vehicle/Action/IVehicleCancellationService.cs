using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IVehicleCancellationService
    {

      public  Task<ResponseMessage> CreateVehicleCancellation(VehicleCancellationDTO CreateVehicleCancellation);
      public  Task<ResponseMessage> UpdateVehicleCancellation(VehicleCancellationDTO CreateVehicleCancellation);
      public  Task<List<VehicleCancellationDTO>> GetVehicleCancellationById(Guid id);
      // public Task<IEnumerable<VehicleCancellationDTO>> GetAllVehicleCancellations();
    }
}
