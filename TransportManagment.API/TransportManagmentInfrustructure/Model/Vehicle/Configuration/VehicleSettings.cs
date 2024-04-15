using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Configuration
{
    public class VehicleSettings: SettingIdModel
    {
        public VehicleSettingType VehicleSettingType { get; set; }
        [Required]
        public int Value { get; set; }
    }
}
