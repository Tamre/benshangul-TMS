using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class SlideSlipInspection: ActionIdModel
    {
        public string InspectionId { get; set; }
     
        // Front wheel slide slip
        public float FrontLeftSlideSlip { get; set; }
        public float FrontRightSlideSlip { get; set; }
        public bool FrontRightStatus { get; set; }

        // Rear wheel slide slip
        public float RearLeftSlideSlip { get; set; }
        public float RearRightSlideSlip { get; set; }
        public bool RearRightStatus { get; set; }

        


    }
}
