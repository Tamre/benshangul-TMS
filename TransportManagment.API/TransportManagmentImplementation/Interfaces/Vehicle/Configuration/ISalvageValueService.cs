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
    public interface ISalvageValueService
    {
        Task<ResponseMessage> Add(SalvageValuePostDto salvageValuePost);
        Task<ResponseMessage> Update(SalvageValueGetDto salvageValueGet);
        Task<List<SalvageValueGetDto>> GetAll();
    }

}
