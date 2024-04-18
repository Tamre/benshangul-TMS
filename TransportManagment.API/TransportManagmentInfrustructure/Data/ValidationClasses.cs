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
        public const int MaxLocalNameLength = 15;
        public const int MaxSettingRemarkLength = 3000;
        public const int CodeLength = 3;
    }
}
