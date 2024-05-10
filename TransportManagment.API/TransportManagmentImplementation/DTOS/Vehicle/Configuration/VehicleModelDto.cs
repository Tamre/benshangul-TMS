using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentInfrustructure.Data;

namespace TransportManagmentImplementation.DTOS.Vehicle.Configuration
{
    // DTOs
    public record VehicleModelPostDto
    {
        [StringLength(ValidationClasses.MaxNameLength)]
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public double EngineCapacity { get; set; }

        [Required]
        public double NoOfCylinder { get; set; }

        [Required]
        public string HorsePowerMeasure { get; set; } = null!;

        [Required]
        public int MarkId { get; set; }

        public string CreatedById { get; set; } = null!;
    }

    public record VehicleModelGetDto : VehicleModelPostDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public string? MarkName { get; set; }
    }

}
