using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class SuspentionInspection : ActionIdModel
    {
        public string InspectionId { get; set; }
        public float RearLeftSpringCompression { get; set; }
        public float RearRightSpringCompression { get; set; }
        public bool RearRightStatus { get; set; }   
        public float FrontLeftSpringCompression { get; set; }
        public float FrontRightSpringCompression { get; set; } 

        public bool FrontRightStatus { get; set; }
        public float SuspensionPerformance { get; set; }        
        public float FrontEfficency { get; set; }
        public float RearEfficency { get; set; }
        


    }
}
