using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentInfrustructure.Enums
{
    public class VehicleEnum
    {
        public enum AISORCStockCategory
        {
            AIS,
            ORC
        }

        public enum BanBodyCategory
        {
            BANK,
            COURT,
            OTHER
        }

        public enum PlateDigit
        {
            THREE = 3,
            FORUR = 4,
            FIVE = 5,
            SIX = 6,
        }

        public enum VehicleLookupType 
        {
            MARK,
            BANCASE,
            PLATESIZE,
            VEHICLECATEGORY,
            VehicleColor,
            Major,
            Minor,
            LoadMeasurement
        }

        public enum HorsePowerMeasure
        {
            BHP,
            KW
        }

        public enum VehicleSettingType
        {
            ANNUAL_INSPECTION_EXPIRE_YEAR,
            ANNUAL_iNSPECTION_MONTH_sTART,
            ANNUAL_iNSPECTION_MONTH_END,
            ET_INSPECTION_MONTH_START,
            ET_INSPECTION_MONTH_END,
            TEMPORARY_PLATE_EXPIREDATE,
            TEMPORARY_PLATE_EXTENDDATE,
            ORGANIZATION_DAYS_PER_VEHICLE,
            ORGANIZATION_NEW_LICENSE_YEARS,
            ORGANIZATION_RENEW_LICENSEYEARS,
            NUMBER_OF_INSPECTORS
        }

        public enum VehicleSerialType
        {
            NEWVEHICLE,
            PERMANENT,
            TEMPORARY,
            TRANSFERNO,
            OWNER
        }


        public enum GivenStatus
        {
            NotGiven,
            Transfer,
            Given,
            Returned
        }

        public enum IssuanceType
        {
            Vehicle,
            Temporary,
            Transit,
            Trailer,
            Motor
        }

        public enum RegistrationType
        {
            ENCODED,
            TEMPORARY,
            PERMANENT
        }
  
        public enum TaxStatus 
        {
            TAX_PAID,
            FREE
        }

        public enum LastActionTaken
        {
            Endoding,
            NewVehicleRegistraion,
            FieldInspection,
            TechnicalInspection,
            PlateAssignemnt,
            FinishNewVehicleRegistration,
            AnnualInspection,
            FinishAnualInspection,
            Valuation,
            CancelValuation,
            FinishValuation,
            ServiceChange,
            FinishServiceChange,
            Ban,
            FinishBan,
            ReturnBan,
            FinishReturnBan,
            TemporaryDeactivate,
            FinishTemporaryDeactivation,
            TemporaryActivation, 
            FinishTemporaryActivation,
            LostPlate,
            FinishLostPlate,
            LostORC,
            FinishLostORC,
            LostAIS,
            FinishLostAIS,
            Transfer,
            FinishTransfer,
            Cancelation,
            FinishCancelation,
            RevertCancelation,
            FinishRevertCancelation,


        }

        public enum TypeOfVehicle
        {
            VEHICLE,
            TRAILER
        }

        public enum VehicleApprovalStatus
        {
            PENDING,
            SENDTOADMIN,
            REJECTED,
            APPROVED,
            APPROVEDWITHOUTVALIDATATION
        }


        public enum VehicleCurrentStatus
        {
            New_Vehicle,
            Drived_Vehicle
        }

        public enum TransferStatus
        {
            New,
            FromZone,
            FromOtherRegion,
            ToZone,
            ToOtherRegion,
        }

        public enum OwnerGroup
        {
            Private_Owner,
            Organization,
            Government,
           
        }


        public enum OwnerState
        {
            CURRENT_OWNER,
            FORMER_OWNER,
            DELETED_OWNER
        }

        public enum EnergyType
        {
            PETROL,
            DIESEL,
            ELECTRIC,
            HYBRID_POWER
        }

        public enum IssueReason
        {
            NEW,
            ANNUAL,
            LOSS,
            DEFECTED,
            SERVICE_CHANGE,
            OWNER_CHANGE,
            RETURN_TRANSFER,
            OTHER
        }





        public enum OwnershipType
        {
            SELLER,
            BUYER
        }

        public enum ServiceChangeType
        {
            ServiceChange,
            ServiceBodyChange,
            EngineChange
        }

        public enum TypeOfOrganization
        {
            Annual_Inspection,
            Repair_Shop,
            SparePare_Shop,
            Importer,
            Assembly_Plant,
            Dealer
        }

        public enum ReplacementType
        {
            Plate,
            AIS,
            ORC
        }

        public enum ReplacementReason
        {
            Loss,
            Defect,
            Other
        }

        public enum VehicleFileteParameter
        {
            RegistrationNo,
            PlateNo,
            ChessisNo,
            EngineNo
        }

        public enum ForVehicleDocument { 

           AnnualInspection,

        
        
        }

    }
}
