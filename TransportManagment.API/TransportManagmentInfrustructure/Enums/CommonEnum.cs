using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentInfrustructure.Enums
{
    public class CommonEnum
    {

        public enum RowStatus
        {
            Active,
            InActive
        }
        public enum RoleModule
        {
            Admin,
            VRMS,
            DPMS,
            PTMS,
            FTMS,
            Archive,
            Payment,
            Penalty
        }

        public enum UserType
        {
            Regional,
            Zonal,
            Institution,
            Association,
            Inspection
        }

        public enum Gender
        {
            Male,
            Female
        }

        public enum ApprovedFor
        {
            Pending,
            NormalUse,
            LicensePrint,
            ExamRoom
        }

        public enum PasswordChangeStatus
        {
            Pending,
            Changed
        }

        public enum CommonCodeType
        {
            UserCode
        }

        public enum FileExtentions
        {
            JPG,
            JPEG,
            PNG,
            PDF
        }

        public enum ServiceModule
        {
            DPMS,
            VRMS,
            PUBLIC,
            FRIGHT
        }
    }
    }
