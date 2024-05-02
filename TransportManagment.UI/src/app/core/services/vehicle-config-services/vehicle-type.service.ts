import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenStorageService } from '../token-storage.service';
import { environment } from 'src/environments/environment';
import { VehicleTypeGetDto, VehicleTypePostDto } from 'src/app/model/vehicle-configuration/vehicle-type';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';

@Injectable({
  providedIn: 'root'
})
export class VehicleTypeService {
  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) { }

  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
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
}
