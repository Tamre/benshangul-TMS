using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Configuration
{
    public class ValuationReason: SettingIdModel
    {
        public string Name { get; set; } = null!;
        public string LocalName { get; set; } = null!;
        public bool IsValuationPayment { get; set; }
        public bool IsOwnershipPayment { get; set; }
    }
}
