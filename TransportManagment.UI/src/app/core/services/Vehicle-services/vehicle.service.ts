import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import { ResponseMessage } from "src/app/model/ResponseMessage.Model";
import { environment } from "src/environments/environment";

import { TokenStorageService } from "../token-storage.service";
import { GetVehicleDetailRequestDto, VehicleData } from "src/app/model/vehicle";
import { IVehicleOwnerGetDto, VehicleOwnerPostDto } from "src/app/tms-pages/vehicle-management/action/vehicle-owners/IVehicleOwnersDto";
import { PaginatedResponse } from "src/app/model/common";
import { OwnerGetDto, OwnerPostDto } from "src/app/tms-pages/vehicle-management/action/owner/IownerDto";
import { IVehicleDocumentGetDto } from "src/app/tms-pages/vehicle-management/action/vehicle-documents/IVehicleDocuemntsDto";
@Injectable({ providedIn: "root" })

export class VehicleService {
  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`
  });

  addVehicleList(formData:VehicleData){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/VehicleList/Add`,
      formData,{headers:headers}
    );
  }
  getVehicleList(formData: GetVehicleDetailRequestDto) {
    var headers = this.headers
    return this.http.post<VehicleData>(
      `${this.baseUrl}/VehicleList/GetVehicleDetail`,
      formData,{headers:headers}
    ); 
  }

  //vehc doc

  addVehicleDoc(formData:FormData){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/VehicleList/AddVehicleDocument`,
      formData,{headers:headers}
    );
  }

  getVehicleDocuemnts(vehicleId : string) {
    var headers = this.headers
    return this.http.get<IVehicleDocumentGetDto[]>(
      `${this.baseUrl}/VehicleList/GetVehicleDocuments?vehicleId=${vehicleId}`,
      {headers:headers}
    ); 
  }

  


  //vech owners 

  getVehicleOwnerByVehicleId(vehicleId:string) {
    var headers = this.headers
    return this.http.get<IVehicleOwnerGetDto[]>(  `${this.baseUrl}/OwnerList/GetOwnerByVechicleId?vehicleId=${vehicleId}`,{headers:headers})
  }
  assignVehicleOwner(formData:VehicleOwnerPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/OwnerList/AssignOwner`,
      formData,{headers:headers}
    );
  }

  getAllOwner(pageNumber: number, pageSize: number, criteria: { columnName: string, filterValue: string }[]) {
    var headers = this.headers
    var params = new HttpParams().set('PageNumber', pageNumber.toString())
      .set('PageSize', pageSize.toString())
    criteria.forEach((c, index) => {
      params = params
        .set(`Criteria[${index}].ColumnName`, c.columnName)
        .set(`Criteria[${index}].FilterValue`, c.filterValue);
    });
    return this.http.get<PaginatedResponse<OwnerGetDto>>(`${this.baseUrl}/OwnerList/GetAllOwners`, { headers, params });
  }
  addOwner(formData:OwnerPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/OwnerList/AddOwner`,
      formData,{headers:headers}
    );
  }
}