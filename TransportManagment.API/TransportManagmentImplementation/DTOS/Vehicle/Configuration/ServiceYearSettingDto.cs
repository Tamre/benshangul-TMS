using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.DTOS.Vehicle.Configuration
{
    // DTOs
    public record ServiceYearSettingPostDto
    {
        [Required]
        public int FromYear { get; set; }

        [Required]
        public int ToYear { get; set; }

        [Required]
        public double YearValue { get; set; }

        public string CreatedById { get; set; } = null!;
    }

    public record ServiceYearSettingGetDto : ServiceYearSettingPostDto
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }
    }

}
