using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Common
{
    public interface ICompanyProfileService
    {

        public Task<ResponseMessage> Update(CompanyProfileGetDto countryGet);
        public Task<CompanyProfileGetDto> Get();
    }
}
