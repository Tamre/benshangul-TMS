using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentInfrustructure.Model.Common;
using System.ComponentModel.DataAnnotations;
using TransportManagmentInfrustructure.Data;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class AIS: ActionIdModel
    {
        [Required] 
        public Guid VehicleId { get; set; }
        public virtual VehicleList Vehicle { get; set; } = null!;
        [Required]
        public Guid StockId { get; set; }
        public virtual AisStock Stock { get; set; } = null!;
       
        public bool IsPrinted { get; set; }
        public DateTime? PrintedDate { get; set; }
        [Required]
        [StringLength(ValidationClasses.CodeLength)]
        public string AISYear { get; set; } = null!;
        [Required]
        [StringLength(ValidationClasses.CodeLength)]
        public string RegionCode { get; set; } = null!;
        [Required]
        public int GivenZoneId { get; set; }
        public virtual ZoneList GivenZone { get; set; } = null!;
        [Required]
        public IssueReason IssueReason { get; set; }
        [Required]
        public IssueReason PreviousReason { get; set; }
    }
}
