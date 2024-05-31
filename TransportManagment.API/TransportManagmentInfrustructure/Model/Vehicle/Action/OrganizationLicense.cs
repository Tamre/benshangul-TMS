using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class OrganizationLicense : ActionIdModel
    {
        [StringLength(40)]
        public string OrganizationId { get; set; }

        [StringLength(40)]
        public string ServiceZoneId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime FromDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ToDate { get; set; }

        [StringLength(45)]
        public string StartDate { get; set; }

        [StringLength(45)]
        public string EndDate { get; set; }

        [StringLength(50)]
        public string CardSeries { get; set; }

        public OrganizationLicenseType LicenseType { get; set; }

        public string Remark { get; set; }

        public bool IsPrinted { get; set; }

        public OrganizationType Organization { get; set; }
      
        public int NoOfVehicles { get; set; }
   
        public OrganizationLicenseReason IssueReason { get; set; }

    }
}
