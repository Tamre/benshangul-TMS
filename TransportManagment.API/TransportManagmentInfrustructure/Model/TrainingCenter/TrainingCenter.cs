using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;

namespace TransportManagmentInfrustructure.Model.TrainingCenter
{
    public class TrainingCenterList: ActionIdModel
    {
        public string TrainingCenterNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string AmharicName { get; set; } = null!;
        public  int ServiceZoneId { get;set; }
        public virtual ZoneList ServiceZone { get; set; } = null!;
        public int ZoneId { get; set; }
        public virtual ZoneList Zone { get; set;} = null!;
        public int WoredaId { get; set; }
        public virtual Woreda Woreda { get; set; } = null!;
        public string HouseNumber { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? SecondaryPhone { get; set; }
        public string? Longtiude { get; set; }
        public string? Latitude { get; set; }
        public string Location { get; set; } = null!;
        public string LogoPath { get; set; } = null!;
    }
}
