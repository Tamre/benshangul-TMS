import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { VehicleSettingGetDto, VehicleSettingPostDto } from 'src/app/model/vehicle-configuration/vehicle-setting';

@Injectable({
  providedIn: 'root'
})
export class VehicleSettingService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) { }

  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
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
}
