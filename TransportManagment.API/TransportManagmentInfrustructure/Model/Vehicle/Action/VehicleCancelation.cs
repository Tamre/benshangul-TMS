using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class VehicleCancelation: ActionIdModel
    {
        [Required]
        public Guid VehicleId { get; set; }
        public virtual VehicleList Vehicle { get; set; } = null!;
        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        public string? Reason { get; set; } = null!;
        [Required, StringLength(ValidationClasses.SerialNumberLength)]
        public string ClearanceLetterNo { get; set; } = null!;
        public DateTime CleranceDate { get; set; }
        public bool IsReverted { get; set; } = false!;

        [StringLength(ValidationClasses.UserId)]
        public string? RevertedById { get; set; }
        public virtual ApplicationUser RevertedBy { get; set; } = null!;


    }
}
