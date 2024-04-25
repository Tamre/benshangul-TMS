using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.DTOS.Vehicle.Configuration
{
    // DTOs
    public record FactoryPointPostDto
    {
        [Required]
        public int MarkId { get; set; }

        [Required]
        public double Value { get; set; }

        public string CreatedById { get; set; } = null!;
    }

    public record FactoryPointGetDto : FactoryPointPostDto
    {
        public int Id { get; set; }

        public string MarkName { get; set; }
        public bool IsActive { get; set; }
    }

}
