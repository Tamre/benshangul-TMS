using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IOwnerManagmentService
    {
        public Task<List<VehicleOwnerListGetDto>> GetOwnerByVechicleId(Guid ownerId);
        public Task<ResponseMessage> CreateOwner(OwnerListPostDto ownerListPostDto);
        public Task<ResponseMessage> AssignOwner(VehicleOwnerDto vehicleOwnerDto);

        public Task<PagedList<OwnerListGetDto>> GetAllOwners(FilterDetail filterData);

        Task<ResponseMessage> UpdateOwner(OwnerListGetDto ownerListGetDto);
    }
}
