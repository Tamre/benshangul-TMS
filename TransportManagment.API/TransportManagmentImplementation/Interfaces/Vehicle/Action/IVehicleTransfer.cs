using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IVehicleTransfer
    {
      public  Task<ResponseMessage> CreateVehicleTransferAsync(VehicleTransferDTO vehicleTransferDTO);
      public Task< List<VehicleTransferDTO>> GetVehicleTransferByIdAsync(Guid id);
        //Task<IEnumerable<VehicleTransferDTO>> GetAllVehicleTransfersAsync();
       public  Task<List<VehicleTransferDTO>> GetAllTransfersFromZone(int zoneId);
    }
}
