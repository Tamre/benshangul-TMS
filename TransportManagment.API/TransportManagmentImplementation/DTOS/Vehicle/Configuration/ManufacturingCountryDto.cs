using System.ComponentModel.DataAnnotations;
using TransportManagmentInfrustructure.Data;

namespace TransportManagmentAPI.Controllers.Vehicle.Configuration
{
    // DTOs
    public record ManufacturingCountryPostDto
    {
        [StringLength(ValidationClasses.MaxNameLength)]
        [Required]
        public string Name { get; set; } = null!;

        [StringLength(ValidationClasses.MaxLocalNameLength)]
        [Required]
        public string LocalName { get; set; } = null!;

        [Required]
        public double Value { get; set; }

        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        [Required]
        public string ListOfCountries { get; set; } = null!;

        public string CreatedById { get; set; } = null!;
    }

    public record ManufacturingCountryGetDto : ManufacturingCountryPostDto
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }
    }

}
