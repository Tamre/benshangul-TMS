using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Action;

using AutoMapper;
using TransportManagmentInfrustructure.Migrations;
using Microsoft.EntityFrameworkCore;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class AISService : IAISServicecs
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper; 
        public AISService (ApplicationDbContext dbContext, IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;

        }
        public async Task<ResponseMessage> CreateAnnualInspection(AISPostDto aisPostDto)
        {
          

            try
            {

                var vechicleInspections = await _dbContext.AisLists.Where(x => x.VehicleId == aisPostDto.VehicleId).OrderBy(x=>x.CreatedDate).ToListAsync();


                vechicleInspections.ForEach(vi =>
                {
                    vi.IsActive = false;
                });
                await _dbContext.SaveChangesAsync();


                var annualInspection = new AIS
                {
                    Id = Guid.NewGuid(),
                    CreatedById = aisPostDto.CreatedById,
                    CreatedDate = DateTime.Now,
                    VehicleId = aisPostDto.VehicleId,
                    StockId = aisPostDto.StockId,
                    RegionCode = aisPostDto.RegionCode,
                    GivenZoneId = aisPostDto.GivenZoneId,
                    IsActive = true ,
                    IsPrinted = false,
                    IssueReason = Enum.Parse<IssueReason>(aisPostDto.IssueReason)

                };
                if (vechicleInspections.Any())
                {
                    annualInspection.PreviousReason = vechicleInspections.FirstOrDefault().IssueReason;
                }



                annualInspection.AISYear = EthiopicDateTime.GetEthiopicYear(annualInspection.CreatedDate.Day, annualInspection.CreatedDate.Month, annualInspection.CreatedDate.Year);




                await _dbContext.AisLists.AddAsync(annualInspection);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = $"Annual Inspection Created For Vechicle Id {aisPostDto.VehicleId}"
                };



            }catch (Exception ex)
            {
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message,
                };
            }



    }

        public async Task<List<AISGetDto>> GetAISByVehicleId(Guid vehicleId)
        {
            var vechicleAnnualInspections = await _dbContext.AisLists.Where(x=>x.VehicleId == vehicleId).OrderBy(x=>x.CreatedDate).ToListAsync();            

            var vechicleAnnualInspectionDtos = _mapper.Map<List<AISGetDto>>(vechicleAnnualInspections);

            return vechicleAnnualInspectionDtos;
        }

       
        public async Task<ResponseMessage> PrintAnnualInspection (Guid aisId)
        {
            try
            {
                var vehicleAnnualInspection = await _dbContext.AisLists.FindAsync(aisId);

                if (vehicleAnnualInspection!= null)
                {
                    vehicleAnnualInspection.IsPrinted = true;
                    vehicleAnnualInspection.PrintedDate = DateTime.Now;


                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = $"Annaual Inspection Vehicle {aisId} updated Successfully "
                    };
                }
                else
                {

                    return new ResponseMessage
                    {
                        Success = false,
                        Message = $"Annual Inspection for vehicle {aisId} not found !!!"
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
