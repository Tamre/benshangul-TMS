using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.DTOS.Vehicle.Configuration
{
    // DTOs
    public record VehicleSettingsPostDto
    {
        [Required]
        public string VehicleSettingType { get; set; } = null!;

        [Required]
        public int Value { get; set; }

        public string CreatedById { get; set; } = null!;
    }

    public record VehicleSettingsGetDto : VehicleSettingsPostDto
    {
        public int Id { get; set; }

        public bool IsActive { get;set; }
    }

}
