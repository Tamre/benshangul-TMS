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
    public interface IAISORCStockTypeService
    {
        public Task<ResponseMessage> Add(AISORCStockTypePostDto AISORCStockTypePost);
        public Task<ResponseMessage> Update(AISORCStockTypeGetDto AISORCStockTypeGet);
        public Task<List<AISORCStockTypeGetDto>> GetAll(RequestParameter requestParameter);

    }
}
