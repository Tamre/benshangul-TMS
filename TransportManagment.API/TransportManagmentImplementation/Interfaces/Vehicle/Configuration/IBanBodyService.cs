using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Configuration
{
    public interface IBanBodyService
    {

        public Task<ResponseMessage> Add(BanBodyPostDto BanBodyPost);
        public Task<ResponseMessage> Update(BanBodyGetDto BanBodyGet);
        public Task<List<BanBodyGetDto>> GetAll(RequestParameter requestParameter);
    }
}
