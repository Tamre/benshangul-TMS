using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.DTOS.Vehicle.Configuration
{
    public record BanBodyPostDto
    {
        [StringLength(10)]
        [Required]
        public string Name { get; set; } = null!;
        [StringLength(20)]
        [Required]
        public string LocalName { get; set; } = null!;

        [Required]
        public string BanBodyCategory { get; set; } = null!;

        public string CreatedById { get; set; } = null!;
    }

    public record BanBodyGetDto : BanBodyPostDto
    {
        public int Id { get; set; }
    }
}
