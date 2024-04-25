using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Configuration
{
    public interface IFactoryPointService
    {
        Task<ResponseMessage> Add(FactoryPointPostDto factoryPointPost);
        Task<ResponseMessage> Update(FactoryPointGetDto factoryPointGet);
        Task<List<FactoryPointGetDto>> GetAll();
    }
}
