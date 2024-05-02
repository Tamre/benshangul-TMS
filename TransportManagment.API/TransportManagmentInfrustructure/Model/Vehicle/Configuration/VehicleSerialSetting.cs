using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Configuration
{
    public class VehicleSerialSetting: SettingIdModel
    {
        public VehicleSerialType VehicleSerialType { get; set; }
   

        [Required]
        public int Value { get; set; }
        [Required]
        public int Pad { get; set; }
        [Required]
        public int ZoneId { get; set; }
        public virtual ZoneList Zone { get; set; } = null!;
    }
}
