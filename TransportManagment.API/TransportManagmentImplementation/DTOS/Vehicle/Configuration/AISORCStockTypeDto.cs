using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.DTOS.Vehicle.Configuration
{
    public record AISORCStockTypePostDto
    {

        public string Name { get; set; } = null!;
        [StringLength(10)]
        [Required]
        public string AmharicName { get; set; } = null!;
        [StringLength(3)]
        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public AISORCStockCategory Category { get; set; }
        public string CreatedById { get; set; } = null!;

    }

    public record AISORCStockTypeGetDto : AISORCStockTypePostDto
    {
        public int Id { get; set; }

    }
}
