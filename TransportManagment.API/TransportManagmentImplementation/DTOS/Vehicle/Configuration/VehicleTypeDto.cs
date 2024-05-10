using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;

namespace TransportManagmentImplementation.DTOS.Vehicle.Configuration
{
    // DTOs
    public record VehicleTypePostDto
    {
        [Required]
        public int VehicleCategoryId { get; set; }

        [StringLength(ValidationClasses.MaxNameLength)]
        [Required]
        public string Name { get; set; } = null!;

        [StringLength(ValidationClasses.MaxLocalNameLength)]
        [Required]
        public string LocalName { get; set; } = null!;

        public string CreatedById { get; set; } = null!;
    }

    public record VehicleTypeGetDto : VehicleTypePostDto
    {
        public int Id { get; set; }

        public string ? CategoryName { get; set; }
        public bool IsActive { get; set; }
    }

}
