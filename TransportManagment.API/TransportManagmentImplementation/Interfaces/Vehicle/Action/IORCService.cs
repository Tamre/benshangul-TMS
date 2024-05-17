using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IORCService
    {

        public Task<List<ORCGetDto>> GetORCByVehicleId(Guid vehicleId);
        public Task<ResponseMessage> CreateOwnerRegistration(ORCPostDto orcPostDto);
        public Task<ResponseMessage> PrintOwnerRegistration(Guid orcId);
    }
}
