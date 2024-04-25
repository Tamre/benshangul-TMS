using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class ORCStock: ActionIdModel
    {
        [Required]
        [StringLength(ValidationClasses.SerialNumberLength)]
        public string ORCNo { get; set; } = null!;
        [Required]
        public int StockTypeId { get; set; }
        public virtual AISORCStockType StockType { get; set; } = null!;
        [Required]
        public int RegionId { get; set; }
        public virtual Common.Region Region { get; set; } = null!;
        public int? ToZoneId { get; set; }
        public virtual ZoneList ToZone { get; set; } = null!;
        public ORC ORC { get; set; } = null!;
    }
}
