using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Configuration
{
    public class ServiceYearSetting: SettingIdModel
    {
        [Required]
        public int FromYear { get; set; }
        [Required]
        public int ToYear { get; set;}
        [Required]
        public double YearValue { get; set; }
       
    }
}
