import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { VehicleModelGetDto, VehicleModelPostDto } from 'src/app/model/vehicle-configuration/vehicle-model';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';

@Injectable({
  providedIn: 'root'
})
export class VehicleModelService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) { }

  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
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
}
