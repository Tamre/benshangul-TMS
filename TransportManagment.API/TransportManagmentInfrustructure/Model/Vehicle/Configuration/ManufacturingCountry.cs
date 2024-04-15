using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Configuration
{
    public class ManufacturingCountry: SettingIdModel
    {
        [StringLength(10)]
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public double Value { get; set; }

        [StringLength(1000)]
        [Required]
        public string ListOfCountries { get; set; } = null!;
    }
}
