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
      public class DataChange : ActionIdModel
    {
        
        public Guid VehicleId { get; set; }  
        public bool? IsSensitive { get; set; } // Flag to indicate update includes sensitive data
        public string TableName { get; set; }
        [Required]
        public TableColumnName ColumnName { get; set; }
        [Required]
        public string OldValue { get; set; }
        [Required]
        public string NewValue { get; set; }
        public string? Reason { get; set; }
        public RegistrationType RegistrationType { get; set; }
        public bool ISApproved { get; set; }
        public VehicleApprovalStatus ApprovalStatus { get; set; }
        [Required]       
        public DateTime RequestedDate { get; set; } = DateTime.UtcNow;
        public DataChangeStatus Status { get; set; }
        [StringLength(ValidationClasses.UserId)]
        public string? ApprovedById { get; set; }  
        public DateTime? ApprovedDate { get; set; }
        public string? Comments { get; set; }
        public string AdditionalChanges { get; set; } // Optional JSON string for additional sensetive column changes
      
        
    }
}




