using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Configuration
{
    public class ServiceType: SettingIdModel
    {
        [StringLength(10)]
        [Required]
        public string Name { get; set; } = null!;
        [StringLength(20)]
        [Required]
        public string AmharicName { get; set; } = null!;
        public ServiceModule ServiceModule { get; set; }
        [StringLength(1000)]
        [Required]
        public string ListOfPlates { get; set; } = null!;
        [StringLength(1000)]
        [Required]
        public string ListOfAIS { get; set; } = null!;

    }
}
