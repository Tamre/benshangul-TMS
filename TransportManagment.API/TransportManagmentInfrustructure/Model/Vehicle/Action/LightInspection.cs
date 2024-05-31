using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class LightInspection: ActionIdModel
    {
        public string InspectionId { get; set; }    

        // Headlights
        public float LeftHeadlightIntensity { get; set; }
        public float RightHeadlightIntensity { get; set; }
        public float LeftHeadlightAngle { get; set; }
        public float RightHeadlightAngle { get; set; }
       
        

        // Taillights
        public float LeftTaillightIntensity { get; set; }
        public float RightTaillightIntensity { get; set; }
        public float LeftTaillightAngle { get; set; }
        public float RightTaillightAngle { get; set; }
      

        // Brake lights
        public float LeftBrakeLightIntensity { get; set; }
        public float RightBrakeLightIntensity { get; set; }
     

        // Turn signals
        public float LeftTurnSignalIntensity { get; set; }
        public float RightTurnSignalIntensity { get; set; }
       

    }
}
