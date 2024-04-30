using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IPlateStockService
    {
        Task<ResponseMessage> Add(PlateStockPostDto PlateStockPost);
        Task<PagedList<PlateStockGetDto>> GetAll(FilterDetail filterData);
        Task<ResponseMessage> TransferToZone(TransferToZoneDto TransferToZone);


    }
}
