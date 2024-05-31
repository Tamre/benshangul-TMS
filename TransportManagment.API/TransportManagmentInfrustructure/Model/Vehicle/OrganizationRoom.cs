using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle
{
    public class OrganizationRoom : ActionIdModel
    {
        public string OrganizationId { get; set; }
        public string RoomType { get; set; }
        public string RoomSize { get; set; }
        public string Remark { get; set; }     
        public string ServiceZoneId { get; set; }
    }
}
