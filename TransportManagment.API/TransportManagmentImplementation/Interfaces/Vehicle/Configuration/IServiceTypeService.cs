using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Configuration
{// Interface
    public interface IServiceTypeService
    {
        Task<ResponseMessage> Add(ServiceTypePostDto serviceTypePost);
        Task<ResponseMessage> Update(ServiceTypeGetDto serviceTypeGet);
        Task<List<ServiceTypeGetDto>> GetAll();
    }

}
