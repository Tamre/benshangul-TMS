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
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
      public class DataChange : ActionIdModel
      {

        public DataChange()
        {
            DataChangeDetails = new HashSet<DataChangeDetail>();
        }

        //  public bool? IsSensitive { get; set; } // Flag to indicate update includes sensitive data
        [Required]
        public string TableName { get; set; } = null!;
        [Required]
        public Guid VehicleId { get; set; }
        [Required]      
        public string? Reason { get; set; }
        [Required]
        public DataChangeStatus Status { get; set; }
        [Required]   
        [StringLength(ValidationClasses.UserId)]
        public string? ApprovedById { get; set; } = null!;
        public virtual ApplicationUser ApprovedBy { get; set; } = null!;
        public DateTime? ApprovedDate { get; set; }= DateTime.UtcNow;
        public string? Comments { get; set; }
        [Required]
        [InverseProperty(nameof(DataChangeDetail.DataChange))]
        public  ICollection<DataChangeDetail> DataChangeDetails { get; set; } = null!;

    }

}




