using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Common
{
    public interface IDeviceListService
    {
        public Task<ResponseMessage> Add(DeviceListPostDto DeviceListPost);
        public Task<ResponseMessage> Update(DeviceListGetDto DeviceListGet);
        public Task<List<DeviceListGetDto>> GetAll(RequestParameter requestParameter);
    }
}
