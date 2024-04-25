using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class ORC: ActionIdModel
    {
        [Required]
        public Guid VehicleId { get; set; }
        public virtual VehicleList Vehicle { get; set; } = null!;
        [Required] 
        public Guid StockId { get; set; }
        public virtual ORCStock Stock { get; set; } = null!;
        public bool IsPrinted { get; set; }
        public DateTime? PrintedDate { get; set; }
        [Required]
        public int GivenZoneId { get; set; }
        public virtual ZoneList GivenZone { get; set; } = null!;
        public IssueReason IssueReason { get; set; }
        public IssueReason PreviousReason { get; set; }
    }
}
