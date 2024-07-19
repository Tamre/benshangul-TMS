using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Organaizations;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Organaizations
{
    public class IOrganaizationOwner
    {
        public Task<ResponseMessage> AddOrgOwner(OrganaizationOwnerDTO OrganaizationOwner);
        public Task<ResponseMessage> UpdateOrgOwnre(OrganaizationOwnerDTO OrganaizationOwner);
        public Task<ResponseMessage> DeleteOrgOwner(Guid id);
        public Task<PagedList<OrganaizationOwnerDTO>> GetAllOrgOwner(FilterDetail filterData);

    }
}
