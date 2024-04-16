using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;
using TransportManagmentInfrustructure.Data;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TransportManagmentImplementation.Services.Vehicle.Configuration
{
    public class BanBodyService : IBanBodyService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public BanBodyService(ApplicationDbContext dbContext, IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;

        }
        public async Task<ResponseMessage> Add(BanBodyPostDto BanBodyPost)
        {
            try
            {
                var banBody = new BanBody
                {
                    Name = BanBodyPost.Name,
                    AmharicNAme = BanBodyPost.AmharicNAme,
                    BanBodyCategory = Enum.Parse<BanBodyCategory>(BanBodyPost.BanBodyCategory),
                    CreatedById = BanBodyPost.CreatedById,
                    CreatedDate = DateTime.Now,

                };
                await _dbContext.BanBodies.AddAsync(banBody);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Band Body Added Successfully !!!"
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

        public async Task<List<BanBodyGetDto>> GetAll()
        {
            var banBodies = await _dbContext.BanBodies.AsNoTracking().ToListAsync();

            var banBodyDtos = _mapper.Map<List<BanBodyGetDto>>(banBodies);

            return banBodyDtos;
        }

        public async Task<ResponseMessage> Update(BanBodyGetDto BanBodyGet)
        {
            try
            {

                var banBody = await _dbContext.BanBodies.FindAsync(BanBodyGet.Id);

                if (banBody != null)
                {
                    banBody.Name = BanBodyGet.Name;
                    banBody.AmharicNAme = BanBodyGet.AmharicNAme;
                    banBody.BanBodyCategory = Enum.Parse<BanBodyCategory>(BanBodyGet.BanBodyCategory);

                    // Save the changes to the database
                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Ban Body Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Ban Body Not Found !!!"
                    };
                }

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
    }
}
