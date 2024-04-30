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
    public interface IDepreciationCostService
    {
        Task<ResponseMessage> Add(DepreciationCostPostDto depreciationCostPost);
        Task<ResponseMessage> Update(DepreciationCostGetDto depreciationCostGet);
        Task<List<DepreciationCostGetDto>> GetAll(RequestParameter requestParameter);
    }
}
