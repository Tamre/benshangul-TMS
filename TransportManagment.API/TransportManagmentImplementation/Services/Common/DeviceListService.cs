using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using static TransportManagmentInfrustructure.Enums.CommonEnum;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Common;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
using System.Diagnostics.Metrics;


namespace TransportManagmentImplementation.Services.Common
{
    public class DeviceListService : IDeviceListService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeviceListService(ApplicationDbContext dbContext, IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;

        }

        public async Task<ResponseMessage> Add(DeviceListPostDto DeviceListPost)
        {
            try
            {



                var DeviceList = new DeviceList
                {

                    PCNAme = DeviceListPost.PCNAme,
                    IpAddress = DeviceListPost.IpAddress,
                    MACAddress = DeviceListPost.MACAddress,
                    ApprovedFor = Enum.Parse<ApprovedFor>(DeviceListPost.ApprovedFor),
                    // ApproverId = DeviceListPost.ApproverId,
                    CreatedById = DeviceListPost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };
                await _dbContext.DeviceLists.AddAsync(DeviceList);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Device List Added Successfully !!!"
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

        public async Task<List<DeviceListGetDto>> GetAll()
        {


            var DeviceLists = await _dbContext.DeviceLists.Include(x => x.Approver).AsNoTracking().ToListAsync();

            var DeviceListsDtos = _mapper.Map<List<DeviceListGetDto>>(DeviceLists);

            return DeviceListsDtos;




        }

        public async Task<ResponseMessage> Update(DeviceListGetDto DeviceListGet)
        {
            try
            {

                var DeviceList = await _dbContext.DeviceLists.FindAsync(DeviceListGet.Id);

                if (DeviceList != null)
                {
                    // Update the properties of the DeviceList entity
                    DeviceList.PCNAme = DeviceListGet.PCNAme;
                    DeviceList.IpAddress = DeviceListGet.IpAddress;
                    DeviceList.MACAddress = DeviceListGet.MACAddress;
                    DeviceList.ApproverId = DeviceListGet.ApproverId;
                    DeviceList.ApprovedFor = Enum.Parse<ApprovedFor>(DeviceListGet.ApprovedFor);


                    DeviceList.IsActive = DeviceListGet.IsActive;



                    // Save the changes to the database
                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Device List Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Device List Not Found !!!"
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
