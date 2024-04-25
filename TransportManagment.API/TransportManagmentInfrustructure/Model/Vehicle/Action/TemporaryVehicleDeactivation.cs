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
    public class TemporaryVehicleDeactivation: ActionIdModel
    {
        [Required]
        public Guid VehicleId { get; set; }
        public virtual VehicleList Vehicle { get; set; } = null!;
        [Required, StringLength(ValidationClasses.LetterLength)]
        public string LetterNumber { get; set; } = null!;
        public DateTime LetterDate { get; set; }
        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        public string? Reason { get; set; }
        public bool IsActivated { get; set; }
        public DateTime? ActivatedDate { get; set; }
        [StringLength(ValidationClasses.UserId)]
        public string? ActivatedById { get; set; }
        public virtual ApplicationUser ActivatedBy { get; set; } = null!;
    }
}
