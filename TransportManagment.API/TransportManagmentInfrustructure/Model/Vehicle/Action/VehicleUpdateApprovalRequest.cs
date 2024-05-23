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
    public class VehicleUpdateApprovalRequest : ActionIdModel
    {
        public string TableName { get; set; }
        [Required]
        public Guid VehicleId { get; set; }
        public TableColumnName ColumnName { get; set; }
        [Required]
        public string OldValue { get; set; }
        [Required]
        public string NewValue { get; set; }
        public string? Reason { get; set; }        
        public bool ISApproved { get; set; }
        public VehicleApprovalStatus ApprovalStatus { get; set; }
        public RegistrationType RegistrationType { get; set; }
        [Required]
        public string RequestorId { get; set; }
        public virtual ApplicationUser Requestor { get; set; }
        public DateTime RequestedDate { get; set; } = DateTime.UtcNow;
        public DataChangeStatus Status { get; set; }
        [StringLength(ValidationClasses.UserId)]
        public string? ApprovedById { get; set; }
        public virtual ApplicationUser? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Comments { get; set; }
        

    }
}
