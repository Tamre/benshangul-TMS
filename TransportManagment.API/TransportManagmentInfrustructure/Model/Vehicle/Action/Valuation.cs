using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class Valuation: ActionIdModel
    {
        [Required]
        public Guid VehicleId { get; set; }
        public virtual VehicleList VehicleList { get; set; } = null!;

        [Required]
        public int DepreciationCostId { get; set; }
        public virtual DepreciationCost DepreciationCost { get; set; } = null!;
        [Required]
        public double DepreciationCostValue { get; set; }
        [Required]
        public int FactoryPointId { get; set; }
        public virtual FactoryPoint FactoryPoint { get; set; } = null!;
        [Required]
        public double FactoryPointValue { get; set; }
        [Required]
        public int InitialPriceId { get; set; }
        public virtual InitialPrice InitialPrice { get; set; } = null!;
        [Required]
        public double InitialPriceValue { get; set; }
        [Required]
        public int SalvageValueID { get; set; }
        public virtual SalvageValue SalvageValue { get; set; } = null!;
        [Required]
        public double SalvageValuePrice { get; set; }
        [Required]
        public int ServiceYearId { get; set; }
        public virtual ServiceYearSetting ServiceYear { get; set; } = null!;
        [Required]
        public double ServiceYearValue { get; set; }
        [Required]
        public double VehicleTypeValue { get; set; }

        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        public string? Remark { get; set;} = null!;
        [Required]
        public int ValuationReasonId { get; set; }
        public virtual ValuationReason ValuationReason { get; set; } = null!;
        [Required]
        public double SellersAgreement { get; set; }
    }
}
