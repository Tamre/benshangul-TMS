using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Organaizations
{
    public interface IOrganaizationList
    {
      public  Task<ResponseMessage> CreateOrganization(OrganizationDTO organaizationListDto);
      public   Task<ResponseMessage> UpdateOrganization( OrganizationDTO organaizationListDto);
      public  Task<ResponseMessage> DeleteOrganization(Guid id);
      public  Task<PagedList<OrganizationDTO>> GetAllOrganizations(FilterDetail filterData);

       

        //Task<OrganizationDTO> GetByIdAsync(Guid id);
    }
}
