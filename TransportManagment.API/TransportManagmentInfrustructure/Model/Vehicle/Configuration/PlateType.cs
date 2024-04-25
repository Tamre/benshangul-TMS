using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Configuration
{
    public class PlateType : SettingIdModel
    {
        [StringLength(ValidationClasses.MaxNameLength)]
        [Required]
        public string Name { get; set; } = null!;
        [StringLength(ValidationClasses.MaxLocalNameLength)]
        [Required]
        public string LocalName { get; set; } = null!;
        [StringLength(ValidationClasses.CodeLength)]
        [Required]
        public string Code { get; set; } = null!;
        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        [Required]
        public string RegionList { get; set; } = null!;

        public int? MinorId { get; set; }
        public virtual VehicleLookups Minor { get; set; } = null!;

        public int? MajorId { get; set; }
        public virtual VehicleLookups Major { get; set; } = null!;

    }
}
