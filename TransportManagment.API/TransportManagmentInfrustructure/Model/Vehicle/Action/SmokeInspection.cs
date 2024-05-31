using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class SmokeInspection: ActionIdModel
    {
        public string InspectionId { get; set; }     

        // Exhaust smoke inspection
        public float ExhaustSmokeOpacity { get; set; }       

        // Engine oil consumption inspection
        public float EngineOilConsumption { get; set; }
       
    }
}
