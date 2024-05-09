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
using Microsoft.AspNetCore.Http;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public record  VehicleListPostDto
    {
        [Required]
        public int ModelId { get; set; }
        [Required]
        public TaxStatus TaxStatus { get; set; }
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
        
        public HorsePowerMeasure HorsePowerMeasure { get; set; }
        [Required]
        public int NoCylinder { get; set; }
        [Required]
        public double EngineCapacity { get; set; }
        [Required]
        public TypeOfVehicle TypeOfVehicle { get; set; }
        [Required]
        public VehicleCurrentStatus VehicleCurrentStatus { get; set; }
        [Required]
        public TransferStatus TransferStatus { get; set; }
        public string CreatedById { get; set; } = null!;
        public int ServiceZoneId { get; set; }
        public int? FromZoneId { get; set; }
        public int? FromRegionId { get; set; }
        public string? PreviousPlate { get; set; }
        public string? LetterNo { get; set; }
        public string? LetterDate { get; set; }
    }

  
    public record UpdateVehicleDto: VehicleListPostDto
    {
        [Required]
        public Guid Id { get; set; }
        public bool ISApproved { get; set; }
        public RegistrationType RegistrationType { get; set; }
    }

    public record VehicleDetailDto
    {
        public Guid Id { get; set; }
        public string Model { get; set; } = null!;
        public int ModelId { get; set; }
        public string TaxStatus { get; set; } = null!;
        public string? OfficeCode { get; set; }
        public string DeclarationNo { get; set; } = null!;
        public DateTime DeclarationDate { get; set; }
        public string? BillOfLoading { get; set; } = null!;
        public string? RemovalNumber { get; set; } = null!;
        public DateTime? InvoiceDate { get; set; }
        public double? InvoicePrice { get; set; }
        public string ChassisNo { get; set; } = null!;
        public string? EngineNumber { get; set; }
        public int AssembledCountryId { get; set; }
        public string AssembledCountry { get; set; } = null!;
        public int ChassisMadeId { get; set; }
        public string ChassisMadeCountry { get; set; } = null!;
        public int ManufacturingYear { get; set; }
        public int HorsePower { get; set; }

        public string ApprovalStatus { get; set; }= null!;

        public string HorsePowerMeasure { get; set; } = null!;
        public int NoCylinder { get; set; }
        public double EngineCapacity { get; set; }
        public string TypeOfVehicle { get; set; } = null!;
        public string VehicleCurrentStatus { get; set; } = null!;
        public string TransferStatus { get; set; } = null!;

    }


    public record VehicleGetParameterDto
    {
        public VehicleFileteParameter VehicleFileteParameter { get; set; }
        public string Value { get; set; } = null!;
        public bool RegionalUser { get; set; } 
        public RegistrationType? RegistrationType { get; set; }

    }


    public record AddVehicleDocumetDto
    {
        public Guid VehicleId { get; set; }
        public string CreatedById { get; set; } = null!;
        public IFormFile Document { get; set; } = null!;
        public int DocumentTypeId { get; set; }

    }


    public record VehicleStatusActionDto
    {
        public Guid VechileId { get; set; }

        public string VehicleAction { get; set; } = null!;

        public string CreatedById { get; set; } = null!;
    }

    
}
