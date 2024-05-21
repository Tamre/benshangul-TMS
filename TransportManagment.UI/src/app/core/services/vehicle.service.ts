import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { User } from "src/app/store/Authentication/auth.models";
import { ResponseMessage } from "src/app/model/ResponseMessage.Model";
import { environment } from "src/environments/environment";

import { TokenStorageService } from "./token-storage.service";
import { Country } from "src/app/model/address/country";
import { Region } from "src/app/model/address/region";
import { Zone } from "src/app/model/address/zone";
import { Woreda } from "src/app/model/address/woreda";
import { GetVehicleDetailRequestDto, VehicleData } from "src/app/model/vehicle";
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

}