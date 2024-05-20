

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
                .ForMember(a => a.RequesterUser, e => e.MapFrom(mfg => mfg.CreatedBy.FullName));
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
            CreateMap<VehicleBodyType, VehicleBodyTypeGetDto>()
                                .ForMember(a => a.TypeName, e => e.MapFrom(mfg => mfg.VehicleType.Name));

            CreateMap<VehicleLookups, VehicleLookupsGetDto>()
                .ForMember(a => a.VehicleLookupType, e => e.MapFrom(mfg => mfg.VehicleLookupType.ToString()));

            CreateMap<VehicleModel, VehicleModelGetDto>()
                .ForMember(a => a.HorsePowerMeasure, e => e.MapFrom(mfg => mfg.HorsePowerMeasure.ToString()))
                .ForMember(a => a.MarkName, e => e.MapFrom(mfg => mfg.Mark.Name));

            CreateMap<VehicleSerialSetting, VehicleSerialSettingGetDto>()
                .ForMember(a => a.VehicleSerialType, e => e.MapFrom(mfg => mfg.VehicleSerialType.ToString()));

            CreateMap<VehicleSettings, VehicleSettingsGetDto>()
                .ForMember(a => a.VehicleSettingType, e => e.MapFrom(mfg => mfg.VehicleSettingType.ToString()));

            CreateMap<VehicleType, VehicleTypeGetDto>()
                .ForMember(a => a.CategoryName, e => e.MapFrom(mfg => mfg.VehicleCategory.Name)); ;

            CreateMap<ValuationReason, ValuationReasonGetDto>();

            #endregion


            #region Vechile_Action

            CreateMap<AIS, AISGetDto>()
                    .ForMember(a => a.GivenZone, e => e.MapFrom(mfg => mfg.GivenZone.Name))
                    .ForMember(a => a.AISNo, e => e.MapFrom(mfg => mfg.Stock.AISNo))
                    .ForMember(a => a.VehicleRegistrationNo, e => e.MapFrom(mfg => mfg.Vehicle.RegistrationNo))
                    .ForMember(a => a.IssueReason, e => e.MapFrom(mfg => mfg.IssueReason.ToString()))
                    .ForMember(a => a.PreviousReason, e => e.MapFrom(mfg => mfg.PreviousReason.ToString()));

            CreateMap<ORC, ORCGetDto>()
                 .ForMember(a => a.GivenZone, e => e.MapFrom(mfg => mfg.GivenZone.Name))
                 .ForMember(a => a.AISNo, e => e.MapFrom(mfg => mfg.Stock.ORCNo))
                 .ForMember(a => a.VehicleRegistrationNo, e => e.MapFrom(mfg => mfg.Vehicle.RegistrationNo))
                 .ForMember(a => a.IssueReason, e => e.MapFrom(mfg => mfg.IssueReason.ToString()))
                 .ForMember(a => a.PreviousReason, e => e.MapFrom(mfg => mfg.PreviousReason.ToString()));


            CreateMap<OwnerList, OwnerListGetDto>()
              .ForMember(a => a.Woreda, e => e.MapFrom(mfg => $"{mfg.Woreda.Name} {mfg.Woreda.LocalName}"))
              .ForMember(a => a.Zone, e => e.MapFrom(mfg => $"{mfg.Zone.Name} {mfg.Zone.LocalName}"));


            CreateMap<VehicleBan, VehicleBanGetDto>()
                .ForMember(a => a.VehicleChesisNo, e => e.MapFrom(mfg => mfg.Vehicle.ChassisNo))
                .ForMember(a => a.VehicleRegistrationNo, e => e.MapFrom(mfg => mfg.Vehicle.RegistrationNo))
                .ForMember(a => a.BanBody, e => e.MapFrom(mfg => mfg.BanBody.Name))
                .ForMember(a => a.BanCase, e => e.MapFrom(mfg => mfg.BanCase.Name));



            CreateMap<AisStock, AISStockGetDto>();

            CreateMap<ORCStock, ORCStockGetDto>();


            CreateMap<PlateStock, PlateStockGetDto>()
                .ForMember(a => a.PlateDigit, e => e.MapFrom(mfg => mfg.PlateDigit.ToString()))
                .ForMember(a => a.PlateTypeName, e => e.MapFrom(mfg => mfg.PlateType.Name))
                .ForMember(a => a.IssuanceType, e => e.MapFrom(mfg => mfg.IssuanceType.ToString()));


            CreateMap<VehiclePlate, VehiclePlateGetDto>()
                    .ForMember(a => a.PlateNo, e => e.MapFrom(mfg => mfg.PlateStock.PlateNo))
                    .ForMember(a => a.PlateType, e => e.MapFrom(mfg => mfg.PlateStock.PlateType.Name))
                    .ForMember(a => a.Region, e => e.MapFrom(mfg => mfg.PlateStock.Region.Name))
                    .ForMember(a => a.GivenZone, e => e.MapFrom(mfg => mfg.GivenZone.Name))
                    .ForMember(a => a.IssueReason, e => e.MapFrom(mfg => mfg.IssueReason.ToString()));

            CreateMap<FieldInspection, FieldInspectionGetDto>()
                      .ForMember(a => a.GivenZoneName, e => e.MapFrom(mfg => mfg.GivenZone.Name))

                      .ForMember(a => a.FrontPlateSize, e => e.MapFrom(mfg => mfg.FrontPlateSize.Name))
                      .ForMember(a => a.BackPlateSize, e => e.MapFrom(mfg => mfg.BackPlateSize.Name));

            CreateMap<TechnicalInspection, TechnicalInspectionGetDto>()

                    .ForMember(a => a.VehicleBodyTypeName, e => e.MapFrom(mfg => mfg.VehicleBodyType.Name))
                    .ForMember(a => a.ServiceType, e => e.MapFrom(mfg => mfg.ServiceType.Name))
                    .ForMember(a => a.LoadMeasurment, e => e.MapFrom(mfg => mfg.LoadMesurement.Name))
                    .ForMember(a => a.Color, e => e.MapFrom(mfg => mfg.Color.Name))
                    ;




            #endregion
        }
    }
}
