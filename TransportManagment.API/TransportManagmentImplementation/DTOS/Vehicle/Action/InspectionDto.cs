using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public record FieldInspectionPostDto
    {

        [Required]
        public Guid VehicleId { get; set; }

        [Required]
        public int GivenZoneId { get; set; }
        public Guid? ServiceChangeId { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }

        [StringLength(ValidationClasses.MaxLocalNameLength)]
        public string FrontTyreSize { get; set; } = null!;

        [StringLength(ValidationClasses.MaxLocalNameLength)]
        public string RearTyreSize { get; set; } = null!;
        public int NoOfRearAxel { get; set; }
        public int NoOfFrontAxel { get; set; }
        [StringLength(ValidationClasses.MaxNameLength)]
        public string AxelDriveType { get; set; } = null!;
        public int NumberOfTyre { get; set; }
        public double FrontAxelMAxLoad { get; set; }
        public double RearAxelMaxLoad { get; set; }
        public double GrossWeight { get; set; }
        public double TareWeight { get; set; }
        public int FrontPlateSizeId { get; set; }
        public int? BackPlateSizeId { get; set; }
        public string CreatedById { get; set; }

    }

    public record FieldInspectionGetDto : FieldInspectionPostDto
    {
        public string? GivenZoneName { get; set; }

        public Guid Id { get; set; }

        public string? FrontPlateSize { get; set; }

        public string? BackPlateSize { get; set; }
    }


    public record TechnicalInspectionPostDto
    {

        [Required]
        public Guid FieldInspectionId { get; set; }
     
        [Required]
        public int VehicleBodyTypeId { get; set; }
       
        [Required]
        public int ServiceTypeId { get; set; }
     
        public int? LoadMesurementId { get; set; }      
        public int NoOfPeople { get; set; }

        public double? LoadValue { get; set; }
        [Required]
        public int ColorId { get; set; }

        public string? HydroCarbon { get; set; } = null!;
        [StringLength(ValidationClasses.MaxNameLength)]
        public string? CarbonMonoOxide { get; set; } = null!;

        public bool IsEngineReadable { get; set; }
        [StringLength(ValidationClasses.MaxLocalNameLength)]
        public string? PermissionLetterNo { get; set; }

        public DateTime? PermissionDate { get; set; }
        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        public string? Remark { get; set; }

        public string CreatedById { get; set; }

    }
    public record TechnicalInspectionGetDto :TechnicalInspectionPostDto
    {
        public Guid Id { get; set; }

        public string? VehicleBodyTypeName { get; set; }
        public string ? ServiceType { get; set; }
        public string ? LoadMeasurment { get; set; }
        public string ? Color { get; set; }
    }


    public record InspectionDto
    {

        public List<TechnicalInspectionGetDto> TechnicalInspection { get; set; } = null!;

        public List<FieldInspectionGetDto> FieldInspection { get; set; } = null!;

       
    }

}
