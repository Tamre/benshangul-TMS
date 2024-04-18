using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.DTOS.Vehicle.Configuration
{
    // DTOs
    public record PlateTypePostDto
    {
        [StringLength(10)]
        [Required]
        public string Name { get; set; } = null!;

        [StringLength(20)]
        [Required]
        public string AmharicName { get; set; } = null!;

        [StringLength(3)]
        [Required]
        public string Code { get; set; } = null!;

        [StringLength(500)]
        [Required]
        public string RegionList { get; set; } = null!;

        public string CreatedById { get; set; } = null!;
    }

    public record PlateTypeGetDto : PlateTypePostDto
    {
        public int Id { get; set; }
    }

}
