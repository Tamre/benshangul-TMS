using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Configuration
{
    public interface IvehicleDropDownService
    {
        Task<List<SettingDropDownsDto>> GetNotAddedDocuments(Guid VehicleId);
    }
}
