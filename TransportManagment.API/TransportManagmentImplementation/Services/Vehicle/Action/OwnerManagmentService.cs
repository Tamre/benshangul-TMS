using AutoMapper;
using IntegratedImplementation.Interfaces.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentImplementation.Services.Configuration;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using static TransportManagmentInfrustructure.Enums.CommonEnum;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class OwnerManagmentService : IOwnerManagmentService
    {

        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        private readonly IGeneralConfigService _generalConfigService;
        public OwnerManagmentService(IMapper mapper, ApplicationDbContext dbContext, IGeneralConfigService generalConfigService)
        {

            _mapper = mapper;
            _dbContext = dbContext;
            _generalConfigService = generalConfigService;

        }

        public async Task<ResponseMessage> AssignOwner(VehicleOwnerDto vehicleOwnerDto)
        {
            try
            {

                var owners = await _dbContext.VehicleOwners.Where(x=>x.VehicleId==vehicleOwnerDto.VehicleId&& x.OwnerState==OwnerState.CURRENT_OWNER).ToListAsync();

                owners.ForEach(vi =>
                {
                    vi.OwnerState = OwnerState.FORMER_OWNER;
                });
                await _dbContext.SaveChangesAsync();


                var vehicleOwners = new VehicleOwner
                {

                    Id = Guid.NewGuid(),
                    VehicleId = vehicleOwnerDto.VehicleId,
                    OwnerId = vehicleOwnerDto.OwnerId,
                    TrainingCenterId = vehicleOwnerDto.TrainingCenterId,
                    OwnerState = OwnerState.CURRENT_OWNER,
                    CreatedById = vehicleOwnerDto.CreatedById,
                    CreatedDate = DateTime.Now,
                };

                await _dbContext.VehicleOwners.AddAsync(vehicleOwners);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = $"Vehicle assigned to owner successfully !!!"
                };

            }
            catch (Exception ex)
            {

                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };
            }
            
        }

        public async Task<ResponseMessage> CreateOwner(OwnerListPostDto ownerListPostDto)
        {

            try
            {

                if (ownerListPostDto == null)
                    return new ResponseMessage { Success = false, Message = "Data not sent" };

                var ownerExist = await _dbContext.OwnerLists
                    .Where(x => (x.PhoneNumber == ownerListPostDto.PhoneNumber || x.SecondaryPhoneNumber == ownerListPostDto.PhoneNumber)||x.IdNumber == ownerListPostDto.IdNumber).Select(x=> new { 
                    x.FirstName, x.LastName,x.MiddleName,x.PhoneNumber
                    }).FirstOrDefaultAsync();


                if (ownerExist != null)
                {
                    if (ownerExist.PhoneNumber == ownerListPostDto.PhoneNumber)
                    {
                        return new ResponseMessage
                        {
                            Success = false,
                            Message = $"Owner Phonenumber is already assigned for the owner {ownerExist.FirstName} {ownerExist.MiddleName} {ownerExist.LastName}"
                        };
                    }
                    else
                    {
                        return new ResponseMessage
                        {
                            Success = false,
                            Message = $"Owner Id Number is already assigned for the owner {ownerExist.FirstName} {ownerExist.MiddleName} {ownerExist.LastName}"
                        };

                    }

                  
                }

                var ownerRegistrationNo = await _generalConfigService.GenerateVehicleNumber(VehicleSerialType.OWNER, ownerListPostDto.ServiceZoneId, ownerListPostDto.CreatedById);



                var owner = new OwnerList
                {
                    OwnerNumber = ownerRegistrationNo,
                    FirstName = ownerListPostDto.FirstName,
                    MiddleName = ownerListPostDto.MiddleName,
                    LastName = ownerListPostDto.LastName,
                    AmharicFirstName = ownerListPostDto.AmharicFirstName,
                    AmharicMiddleName = ownerListPostDto.AmharicMiddleName,
                    AmharicLastName = ownerListPostDto.AmharicLastName,
                    Gender = ownerListPostDto.Gender,
                    ZoneId = ownerListPostDto.ZoneId,
                    WoredaId = ownerListPostDto?.WoredaId,
                    Town = ownerListPostDto.Town,
                    HouseNo = ownerListPostDto?.HouseNo,
                    PhoneNumber = ownerListPostDto.PhoneNumber,
                    SecondaryPhoneNumber = ownerListPostDto?.SecondaryPhoneNumber,
                    IdNumber = ownerListPostDto.IdNumber,
                    PoBox = ownerListPostDto?.PoBox,
                    OwnerGroup = ownerListPostDto.OwnerGroup,

                    Id = Guid.NewGuid(),
                    CreatedById = ownerListPostDto.CreatedById,
                    CreatedDate = DateTime.Now
                };


                await _dbContext.OwnerLists.AddAsync(owner);
                await _dbContext.SaveChangesAsync();



                return new ResponseMessage
                {
                    Success = true,
                    Message = $"Owner Added Successfully With Owner Numeber {owner.OwnerNumber}",
                    Data = owner.OwnerNumber
                };

            }
            catch (Exception ex)
            {

                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseMessage> UpdateOwner(OwnerListGetDto ownerListGetDto)
        {

            try
            {

                var ownerExist = await _dbContext.OwnerLists.FindAsync(ownerListGetDto.Id);


                if (ownerExist == null)
                {

                    return new ResponseMessage
                    {
                        Success = false,
                        Message = $"Owner Not Found !!!"
                    };
                }





                ownerExist.FirstName = ownerListGetDto.FirstName;
                ownerExist.MiddleName = ownerListGetDto.MiddleName;
                ownerExist.LastName = ownerListGetDto.LastName;
                ownerExist.AmharicFirstName = ownerListGetDto.AmharicFirstName;
                ownerExist.AmharicMiddleName = ownerListGetDto.AmharicMiddleName;
                ownerExist.AmharicLastName = ownerListGetDto.AmharicLastName;
                ownerExist.Gender = ownerListGetDto.Gender;
                ownerExist.ZoneId = ownerListGetDto.ZoneId;
                ownerExist.WoredaId = ownerListGetDto?.WoredaId;
                ownerExist.Town = ownerListGetDto?.Town;
                ownerExist.HouseNo = ownerListGetDto?.HouseNo;
                ownerExist.PhoneNumber = ownerListGetDto?.PhoneNumber;
                ownerExist.SecondaryPhoneNumber = ownerListGetDto?.SecondaryPhoneNumber;
                ownerExist.IdNumber = ownerListGetDto?.IdNumber;
                ownerExist.PoBox = ownerListGetDto?.PoBox;

            



            await _dbContext.SaveChangesAsync();



            return new ResponseMessage
            {
                Success = true,
                Message = $"Owner updated Successfully With Owner Numeber {ownerExist.OwnerNumber}",
                Data = ownerExist.OwnerNumber
            };

        }
            catch (Exception ex)
            {

                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message,
                };
}

        }

        public async Task<List<VehicleOwnerListGetDto>> GetOwnerByVechicleId(Guid VehicleId)
{


    var owners = await _dbContext.VehicleOwners
        .Include(x => x.TrainingCenter)
        .Include(x => x.Vehicle)
        .Include(x => x.Owner.Zone)
        .Include(x => x.Owner.Woreda)
        .Where(x => x.VehicleId == VehicleId).ToListAsync();

    var ownerDtos = owners.Select(x => new VehicleOwnerListGetDto
    {
        Id = x.Id,
        VechicleId = x.VehicleId,
        OwnerId =  x.Owner.Id,
        OwnerNumber =x.Owner.OwnerNumber,
        FullName = $"{x.Owner.FirstName} {x.Owner.MiddleName} {x.Owner.LastName}",
        AmharicName = $"{x.Owner.AmharicFirstName} {x.Owner.AmharicMiddleName} {x.Owner.AmharicLastName}",
        VehicleRegistrationNo = x.Vehicle.RegistrationNo,
        Zone = x.Owner.Zone.Name,
        Woreda = x.Owner.Woreda.Name,
        Gender = x.Owner.Gender.ToString(),
        IdNumber = x.Owner.IdNumber,
        Town = x.Owner.Town,
        HouseNo = x.Owner.HouseNo,
        PhoneNumber = x.Owner.PhoneNumber,
        SecondaryPhoneNumber = x.Owner.SecondaryPhoneNumber,
        PoBox = x.Owner.PoBox,
        TrainingCenter = x.TrainingCenterId!=null? x.TrainingCenter.Name:null,
        OwnerState = x.OwnerState.ToString()

    }).ToList();



    return ownerDtos;


}

        public async  Task<PagedList<OwnerListGetDto>> GetAllOwners(FilterDetail filterData)
        {
            IQueryable<OwnerList> ownerQuery = _dbContext.OwnerLists.Include(x=>x.Woreda).Include(x=>x.Zone).AsNoTracking().OrderBy(x => x.CreatedDate);

            /// Do the Sort And Serch Impleentation here

            if (!string.IsNullOrEmpty(filterData.SearchTerm))
            {
                ownerQuery = ownerQuery.Where(p =>
               p.FirstName.Contains(filterData.SearchTerm));
            }

            if (filterData.Criteria != null && filterData.Criteria.Count() > 0)
            {
                foreach (var criteria in filterData.Criteria)
                {
                    ownerQuery = ownerQuery.Where(GetFilterProperty(criteria));
                }
            }



            var pagedOwnerList = await PagedList<OwnerList>.ToPagedListAsync(ownerQuery, filterData.PageNumber, filterData.PageSize);

            var pagedOwnerListDtos = _mapper.Map<List<OwnerListGetDto>>(pagedOwnerList);


            return new PagedList<OwnerListGetDto>(pagedOwnerListDtos, pagedOwnerList.MetaData);
        }

        private static Expression<Func<OwnerList, bool>> GetFilterProperty(FilterCriteria criteria)
        {
            return criteria.ColumnName?.ToLower() switch
            {
                "firstname" => owner => owner.FirstName.Contains(criteria.FilterValue),
                "lastname" => owner => owner.LastName.Contains(criteria.FilterValue),
                "middlename" => owner => owner.MiddleName.Contains(criteria.FilterValue),
                "ownernumber" => owner => owner.OwnerNumber.Contains(criteria.FilterValue),
                "phonenumber" => owner => owner.PhoneNumber.Contains(criteria.FilterValue),
               
            };
        }

    }
}
