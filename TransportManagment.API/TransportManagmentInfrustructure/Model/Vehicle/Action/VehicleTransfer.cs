using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class VehicleTransfer: ActionIdModel
    {
        [Required]
        public Guid VehicleId { get; set; }
        public virtual VehicleList Vehicle { get; set; } = null!;
        [Required]
        public int FromZoneId { get; set; }
        public virtual ZoneList FromZone { get; set; } = null!;
        [Required]
        public int ToZoneId { get; set; }
        public virtual ZoneList ToZone { get; set; } = null!;
        [Required]
        public DateTime TransferedDate { get; set; }
        [Required, StringLength(ValidationClasses.LetterLength)]
        public string LetterNo { get; set; } = null!;
        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        public string? Description { get; set; } = null!;
        [Required, StringLength(ValidationClasses.SerialNumberLength)]
        public string TransferNumber { get; set; } = null!;
        [Required]
        public TransferStatus TransferStatus { get; set; }
        [StringLength(ValidationClasses.SerialNumberLength)]
        public string? PreviousPlate { get; set; }
        public bool IsVehicleRejected { get; set; }
        public bool ChangePlate { get; set;}
        public bool ChangeOwner { get; set; }
        public bool ChangeServiceType { get; set; }

    }
}
