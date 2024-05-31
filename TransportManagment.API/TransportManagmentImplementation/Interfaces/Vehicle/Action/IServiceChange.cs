using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IServiceChange
    {

        
       
        public Task<IEnumerable<ServiceChangeDTO>> GetAllServiceChanges();
        public Task<ResponseMessage> CreateServiceChangeRequest(ServiceChangeDTO request);
      
        public Task<ResponseMessage> ApproveRequestAsync(ServiceChangeDTO ApprovedData);
        public Task<ResponseMessage> RejectRequestAsync(ServiceChangeDTO rejectedrequesr);
        public Task<List<ServiceChangeDTO>> GetByVehicleId(Guid vehicleId);



        

    }
}
