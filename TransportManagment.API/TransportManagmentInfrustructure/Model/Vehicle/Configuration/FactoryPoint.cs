using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Configuration
{
    public class FactoryPoint: SettingIdModel
    {
        [Required]
        public int MarkId { get; set; }
        public virtual VehicleLookups Mark { get; set; } = null!;
        [Required]
        public double Value { get; set; }
    }
}
