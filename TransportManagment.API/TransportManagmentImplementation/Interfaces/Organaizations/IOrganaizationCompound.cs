using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Organaizations;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Organaizations
{
    public interface IOrganaizationCompound
    {
        public Task<ResponseMessage> CreateOrganizationCompound(OrganizationCompoundDto organaizationListDto);
        public Task<ResponseMessage> UpdateOrganizationCompound(OrganizationCompoundDto organaizationListDto);
        public Task<ResponseMessage> DeleteOrganizationCompound(Guid id);
        public Task<List<OrganizationCompoundDto>> GetOrganaizationCompoundByIdAsync(Guid Id);


    }
}
