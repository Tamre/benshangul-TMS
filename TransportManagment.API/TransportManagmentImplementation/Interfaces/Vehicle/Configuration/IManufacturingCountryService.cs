using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentAPI.Controllers.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Configuration
{
    // Interface
    public interface IManufacturingCountryService
    {
        Task<ResponseMessage> Add(ManufacturingCountryPostDto manufacturingCountryPost);
        Task<ResponseMessage> Update(ManufacturingCountryGetDto manufacturingCountryGet);
        Task<List<ManufacturingCountryGetDto>> GetAll();
    }

}
