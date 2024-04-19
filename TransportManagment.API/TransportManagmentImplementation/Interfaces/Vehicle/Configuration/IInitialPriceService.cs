using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Configuration
{
    public interface IInitialPriceService
    {
        Task<ResponseMessage> Add(InitialPricePostDto initialPricePost);
        Task<ResponseMessage> Update(InitialPriceGetDto initialPriceGet);
        Task<List<InitialPriceGetDto>> GetAll();
    }
}
