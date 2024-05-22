import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { User } from "src/app/store/Authentication/auth.models";
import { ResponseMessage } from "src/app/model/ResponseMessage.Model";
import { environment } from "src/environments/environment";

import { IActionDropDownDto, ISettingDropDownsDto } from "src/app/model/common";
import { TokenStorageService } from "../token-storage.service";
import { IOwnerListDropdownDto, OwnerGroup } from "src/app/tms-pages/vehicle-management/action/vehicle-owners/IVehicleOwnersDto";
import { DepCostGetDto, DepCostPostDto } from "src/app/model/vehicle-configuration/dep-cost";

@Injectable({ providedIn: "root" })

export class VehicleDropdownService {
  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });

  getDocumentTypeDropdown() {
    var headers = this.headers
    return this.http.get<ISettingDropDownsDto[]>(
      `${this.baseUrl}/VehicleDropDown/GetDocumentTypeDropdown`,{headers:headers}
    ); 
  }

  getOwnerListDropdown(ownerGroup:OwnerGroup) {
    var headers = this.headers
    return this.http.get<IOwnerListDropdownDto[]>(
      `${this.baseUrl}/VehicleDropDown/GetOwnerListDropdown?ownerGroup=${ownerGroup}`,{headers:headers}
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