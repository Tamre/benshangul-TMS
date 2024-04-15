using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Configuration
{
    public class VehicleType : SettingIdModel
    {
        [Required]
        public int VehicleCategoryId { get; set; }
        public virtual VehicleLookups VehicleCategory { get; set; } = null!;

        [StringLength(10)]
        [Required]
        public string Name { get; set; } = null!;
        [StringLength(10)]
        [Required]
        public string AmharicName { get; set; } = null!;
    }
}
