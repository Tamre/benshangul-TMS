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
    public  class BanBody: SettingIdModel
    {
        [StringLength(ValidationClasses.MaxNameLength)]
        [Required]
        public string Name { get; set; } = null!;
        [StringLength(ValidationClasses.MaxLocalNameLength)]
        [Required]
        public string LocalName { get; set; } = null!;
     
        [Required]
        public BanBodyCategory BanBodyCategory { get; set; }

    }
}
