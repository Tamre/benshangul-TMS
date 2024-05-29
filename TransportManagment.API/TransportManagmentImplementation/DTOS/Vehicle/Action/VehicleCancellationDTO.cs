using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Vehicle.Action;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public class VehicleCancellationDTO
    {

        public Guid Id { get; set; }
        [Required]
        public Guid VehicleId { get; set; }
       
        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        public string? Reason { get; set; } = null!;
        [Required, StringLength(ValidationClasses.SerialNumberLength)]
        public string ClearanceLetterNo { get; set; } = null!;
        public DateTime CleranceDate { get; set; }
        public bool IsReverted { get; set; } = false!;

        [StringLength(ValidationClasses.UserId)]
        public string? RevertedById { get; set; }
       // public virtual ApplicationUser RevertedBy { get; set; } = null!;
        public string CreatedById { get; set; } = null!;


    }
}
