using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.DTOS.Common
{
    public class SettingDropDownsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

    }

    public class ActionDropDownDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
