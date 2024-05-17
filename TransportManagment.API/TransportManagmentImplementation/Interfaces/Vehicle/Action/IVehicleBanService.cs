using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IVehicleBanService
    {
        public Task<ResponseMessage> BanVehicle(VehicleBanPostDto vehicleBanPost);

        public Task<List<VehicleBanGetDto>> GetBanHistories(Guid VehicleId);

        public Task<ResponseMessage> LiftBanVehicle(VehicleLiftBanDto liftBanPost);
    }
}
