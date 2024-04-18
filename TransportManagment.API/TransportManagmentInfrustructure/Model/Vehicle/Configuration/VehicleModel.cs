using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Configuration
{
    public class VehicleModel: SettingIdModel
    {
        [StringLength(ValidationClasses.MaxNameLength)]
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public double EngineCapacity { get; set; }
        [Required]
        public double NoOfCylinder { get; set; }
        public HorsePowerMeasure HorsePowerMeasure { get; set; }
        [Required]
        public int MarkId { get; set; }
        public virtual VehicleLookups Mark { get; set; } = null!;
    }
}
