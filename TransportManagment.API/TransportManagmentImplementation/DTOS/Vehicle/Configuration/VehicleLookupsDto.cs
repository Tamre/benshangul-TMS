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
    public record VehicleLookupsPostDto
    {
        [Required]
        public string VehicleLookupType { get; set; } = null!;

        [StringLength(ValidationClasses.MaxNameLength)]
        [Required]
        public string Name { get; set; } = null!;

        [StringLength(ValidationClasses.MaxLocalNameLength)]
        [Required]
        public string LocalName { get; set; } = null!;

        public string CreatedById { get; set; } = null!;
    }

    public record VehicleLookupsGetDto : VehicleLookupsPostDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }

}
