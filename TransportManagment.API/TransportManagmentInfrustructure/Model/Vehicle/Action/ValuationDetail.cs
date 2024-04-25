using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class ValuationDetail: ActionIdModel
    {
        [Required] 
        public Guid ValuationId { get; set; }
        public virtual Valuation Valuation { get; set; } = null!;
        [Required]
        public Guid OwnerId { get; set; }
        public virtual OwnerList Owner { get; set; } = null!;
        public string? RepresentativeName { get; set;} = null!;
        public string? RepresentativeAddress { get; set; } = null!;
        public OwnershipType OwnershipType { get; set; }
    }
}
