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
    public record VehicleSerialSettingPostDto
    {
        [Required]
        public string VehicleSerialType { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public int Pad { get; set; }

        [Required]
        public int ZoneId { get; set; }

        public string CreatedById { get; set; } = null!;
    }

    public record VehicleSerialSettingGetDto : VehicleSerialSettingPostDto
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }
    }

}
