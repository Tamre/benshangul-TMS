using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.DTOS.Vehicle.Configuration
{
    // DTOs
    public record ValuationReasonPostDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string LocalName { get; set; } = null!;
        public bool IsValuationPayment { get; set; }
        public bool IsOwnershipPayment { get; set; }

        public string CreatedById { get; set; } = null!;
    }

    public record ValuationReasonGetDto : ValuationReasonPostDto
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }
    }

}
