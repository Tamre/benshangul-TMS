using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public class MachineConfigurationDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public MachineModel model { get; set; }

        public string ApiEndpoint { get; set; }
        public string SqlConnectionString { get; set; }
        public int ScheduleIntervalMinutes { get; set; }
        public string Remark { get; set; }
        public string ServiceZoneId { get; set; }
    }
}
