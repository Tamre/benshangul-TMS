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
    public interface IServiceYearSettingService
    {
        Task<ResponseMessage> Add(ServiceYearSettingPostDto serviceYearSettingPost);
        Task<ResponseMessage> Update(ServiceYearSettingGetDto serviceYearSettingGet);
        Task<List<ServiceYearSettingGetDto>> GetAll();
    }

}
