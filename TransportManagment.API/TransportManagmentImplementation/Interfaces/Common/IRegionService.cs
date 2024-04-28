using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Common
{
    public interface IRegionService
    {
        public Task<ResponseMessage> Add(RegionPostDto RegionPost);
        public Task<ResponseMessage> Update(RegionGetDto RegionGet);
        public Task<List<RegionGetDto>> GetAll(RequestParameter requestParameter);
    }
}
