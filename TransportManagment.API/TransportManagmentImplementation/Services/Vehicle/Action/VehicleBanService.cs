using AutoMapper;
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
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class VehicleBanService : IVehicleBanService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public VehicleBanService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<ResponseMessage> BanVehicle(VehicleBanPostDto vehicleBanPost)
        {
            try
            {
                var vehicle = await _dbContext.VehicleLists.FindAsync(vehicleBanPost.VehicleId);
                if (vehicle == null)
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Vehicle not Found !!!"

                    };
                }
                var vehicleBan = new VehicleBan
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    CreatedById = vehicleBanPost.CreatedById,
                    BanDate = vehicleBanPost.BanDate,
                    Enclosure = vehicleBanPost.Enclosure,
                    MoneyAmmount = vehicleBanPost.MoneyAmmount,
                    BanBodyId = vehicleBanPost.BanBodyId,
                    VehicleId = vehicleBanPost.VehicleId,
                    BanCaseId = vehicleBanPost.BanCaseId,
                    BanLetterNo = vehicleBanPost.BanLetterNo
                };

                await _dbContext.VehicleBans.AddAsync(vehicleBan);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Vehicle Banned Successfully !!!"
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

        public async Task<List<VehicleBanGetDto>> GetBanHistories(Guid vehicleId)
        {

            var bans = await _dbContext.VehicleBans.Where(x => x.VehicleId == vehicleId).ToListAsync();
            var banDtos = _mapper.Map<List<VehicleBanGetDto>>(bans);
            return banDtos;

        }

        public async Task<ResponseMessage> LiftBanVehicle(VehicleLiftBanDto liftBanPost)
        {
            try
            {
                var vehicle = await _dbContext.VehicleLists.FindAsync(liftBanPost.VehicleId);
                if (vehicle == null)
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Vehicle not Found !!!"

                    };
                }
                var vehicleban = await _dbContext.VehicleBans.FindAsync(liftBanPost.BanId);
                if (vehicleban == null)
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Vehicle ban history not Found !!!"

                    };
                }

                if (vehicleban.IsLifted)
                {



                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Vehicle ban Has Already Lifted !!!"

                    };
                }




                vehicleban.LetterLiftDate = liftBanPost.LetterLiftDate;
                vehicleban.LetterLiftNo = liftBanPost.LetterLiftNo;
                vehicleban.LiftedById = liftBanPost.LiftedById;
                vehicleban.IsLifted = true;


                await _dbContext.SaveChangesAsync();


                return new ResponseMessage
                {
                    Success = true,
                    Message = "Vehicle Bann Lifted Successfully "
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
    }
}
