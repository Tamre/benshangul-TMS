using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class VehicleReplacement: ActionIdModel
    {
        [Required]
        public Guid VehicleId { get; set; }
        public virtual VehicleList Vehicle { get; set; } = null!;
        [Required]
        public ReplacementType ReplacementType { get; set; }
        [Required]
        public ReplacementReason ReplacementReason { get; set; }
        [Required , StringLength(ValidationClasses.LetterLength)]
        public string LetterNo { get; set; } = null!;
        [StringLength(ValidationClasses.MaxNameLength)]
        public string? PoliceStation { get; set; }
        public DateTime LetterDate { get; set;}
        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        public string?  Remark { get; set; }
        [Required]
        public DataChangeStatus Status { get; set; }
        public string? CretedById { get; set; } = null!;
        [Required]
        [StringLength(ValidationClasses.UserId)]
        public string? ApprovedById { get; set; } = null!;
        public virtual ApplicationUser ApprovedBy { get; set; } = null!;
        public DateTime? ApprovedDate { get; set; } = DateTime.UtcNow;
    }
}
