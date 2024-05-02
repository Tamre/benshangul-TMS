using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Configuration
{
    public interface IValuationReasonService
    {
        Task<ResponseMessage> Add(ValuationReasonPostDto dto);
        Task<ResponseMessage> Update(ValuationReasonGetDto dto);
        Task<List<ValuationReasonGetDto>> GetAll ();
    }
}
