using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Common
{
    public interface ICommonCodeService
    {
        public Task<ResponseMessage> Add(CommonCodePostDto CommonCodePost);
        public Task<ResponseMessage> Update(CommonCodeGetDto CommonCodeGet);
        public Task<List<CommonCodeGetDto>> GetAll();
    }
}
