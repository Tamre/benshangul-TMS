

using AutoMapper;
using TransportManagmentAPI.Controllers.Vehicle.Configuration;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.DTOS.Configuration;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentImplementation.Services.Common;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentImplementation.Datas
{
    public class AutoMapperConfigurations : Profile
    {

        public AutoMapperConfigurations()
        {
            #region Configuration

            #endregion

            #region Common 

            CreateMap<Country, CountryGetDto>();
            CreateMap<Region, RegionGetDto>().ForMember(a => a.CountryName, e => e.MapFrom(mfg => mfg.Country.Name));
            CreateMap<ZoneList, ZoneGetDto>().ForMember(a => a.RegionName, e => e.MapFrom(mfg => mfg.Region.Name));
            CreateMap<Woreda, WoredaGetDto>().ForMember(a => a.ZoneName, e => e.MapFrom(mfg => mfg.Zone.Name));
            CreateMap<CompanyProfile, CompanyProfileGetDto>();
            CreateMap<CommonCodes, CommonCodeGetDto>()
                .ForMember(a => a.ZoneName, e => e.MapFrom(mfg => mfg.Zone.Name))
                .ForMember(a => a.CommonCodeType, e => e.MapFrom(mfg => mfg.CommonCodeType.ToString()))
                ;
            CreateMap<DeviceList, DeviceListGetDto>()
                .ForMember(a => a.ApprovedFor, e => e.MapFrom(mfg => mfg.ApprovedFor.ToString()))
                .ForMember(a => a.ApproverUser, e => e.MapFrom(mfg => mfg.Approver.FullName))
        ;
            #endregion

            #region vechile-config

            CreateMap<AISORCStockType, AISORCStockTypeGetDto>()
                 .ForMember(a => a.Category, e => e.MapFrom(mfg => mfg.Category.ToString()));

            CreateMap<BanBody, BanBodyGetDto>()
                .ForMember(a => a.BanBodyCategory, e => e.MapFrom(mfg => mfg.BanBodyCategory.ToString()));

            CreateMap<DepreciationCost, DepreciationCostGetDto>();

            CreateMap<DocumentType, DocumentTypeGetDto>()
                .ForMember(a => a.FileExtentions, e => e.MapFrom(mfg => mfg.FileExtentions.ToString()));

            CreateMap<FactoryPoint, FactoryPointGetDto>()
                .ForMember(a => a.MarkName, e => e.MapFrom(mfg => mfg.Mark.Name.ToString()));

            CreateMap<InitialPrice, InitialPriceGetDto>();
            CreateMap<ManufacturingCountry, ManufacturingCountryGetDto>();
            CreateMap<PlateType, PlateTypeGetDto>();
            CreateMap<SalvageValue, SalvageValueGetDto>();


            CreateMap<ServiceType, ServiceTypeGetDto>()
                .ForMember(a => a.ServiceModule, e => e.MapFrom(mfg => mfg.ServiceModule.ToString()));

            CreateMap<ServiceYearSetting, ServiceYearSettingGetDto>();
            CreateMap<VehicleBodyType, VehicleBodyTypeGetDto>();

            CreateMap<VehicleLookups, VehicleLookupsGetDto>()
                .ForMember(a => a.VehicleLookupType, e => e.MapFrom(mfg => mfg.VehicleLookupType.ToString()));

            CreateMap<VehicleModel, VehicleModelGetDto>()
                .ForMember(a => a.HorsePowerMeasure, e => e.MapFrom(mfg => mfg.HorsePowerMeasure.ToString()));

            CreateMap<VehicleSerialSetting, VehicleSerialSettingGetDto>()
                .ForMember(a => a.VehicleSerialType, e => e.MapFrom(mfg => mfg.VehicleSerialType.ToString()));

            CreateMap<VehicleSettings, VehicleSettingsGetDto>()
                .ForMember(a => a.VehicleSettingType, e => e.MapFrom(mfg => mfg.VehicleSettingType.ToString()));

            CreateMap<VehicleType, VehicleTypeGetDto>();
            CreateMap<ValuationReason, ValuationReasonGetDto>();

            #endregion


            #region Vechile_Action

            CreateMap<AisStock, AISStockGetDto>();

            CreateMap<ORCStock, ORCStockGetDto>();

            CreateMap<PlateStock, PlateStockGetDto>()
                .ForMember(a => a.PlateDigit, e => e.MapFrom(mfg => mfg.PlateDigit.ToString()))
                .ForMember(a => a.PlateTypeName, e => e.MapFrom(mfg => mfg.PlateType.Name))
                .ForMember(a => a.IssuanceType, e => e.MapFrom(mfg => mfg.IssuanceType.ToString()));

            #endregion
        }
    }
}
