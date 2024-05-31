using AutoMapper;
using IntegratedImplementation.Interfaces.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class OrganizationCompoundService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        private readonly IGeneralConfigService _generalConfigService;
        public OrganizationCompoundService(IMapper mapper, ApplicationDbContext dbContext, IGeneralConfigService generalConfigService)
        {

            _mapper = mapper;
            _dbContext = dbContext;
            _generalConfigService = generalConfigService;

        }
       

        public async Task<ResponseMessage> DeleteAsync(Guid id)
        {
              try
            {
                var organization = await _dbContext.GetOrganizationCompounds.FindAsync(id);
                if (organization == null)
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Organization Compound not found"
                    };
                }

                organization.IsActive = false;
                organization.ModifiedDate = DateTime.Now;
                

                _dbContext.GetOrganizationCompounds.Update(organization);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Organization deleted successfully"
                };
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error deleting organization");
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
        


    }
}
