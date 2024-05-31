using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentImplementation.Interfaces.Organaizations;
using TransportManagmentInfrustructure.Data;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using TransportManagmentInfrustructure.Model.Organizations;
using Microsoft.EntityFrameworkCore;
using TransportManagmentInfrustructure.Model.Common;
using System.Xml;

namespace TransportManagmentImplementation.Services.Organizations
{
   
    public class OrganizationListSetvice : IOrganaizationList
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILoggerManagerService _logger;

        public OrganizationListSetvice(ApplicationDbContext dbContext, IMapper mapper, ILoggerManagerService logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseMessage> CreateOrganization(OrganizationDTO organizationDto)
        {
            try
            {
                var checkPlateExistance = _dbContext.GetOrganizationLists.Any(x => x.PhoneNumber == organizationDto.PhoneNumber);


                if (!checkPlateExistance)
                {
                    var organaization = new OrganizationList
                    {
                        Id = Guid.NewGuid(),
                        Name = organizationDto.Name,
                        LocalName = organizationDto.LocalName,
                        ZoneId=organizationDto.ZoneId,
                        SubCity = organizationDto.SubCity,
                        Kebele = organizationDto.Kebele,
                        WoredaId = organizationDto.WoredaId,
                        Town= organizationDto.Town,
                        HouseNumnber = organizationDto.HouseNumber,
                        PhoneNumber = organizationDto.PhoneNumber,
                        SecondaryPhoneNumber = organizationDto.SecondaryPhoneNumber,
                        Tin= organizationDto.Tin,                          
                        //TypeOfOrganization=OrganizationType.Type1,
                        CreatedById = organizationDto.CreatedById,
                        CreatedDate = DateTime.Now,                 
                        IsActive = true

                    };


                    

                    await _dbContext.GetOrganizationLists.AddAsync(organaization);
                }


                return new ResponseMessage
                {
                    Success = true,
                    Message = "Organization created successfully"
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

       
        public async Task<ResponseMessage> UpdateOrganization(OrganizationDTO organizationDto)
        {
            try
            {

                var currentOrg = await _dbContext.GetOrganizationLists.FirstOrDefaultAsync(x => x.Id == organizationDto.Id && x.IsActive==true);

                if (currentOrg == null)
                {
                    return new ResponseMessage { Success = false, Message = "Organization could not be found" };
                }

                currentOrg.Name = organizationDto.Name;
                currentOrg.LocalName = organizationDto.LocalName;
                currentOrg.ZoneId = organizationDto.ZoneId;
                currentOrg.SubCity = organizationDto.SubCity;
                currentOrg.Kebele = organizationDto.Kebele;
                currentOrg.WoredaId = organizationDto.WoredaId;
                currentOrg.Town = organizationDto.Town;
                currentOrg.HouseNumnber = organizationDto.HouseNumber;
                currentOrg.PhoneNumber = organizationDto.PhoneNumber;
                currentOrg.SecondaryPhoneNumber = organizationDto.SecondaryPhoneNumber;
                currentOrg.Tin = organizationDto.Tin;
                //TypeOfOrganization=OrganizationType.Type1,
                currentOrg.CreatedById = organizationDto.CreatedById;
                currentOrg.CreatedDate = DateTime.Now;
                currentOrg.ModifiedById = organizationDto.ModifiedById;
                currentOrg.ModifiedDate = organizationDto.ModifiedDate;
                currentOrg. IsActive = true;

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

        public async Task<ResponseMessage> DeleteOrganization(Guid organizationId)
        {
            try
            {
                var organization = await _dbContext.GetOrganizationLists.FindAsync(organizationId);
                if (organization == null)
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Organization not found"
                    };
                }

                organization.IsActive = false;
                organization.ModifiedDate = DateTime.Now;

                _dbContext.GetOrganizationLists.Update(organization);
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

        public async Task<PagedList<OrganizationDTO>> GetAllOrganizations(FilterDetail filterData)
        {
            IQueryable<OrganizationList> organizationQuery = _dbContext.GetOrganizationLists.AsNoTracking().OrderBy(x => x.CreatedDate);

            // Implement sorting and search logic here
            if (!string.IsNullOrEmpty(filterData.SearchTerm))
            {
                organizationQuery = organizationQuery.Where(o => o.Name.Contains(filterData.SearchTerm));
            }

            if (filterData.Criteria != null && filterData.Criteria.Count() > 0)
            {
                foreach (var criteria in filterData.Criteria)
                {
                    organizationQuery = organizationQuery.Where(GetFilterProperty(criteria));
                }
            }

            var pagedOrganizationList = await PagedList<OrganizationList>.ToPagedListAsync(organizationQuery, filterData.PageNumber, filterData.PageSize);

            var pagedOrganizationListDtos = _mapper.Map<List<OrganizationDTO>>(pagedOrganizationList);

            return new PagedList<OrganizationDTO>(pagedOrganizationListDtos, pagedOrganizationList.MetaData);
        }
       

        private static Expression<Func<OrganizationList, bool>> GetFilterProperty(FilterCriteria criteria)
        {
            switch (criteria.ColumnName)
            {
                case "Name":
                    return o => o.Name.Contains(criteria.FilterValue);
                case "PhoneNumber":
                    return o => o.PhoneNumber.Contains(criteria.FilterValue);
               
            }
            return criteria.ColumnName?.ToLower() switch
            {
               // "PhoneNumber" => o => o.PhoneNumber.ToString() == criteria.FilterValue,

                  "Name"
                    => o => o.Name.Contains(criteria.FilterValue),
                 "PhoneNumber"=>
                 o => o.PhoneNumber.Contains(criteria.FilterValue)
            };
        }
    }
}
