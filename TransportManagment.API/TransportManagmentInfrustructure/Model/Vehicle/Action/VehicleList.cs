using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class VehicleList: ActionIdModel
    {
        [Required]
        public RegistrationType RegistrationType { get; set; }
        [Required, StringLength(ValidationClasses.SerialNumberLength)]
        public string RegistrationNo { get; set; } = null!;
        [Required]
        public int ModelId { get; set; }
        public virtual VehicleModel Model { get; set; } = null!;
        [Required]
        public VehicleApprovalStatus ApprovalStatus { get; set; }
        [Required]
        public TaxStatus TaxStatus { get; set; }
        public bool IsVehicleComplete { get; set; }
        [StringLength(ValidationClasses.UserId)]
        public string? ApprovedById { get; set; } = null!;
        public virtual ApplicationUser ApprovedBy { get; set; } = null!;

        [StringLength(ValidationClasses.MaxNameLength)]
        public string? OfficeCode { get; set; } = null!;
        [Required, StringLength(ValidationClasses.MaxLocalNameLength)]
        public string DeclarationNo { get; set; }  = null!;
        public DateTime DeclarationDate { get; set; }
        [StringLength(ValidationClasses.MaxLocalNameLength)]
        public string? BillOfLoading { get; set; } = null!;
        [StringLength(ValidationClasses.MaxLocalNameLength)]
        public string? RemovalNumber { get; set; } = null!;
        public DateTime? InvoiceDate { get; set; }
        public double? InvoicePrice { get; set; }
        [Required, StringLength(ValidationClasses.ChassisNo)]
        public string ChassisNo { get; set; } = null!;
        [StringLength(ValidationClasses.MaxNameLength)]
        public string? EngineNumber { get; set; }
        [Required]
        public int AssembledCountryId { get; set; }
        public virtual Country AssembledCountry { get; set; } = null!;
        [Required]
        public int ChassisMadeId { get; set; }
        public virtual Country ChassisMade { get; set; } = null!;
        [Required]
        public int ManufacturingYear { get; set; }
        [Required]
        public int HorsePower { get; set; }
        [Required]
        public HorsePowerMeasure HorsePowerMeasure { get; set; }
        [Required]
        public int NoCylinder { get; set; }
        [Required]
        public double EngineCapacity { get; set; }
        [Required]
        public LastActionTaken LastActionTaken { get; set; }
        [Required]
        public TypeOfVehicle TypeOfVehicle { get; set; }
        [Required]
        public VehicleCurrentStatus VehicleCurrentStatus { get; set; }
        [Required]
        public TransferStatus TransferStatus { get; set; }
        [Required]
        public int ServiceZoneId { get; set; }
        public virtual ZoneList ServiceZone { get; set; } = null!;
    }
}
