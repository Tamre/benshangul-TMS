using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IMachineConfigurations
    {

       // public Task<IEnumerable<BrakeInspectionDTO>> GetMachinData();
        public Task<ResponseMessage> Add(MachineConfigurationDTO data);
        public Task<List<MachineConfigurationDTO>> GetMachinData();
    }
}
