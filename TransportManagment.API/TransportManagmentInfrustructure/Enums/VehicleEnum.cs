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
            SERVICEYEARCATEGORY,
            VEHICLECATEGORY,
            VehicleColor
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
            EN_INSPECTION_MONTH_END,
            TEMPORARY_PLATE_EXPIREDATE,
            TEMPORARY_PLATE_EXTENDDATE,
            ORGANIZATION_DAYS_PER_VEHICLE,
            ORGANIZATION_NEW_LICENSE_YEARS,
            ORGANIZATION_RENEW_LICENSEYEARS,
        }

        public enum VehicleSerialType
        {
            NEWVEHICLE,
            PERMANENT,
            TEMPORARY,
            TRANSFERNO,

        }

  
    }
}
