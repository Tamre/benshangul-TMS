using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public record PlateStockDto
    {
        [Required]
        public int PlateTypeId { get; set; }
        [Required]
        public int RegionId { get; set; }
        public int FrontPlateSizeId { get; set; }
        public int? BackPlateSizeId { get; set; }
        public string PlateDigit { get; set; }
        public string IssuanceType { get; set; }
        public string CreatedById { get; set; } = null!;
        public string? AToZ { get; set; }
    }

    public record PlateStockPostDto : PlateStockDto
    {
        public int FromPlateNo { get; set; }
        public int ToPlateNo { get; set; }
        

    }

    public record PlateStockGetDto : PlateStockDto
    {
        public Guid Id { get; set; }
        [Required, StringLength(ValidationClasses.SerialNumberLength)]
        public string PlateNo { get; set; } = null!;
        public bool IsActive { get; set; }

    }

    public record TransferToZoneDto
    {
        public List<Guid> PlateStockIds { get; set; }
        public int? ToZoneId { get; set; }
    }

    public record DeletePlateStockDto
    {
        public List<Guid> PlateStockIds { get; set; }
    }

}
