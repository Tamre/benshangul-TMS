using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Common
{
    public interface ICountryService
    {
        public Task<ResponseMessage> Add(CountryPostDto countryPost);
        public Task<ResponseMessage> Update(CountryGetDto countryGet);
        public Task<List<CountryGetDto>> GetAll(RequestParameter requestParameter); 

    }
}
