﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IORCStockService
    {
        Task<ResponseMessage> Add(ORCStockPostDto ORCStockPost);
        Task<PagedList<ORCStockGetDto>> GetAll(FilterDetail filterData);
        Task<ResponseMessage> TransferToZone(TransferORCToZoneDto TransferToZone);


    }
}
