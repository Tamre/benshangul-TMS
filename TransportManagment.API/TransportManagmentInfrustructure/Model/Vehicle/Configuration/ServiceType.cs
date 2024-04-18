using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Configuration
{
    public class ServiceType: SettingIdModel
    {
        [StringLength(ValidationClasses.MaxNameLength)]
        [Required]
        public string Name { get; set; } = null!;
        [StringLength(ValidationClasses.MaxLocalNameLength)]
        [Required]
        public string LocalName { get; set; } = null!;
        public ServiceModule ServiceModule { get; set; }
        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        [Required]
        public string ListOfPlates { get; set; } = null!;
        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        [Required]
        public string ListOfAIS { get; set; } = null!;

    }
}
