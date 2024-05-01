using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public record ORCStockDto
    {
        [Required]
        public int StockTypeId { get; set; }
        [Required]
        public int RegionId { get; set; }
        public int? ToZoneId { get; set; }
        public string CreatedById { get; set; } = null!;
    }
    public record ORCStockPostDto : ORCStockDto
    {
        public int FromORCNo { get; set; } 
        public int ToORCNo { get; set; } 


    }

    public record ORCStockGetDto : ORCStockDto
    {
        public Guid Id { get; set; }
        public string ORCNo { get; set; } = null!;
        public bool IsActive { get; set; }

    }

    public record TransferORCToZoneDto
    {
        public List<Guid> ORCStockIds { get; set; }
        public int? ToZoneId { get; set; }
    }
}
