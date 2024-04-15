using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Common
{
    public interface IWoredaService
    {
        public Task<ResponseMessage> Add(WoredaPostDto WoredaPost);
        public Task<ResponseMessage> Update(WoredaGetDto WoredaGet);
        public Task<List<WoredaGetDto>> GetAll();
    }
}
