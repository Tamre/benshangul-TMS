using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{      public class VehicleInspection : ActionIdModel
       {
        public string VehicleId { get; set; }      
        public  MachineModel MachineModel { get; set; }     
        public string PassFailStatus { get; set; }
        public string OrganizationId { get; set; }
        public string MachineResult { get; set; }
        public string VisualResult { get; set; }
        public string InspectionById { get; set; }
        public string InspectionReasonId { get; set; }

        //public string InspectionReason { get; set; }
        public DateTime InspectionDate { get; set; }


      }
}


    

