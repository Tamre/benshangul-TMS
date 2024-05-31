using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class OrganizationCompound : ActionIdModel
    {
        public Guid OrganizationId { get; set; }
        public string CompoundType { get; set; }
        public string CompoundSize { get; set; }
        public string Remark { get; set; } 
        public string ServiceZoneId { get; set; }

        public string? ModifiedById { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; } = null!;
      
       

    }
}
