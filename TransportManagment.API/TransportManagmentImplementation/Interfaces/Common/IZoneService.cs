using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Common
{
    public interface IZoneService
    {
        public Task<ResponseMessage> Add(ZonePostDto ZonePost);
        public Task<ResponseMessage> Update(ZoneGetDto ZoneGet);
        public Task<List<ZoneGetDto>> GetAll(RequestParameter requestParameter);
    }
}
