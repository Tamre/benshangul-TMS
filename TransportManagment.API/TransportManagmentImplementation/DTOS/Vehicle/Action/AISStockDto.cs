using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public record AISStockDto
    {
        [Required]
        public int StockTypeId { get; set; }
        [Required]
        public int RegionId { get; set; }
        public int? ToZoneId { get; set; }
        public string CreatedById { get; set; } = null!;
    }
    public record AISStockPostDto : AISStockDto
    {
        public int FromAISNo { get; set; } 
        public int ToAISNo { get; set; }

        
    }

    public record AISStockGetDto : AISStockDto
    {
        public Guid Id { get; set; }
        public string AISNo { get; set; } = null!;
        public bool IsActive { get; set; }
        
    }

    public record TransferAISToZoneDto
    {
        public List<Guid> AISStockIds { get; set; }
        public int? ToZoneId { get; set; }
    }
}
