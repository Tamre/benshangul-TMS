using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IAISStockService
    {
        Task<ResponseMessage> Add(AISStockPostDto AISStockPostDto);
        Task<PagedList<AISStockGetDto>> GetAll(FilterDetail filterData);
        Task<ResponseMessage> TransferToZone(TransferAISToZoneDto TransferToZone);

    }
}
