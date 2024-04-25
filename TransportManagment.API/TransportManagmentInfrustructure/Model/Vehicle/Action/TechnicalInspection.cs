using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class TechnicalInspection: ActionIdModel
    {
        [Required]
        public Guid FieldInspectionId { get; set; }
        public virtual FieldInspection FieldInspection { get; set; } = null!;
        [Required]
        public int VehicleBodyTypeId { get; set; }
        public virtual VehicleBodyType VehicleBodyType { get; set; } = null!;
        [Required]
        public int ServiceTypeId { get; set; }
        public virtual ServiceType ServiceType { get; set; } = null!;
        public int? LoadMesurementId { get; set; }
        public virtual VehicleLookups LoadMesurement { get; set; } = null!;
        public int NoOfPeople { get; set; }
        public double? LoadValue { get; set; }
        [Required]
        public int ColorId { get; set; }
        public virtual VehicleLookups Color { get; set; } = null!;
        [StringLength(ValidationClasses.MaxNameLength)]
        public string? HydroCarbon { get; set; } = null!;
        [StringLength(ValidationClasses.MaxNameLength)]
        public string? CarbonMonoOxide { get; set; } = null!;

        public bool IsEngineReadable { get; set; }
        [StringLength(ValidationClasses.MaxLocalNameLength)]
        public string? PermissionLetterNo { get; set; } 
        public DateTime? PermissionDate { get; set; }
        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        public string? Remark { get; set;  }

    }
}
