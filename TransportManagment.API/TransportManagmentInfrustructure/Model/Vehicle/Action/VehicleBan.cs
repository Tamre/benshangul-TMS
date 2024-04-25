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
    public class VehicleBan: ActionIdModel
    {
        [Required]
        public Guid VehicleId { get; set; }
        public virtual VehicleList Vehicle { get; set; } = null!;
        [Required]
        public int BanCaseId { get; set; }
        public virtual VehicleLookups BanCase { get; set; } = null!;
        [Required]
        public int BanBodyId { get; set; }
        public virtual BanBody BanBody { get; set; } = null!;
        public double? MoneyAmmount { get; set; }
        public DateTime BanDate { get; set; }
        [Required, StringLength(ValidationClasses.LetterLength)]
        public string BanLetterNo { get; set; } = null!;
        public bool IsLifted { get; set; }
        [StringLength(ValidationClasses.UserId)]
        public string? LiftedById { get; set; } = null!;
        public virtual ApplicationUser LiftedBy { get; set; } = null!;
        public  DateTime? LetterLiftDate { get; set; }
        [StringLength(ValidationClasses.LetterLength)]
        public string? LetterLiftNo { get; set; }

        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        public string? Enclosure { get; set; }
    }
}
