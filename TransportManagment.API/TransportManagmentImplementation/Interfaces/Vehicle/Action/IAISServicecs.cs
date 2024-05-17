using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IAISServicecs
    {

        public Task<List<AISGetDto>> GetAISByVehicleId(Guid vehicleId);
        public Task<ResponseMessage> CreateAnnualInspection(AISPostDto aisPostDto);
        public Task<ResponseMessage> PrintAnnualInspection(Guid aisId);


    }
}
