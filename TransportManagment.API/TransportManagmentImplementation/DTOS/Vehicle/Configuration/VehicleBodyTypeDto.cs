using System.ComponentModel.DataAnnotations;
using TransportManagmentInfrustructure.Data;

namespace TransportManagmentAPI.Controllers.Vehicle.Configuration
{
    // DTOs
    public record VehicleBodyTypePostDto
    {
        [StringLength(ValidationClasses.MaxNameLength)]
        [Required]
        public string Name { get; set; } = null!;

        [StringLength(ValidationClasses.MaxLocalNameLength)]
        [Required]
        public string LocalName { get; set; } = null!;

        [Required]
        public int VehicleTypeId { get; set; }

        [Required]
        public double Value { get; set; }

        public string CreatedById { get; set; } = null!;
    }

    public record VehicleBodyTypeGetDto : VehicleBodyTypePostDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }

}
