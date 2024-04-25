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
    public record InitialPricePostDto
    {
        [StringLength(ValidationClasses.MaxNameLength)]
        [Required]
        public string Name { get; set; } = null!;

        [StringLength(ValidationClasses.MaxLocalNameLength)]
        [Required]
        public string LocalName { get; set; } = null!;

        [Required]
        public double Price { get; set; }

        public string CreatedById { get; set; } = null!;
    }

    public record InitialPriceGetDto : InitialPricePostDto
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }  
    }

}
