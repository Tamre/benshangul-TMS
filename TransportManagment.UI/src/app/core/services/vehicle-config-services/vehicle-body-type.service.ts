import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { VehicleBodyTypeGetDto, VehicleBodyTypePostDto } from 'src/app/model/vehicle-configuration/vehicle-body-type';

@Injectable({
  providedIn: 'root'
})
export class VehicleBodyTypeService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
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
}