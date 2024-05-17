using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Action;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public record ORCPostDto
    {

        [Required]
        public Guid VehicleId { get; set; }

        [Required]
        public Guid StockId { get; set; }

        [Required]
        public int GivenZoneId { get; set; }

        public string IssueReason { get; set; } = null!;
        public string CreatedById { get; set; } = null!;
    }

    public record ORCGetDto : ORCPostDto
    {
        public Guid Id { get; set; }
        public string VehicleRegistrationNo { get; set; } = null!;
        public string AISNo { get; set; } = null!;
        public string GivenZone { get; set; } = null!;
        public string PreviousReason { get; set; } = null!;


    }
}
