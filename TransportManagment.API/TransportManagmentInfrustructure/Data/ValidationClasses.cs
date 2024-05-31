using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentInfrustructure.Data
{
    public class ValidationClasses
    {
        public const int MaxNameLength = 10;
        public const int MaxLocalNameLength = 20;
        public const int MaxSettingRemarkLength = 3000;
        public const int CodeLength = 5;
        public const int SerialNumberLength = 40;
        public const int PhoneNumber = 13;
        public const int LetterLength = 20;
        public const int UserId = 450;
        public const int ChassisNo = 17;
        public const int TaxIdentificationNumberLength = 10;
    }
}
