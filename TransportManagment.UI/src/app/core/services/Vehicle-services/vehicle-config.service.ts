import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { BanBodyGetDto, BanBodyPostDto } from 'src/app/model/vehicle-configuration/ban-body';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { DocTypeGetDto, DocTypePostDto } from 'src/app/model/vehicle-configuration/doc-type';
import { FactoryPointGetDto, FactoryPointPostDto, FactoryPointUpdateDto } from 'src/app/model/vehicle-configuration/factory-point';
import { InitialPriceGetDto, InitialPricePostDto } from 'src/app/model/vehicle-configuration/initial-price';
import { ManufactureYearGetDto, ManufactureYearPostDto } from 'src/app/model/vehicle-configuration/manufacture-year';
import { PlateTypeGetDto, PlateTypePostDto } from 'src/app/model/vehicle-configuration/plate-type';
import { SalvageValueGetDto, SalvageValuePostDto } from 'src/app/model/vehicle-configuration/salvage-value';
import { ServiceTypeGetDto, ServiceTypePostDto } from 'src/app/model/vehicle-configuration/service-type';
import { ServiceYearGetDto, ServiceYearPostDto } from 'src/app/model/vehicle-configuration/service-year';
import { StockTypeGetDto, StockTypePostDto } from 'src/app/model/vehicle-configuration/stock-type';
import { VehicleBodyTypeGetDto, VehicleBodyTypePostDto } from 'src/app/model/vehicle-configuration/vehicle-body-type';
import { VehicleLookupGetDto, VehicleLookupPostDto } from 'src/app/model/vehicle-configuration/vehicle-lookup';
import { VehicleModelGetDto, VehicleModelPostDto } from 'src/app/model/vehicle-configuration/vehicle-model';
import { VehicleSettingGetDto, VehicleSettingPostDto } from 'src/app/model/vehicle-configuration/vehicle-setting';
import { VehicleTypeGetDto, VehicleTypePostDto } from 'src/app/model/vehicle-configuration/vehicle-type';
import { DepCostGetDto, DepCostPostDto } from 'src/app/model/vehicle-configuration/dep-cost';
import { PaginatedResponse } from 'src/app/model/common';
import { PlateStockGetDto, PlateStockPostDto } from 'src/app/model/stock-management/plate-stock';

@Injectable({
  providedIn: 'root'
})
export class VehicleConfigService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllBanBody() {
    var headers = this.headers
    return this.http.get<BanBodyGetDto[]>(`${this.baseUrl}/vech-config/BanBody/GetAll`,{headers});
  }
  updateBanBody(formData:BanBodyPostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/BanBody/Update`,
      formData,{headers:headers}
    );
  }
  addBanBody(formData:BanBodyPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/BanBody/Add`,
      formData,{headers:headers}
    );
  }

  getAllDocType() {
    var headers = this.headers
    return this.http.get<DocTypeGetDto[]>(`${this.baseUrl}/vech-config/DocumentType/GetAll`,{headers});
  }
  updateDocType(formData:DocTypePostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/DocumentType/Update`,
      formData,{headers:headers}
    );
  }
  addDocType(formData:DocTypePostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/DocumentType/Add`,
      formData,{headers:headers}
    );
  }

  getAllFactoryPoint() {
    var headers = this.headers
    return this.http.get<FactoryPointGetDto[]>(`${this.baseUrl}/vech-config/FactoryPoint/GetAll`,{headers});
  }
  updateFactoryPoint(formData:FactoryPointUpdateDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/FactoryPoint/Update`,
      formData,{headers:headers}
    );
  }
  addFactoryPoint(formData:FactoryPointPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/FactoryPoint/Add`,
      formData,{headers:headers}
    );
  }

  getAllInitialPrice() {
    var headers = this.headers
    return this.http.get<InitialPriceGetDto[]>(`${this.baseUrl}/vech-config/InitialPrice/GetAll`,{headers});
  }
  updateInitialPrice(formData:InitialPricePostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/InitialPrice/Update`,
      formData,{headers:headers}
    );
  }
  addInitialPrice(formData:InitialPricePostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/InitialPrice/Add`,
      formData,{headers:headers}
    );
  }
  
  getAllManufactureYear() {
    var headers = this.headers
    return this.http.get<ManufactureYearGetDto[]>(`${this.baseUrl}/vech-config/ManufacturingCountry`,{headers});
  }
  updateManufactureYear(formData:ManufactureYearPostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/ManufacturingCountry`,
      formData,{headers:headers}
    );
  }
  addManufactureYear(formData:ManufactureYearPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/ManufacturingCountry`,
      formData,{headers:headers}
    );
  }
  getAllPlateType() {
    var headers = this.headers
    return this.http.get<PlateTypeGetDto[]>(`${this.baseUrl}/vech-config/PlateType/GetAll`,{headers});
  }
  updatePlateType(formData:PlateTypePostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/PlateType/Update`,
      formData,{headers:headers}
    );
  }
  addPlateType(formData:PlateTypePostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/PlateType/Add`,
      formData,{headers:headers}
    );
  }

  getAllSalvageValue() {
    var headers = this.headers
    return this.http.get<SalvageValueGetDto[]>(`${this.baseUrl}/vech-config/SalvageValue/GetAll`,{headers});
  }
  updateSalvageValue(formData:SalvageValuePostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/SalvageValue/Update`,
      formData,{headers:headers}
    );
  }
  addSalvageValue(formData:SalvageValuePostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/SalvageValue/Add`,
      formData,{headers:headers}
    );
  }

  getAllServiceType() {
    var headers = this.headers
    return this.http.get<ServiceTypeGetDto[]>(`${this.baseUrl}/vech-config/ServiceType/GetAll`,{headers});
  }
  updateServiceType(formData:ServiceTypePostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/ServiceType/Update`,
      formData,{headers:headers}
    );
  }
  addServiceType(formData:ServiceTypePostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/ServiceType/Add`,
      formData,{headers:headers}
    );
  }

  getAllServiceYear() {
    var headers = this.headers
    return this.http.get<ServiceYearGetDto[]>(`${this.baseUrl}/vech-config/ServiceType/GetAll`,{headers});
  }
  updateServiceYear(formData:ServiceYearPostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/ServiceType/Update`,
      formData,{headers:headers}
    );
  }
  addServiceYear(formData:ServiceYearPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/ServiceType/Add`,
      formData,{headers:headers}
    );
  }

  getAllStockType() {
    var headers = this.headers
    return this.http.get<StockTypeGetDto[]>(`${this.baseUrl}/vech-config/AISORCStockType/GetAll`,{headers});
  }
  updateStockType(formData:StockTypePostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/AISORCStockType/Update`,
      formData,{headers:headers}
    );
  }
  addStockType(formData:StockTypePostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/AISORCStockType/Add`,
      formData,{headers:headers}
    );
  }

  getAllVehicleBodyType() {
    var headers = this.headers
    return this.http.get<VehicleBodyTypeGetDto[]>(`${this.baseUrl}/vech-config/VehicleBodyType/GetAll`,{headers});
  }
  updateVehicleBodyType(formData:VehicleBodyTypePostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/VehicleBodyType/Update`,
      formData,{headers:headers}
    );
  }
  addVehicleBodyType(formData:VehicleBodyTypePostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/VehicleBodyType/Add`,
      formData,{headers:headers}
    );
  }
  getVehicleLookup(id: number) {
    var headers = this.headers
    return this.http.get<VehicleLookupGetDto[]>(`${this.baseUrl}/vech-config/VehicleLookups/GetAllByLookUpType?LookUpTyoe=${id}`,{headers},);
  }
  getAllVehicleLookup() {
    var headers = this.headers
    return this.http.get<VehicleLookupGetDto[]>(`${this.baseUrl}/vech-config/VehicleLookups/GetAll`,{headers});
  }
  updateVehicleLookup(formData:VehicleLookupPostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/VehicleLookups/Update`,
      formData,{headers:headers}
    );
  }
  addVehicleLookup(formData:VehicleLookupPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/VehicleLookups/Add`,
      formData,{headers:headers}
    );
  }
  getAllVehicleModel() {
    var headers = this.headers
    return this.http.get<VehicleModelGetDto[]>(`${this.baseUrl}/vech-config/VehicleModel/GetAll`,{headers});
  }
  updateVehicleModel(formData:VehicleModelPostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/VehicleModel/Update`,
      formData,{headers:headers}
    );
  }
  addVehicleModel(formData:VehicleModelPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/VehicleModel/Add`,
      formData,{headers:headers}
    );
  }
  getAllVehicleSetting() {
    var headers = this.headers
    return this.http.get<VehicleSettingGetDto[]>(`${this.baseUrl}/vech-config/VehicleSettings`,{headers});
  }
  updateVehicleSetting(formData:VehicleSettingPostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/VehicleSettings`,
      formData,{headers:headers}
    );
  }
  addVehicleSetting(formData:VehicleSettingPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/VehicleSettings`,
      formData,{headers:headers}
    );
  }
  getAllVehicleType() {
    var headers = this.headers
    return this.http.get<VehicleTypeGetDto[]>(`${this.baseUrl}/vech-config/VehicleType/GetAll`,{headers});
  }
  updateVehicleType(formData:VehicleTypePostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/VehicleType/Update`,
      formData,{headers:headers}
    );
  }
  addVehicleType(formData:VehicleTypePostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/VehicleType/Add`,
      formData,{headers:headers}
    );
  }

  getAllDepCost() {
    var headers = this.headers
    return this.http.get<DepCostGetDto[]>(`${this.baseUrl}/vech-config/DepreciationCost/GetAll`,{headers});
  }
  updateDepCost(formData:DepCostPostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/DepreciationCost/Update`,
      formData,{headers:headers}
    );
  }
  addDepCost(formData:DepCostPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/DepreciationCost/Add`,
      formData,{headers:headers}
    );
  }


}
