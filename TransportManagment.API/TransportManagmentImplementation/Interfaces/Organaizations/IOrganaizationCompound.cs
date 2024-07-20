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
        public Task<ResponseMessage> Add(OrganizationCompoundDto organaizationListDto);
        public Task<ResponseMessage> Update(OrganizationCompoundDto organaizationListDto);
        public Task<ResponseMessage> Delete(Guid id);
        public Task<List<OrganizationCompoundDto>> GetAll(Guid Id);


    }
}
