using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{

    public record DataChangePostDto
    {
       //  public Guid Id { get; set; }      
        public Guid VehicleId { get; set; }  
        // public bool? IsSensitive { get; set; } // Flag to indicate update includes sensitive data
        public string TableName { get; set; }
        [Required]      
        public  TableColumnName ColumnName { get; set; }
        [Required]
        public string OldValue { get; set; }
        [Required]
        public string NewValue { get; set; }
        public string? Reason { get; set; }
        public RegistrationType RegistrationType { get; set; }
        public bool ISApproved { get; set; }
        //  public VehicleApprovalStatus ApprovalStatus { get; set; }
        public string CreatedById { get; set; } = null!;
        [Required]
       // public string RequestorId { get; set; }
      // public virtual ApplicationUser Requestor { get; set; }
        public DateTime RequestedDate { get; set; } = DateTime.UtcNow;
        public DataChangeStatus Status { get; set; }
        [StringLength(ValidationClasses.UserId)]
        public string? ApprovedById { get; set; }
        //public virtual ApplicationUser? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Comments { get; set; }
        public Dictionary<string, string> AdditionalChanges { get; set; }=null!; // Optional dictionary for additional changes

    }

    public record DataChangeGetDto : DataChangePostDto
    {

        public string AISNo { get; set; } = null!;
        public string VehicleRegistrationNo { get; set; } = null!;
        public string GivenZone { get; set; } = null!;
       
    }


}
