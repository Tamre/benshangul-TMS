using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IOrganizationCompound
    {
       public  Task<IEnumerable<OrganizationCompoundDto>> GetAllAsync();
       public Task<OrganizationCompoundDto> GetByIdAsync(string id);
       public Task CreateAsync(OrganizationCompoundDto dto);
       public Task UpdateAsync(string id, OrganizationCompoundDto dto);
       public Task DeleteAsync(string id);

    }
}
