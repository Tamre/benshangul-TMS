﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Organizations;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using static TransportManagmentInfrustructure.Model.Vehicle.Action.ServiceChange;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class ServiceChange: ActionIdModel
    {
        [Required]
        public Guid VehilceId { get; set; }
        public virtual VehicleList Vehicle { get; set; } = null!;
        [Required]
        public Guid OrganizationId { get; set; }
        public virtual OrganizationList Organization { get; set; } = null!;
        [Required]
        public int GivingZoneId { get; set; }
        public virtual ZoneList GivingZone { get; set; } = null!;
        public ServiceChangeType ServiceChangeType { get; set; }
        [StringLength(ValidationClasses.MaxNameLength)]
        public string? LetterNo { get; set; }
        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        public string? Reason { get; set; }
        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        public string? Remark { get; set; }
        public bool IsORCChanges { get; set; }
        public bool ISAISChanges { get; set; }
        public bool IsPlateChanges { get; set; }
        [StringLength(ValidationClasses.SerialNumberLength)]
        public string PreviousEngineNo { get; set; } = null!;
        [StringLength(ValidationClasses.SerialNumberLength)]
        public string EngineNo { get; set; } = null!;
        public DataChangeStatus Status { get; set; }
        [Required]
        [StringLength(ValidationClasses.UserId)]
        public string? ApprovedById { get; set; } = null!;
        public virtual ApplicationUser ApprovedBy { get; set; } = null!;
        public DateTime? ApprovedDate { get; set; } = DateTime.UtcNow;

        /* *****  ServiceChange model is modified by Tamire*/

        //public ServiceChange()
        //{
        //    ServiceChangeDetails = new HashSet<ServiceChangeDetail>();
        //}
        //[Required]
        //    public Guid VehilceId { get; set; }
        //    public virtual VehicleList Vehicle { get; set; } = null!;
        //    [Required]
        //    public Guid OrganizationId { get; set; }
        //    public virtual OrganizationList Organization { get; set; } = null!;
        //    [Required]
        //    public int GivingZoneId { get; set; }
        //    public virtual ZoneList GivingZone { get; set; } = null!;
        //    public ServiceChangeType ServiceChangeType { get; set; }
        //   [StringLength(ValidationClasses.MaxNameLength)]
        //   public string? LetterNo { get; set; }
        //   [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        //    public string? Reason { get; set; }
        //    [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        //    public string? Remark { get; set; }
        //    public bool IsORCChanges { get; set; }
        //    public bool ISAISChanges { get; set; }
        //    public bool IsPlateChanges { get; set; }
        //// FieldInspectionId        
        //  //public string FieldInspectionId { get; set; }
        //   public string? CreatedById { get; set; } = null!;
        //    [Required]
        //    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        //    public DataChangeStatus Status { get; set; }

        //    [Required]
        //    [StringLength(ValidationClasses.UserId)]
        //    public string? ApprovedById { get; set; } = null!;
        //    public virtual ApplicationUser ApprovedBy { get; set; } = null!;
        //    public DateTime? ApprovedDate { get; set; } = DateTime.UtcNow;

        //    public ICollection<ServiceChangeDetail> ServiceChangeDetails { get; set; } = null!;


    }
}
