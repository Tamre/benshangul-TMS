using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentInfrustructure.Model.MachineConfigeration
{
    public class MachineConfiguration : ActionIdModel
    {
        public string Name { get; set; }
        public  MachineModel model { get; set; }

        public string ApiEndpoint { get; set; }
        public string SqlConnectionString { get; set; }
        public int ScheduleIntervalMinutes { get; set; }
        public string Remark { get; set; }
        public string ServiceZoneId { get; set; }


    }
}
