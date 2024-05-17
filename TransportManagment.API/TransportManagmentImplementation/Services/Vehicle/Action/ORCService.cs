using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentInfrustructure.Data;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using Microsoft.EntityFrameworkCore;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class ORCService : IORCService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;


        public ORCService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ResponseMessage> CreateOwnerRegistration(ORCPostDto orcPostDto)
        {


            try
            {

                var vechicleORCs = await _dbContext.ORCLists.Where(x => x.VehicleId == orcPostDto.VehicleId).OrderBy(x => x.CreatedDate).ToListAsync();


                vechicleORCs.ForEach(vi =>
                {
                    vi.IsActive = false;
                });
                await _dbContext.SaveChangesAsync();


                var ownerRegistraionCertficate = new ORC
                {
                    Id = Guid.NewGuid(),
                    CreatedById = orcPostDto.CreatedById,
                    CreatedDate = DateTime.Now,
                    VehicleId = orcPostDto.VehicleId,
                    StockId = orcPostDto.StockId,                   
                    GivenZoneId = orcPostDto.GivenZoneId,

                    IsActive = true,
                    IsPrinted = false,
                    IssueReason = Enum.Parse<IssueReason>(orcPostDto.IssueReason)

                };
                if (vechicleORCs.Any())
                {
                    ownerRegistraionCertficate.PreviousReason = vechicleORCs.FirstOrDefault().IssueReason;
                }





                await _dbContext.ORCLists.AddAsync(ownerRegistraionCertficate);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = $"Owner Registration Certficate Given For Vechicle Id {orcPostDto.VehicleId}"
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

        public async Task<List<ORCGetDto>> GetORCByVehicleId(Guid vehicleId)
        {


            var vechicleOwnerRegistration = await _dbContext.ORCLists.Where(x => x.VehicleId == vehicleId).OrderBy(x => x.CreatedDate).ToListAsync();

            var vechicleOwnerRegistrationDtos = _mapper.Map<List<ORCGetDto>>(vechicleOwnerRegistration);

            return vechicleOwnerRegistrationDtos;
        }

        public async  Task<ResponseMessage> PrintOwnerRegistration(Guid orcId)
        {
            try
            {
                var vechicleOwnerRegistration = await _dbContext.ORCLists.FindAsync(orcId);

                if (vechicleOwnerRegistration != null)
                {
                    vechicleOwnerRegistration.IsPrinted = true;
                    vechicleOwnerRegistration.PrintedDate = DateTime.Now;


                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = $"Owner Registration Certficate for Vehicle {orcId} updated Successfully "
                    };
                }
                else
                {

                    return new ResponseMessage
                    {
                        Success = false,
                        Message = $"Owner Registration Certficate forvehicle {orcId} not found !!!"
                    };
                }

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
    }
}
