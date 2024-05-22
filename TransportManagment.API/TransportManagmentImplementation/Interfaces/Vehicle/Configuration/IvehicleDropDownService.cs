using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Configuration
{
    public interface IvehicleDropDownService
    {
        Task<List<SettingDropDownsDto>> GetNotAddedDocuments(Guid VehicleId);
        Task<List<OwnerListDropdownDto>> GetOwnerListDropdown(OwnerGroup ownerGroup);
        Task<List<SettingDropDownsDto>> GetDocumentTypeDropdown();
      
    }
}
