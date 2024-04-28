using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public record  VehicleListPostDto
    {
       
     
       
        [Required]
        public int ModelId { get; set; }

        [Required]
        public string TaxStatus { get; set; } = null!;


        [StringLength(ValidationClasses.MaxNameLength)]
        public string? OfficeCode { get; set; } 
        [Required, StringLength(ValidationClasses.MaxLocalNameLength)]
        public string DeclarationNo { get; set; } = null!;
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
       
        [Required]
        public int ChassisMadeId { get; set; }

        [Required]
        public int ManufacturingYear { get; set; }
        [Required]
        public int HorsePower { get; set; }
        [Required]
        public string HorsePowerMeasure { get; set; }
        [Required]
        public int NoCylinder { get; set; }
        [Required]
        public double EngineCapacity { get; set; }
        [Required]
        public string? LastActionTaken { get; set; }
        [Required]
        public string? TypeOfVehicle { get; set; }
        [Required]
        public string? VehicleCurrentStatus { get; set; }
        [Required]
        public string TransferStatus { get; set; }
        [Required]
        public int ServiceZoneId { get; set; }

        public string CreatedById { get; set; }
        

    }

    public record IVehicleListGetDto : VehicleListPostDto
    {

    }
}
