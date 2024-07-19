using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IBrake
    {

       public Task<IEnumerable<BrakeInspectionDTO>> GetDataFromMachineAsync();
       public Task<ResponseMessage> CreateBrake(IEnumerable<BrakeInspectionDTO> data);


    }
}
