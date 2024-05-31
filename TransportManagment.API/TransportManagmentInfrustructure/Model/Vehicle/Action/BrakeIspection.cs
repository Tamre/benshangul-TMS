using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class BrakeIspection: ActionIdModel
    {
     public string InspectionId {get; set; }
    public string FrontLeftBrakeForce { get; set; }
    public string FrontRightBrakeForce { get; set; }     
    public bool FrontRightBrakeForceStatus { get; set; }

    public string RearLeftBrakeForce { get; set; }
    public string RearRightBrakeForce { get; set; }
    public bool RearRightBrakeForceStatus { get; set; }
        
    public string FrontLeftFriction { get; set; }
    public string FrontRightFriction { get; set; }
    public bool FrontLeftFrictionStatus { get; set; }
    
    public string RearLeftFriction { get; set; }
    public string RearRightFriction { get; set; }

    public string RearLeftFrictionEfficency { get; set; }
    public string RearRightFrictionEfficency { get; set; }

    public string FrontLeftFrictionEfficency { get; set; }
    public string FrontRightFrictionEfficency { get; set; }

    public string FrontBrakeEfficency { get; set; }
    public string RearBrakeEfficency { get; set; }
    public string HandBrakeEfficency { get; set; }
    public string BrakeEfficency { get; set; }    
    public string PedalForce { get; set; }




}
}
