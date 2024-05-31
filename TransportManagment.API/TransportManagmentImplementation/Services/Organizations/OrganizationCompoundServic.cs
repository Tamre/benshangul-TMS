using AutoMapper;
using IntegratedImplementation.Interfaces.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Organaizations;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Organaizations;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Organizations;
using TransportManagmentInfrustructure.Model.Vehicle.Action;

namespace TransportManagmentImplementation.Services.Organizations
{
    public class OrganizationCompoundService: IOrganaizationCompound
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


        public async Task<ResponseMessage> DeleteOrganizationCompound(Guid id)
        {
            try
            {
                var organization = await _dbContext.organizationCompounds.FindAsync(id);
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


                _dbContext.organizationCompounds.Update(organization);
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

        public async Task<ResponseMessage> UpdateOrganizationCompound( OrganizationCompoundDto organizationDto)
        {
            try
            {

                var currentOrg = await _dbContext.organizationCompounds.FirstOrDefaultAsync(x => x.Id == organizationDto.Id && x.IsActive == true);

                if (currentOrg == null)
                {
                    return new ResponseMessage { Success = false, Message = "Organization could not be found" };
                }

                currentOrg.Id = organizationDto.Id;
                currentOrg.OrganizationId = organizationDto.OrganizationId;
                currentOrg.ServiceZoneId = organizationDto.ServiceZoneId;
                currentOrg.CompoundSize = organizationDto.CompoundSize;
                currentOrg.CompoundType = organizationDto.CompoundType;
                currentOrg.Remark = organizationDto.Remark;                   
              
                currentOrg.CreatedDate = DateTime.Now;
                currentOrg.ModifiedById = organizationDto.ModifiedById;
                currentOrg.ModifiedDate = organizationDto.ModifiedDate;
                currentOrg.IsActive = true;

                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Organization updated successfully"
                };
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "Error updating organization");
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

      
      

        public async Task<List<OrganizationCompoundDto>> GetOrganaizationCompoundByIdAsync(Guid Id)
        {


            var _orgCompund = await _dbContext.organizationCompounds.Where(x => x.OrganizationId == Id).OrderBy(x => x.CreatedDate).ToListAsync();

            var orgCompound = _mapper.Map<List<OrganizationCompoundDto>>(_orgCompund);

            return orgCompound;

        }
        public async Task<ResponseMessage> CreateOrganizationCompound(OrganizationCompoundDto organizationDto)
        {
            try
            {
               
                    var organaization = new OrganizationCompound
                    {
                        Id = Guid.NewGuid(),
                        OrganizationId = organizationDto.OrganizationId,
                        ServiceZoneId = organizationDto.ServiceZoneId,
                        CompoundSize = organizationDto.CompoundSize,
                        CompoundType = organizationDto.CompoundType,
                        Remark = organizationDto.Remark,
                        ModifiedById = organizationDto.ModifiedById,                      
                 
                        IsActive = true

                    };




                    await _dbContext.organizationCompounds.AddAsync(organaization);

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Organization  Compound created successfully"
                };


            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error creating organization");
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }


    }
}
