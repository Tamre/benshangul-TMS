using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class OrganizationCompound : ActionIdModel
    {
        public string OrganizationId { get; set; }
        public string CompoundType { get; set; }
        public string CompoundSize { get; set; }
        public string Remark { get; set; } 
        public string ServiceZoneId { get; set; }

    }
}
