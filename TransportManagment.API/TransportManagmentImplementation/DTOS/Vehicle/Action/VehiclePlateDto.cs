using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.CommonEnum;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Action;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public record VehiclePlatePostDto
    {
        [Required]
        public Guid VehicleId { get; set; }
        [Required]
        public Guid PlateStockId { get; set; }
        [Required]
        public int GivenZoneId { get; set; }

        public string IssueReason { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

    }

    public record VehiclePlateGetDto : VehiclePlatePostDto
    {

        public Guid Id { get; set; }

        public string? PlateNo { get; set; }

        public string? PlateType { get; set; }

        public string? Region { get; set; }

        public string? GivenZone { get; set; }

        public string? IssueReason { get; set; }

    }

}
