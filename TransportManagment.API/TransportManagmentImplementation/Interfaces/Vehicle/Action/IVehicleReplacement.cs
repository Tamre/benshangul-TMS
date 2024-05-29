using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IVehicleReplacement
    {
        public Task<ResponseMessage> CreateReplecementRequest(VehicleReplacementDTO request);      
        public Task<ResponseMessage> ApproveRequestAsync(VehicleReplacementDTO ApprovedData);
        public Task<ResponseMessage> RejectRequestAsync(VehicleReplacementDTO request);
        public  Task<List<VehicleReplacementDTO>> GetByVehicleId(Guid vehicleId);

    }
}
