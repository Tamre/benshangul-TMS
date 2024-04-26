import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { VehicleLookupGetDto, VehicleLookupPostDto } from 'src/app/model/vehicle-configuration/vehicle-lookup';

@Injectable({
  providedIn: 'root'
})
export class VehicleLookupService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getVehicleLookup(id: string) {
    var headers = this.headers
    return this.http.get<VehicleLookupGetDto[]>(`${this.baseUrl}/vech-config/VehicleLookups?LookUpTyoe=${id}`,{headers},);
  }
  updateVehicleLookup(formData:VehicleLookupPostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/AISORCStockType/Update`,
      formData,{headers:headers}
    );
  }
  addVehicleLookup(formData:VehicleLookupPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/AISORCStockType/Add`,
      formData,{headers:headers}
    );
  }
}
