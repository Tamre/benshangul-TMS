using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentInfrustructure.Model.Vehicle.Action;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IVehicleBan
    {
        Task<VehicleBan> CreateVehicleBanAsync(VehicleBanPostDto vehicleBanDto);
        Task<VehicleBan> GetVehicleBanByIdAsync(Guid id);
        Task<IEnumerable<VehicleBanGetDto>> GetAllVehicleBansAsync();
        Task<VehicleBan> LiftVehicleBanAsync(VehicleLiftBanDto liftBanDto);
    }
}
